using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.ViewModels;
using DataLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IVehicleService
    {
        Task<List<VehicleViewModel>> GetAllVehicles();
        Task<List<Vehicle>> GetAllVehicles(User user);
        Task<List<VehicleViewModel>> GetAllVehicles(int userId);
        Task AddVehicle(VehicleViewModel model, int userId);
        Task<VehicleViewModel> GetVehicle(int vehicleId);
        Task EditVehicle(VehicleViewModel model);
        Task DeleteVehicle(int vehicleId);
    }
}