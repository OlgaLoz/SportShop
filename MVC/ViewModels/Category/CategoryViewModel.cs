using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels.Category
{
    public class CategoryViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Category")]
        public string Name { get; set; }

        public int LotCount { get; set; }

        public int LotCountWithoutCurrentUser { get; set; }
    }
}