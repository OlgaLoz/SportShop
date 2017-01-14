using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using MVC.Infrastructure.Mappers;
using MVC.ViewModels.Pagging;

namespace MVC.Controllers
{
    [Authorize] 
    public class HomeController : Controller
    {
        private readonly ILotService lotService;
        private readonly IUserService userService;

        private int CurrentUserId => userService.GetByLogin(User.Identity.Name).Id;

        public HomeController(ILotService lotService,
            IUserService userService)
        {
            this.lotService = lotService;
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Index(int categoryId = 0, int page = 1)
        {
            var pageLots = lotService.GetByCategory(categoryId, CurrentUserId)
                .OrderByDescending(lot => lot.BetCount).ToLotByCategoriesPageViewModel(categoryId, page);
            ViewBag.Page = page;
            ViewBag.CategoryId = categoryId;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_LotsPartial", pageLots);
            }

            return View("Index", pageLots);
        }

        [HttpGet]
        public ActionResult UpdateBetCount(int? lotId, int categoryId, int page = 1)
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
                ViewBag.Page = page;
                ViewBag.CategoryId = categoryId;
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_SingleLotPartial", lotService.GetById(lotId.Value).ToMvcLot());
                }
            }
            return RedirectToAction("Index", new {categoryId, page});
        }

        [HttpGet]
        public ActionResult LotPage(int id = 0)
        {
            if (id == 0)
            {
                return View("Index",new LotByCategoriesPageViewModel());
            }
            var lot = lotService.GetById(id).ToMvcLot();
            return View(lot);
        }

        [HttpGet]
        public ActionResult DoBet(int? lotId)
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
                    return PartialView("_BetCountPartial", lotService.GetById(lotId.Value).ToMvcLot());
                }
            }
            return RedirectToAction("LotPage", new {id = lotId});
        }

        public FileContentResult GetImage(int id)
        {
            var lot = lotService.GetById(id);

            if (lot?.Image != null)
            {
                return File(lot.Image, "image");
            }

            var img = System.IO.File.ReadAllBytes(Request.PhysicalApplicationPath + "/Content/Images/noimage.png");
            return File(img, "image");
        }
    }
}