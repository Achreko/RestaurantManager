using RestaurantManager.Core.Domains;
using RestaurantManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext appDbContext;

        public RestaurantRepository(AppDbContext dbContext)
        {
            appDbContext = dbContext;
        }

        public async Task AddAsync(Restaurant restaurant)
        {
            try
            {
                appDbContext.Restaurants.Add(restaurant);
                appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Restaurant>> BrowseAllAsync()
        {
            return await Task.FromResult(appDbContext.Restaurants);
        }

        public async Task DelAsync(Restaurant restaurant)
        {
            try
            {
                appDbContext.Restaurants.Remove(appDbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id));
                appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Restaurant> GetAsync(int id)
        {
            Restaurant r = appDbContext.Restaurants.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(r);
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            try
            {
                var targetRestaurant = appDbContext.Restaurants.FirstOrDefault(x => x.Id == restaurant.Id);
                if (restaurant.Name != null)
                {
                    targetRestaurant.Name = restaurant.Name;
                }
                if (restaurant.MonthlyRevenue != targetRestaurant.MonthlyRevenue)
                {
                    targetRestaurant.MonthlyRevenue = restaurant.MonthlyRevenue;
                }
                if (restaurant.NumberOfEmployees != targetRestaurant.NumberOfEmployees)
                {
                    targetRestaurant.NumberOfEmployees = restaurant.NumberOfEmployees;
                }
                appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
