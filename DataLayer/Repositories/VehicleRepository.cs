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

        public async Task<List<Vehicle>> GetAll()
        {
            return await _appDbContext.Set<Vehicle>().Include(x => x.User).ToListAsync();
        }
    }
}