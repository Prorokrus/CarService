using System;
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
        private readonly IGenericRepository<User> _userRepository;

        public UserHelper(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll(x => true);
            return users.ToViewModel();
        }

        public async Task<User> GetByUserName(string username)
        {
            return await _userRepository.Get(x => x.UserName == username);
        }

        public async Task<UserViewModel> GetByUserName(string username, bool returnModel)
        {
            var user = await _userRepository.Get(x => x.UserName == username);
            return user.ToViewModel();
        }
    }
}
