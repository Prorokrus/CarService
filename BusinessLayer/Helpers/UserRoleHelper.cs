using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace BusinessLayer.Helpers
{
    public class UserRoleHelper
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleHelper(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserRole> GetUserRole(User user)
        {
            return await _userRoleRepository.GetUserRole(user);
        }
    }
}
