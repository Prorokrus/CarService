using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllUsers();
    }
}