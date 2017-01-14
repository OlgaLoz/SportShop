using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interfaces.Interfaces.UnitOfWork;

namespace BLL.Services
{
    public class BetService : IBetService
    {
        private readonly IUnitOfWork unitOfWork;

        public BetService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public BllBet GetLastBet(int lotId)
        {
            return unitOfWork.Bets.GetLastBet(lotId)?.ToBllBet();
        }

        public void Create(BllBet bet)
        {
            unitOfWork.Bets.Create(bet?.ToDalBet());
            unitOfWork.Commit();
        }

        public IEnumerable<BllBet> GetLotBets(int lotId)
        {
            return unitOfWork.Bets.GetLotBets(lotId).ToBllBets();
        }

        public IEnumerable<BllBet> Search(int userId, string name, DateTime? low, DateTime? high)
        {
            var bets = unitOfWork.Bets.GetByUserId(userId).ToList();

            if (name != null)
            {
                var nameBets = unitOfWork.Bets.GetByLotName(name).ToList();
                var tmpBets = bets;
                bets = nameBets.Select(bet => tmpBets.SingleOrDefault(cbet => cbet.Id == bet.Id)).Where(current => current != null).ToList();
            }

            if (low != null)
            {
                var lowBets = unitOfWork.Bets.GetByLowDate(low.Value).ToList();
                var tmpBets = bets;
                bets = lowBets.Select(bet => tmpBets.SingleOrDefault(cbet => cbet.Id == bet.Id)).Where(current => current != null).ToList();
            }

            if (high != null)
            {
                var highBets = unitOfWork.Bets.GetByHighDate(high.Value).ToList();
                var tmpBets = bets;
                bets = highBets.Select(bet => tmpBets.SingleOrDefault(cbet => cbet.Id == bet.Id)).Where(current => current != null).ToList();
            }
            return bets.ToBllBets();
        }
    }
}