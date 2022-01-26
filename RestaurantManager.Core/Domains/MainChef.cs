namespace RestaurantManager.Core.Domains
{
    public class MainChef
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public string Specialty { get; set; }

        public double Salary { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
