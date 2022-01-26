using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManager.Infrastructure.DTO
{
    public class RestaurantDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfEmployees { get; set; }

        public DateTime DateOfOpening { get; set; }

        public double MonthlyRevenue { get; set; }
    }
}
