using RestaurantManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Infrastructure.Services
{
    public interface IManagerService
    {
        public Task<IEnumerable<ManagerDTO>> BrowseAll();
        public Task<RestaurantDTO> GetRestaurant(int id);
        public Task DeleteRestaurant(ManagerDTO manager);
        public Task AddRestaurant(ManagerDTO manager);
        public Task UpdateRestaurant(ManagerDTO manager);
    }
}
