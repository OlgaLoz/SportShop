using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using MVC.ViewModels.Lot;
using MVC.ViewModels.Pagging;

namespace MVC.Infrastructure.Mappers
{
    public static class LotMappers
    {
        private static int pageSize = 4;

        public static LotViewModel ToMvcLot(this BllLot bllLot)
        {
            return new LotViewModel
            {
                Id = bllLot.Id,
                Name = bllLot.Name,
                Description = bllLot.Description,
                Price = bllLot.Price,
                Status = bllLot.Status,
                Image = bllLot.Image,
                BetCount = bllLot.BetCount,
                Category = bllLot.CategoryName,
                Owner = bllLot.UserName
            };
        }

        public static BllLot ToBllLot(this LotViewModel lotViewModel)
        {
            return new BllLot
            {
                Id = lotViewModel.Id,
                Name = lotViewModel.Name,
                Description = lotViewModel.Description,
                Price = lotViewModel.Price,
                Status = lotViewModel.Status,
                Image = lotViewModel.Image,
            };
        }

        public static BllLot ToBllLot(this ShortLotViewModel shortLotViewModel)
        {
            return new BllLot
            {
                Id = shortLotViewModel.Id,
                Name = shortLotViewModel.Name,
                Description = shortLotViewModel.Description,
                Price = shortLotViewModel.Price,
                Image = shortLotViewModel.Image,
                CategoryId = shortLotViewModel.CategoryId,
                UserId = shortLotViewModel.UserId
            };
        }

        public static ShortLotViewModel ToShortMvcLot(this BllLot bllLot)
        {
            return new ShortLotViewModel
            {
                Id = bllLot.Id,
                Name = bllLot.Name,
                Description = bllLot.Description,
                Price = bllLot.Price,
                Image = bllLot.Image,
                CategoryId = bllLot.CategoryId,
                UserId = bllLot.UserId
            };
        }

        public static LotByCategoriesPageViewModel ToLotByCategoriesPageViewModel(this IEnumerable<BllLot> lots, int category, int page)
        {
            return new LotByCategoriesPageViewModel
            {
                PageInfo = new PageInfo
                {
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalItems = lots.Count()
                },
                CurrentCategory = category,
                Lots = lots.Skip((page - 1) * pageSize).Take(pageSize).ToMvcLots().ToList()
            };
        }

        public static SearchLotsPageViewModel ToSearchLotsPageViewModel(this IEnumerable<BllLot> lots, string name, int? low, int? high, int page)
        {
            int pageSize = 6;
            return new SearchLotsPageViewModel
            {
                PageInfo = new PageInfo
                {
                    PageNumber = page,
                    PageSize = 6,
                    TotalItems = lots.Count()
                },
                SearchName = name,
                LowPrice = low,
                HighPrice = high,
                Lots = lots.Skip((page - 1) * pageSize).Take(pageSize).ToMvcLots().ToList()
            };
        }

        public static LotPageViewModel ToLotPageViewModel(this IEnumerable<BllLot> lots, int page)
        {
            return new LotPageViewModel
            {
                PageInfo = new PageInfo
                {
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalItems = lots.Count()
                },
                Lots = lots.Skip((page - 1) * pageSize).Take(pageSize).ToMvcLots().ToList()
            };
        }

        public static IEnumerable<LotViewModel> ToMvcLots(this IEnumerable<BllLot> lots)
        {
            return lots.Select(lot => lot.ToMvcLot()).ToList();
        }
    }
}