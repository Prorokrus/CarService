using DataLayer.Entities;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IUserRoleService
    {
        Task<UserRole> GetUserRole(User user);
    }
}