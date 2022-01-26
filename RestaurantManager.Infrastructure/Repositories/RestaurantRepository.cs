using RestaurantManager.Core.Domains;
using RestaurantManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext appDbContext;
        public Task AddAsync(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public Task<Manager> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
