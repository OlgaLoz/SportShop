using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using MVC.Infrastructure.Mappers;

namespace MVC.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly ILotService lotService;
        private readonly IUserService userService;

        private int CurrentUserId => userService.GetByLogin(User.Identity.Name).Id ;

        public SearchController(ILotService lotService,
            IUserService userService)
        {
            this.lotService = lotService;
            this.userService = userService;
        }

        public ActionResult Index(string name, int? low, int? high, int page = 1)
        {
            var pageLots = lotService.GetByNameAndPrice(name == "" ? null : name, low, high, CurrentUserId)
                .OrderByDescending(lot => lot.BetCount).ToSearchLotsPageViewModel(name, low, high, page);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_SearchLotsPartial", pageLots);
            }

            ViewBag.Name = name;
            ViewBag.Low = low;
            ViewBag.High = high;
            ViewBag.Page = page;
            return View(pageLots);
        }

        [HttpGet]
        public ActionResult UpdateBetCount(int? lotId, string name, DateTime? low, DateTime? high, int page = 1)
        {
            if (lotId != null)
            {
                var bet = new BllBet
                {
                    LotId = lotId.Value,
                    UserId = CurrentUserId,
                    Time = DateTime.Now
                };
                lotService.AddBet(bet);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_SingleLotPartial", lotService.GetById(lotId.Value).ToMvcLot());
                }
            }
            return RedirectToAction("Index",new {name, low, high, page} );
        }
    }
}