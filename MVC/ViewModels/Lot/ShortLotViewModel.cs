using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.ViewModels.Lot
{
    public class ShortLotViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter lot name!")]
        [Display(Name = "Lot name:")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Enter lot description!")]
        [Display(Name = "Lot description:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter lot price!")]
        [Display(Name = "Lot price:")]
        [Range(0, int.MaxValue, ErrorMessage = "Must be more than 0!")]
        public int Price { get; set; }

        [DisplayName ("Category: ")]
        public int CategoryId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public byte[] Image { get; set; }

        public int UserId { get; set; }
    }
}