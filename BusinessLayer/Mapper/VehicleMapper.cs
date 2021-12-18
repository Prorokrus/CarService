using CommonLayer.ViewModels;
using DataLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BusinessLayer.Mapper
{
    public static class VehicleMapper
    {
        public static List<VehicleViewModel> ToViewModel(this IList<Vehicle> vehicles)
        {
            return vehicles.Select(x => new VehicleViewModel
            {
                Id = x.Id,
                Brand = x.Brand,
                Color = x.Color,
                Fuel = x.Fuel,
                Motor = x.Motor,
                User = x.User,
                VinCode = x.VinCode
            }).ToList();
        }

        public static Vehicle ToEntity(this VehicleViewModel vehicleModel)
        {
            return new Vehicle
            {
                Id = vehicleModel.Id,
                Brand = vehicleModel.Brand,
                Color = vehicleModel.Color,
                Fuel = vehicleModel.Fuel,
                Motor = vehicleModel.Motor,
                VinCode = vehicleModel.VinCode
            };
        }

        public static VehicleViewModel ToViewModel(this Vehicle vehicle)
        {
            return new VehicleViewModel
            {
                Id = vehicle.Id,
                Brand = vehicle.Brand,
                Color = vehicle.Color,
                Fuel = vehicle.Fuel,
                Motor = vehicle.Motor,
                VinCode = vehicle.VinCode,
                User = vehicle.User
            };
        }
    }
}
