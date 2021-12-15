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
        private readonly IGenericRepository<Vehicle> _vehicleRepository;

        public VehicleHelper(IGenericRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<VehicleViewModel>> GetAll()
        {
            var vehicles = await _vehicleRepository.GetAll(x => true);
            return vehicles.ToViewModel();
        }
    }
}
