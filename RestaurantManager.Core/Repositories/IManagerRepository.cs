﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Core.Repositories
{
    public interface IManagerRepository
    {
        Task AddAsync(Manager manager);

        Task UpdateAsync(Manager manager);

        Task DelAsync(Manager manager);

        Task<Manager> GetAsync(int id);

        Task<IEnumerable<Manager>> BrowseAllAsync();
    }
}
