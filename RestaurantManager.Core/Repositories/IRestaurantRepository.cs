using RestaurantManager.Core.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManager.Core.Repositories
{
    public interface IRestaurantRepository
    {
        Task AddAsync(Restaurant restaurant);

        Task UpdateAsync(Restaurant restaurant);

        Task DelAsync(Restaurant restaurant);

        Task<Restaurant> GetAsync(int id);

        Task<IEnumerable<Restaurant>> BrowseAllAsync();

        Task<IEnumerable<Restaurant>> BrowseAllFilter(string country);
    }
}
