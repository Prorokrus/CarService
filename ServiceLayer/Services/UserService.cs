using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using CommonLayer.ViewModels;
using DataLayer.Entities;
using Microsoft.Extensions.Logging;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly UserHelper _userHelper;

        public UserService(ILogger<UserService> logger, UserHelper userHelper)
        {
            _logger = logger;
            _userHelper = userHelper;
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            _logger.LogInformation("Getting all users");
            try
            {
                return await _userHelper.GetAll();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }

            return new List<UserViewModel>();
        }

        public async Task<User> GetByUserName(string username)
        {
            _logger.LogInformation($"Getting user with username: {username}");
            try
            {
                return await _userHelper.GetByUserName(username);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }

            return new User();
        }

        public async Task<UserViewModel> GetByUserName(string username, bool returnModel)
        {
            _logger.LogInformation("Getting all users");
            try
            {
                return await _userHelper.GetByUserName(username, returnModel);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }

            return new UserViewModel();
        }
    }
}
