using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Core.Repositories
{
    public interface IRestaurantRepository
    {
        Task AddAsync(Restaurant restaurant);

        Task UpdateAsync(Restaurant restaurant);

        Task DelAsync(Restaurant restaurant);

        Task<Manager> GetAsync(int id);

        Task<IEnumerable<Restaurant>> BrowseAllAsync();
    }
}
