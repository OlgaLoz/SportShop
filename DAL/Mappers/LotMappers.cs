using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces.Entities;
using ORM;

namespace DAL.Mappers
{
    public static class LotMappers
    {
        public static Lot ToOrmLot(this DalLot dalLot)
        {
            if (dalLot == null) return null;

            return new Lot
            {
                Id = dalLot.Id,
                Name = dalLot.Name,
                Description = dalLot.Description,
                Price = dalLot.Price,
                Status = dalLot.Status,
                Image = dalLot.Image,
                UserId = dalLot.UserId,
                CategoryId = dalLot.CategoryId
            };
        }

        public static DalLot ToDalLot(this Lot lot)
        {
            if (lot == null) return null;

            return new DalLot
            {
                Id = lot.Id,
                Name = lot.Name,
                Description = lot.Description,
                Price = lot.Price,
                Status = lot.Status,
                Image = lot.Image,
                UserId = lot.UserId,
                UserName = lot.User.Login,
                CategoryId = lot.CategoryId,
                CategoryName = lot.Category.Name,
                BetCount = lot.Bets.Count
             };
        }

        public static IEnumerable<DalLot> ToDalLots(this IQueryable<Lot> lots )
        {
            return lots?.AsEnumerable().Select(bet => bet.ToDalLot()).ToList();
        }

    }
}