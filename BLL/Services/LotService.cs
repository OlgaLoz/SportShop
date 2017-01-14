using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interfaces.Interfaces.UnitOfWork;

namespace BLL.Services
{
    public class LotService : ILotService
    {
        private readonly IUnitOfWork unitOfWork;

        public LotService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<BllLot> GetAll()
        {
            return unitOfWork.Lots.GetAll().ToBllLots();
        }

        public BllLot GetById(int id)
        {
           return unitOfWork.Lots.GetById(id)?.ToBllLot();
        }

        public void Create(BllLot lot)
        {
            unitOfWork.Lots.Create(lot?.ToDalLot());
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            unitOfWork.Lots.Delete(id);
            unitOfWork.Commit();
        }

        public void Update(BllLot lot)
        {
            unitOfWork.Lots.Update(lot?.ToDalLot());
            unitOfWork.Commit();
        }

        public IEnumerable<BllLot> GetUserLots(int userId)
        {
            return unitOfWork.Lots.GetUserLots(userId)?.ToBllLots();
        }

        public IEnumerable<BllLot> GetByCategory(int categoryId, int excludeUserId)
        {
            //return unitOfWork.Lots.GetBy(x => x.CategoryId == categoryId).ToBllLots();
            return unitOfWork.Lots.GetByCategory(categoryId, excludeUserId)?.ToBllLots();
        }

        public IEnumerable<BllLot> GetByName(string name, int excludeUser = 0)
        {
            return unitOfWork.Lots.GetByName(name, excludeUser).ToBllLots();
        }

        public IEnumerable<BllLot> GetByNameAndPrice(string name, int? start, int? end, int excludeUser = 0)
        {
            var lots = name != null ? unitOfWork.Lots.GetByName(name, excludeUser) 
                : unitOfWork.Lots.GetAll().Where(lot => lot.UserId != excludeUser)
                .Where(lot => lot.Status);

            if (start != null)
            {
                var startLots = unitOfWork.Lots.GetByLowPrice(start.Value);
                var tmpLots = lots;
                lots = startLots.Select(lot => tmpLots.SingleOrDefault(clot => clot.Id == lot.Id)).Where(current => current != null);

            }
            if (end != null)
            {
                var endLots = unitOfWork.Lots.GetByHighPrice(end.Value);
                var tmpLots = lots;
                lots = endLots.Select(lot => tmpLots.SingleOrDefault(clot => clot.Id == lot.Id)).Where(current => current != null);
            }
            return lots.ToBllLots();
        }


        public void UpdateStatus(int id)
        {
            unitOfWork.Lots.UpdateStatus(id);
            unitOfWork.Commit();
        }

        public void UpdateImage(int id, byte[] newImage)
        {
            var lot = unitOfWork.Lots.GetById(id);
            lot.Image = newImage;
            unitOfWork.Lots.Update(lot);
            unitOfWork.Commit();
        }

        public void ChangeOwner(int id)
        {
            var lot = unitOfWork.Lots.GetById(id);
            if (lot == null) return;
            lot.Status = false;

            var lastBet = unitOfWork.Bets.GetLastBet(id);
            if (lastBet == null) return;
            lot.UserId = lastBet.UserId;

            unitOfWork.Lots.Update(lot);

            var bets = unitOfWork.Bets.GetLotBets(id).ToList();
            foreach (var bet in bets)
            {
               unitOfWork.Bets.Delete(bet.Id);
            }
            unitOfWork.Commit();
        }

        public void AddBet(BllBet bet)
        {
            unitOfWork.Lots.AddBet(bet?.ToDalBet());
            unitOfWork.Commit();
        }
    }
}