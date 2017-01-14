using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MVC.ViewModels.Bet;

namespace MVC.ViewModels.Pagging
{
    public class BetPageViewModel
    {
        public int LotId { get; set; }

        public string SearchName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LowDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? HighDate { get; set; }

        public IEnumerable<BetViewModel> Bets { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}