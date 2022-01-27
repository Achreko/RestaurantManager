using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantManager.Core.Domains;

namespace RestaurantManager.Infrastructure.Repositories
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<MainChef> MainChefs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
