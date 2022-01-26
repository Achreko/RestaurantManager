using RestaurantManager.Core.Domains;
using RestaurantManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Infrastructure.Repositories
{
    public class MainChefRepository : IMainChefRepository
    {
        public Task AddAsync(MainChef mainChef)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MainChef>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(MainChef mainChef)
        {
            throw new NotImplementedException();
        }

        public Task<MainChef> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MainChef mainChef)
        {
            throw new NotImplementedException();
        }
    }
}
