using System.Threading.Tasks;
using CommonLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace FrontOffice.MVC.Controllers
{
    public class BaseCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public BaseCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllBaseCategories());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(BaseCategoryViewModel model)
        {
            await _categoryService.AddBaseCategory(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _categoryService.GetBaseCategory(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BaseCategoryViewModel model)
        {
            await _categoryService.EditBaseCategory(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteBaseCategory(id);
            return RedirectToAction("Index");
        }
    }
}
