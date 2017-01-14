using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using MVC.Infrastructure.Mappers;

namespace MVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;

        private int CurrentUserId => userService.GetByLogin(User.Identity.Name).Id;

        public CategoryController(ICategoryService categoryService, IUserService userService)
        {
            this.categoryService = categoryService;
            this.userService = userService;
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index(int page = 1)
        {
            var model = categoryService.GetAll().ToCategoryPageViewModel(page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_CategoriesPartial", model);
            }
            return View(model);
        }

        [HttpGet]
        public PartialViewResult GetCategories()
        {
            var categories = categoryService.GetAll()
                .Select(category => category.ToMvcCategory()).ToList();
            foreach (var category in categories)
            {
                category.LotCountWithoutCurrentUser = categoryService.GetLotCount(category.Id, CurrentUserId);
            }
            return PartialView("_CategoriesListPartial", categories.OrderBy(x => x.Name));
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddCategory(string name = null, int page = 1)
        {
            if (string.IsNullOrEmpty(name))
            {
                ModelState.AddModelError("name", "Enter name!");
            }
            if (categoryService.GetAll().Any(c => c.Name == name))
            {
                ModelState.AddModelError("name", $"Category with name {name} already exists!");

            }
            if (ModelState.IsValid)
            {
                categoryService.Create(new BllCategory {Name = name});
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_CategoriesPartial", categoryService.GetAll().ToCategoryPageViewModel(page));
                }
            }
            return View("Index", categoryService.GetAll().ToCategoryPageViewModel(page));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteCategory(int id = 0, int page = 1)
        {
            var category = categoryService.GetById(id);
            if (category == null)
            {
                return RedirectToAction("Index", new {page} );
            }
           
            if (category.ToMvcCategory().LotCount != 0)
            {
                ModelState.AddModelError("", "Category contains lots!");
            }
            if (ModelState.IsValid)
            {
                categoryService.Delete(id);
            }

            return View("Index", categoryService.GetAll().ToCategoryPageViewModel(page));
        }

    }
}