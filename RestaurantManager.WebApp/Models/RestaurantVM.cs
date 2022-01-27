using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManager.WebApp.Models
{
    public class RestaurantVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfEmployees { get; set; }

        public DateTime DateOfOpening { get; set; }

        public double MonthlyRevenue { get; set; }

        public string Country { get; set; }
    }
}
