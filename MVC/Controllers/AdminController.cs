using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces.Interfaces;
using MVC.Infrastructure.Mappers;
using MVC.ViewModels.Role;

namespace MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
       
        public AdminController(IRoleService roleService,
            IUserService userService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        public ActionResult Index(string name = null, int page = 1)
        {
            var users = string.IsNullOrEmpty(name) ? userService.GetAll() : roleService.GetByName(name);
            var usersPage = users.ToUserPageViewModel(page);
            usersPage.SearchName = name;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_UsersPartial", usersPage);
            }
            return View("Users", usersPage);
        }

        [HttpGet]
        public ActionResult EditRole(int? userId, string name, int page = 1)
        {
            if (userId == null)
            {
                return RedirectToAction("Index", new {name, page});
            }
            var user = userService.GetById(userId.Value);
            var userRoles = roleService.GetUserRoles(user);
            var model = roleService.GetAll().ToUserRoleViewModel(userRoles, userId.Value, user.Login);
            ViewBag.Name = name;
            ViewBag.Page = page;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddRole(UserRoleViewModel model, string name, int page = 1)
        {
            if (model != null)
            {
                var user = userService.GetById(model.UserId);
                if (roleService.GetUserRoles(user).Any(role => role.Id == model.RoleId))
                {
                    ModelState.AddModelError("", "User has already had this role!");   
                }
                if (ModelState.IsValid)
                {
                    roleService.AddUserRole(userService.GetById(model.UserId),roleService.GetById(model.RoleId));
                }
                else
                {
                    model = roleService.GetAll().ToUserRoleViewModel(roleService.GetUserRoles(user), user.Id, user.Login);
                    return View("EditRole", model);
                }
            }
            return RedirectToAction("Index", new {name, page });
        }

        [HttpPost]
        public ActionResult DeleteRole(UserRoleViewModel model, string name, int page = 1)
        {
            if (model != null)
            {
                var user = userService.GetById(model.UserId);
                if (roleService.GetUserRoles(user).All(role => role.Id != model.RoleId))
                {
                    ModelState.AddModelError("", "User hasn't had any role!");
                }
                if (ModelState.IsValid)
                {
                    roleService.DeleteUserRole(userService.GetById(model.UserId), roleService.GetById(model.RoleId));
                }
                else
                {
                    model = roleService.GetAll().ToUserRoleViewModel(roleService.GetUserRoles(user), user.Id, user.Login);
                    return View("EditRole", model);
                }
            }
            return RedirectToAction("Index", new {name, page });
        }

    }
}