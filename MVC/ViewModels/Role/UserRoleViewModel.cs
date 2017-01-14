using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.ViewModels.Role
{
    public class UserRoleViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "User name: ")]
        public string UserName { get; set; }
        public int RoleId { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        [Display(Name = "User roles: ")]
        public IEnumerable<SelectListItem> UserRoles { get; set; }
    }
}