namespace DataLayer.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Motor { get; set; }
        public string Fuel { get; set; }
        public string VinCode { get; set; }
        public User User { get; set; }
    }
}
