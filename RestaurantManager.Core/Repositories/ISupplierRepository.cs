using RestaurantManager.Core.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManager.Core.Repositories
{
    public interface ISupplierRepository
    {
        Task AddAsync(Supplier supplier);

        Task UpdateAsync(Supplier supplier);

        Task DelAsync(Supplier supplier);

        Task<Manager> GetAsync(int id);

        Task<IEnumerable<Supplier>> BrowseAllAsync();
    }
}
