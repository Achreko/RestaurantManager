using System;

namespace RestaurantManager.Infrastructure.Commands
{
    public class CreateRestaurant
    {
        public string Name { get; set; }

        public int NumberOfEmployees { get; set; }
        
        public string Country { get; set; }
    }
}
