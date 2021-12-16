using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.ViewModels;
using DataLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllUsers();
        Task<User> GetByUserName(string username);
    }
}