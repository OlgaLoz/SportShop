using System.Collections.Generic;
using MVC.ViewModels.Category;

namespace MVC.ViewModels.Pagging
{
    public class CategoryPageViewModel
    {
        public List<ShortCategoryViewModel> Categories { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}