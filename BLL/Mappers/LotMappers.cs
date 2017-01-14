using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using DAL.Interfaces.Entities;

namespace BLL.Mappers
{
    public static class LotMappers
    {
        public static BllLot ToBllLot(this DalLot dalLot)
        {
            if (dalLot == null) return null;

            return new BllLot
            {
                Id = dalLot.Id,
                Name = dalLot.Name,
                Description = dalLot.Description,
                Price = dalLot.Price,
                Status = dalLot.Status,
                Image = dalLot.Image,
                UserId = dalLot.UserId,
                UserName = dalLot.UserName,
                CategoryId = dalLot.CategoryId,
                CategoryName = dalLot.CategoryName,
                BetCount = dalLot.BetCount
            };
        }

        public static DalLot ToDalLot(this BllLot bllLot)
        {
            if (bllLot == null) return null;

            return new DalLot
            {
                Id = bllLot.Id,
                Name = bllLot.Name,
                Description = bllLot.Description,
                Price = bllLot.Price,
                Status = bllLot.Status,
                Image = bllLot.Image,
                UserId = bllLot.UserId,
                CategoryId = bllLot.CategoryId
            };
        }

        public static IEnumerable<BllLot> ToBllLots(this IEnumerable<DalLot> lots)
        {
            return lots?.Select(lot => lot.ToBllLot()).ToList();
        }

    }
}