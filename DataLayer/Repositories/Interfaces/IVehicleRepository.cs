using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetAllUserVehicles(User user);
        Task<List<Vehicle>> GetAllUserVehicles(int userId);
        Task<List<Vehicle>> GetAll();
        Task<Vehicle> Add(Vehicle vehicle, int userId);
        Task<Vehicle> Get(int vehicleId);
        Task<Vehicle> Update(Vehicle vehicle);
        Task Delete(Vehicle vehicle);
    }
}