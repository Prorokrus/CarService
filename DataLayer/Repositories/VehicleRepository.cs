using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _appDbContext;

        public VehicleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Vehicle>> GetAllUserVehicles(User user)
        {
            return await _appDbContext.Set<Vehicle>().Include(v => v.User)
                .Where(x => x.User == user)
                .ToListAsync();
        }

        public async Task<List<Vehicle>> GetAllUserVehicles(int userId)
        {
            return await _appDbContext.Set<Vehicle>().Include(x => x.User)
                .Where(x => x.User.Id == userId)
                .ToListAsync();
        }

        public async Task<List<Vehicle>> GetAll()
        {
            return await _appDbContext.Set<Vehicle>().Include(x => x.User).ToListAsync();
        }

        public async Task<Vehicle> Add(Vehicle vehicle, int userId)
        {
            var user = await _appDbContext.Set<User>().Where(x => x.Id == userId).FirstOrDefaultAsync();

            if (user == null)
                throw new ArgumentNullException($"User with Id: {userId} doesn't exist");

            vehicle.User = user;
            await _appDbContext.Set<Vehicle>().AddAsync(vehicle);
            await _appDbContext.SaveChangesAsync();

            return vehicle;
        }

        public async Task<Vehicle> Get(int vehicleId)
        {
            return await _appDbContext.Set<Vehicle>().Include(x => x.User)
                .Where(x => x.Id == vehicleId)
                .FirstOrDefaultAsync();
        }

        public async Task<Vehicle> Update(Vehicle vehicle)
        {
            var vehicleOld = await _appDbContext.Set<Vehicle>().Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == vehicle.Id);

            if (vehicleOld == null)
                return null;

            vehicleOld.Brand = vehicle.Brand;
            vehicleOld.Color = vehicle.Color;
            vehicleOld.Motor = vehicle.Motor;
            vehicleOld.Fuel = vehicle.Fuel;
            vehicleOld.VinCode = vehicle.VinCode;

            _appDbContext.Attach(vehicleOld);
            _appDbContext.Entry(vehicleOld).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

            return vehicle;
        }

        public async Task Delete(Vehicle vehicle)
        {
            _appDbContext.Set<Vehicle>().Remove(vehicle);
            await _appDbContext.SaveChangesAsync();
        }
    }
}