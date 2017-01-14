using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using MVC.ViewModels.Bet;
using MVC.ViewModels.Pagging;

namespace MVC.Infrastructure.Mappers
{
    public static class BetMappers
    {
        public static BllBet ToBllBet(this ShortBetViewModel betViewModel)
        {
            return new BllBet
            {
                Id = betViewModel.Id,
                Time = betViewModel.Time,
                UserId = betViewModel.Id
            };
        }

        public static ShortBetViewModel ToShortBetViewModel(this BllBet bllBet)
        {
            return new ShortBetViewModel
            {
                Id = bllBet.Id,
                Time = bllBet.Time,
                UserName = bllBet.UserName
            };
        }

        public static BetViewModel ToBetViewModel(this BllBet bllBet)
        {
            return new BetViewModel
            {
                Id = bllBet.Id,
                Time = bllBet.Time,
                UserName = bllBet.UserName,
                UserId = bllBet.UserId,
                LotName = bllBet.LotName,
                LotId = bllBet.LotId
            };
        }

        public static BetPageViewModel ToBetPageViewModel(this IEnumerable<BllBet> bets, int page, string name = null, DateTime? low = null, DateTime? high = null)
        {
            int pageSize = 12;
            return new BetPageViewModel
            {
                PageInfo = new PageInfo
                {
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalItems = bets.Count()
                },
                SearchName = name,
                LowDate = low,
                HighDate = high,
                Bets = bets.Skip((page - 1) * pageSize).Take(pageSize).Select(bet => bet.ToBetViewModel()).ToList()
            };
        }
    }
}