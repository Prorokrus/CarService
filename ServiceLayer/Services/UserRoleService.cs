using DataLayer.Entities;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly ILogger<UserService> _logger;
        private readonly UserRoleHelper _userRoleHelper;

        public UserRoleService(ILogger<UserService> logger, UserRoleHelper userRoleHelper)
        {
            _logger = logger;
            _userRoleHelper = userRoleHelper;
        }

        public async Task<UserRole> GetUserRole(User user)
        {
            _logger.LogInformation($"Getting UserRole for user with Id: {user.Id}");

            try
            {
                return await _userRoleHelper.GetUserRole(user);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }

            return new UserRole();
        }
    }
}
