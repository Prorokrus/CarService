using System.Threading.Tasks;
using CommonLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace FrontOffice.MVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private string _userName; 

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            _userName = HttpContext.User?.Identity?.Name;
            var user = _userService.GetByUserName(_userName, true).Result;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index");

            await _userService.Update(model);

            return RedirectToAction("Index");
        }
    }
}
