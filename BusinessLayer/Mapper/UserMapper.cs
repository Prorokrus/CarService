using System;
using System.Collections.Generic;
using System.Linq;
using CommonLayer.ViewModels;
using DataLayer.Entities;

namespace BusinessLayer.Mapper
{
    public static class UserMapper
    {
        public static List<UserViewModel> ToViewModel(this IList<User> users)
        {
            return users.Select(x => new UserViewModel
            {
                Id = x.Id,
                Address = x.Address,
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone,
                UserName = x.UserName
            }).ToList();
        }

        public static UserViewModel ToViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                Name = user.Name,
                Phone = user.Phone,
                UserName = user.UserName
            };
        }

        public static User ToEntity(this UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                UserName = userViewModel.UserName,
                Address = userViewModel.Address,
                Email = userViewModel.Email,
                Name = userViewModel.Name,
                Phone = userViewModel.Phone,
                Password = string.Empty
            };
        }
    }
}
