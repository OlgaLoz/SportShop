using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces.Interfaces;
using MVC.Infrastructure.Mappers;

namespace MVC.Controllers
{
    [Authorize]
    public class BetController : Controller
    {
        private readonly IUserService userService;
        private readonly IBetService betService;

        private int CurrentUserId => userService.GetByLogin(User.Identity.Name).Id;

        public BetController(IUserService userService, IBetService betService)
        {
            this.userService = userService;
            this.betService = betService;
        }

        [ChildActionOnly]
        public PartialViewResult BetPartial(int lotId = 0)
        {
            var lastBet = betService.GetLastBet(lotId)?.ToShortBetViewModel();
            return PartialView("_BetPartial",lastBet);
        }

        public ActionResult ShowBetHistory(string name, DateTime? low, DateTime? high, int page = 1)
        {
            var bets = betService.Search(CurrentUserId, name == ""? null : name, low, high)
                .ToBetPageViewModel(page, name, low, high);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_BetHistoryPartial", bets);
            }
            return View("BetHistory", bets);
        }

        public ActionResult ShowLotsBetHistory(int lotId, int page = 1)
        {
            var bets = betService.GetLotBets(lotId).ToList().ToBetPageViewModel(page);
            bets.LotId = lotId;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_LotsBetHistoryPartial", bets);
            }

            return View("LotsBetHistory", bets);
        }

    }
}