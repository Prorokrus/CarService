using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace FrontOffice.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllUsers());
        }
    }
}
