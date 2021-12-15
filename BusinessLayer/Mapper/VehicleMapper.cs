using CommonLayer.ViewModels;
using DataLayer.Entities;
using System.Collections.Generic;
using System.Linq;

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
    }
}
