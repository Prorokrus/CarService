namespace DataLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
        public User User { get; set; }
        public ServiceType ServiceType { get; set; }
        public Detail Detail { get; set; }
    }
}
