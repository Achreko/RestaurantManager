using System.Collections.Generic;

namespace RestaurantManager.Core.Domains
{
    public class Supplier
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public string Product { get; set; }

        public int Supply { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
