using RestaurantManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Infrastructure.Services
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<RestaurantDTO>> BrowseAll();
        public Task<IEnumerable<RestaurantDTO>> BrowseAllFilter(string country);
        public Task<RestaurantDTO> GetRestaurant(int id);
        public Task DeleteRestaurant(RestaurantDTO restaurant);
        public Task AddRestaurant(RestaurantDTO restaurant);
        public Task UpdateRestaurant(RestaurantDTO restaurant);
    }
}
