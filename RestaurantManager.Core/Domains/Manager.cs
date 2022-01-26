namespace RestaurantManager.Core.Domains
{
    public class Manager
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public string ForeName { get; set; }

        public double Salary { get; set; }

        public Restaurant Restaurant { get; set; }

    }
}
