using RestaurantManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Infrastructure.Services
{
    public class ManagerService : IManagerService
    {
        public Task AddRestaurant(ManagerDTO manager)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ManagerDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task DeleteRestaurant(ManagerDTO manager)
        {
            throw new NotImplementedException();
        }

        public Task<RestaurantDTO> GetRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRestaurant(ManagerDTO manager)
        {
            throw new NotImplementedException();
        }
    }
}
