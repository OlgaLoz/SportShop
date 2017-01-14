using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces.Interfaces;
using MVC.Infrastructure.Mappers;
using MVC.ViewModels.User;

namespace MVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService userService;

        private int CurrentUserId => userService.GetByLogin(User.Identity.Name).Id;

        public ProfileController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(userService.GetById(CurrentUserId).ToProfileEditViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeLogin(ProfileEditViewModel model)
        {
            if (string.IsNullOrEmpty(model.Login))
            {
                ModelState.AddModelError("Login", "Enter login!");
            }
            string oldLogin = userService.GetById(CurrentUserId).Login;
            if (userService.GetByLogin(model.Login) != null && oldLogin != model.Login)
            {
                ModelState.AddModelError("", $"User with login {model.Login} already exist!");
            }
            if (ModelState.IsValid)
            {
                userService.ChangeLogin(model.Id, model.Login);
                FormsAuthentication.SetAuthCookie(model.Login, true);
                return RedirectToAction("Index", model);
            }
            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ProfileEditViewModel model)
        {
            var user = userService.GetById(CurrentUserId);
            if (string.IsNullOrEmpty(model.OldPassword))
            {
                ModelState.AddModelError("OldPassword", "Enter old password!");
            }
            else
            {
                if (!Crypto.VerifyHashedPassword(user.Password, model.OldPassword))
                {
                    ModelState.AddModelError("OldPassword", "Incorrect old password!");
                }
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Enter new password!");
            }
            if (ModelState.IsValid)
            {
                userService.ChangePassword(model.Id, Crypto.HashPassword(model.Password));
                return RedirectToAction("Index", user.ToProfileEditViewModel());
            }
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View(new UserViewModel { Login = User.Identity.Name });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserViewModel user)
        {
            userService.Delete(CurrentUserId);
            return RedirectToAction("LogOff", "Account");
        }
    }
}