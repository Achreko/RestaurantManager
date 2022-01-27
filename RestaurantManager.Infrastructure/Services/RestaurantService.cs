using RestaurantManager.Core.Domains;
using RestaurantManager.Core.Repositories;
using RestaurantManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Infrastructure.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task AddRestaurant(RestaurantDTO restaurant)
        {
            var ezz = await _restaurantRepository.GetAsync(restaurant.Id);
            if (ezz == null)
            {
                await _restaurantRepository.AddAsync(new Restaurant()
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    NumberOfEmployees = restaurant.NumberOfEmployees,
                    DateOfOpening = restaurant.DateOfOpening,
                    Country = restaurant.Country
                });
            }
            else
            {
                throw new ArgumentException("There already is restaurant with id = " + restaurant.Id);
            }
        }

        public async Task<IEnumerable<RestaurantDTO>> BrowseAll()
        {
            var ezz = await _restaurantRepository.BrowseAllAsync();

            return ezz.Select(x => new RestaurantDTO()
            {
                Id = x.Id,
                Name = x.Name,
                NumberOfEmployees = x.NumberOfEmployees,
                DateOfOpening = x.DateOfOpening,
                MonthlyRevenue = x.MonthlyRevenue,
                Country = x.Country
            });
            
        }

        public async Task<IEnumerable<RestaurantDTO>> BrowseAllFilter(string country)
        {
            var ezz = await _restaurantRepository.BrowseAllFilter(country);

            return ezz.Select(x => new RestaurantDTO()
            {
                Id = x.Id,
                Name = x.Name,
                NumberOfEmployees = x.NumberOfEmployees,
                DateOfOpening = x.DateOfOpening,
                MonthlyRevenue = x.MonthlyRevenue,
                Country = x.Country
            });
        }

        public async Task DeleteRestaurant(RestaurantDTO restaurant)
        {
            var z = await _restaurantRepository.GetAsync(restaurant.Id);
            if (z != null)
            {
                await _restaurantRepository.DelAsync(z);
            }
            else
            {
                throw new ArgumentException("No restaurant with id= " + restaurant.Id);
            }
        }

        public async Task<RestaurantDTO> GetRestaurant(int id)
        {
            var ezz = await _restaurantRepository.GetAsync(id);

            if (ezz != null)
            {
                return new RestaurantDTO()
                {
                    Id = ezz.Id,
                    Name = ezz.Name,
                    Country = ezz.Country,
                    MonthlyRevenue = ezz.MonthlyRevenue,
                    NumberOfEmployees = ezz.NumberOfEmployees,
                    DateOfOpening = ezz.DateOfOpening
                };
            }
            else
            {
                throw new ArgumentException("No restaurant with id= " + id);
            }
        }

        public async Task UpdateRestaurant(RestaurantDTO restaurant)
        {
            var ezz = await _restaurantRepository.GetAsync(restaurant.Id);
            if (ezz == null)
            {
                throw new ArgumentException("No restaurant with id = " + restaurant.Id);
            }
            else
            {
                await _restaurantRepository.UpdateAsync(new Restaurant()
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    MonthlyRevenue = restaurant.MonthlyRevenue,
                    NumberOfEmployees = restaurant.NumberOfEmployees
                });
            }
        }
    }
}
