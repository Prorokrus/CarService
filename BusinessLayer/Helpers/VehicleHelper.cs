using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using CommonLayer.ViewModels;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace BusinessLayer.Helpers
{
    public class VehicleHelper
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleHelper(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<VehicleViewModel>> GetAll()
        {
            var vehicles = await _vehicleRepository.GetAll();
            return vehicles.ToViewModel();
        }

        public async Task<List<Vehicle>> GetAll(User user)
        {
            var vehicles = await _vehicleRepository.GetAllUserVehicles(user);
            return vehicles;
        }
    }
}
