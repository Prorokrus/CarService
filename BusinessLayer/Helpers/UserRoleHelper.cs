using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace BusinessLayer.Helpers
{
    public class UserRoleHelper
    {
        private readonly IGenericRepository<UserRole> _userRoleRepository;

        public UserRoleHelper(IGenericRepository<UserRole> userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserRole> GetUserRole(User user)
        {
            var userRole = await _userRoleRepository.Get(x => x.User == user);
            return userRole;
        }
    }
}
