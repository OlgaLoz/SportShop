using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.ViewModels.Account
{
    public class RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Login:")]
        [Required(ErrorMessage = "Enter your login, please!")]
        [Remote("ValidateLogin","ModelValidation")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter your password, please!")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter your password one more time, please!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password:")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords must match!")]
        public string ConfirmPassword { get; set; }
    }
}