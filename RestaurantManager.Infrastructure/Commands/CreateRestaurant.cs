using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManager.Infrastructure.Commands
{
   public class CreateRestaurant
    {
        public string Name { get; set; }

        public int NumberOfEmployees { get; set; }

        public DateTime DateOfOpening { get; set; }
        
        public string Country { get; set; }
    }
}
