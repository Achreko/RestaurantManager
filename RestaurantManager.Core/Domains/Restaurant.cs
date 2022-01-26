using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManager.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfEmployees { get; set; }

        public DateTime DateOfOpening { get; set; }

        public double MonthlyRevenue { get; set; }

        public Manager Managers { get; set; }

        public List<Supplier> Suppliers { get; set; }

        public MainChef MainChef { get; set; }
    }
}
