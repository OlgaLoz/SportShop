using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using DAL.Interfaces.Entities;

namespace BLL.Mappers
{
    public static class BetMappers
    {
        public static BllBet ToBllBet(this DalBet dalBet)
        {
            if (dalBet == null) return null;

            return new BllBet
            {
                Id = dalBet.Id,
                UserId = dalBet.UserId,
                UserName = dalBet.UserName,
                Time = dalBet.Time,
                LotId = dalBet.LotId,
                LotName = dalBet.LotName
            };
        }

        public static DalBet ToDalBet(this BllBet bllBet)
        {
            if (bllBet == null) return null;

            return new DalBet
            {
                Id = bllBet.Id,
                UserId = bllBet.UserId,
                LotId = bllBet.LotId,
                Time = bllBet.Time
            };
        }

        public static IEnumerable<BllBet> ToBllBets(this IEnumerable<DalBet> bets)
        {
            return bets?.Select(bet => bet.ToBllBet());
        }
    }
}