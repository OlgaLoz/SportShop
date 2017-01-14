using System.Collections.Generic;
using MVC.ViewModels.Lot;

namespace MVC.ViewModels.Pagging
{
    public class LotByCategoriesPageViewModel
    {
        public int CurrentCategory { get; set; }

        public List<LotViewModel> Lots { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}