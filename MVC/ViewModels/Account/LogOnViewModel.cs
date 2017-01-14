using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels.Account
{
    public class LogOnViewModel
    {
        [Required(ErrorMessage = "Enter your login, please!")]
        [Display(Name = "Login:")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter your password, please!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }
    }
}
