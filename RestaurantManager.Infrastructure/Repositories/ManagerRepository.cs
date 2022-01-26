using RestaurantManager.Core.Domains;
using RestaurantManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Infrastructure.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        public Task AddAsync(Manager manager)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Manager>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Manager manager)
        {
            throw new NotImplementedException();
        }

        public Task<Manager> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Manager manager)
        {
            throw new NotImplementedException();
        }
    }
}
