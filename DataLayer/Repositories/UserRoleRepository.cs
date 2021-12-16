using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRoleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UserRole> GetUserRole(User user)
        {
            return await _appDbContext.Set<UserRole>().Include(x => x.Role)
                .Include(x => x.User)
                .Where(x => x.User == user)
                .FirstOrDefaultAsync();
        }
    }
}