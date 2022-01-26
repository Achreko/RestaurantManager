using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Core.Repositories
{
    public interface IMainChefRepository
    {
        Task AddAsync(MainChef mainChef);

        Task UpdateAsync(MainChef mainChef);

        Task DelAsync(MainChef mainChef);

        Task<MainChef> GetAsync(int id);

        Task<IEnumerable<MainChef>> BrowseAllAsync();
    }
}
