using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestaurantManager.Core.Domains;
using RestaurantManager.Core.Repositories;
using RestaurantManager.Infrastructure.DTO;
using RestaurantManager.Infrastructure.Repositories;
using RestaurantManager.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManager.Test
{
    [TestClass]
    public class ServiceTesting
    {
        public IEnumerable<Restaurant> repoList = new List<Restaurant>();
        public IRestaurantRepository repoMock;

        public IRestaurantService service;

        public TestContext TestContext { get; set; }

        public void PrepList()
        {
            ((List<Restaurant>)repoList).Add(new Restaurant()
            {
                Id = 1,
                Name = "K",
                NumberOfEmployees = 2115,
                Country = "pol"
            });
            ((List<Restaurant>)repoList).Add(new Restaurant()
            {
                Id = 2,
                Name = "R",
                NumberOfEmployees = 420,
                Country = "gr"
            });
            ((List<Restaurant>)repoList).Add(new Restaurant()
            {
                Id = 3,
                Name = "Z",
                NumberOfEmployees= 69,
                Country = "EZZZZ"
            });
        }
        [TestInitialize]
        public void Init()
        {
            var mock = new Mock<IRestaurantRepository>();
            PrepList();

            mock.Setup(m => m.BrowseAllAsync()).Returns(Task.FromResult(repoList));
            mock.Setup(m => m.BrowseAllFilter("EZZZZ")).Returns(Task.FromResult(((IEnumerable<Restaurant>)repoList.Where(x => x.Country == "EZZZZ"))));

            mock.Setup(m => m.GetAsync(It.IsAny<int>())).Returns(Task.FromResult((Restaurant)null));
            mock.Setup(m => m.GetAsync(1)).Returns(Task.FromResult(((List<Restaurant>)repoList)[0]));
            mock.Setup(m => m.GetAsync(2)).Returns(Task.FromResult(((List<Restaurant >)repoList)[1]));
            mock.Setup(m => m.GetAsync(3)).Returns(Task.FromResult(((List<Restaurant>)repoList)[2]));

            mock.Setup(m => m.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant r) => {
                    if (r.Id == 0)
                    {
                        r.Id = repoList.Count() + 1;
                    }
                    repoList = repoList.Concat(new[] { r });
                })
                .Returns(Task.CompletedTask);

            mock.Setup(m => m.UpdateAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant r) =>
                {
                    try
                    {
                        var x = repoList.First(x => x.Id == r.Id);
                        x.Name = r.Name;
                        x.NumberOfEmployees = r.NumberOfEmployees;
                        x.Country = r.Country;
                    }
                    catch (InvalidOperationException)
                    {
                        throw new ArgumentException("Passed restaurant is invalid.");
                    }
                })
                .Returns(Task.CompletedTask);

            mock.Setup(m => m.DelAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant r) =>
                {
                    repoList = repoList.Where(x => x.Id != r.Id);
                })
                .Returns(Task.CompletedTask);

            repoMock = mock.Object;
            service = new RestaurantService(repoMock);
        }

        [Owner("Kacper Achramowicz")]
        [Description("Should show all existing Restaurants.")]
        [Priority(0)]
        [TestMethod]
        public async Task BrowseAllTest()
        {
            var z = (await service.BrowseAll()).ToList();

            Assert.AreEqual(3, z.Count);

            Assert.AreEqual(1, z[0].Id);
            Assert.AreEqual("K", z[0].Name);

            Assert.AreEqual(2, z[1].Id);
            Assert.AreEqual("R", z[1].Name);

            Assert.AreEqual(3, z[2].Id);
            Assert.AreEqual("Z", z[2].Name);
        }

        [Owner("Kacper Achramowicz")]
        [Description("Should show all proper Restaurants when passed proper filter.")]
        [Priority(1)]
        [TestMethod]
        public async Task BrowseAllFilterTest()
        {
            var z = (await service.BrowseAllFilter("EZZZZ")).ToList();

            Assert.AreEqual(1, z.Count);

            Assert.AreEqual(3, z[0].Id);
            Assert.AreEqual("Z", z[0].Name);
        }

        [Owner("Kacper Achramowicz")]
        [Description("Should properly get existing Restaurant.")]
        [Priority(0)]
        [TestMethod]
        public async Task GetRestaurantTest()
        {

            var z1 = await service.GetRestaurant(1);
            var z2 = await service.GetRestaurant(2);

            Assert.AreEqual(1, z1.Id);
            Assert.AreEqual("K", z1.Name);

            Assert.AreEqual(2, z2.Id);
            Assert.AreEqual("R", z2.Name);
        }

        [Owner("Kacper Achramowicz")]
        [Description("Should throw ArgumentException when getting non existent Restaurant")]
        [Priority(1)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetNonExistentRestaurantTest()
        {
            await service.GetRestaurant(0);
        }

        [Owner("Kacper Achramowicz")]
        [Description("Should properly add new Restaurant to db.")]
        [Priority(0)]
        [TestMethod]
        public async Task AddRestaurantTest()
        {
            Assert.AreEqual(3, repoList.Count());

            await service.AddRestaurant(new RestaurantDTO()
            {
                Name = "XDDDD"
            });

            Assert.AreEqual(4, repoList.Count());

            Assert.AreEqual(4, repoList.ToList()[3].Id);
            Assert.AreEqual("XDDDD", repoList.ToList()[3].Name);
        }

        [Owner("Kacper Achramowicz")]
        [Description("Should throw ArgumentException when trying to add existing Restaurant.")]
        [Priority(0)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task AddExistingRestaurantTest()
        {
            Assert.AreEqual(3, repoList.Count());

            await service.AddRestaurant(new RestaurantDTO()
            {
                Id = 3
            });

            Assert.AreEqual(3, repoList.Count());
        }

        [Owner("Kacper Achramowicz")]
        [Description("Should update Restaurant when it is existing.")]
        [Priority(1)]
        [TestMethod]
        public async Task UpdateRestaurantTest()
        {
            Assert.AreEqual("K", repoList.ToList()[0].Name);

            await service.UpdateRestaurant(new RestaurantDTO()
            {
                Id = 1,
                Name = "EMOTIONS"
            });

            Assert.AreEqual("EMOTIONS", repoList.ToList()[0].Name);
        }

        [Owner("Kacper Achramowicz")]
        [Description("Should throw ArgumentException when trying to update non existent Restaurant.")]
        [Priority(1)]
        [TestMethod]
        public async Task UpdateNonExistentRestaurantTest()
        {
            await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
            {
                await service.UpdateRestaurant(new RestaurantDTO()
                {
                    Id = 2115,
                    Name = "EMOTIONS"
                });
            });
        }

        [Owner("Kacper Achramowicz")]
        [Description("Should delete existing restaurant")]
        [Priority(0)]
        [TestMethod]
        public async Task DeleteRestaurantTest()
        {
            Assert.AreEqual(3, repoList.Count());

            await service.DeleteRestaurant(new RestaurantDTO()
            {
                Id = 1
            });

            Assert.AreEqual(2, repoList.Count());
        }

        [Owner("Kacper Achramowicz")]
        [Description("Should throw ArgumentException when getting non existent Restaurant")]
        [Priority(0)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task DeleteNonExistentRestaurantTest()
        {
            Assert.AreEqual(3, repoList.Count());

            await service.DeleteRestaurant(new RestaurantDTO()
            {
                Id = 2115
            });

            Assert.AreEqual(3, repoList.Count());
        }
    }
}
