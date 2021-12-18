using System.Threading.Tasks;
using CommonLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace FrontOffice.MVC.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IUserService _userService;
        private string _userName;

        public VehicleController(IVehicleService vehicleService, IUserService userService)
        {
            _vehicleService = vehicleService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            _userName = HttpContext.User?.Identity?.Name;
            var userId = _userService.GetUserIdByUserName(_userName).Result;

            var vehicles = _vehicleService.GetAllVehicles(userId).Result;

            return View(vehicles);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleViewModel model)
        {
            _userName = HttpContext.User?.Identity?.Name;
            var userId = _userService.GetUserIdByUserName(_userName).Result;
            await _vehicleService.AddVehicle(model, userId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int vehicleId)
        {
            var vehicle = await _vehicleService.GetVehicle(vehicleId);
            return View(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleViewModel model)
        {
            await _vehicleService.EditVehicle(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int vehicleId)
        {
            await _vehicleService.DeleteVehicle(vehicleId);
            return RedirectToAction("Index");
        }
    }
}
