using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.ViewModels.Category
{
    public class ShortCategoryViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}