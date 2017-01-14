using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.ViewModels.User
{
    public class ProfileEditViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Login: ")]
        [Remote("ValidateChangedLogin", "ModelValidation")]
        public string Login { get; set; }

        [Display(Name = "Old password: ")]
        [DataType(DataType.Password)]
        [Remote("ValidateOldPassword", "ModelValidation")]
        public string OldPassword { get; set; }

        [Display(Name = "New password: ")]
        [DataType (DataType.Password)]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Confirm password: ")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords must match!")]
        public string ConfirmPassword { get; set; }
    }
}