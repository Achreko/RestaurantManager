using RestaurantManager.Core.Domains;
using RestaurantManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        public Task AddAsync(City city)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<City>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(City city)
        {
            throw new NotImplementedException();
        }

        public Task<City> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(City city)
        {
            throw new NotImplementedException();
        }
    }
}
