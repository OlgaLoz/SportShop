using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels.Bet
{
    public class ShortBetViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Last bet time:")]
        public DateTime Time { get; set; }

        [Display(Name = "Last bet user:")]
        public string UserName { get; set; }
    }
}