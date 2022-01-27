using System;
using System.Collections.Generic;

namespace RestaurantManager.Core.Domains
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfEmployees { get; set; }

        public DateTime DateOfOpening { get; set; }

        public double MonthlyRevenue { get; set; }

        public string Country { get; set; }

        public Manager Manager { get; set; }

        public City City { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }
    }
}
