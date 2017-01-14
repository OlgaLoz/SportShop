using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using BLL.Interfaces.Interfaces;

namespace MVC.Controllers
{
    public class ModelValidationController : Controller
    {
        private readonly IUserService userService;

        public ModelValidationController(IUserService userService)
        {
            this.userService = userService;
        }

        public JsonResult ValidateLogin(string login)
        {
            if (userService.GetAll().Any(u => u.Login == login))
            {
                return Json($"User with login {login} already exists!", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateChangedLogin(string login)
        {
            int currentUserId = userService.GetByLogin(User.Identity.Name).Id;
           string oldLogin = userService.GetById(currentUserId).Login;
            if (userService.GetByLogin(login) != null && oldLogin != login)
            {
                return Json($"User with login {login} already exist!", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateOldPassword(string oldPassword)
        {
            var user = userService.GetById(userService.GetByLogin(User.Identity.Name).Id);

            if (!Crypto.VerifyHashedPassword(user.Password, oldPassword))
            {
                return Json("Incorrect old password!",JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);

        }

    }
}