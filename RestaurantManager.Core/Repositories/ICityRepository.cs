using RestaurantManager.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantManager.Core.Repositories
{
    public interface ICityRepository
    {
        Task AddAsync(City city);

        Task UpdateAsync(City city);

        Task DelAsync(City city);

        Task<City> GetAsync(int id);

        Task<IEnumerable<City>> BrowseAllAsync();
    }
}
