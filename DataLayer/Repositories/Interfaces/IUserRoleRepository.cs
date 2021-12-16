using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<UserRole> GetUserRole(User user);
    }
}