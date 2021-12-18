using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using CommonLayer.ViewModels;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace BusinessLayer.Helpers
{
    public class UserHelper
    {
        private readonly IUserRepository _userRepository;

        public UserHelper(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.ToViewModel();
        }

        public async Task<User> GetByUserName(string username)
        {
            return await _userRepository.GetByUserName(username);
        }

        public async Task<UserViewModel> GetByUserName(string username, bool returnModel)
        {
            var user = await _userRepository.GetByUserName(username);
            return user.ToViewModel();
        }

        public async Task<int> GetUserIdByUserName(string username)
        {
            return await _userRepository.GetUserIdByUserName(username);
        }

        public async Task<UserViewModel> Update(UserViewModel model)
        {
            var user = await _userRepository.Update(model.ToEntity());
            return user.ToViewModel();
        }
    }
}
