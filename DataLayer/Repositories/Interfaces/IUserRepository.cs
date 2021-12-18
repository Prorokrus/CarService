using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetByUserName(string username);
        Task<int> GetUserIdByUserName(string username);
        Task<User> Update(User user);
    }
}