using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels.Role
{
    public class RoleViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Role")]
        public string Name { get; set; }
    }
}