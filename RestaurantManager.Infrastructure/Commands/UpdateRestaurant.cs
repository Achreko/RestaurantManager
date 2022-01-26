using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManager.Infrastructure.Commands
{
    public class UpdateRestaurant
    {
        public string Name { get; set; }

        public int NumberOfEmployees { get; set; }

        public double MonthlyRevenue { get; set; }
    }
}
