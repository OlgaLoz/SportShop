using System.Collections.Generic;
using MVC.ViewModels.Lot;

namespace MVC.ViewModels.Pagging
{
    public class LotPageViewModel
    {
        public List<LotViewModel> Lots { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}