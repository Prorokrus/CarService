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

        public async Task<List<VehicleViewModel>> GetAll(int userId)
        {
            var vehicles = await _vehicleRepository.GetAllUserVehicles(userId);
            return vehicles.ToViewModel();
        }

        public async Task<VehicleViewModel> Create(VehicleViewModel model, int userId)
        {
            var vehicle = await _vehicleRepository.Add(model.ToEntity(), userId);
            return vehicle.ToViewModel();
        }

        public async Task<VehicleViewModel> Get(int vehicleId)
        {
            var vehicle = await _vehicleRepository.Get(vehicleId);
            return vehicle.ToViewModel();
        }

        public async Task<VehicleViewModel> Update(VehicleViewModel model)
        {
            var vehicle = await _vehicleRepository.Update(model.ToEntity());
            return vehicle.ToViewModel();
        }

        public async Task Delete(int vehicleId)
        {
            var vehicle = await _vehicleRepository.Get(vehicleId);

            if (vehicle != null)
            {
                await _vehicleRepository.Delete(vehicle);
            }
        }
    }
}
