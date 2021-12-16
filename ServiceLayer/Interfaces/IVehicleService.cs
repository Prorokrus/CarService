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
    }
}