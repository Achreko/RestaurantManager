using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManager.Infrastructure.Commands
{
    public class CreateManager
    {
        public int Name { get; set; }

        public string ForeName { get; set; }

        public double Salary { get; set; }
    }
}
