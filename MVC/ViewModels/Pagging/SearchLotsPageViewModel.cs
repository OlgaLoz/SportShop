using System.Collections.Generic;
using MVC.ViewModels.Lot;

namespace MVC.ViewModels.Pagging
{
    public class SearchLotsPageViewModel
    {
        public string SearchName { get; set; }
        public int? LowPrice { get; set; }
        public int? HighPrice { get; set; }

        public List<LotViewModel> Lots { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}