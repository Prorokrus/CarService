﻿using System.Collections.Generic;
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
    }
}
