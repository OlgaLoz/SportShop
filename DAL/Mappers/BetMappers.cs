using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces.Entities;
using ORM;

namespace DAL.Mappers
{
    public static class BetMappers
    {
        public static Bet ToOrmBet(this DalBet dalBet)
        {
            if (dalBet == null) return null;

            return new Bet
            {
                Id = dalBet.Id,
                UserId = dalBet.UserId,
                Time = dalBet.Time, 
                LotId = dalBet.LotId
            };
        }

        public static DalBet ToDalBet(this Bet bet)
        {
            if (bet == null) return null;

            return new DalBet
            {
                Id = bet.Id,
                UserId = bet.UserId,
                UserName = bet.User.Login,
                Time = bet.Time,
                LotId = bet.LotId,
                LotName = bet.Lot.Name
            };
        }

        public static IEnumerable<DalBet> ToDalBets(this IQueryable<Bet> bets)
        {
            return bets?.AsEnumerable().Select(bet => bet.ToDalBet());
        }
    }
}