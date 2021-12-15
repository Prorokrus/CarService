using DataLayer.Entities;

namespace CommonLayer.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
        public User User { get; set; }
        public ServiceType ServiceType { get; set; }
        public Detail Detail { get; set; }
    }
}
