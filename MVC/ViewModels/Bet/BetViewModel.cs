using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels.Bet
{
    public class BetViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public DateTime Time { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Lot name")]
        public string LotName { get; set; }

        public int UserId { get; set; }
        public int LotId { get; set; }
    }
}