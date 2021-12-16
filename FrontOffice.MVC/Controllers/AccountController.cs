using System;
using System.Security.Claims;
using BusinessLayer.Helpers;
using CommonLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ServiceLayer.Interfaces;

namespace FrontOffice.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;

        public AccountController(IUserService userService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult UserNotFound()
        {
            ViewData["ErrorMessage"] = "User not found";

            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            ClaimsIdentity identity = null;
            bool isAuthenticate = false;

            var user = _userService.GetByUserName(username.Trim()).Result;
            
            if (user == null)
                RedirectToAction("UserNotFound");

            var passwordHash = HashHelper.HashPassword(password);

            if (username.Equals(user.UserName, StringComparison.InvariantCulture) 
                && passwordHash.Equals(user.Password, StringComparison.InvariantCulture))
            {
                var userRole = _userRoleService.GetUserRole(user).Result;

                var role = userRole.Role.RoleName.Equals(Roles.Admin, StringComparison.InvariantCulture)
                    ? Roles.Admin
                    : Roles.User;

                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }

            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}

