using RestaurantManager.Core.Domains;
using RestaurantManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public Task AddAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Supplier>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Task<Manager> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
