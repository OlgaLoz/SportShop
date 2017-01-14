using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels.Lot
{
    public class LotViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }

        public string Category { get; set; }

        public string Owner { get; set; }

        [Display(Name = "Bet count")]
        public int BetCount { get; set; }

        public byte[] Image { get; set; }

        [Display(Name = "Last bet time")]
        public DateTime? LastBetTime { get; set; }

        [Display(Name = "Last bet user")]
        public string LastBetUser { get; set; }
    }
}
