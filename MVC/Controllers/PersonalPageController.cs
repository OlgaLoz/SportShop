using System.IO;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Interfaces;
using MVC.Infrastructure.Mappers;
using MVC.ViewModels.Lot;

namespace MVC.Controllers
{
    [Authorize]
    public class PersonalPageController : Controller
    {
        private readonly ILotService lotService;
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;

        private int CurrentUserId => userService.GetByLogin(User.Identity.Name).Id;

        public PersonalPageController(ILotService lotService, 
            IUserService userService, ICategoryService categoryService)
        {
            this.lotService = lotService;
            this.userService = userService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult Lots(int page = 1)
        {
            var lots = lotService.GetUserLots(CurrentUserId)?.ToLotPageViewModel(page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_LotsPartial", lots);
            }
            return View(lots);
        }

        [HttpGet]
        public ActionResult AddLot(int page = 1)
        {
            SelectList categories = new SelectList(categoryService.GetAll(), "Id", "Name");
            ViewBag.Categories = categories;
            ViewBag.Page = page;
            return View();
        }

        [HttpPost]
        public ActionResult AddLot(ShortLotViewModel model, HttpPostedFileBase uploadImage, int page = 1)
        {
            if (ModelState.IsValid)
            {
                model.UserId = CurrentUserId;
                if (uploadImage != null)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    model.Image = imageData;
                }
                lotService.Create(model.ToBllLot());
                return RedirectToAction("Lots", new {page});
            }

            SelectList categories = new SelectList(categoryService.GetAll(), "Id", "Name");
            ViewBag.Categories = categories;
            return View();
        }

        [HttpGet]
        public ActionResult EditLot(int id, int page = 1)
        {
            SelectList categories = new SelectList(categoryService.GetAll(), "Id", "Name");
            ViewBag.Categories = categories;
            ViewBag.Page = page;
            return View(lotService.GetById(id)?.ToShortMvcLot());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLot(ShortLotViewModel model, HttpPostedFileBase uploadImage, int page = 1)
        {
            var lot = lotService.GetById(model.Id);
            if (ModelState.IsValid)
            {
                lot.Name = model.Name;
                lot.Description = model.Description;
                lot.CategoryId = model.CategoryId;
                lot.Price = model.Price;

                if (uploadImage != null)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    lot.Image = imageData;
                }
                lotService.Update(lot);
                return RedirectToAction("Lots", new {page});
            }

            SelectList categories = new SelectList(categoryService.GetAll(), "Id", "Name");
            ViewBag.Categories = categories;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteLot(int id = 0, int page = 1)
        {
            var lot = lotService.GetById(id);
            if (lot == null)
            {
                return RedirectToAction("Lots", new {page});
            }
            ViewBag.Page = page;
            return View(lot.ToShortMvcLot());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLot(ShortLotViewModel model, int page = 1)
        {
            lotService.Delete(model.Id);
            return RedirectToAction("Lots", new {page});
        }

        public ActionResult Sell(int id = 0, int page = 1)
        {
            var lot = lotService.GetById(id);
            if (lot != null && lot.BetCount != 0)
            {
                lotService.ChangeOwner(id);
            }
            return RedirectToAction("Lots", new {page});
        }

        public ActionResult UpdateStatus(int id = 0, int page = 1)
        {
            var lot = lotService.GetById(id);
            if (lot != null)
            {
                lotService.UpdateStatus(id);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_StatusPartial", !lot.Status);
                }
            }
            return RedirectToAction("Lots", new {page});
        }
    }
}