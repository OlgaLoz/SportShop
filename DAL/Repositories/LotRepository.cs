using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.Entities;
using DAL.Interfaces.Interfaces.Repositories;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class LotRepository : ILotRepository
    {
        private readonly DbContext context;

        public LotRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalLot> GetAll()
        {
            return context.Set<Lot>().ToDalLots();
        }

        public DalLot GetById(int id)
        {
            return context.Set<Lot>().Find(id).ToDalLot();
        }

        public void Create(DalLot entity)
        {
            var user = context.Set<User>().Find(entity.UserId);
            user.Lots.Add(entity.ToOrmLot());
        }

        public void Delete(int id)
        {
            var lot = context.Set<Lot>().Find(id);
            if (lot == null) return;

            var bets = lot.Bets.ToList();
            bets.ForEach(x => context.Set<Bet>().Remove(x));
            context.Set<Lot>().Remove(lot);
        }

        public void Update(DalLot entity)
        {
            var lot = context.Set<Lot>().Find(entity.Id);
            if (lot == null) return;

            lot.CategoryId = entity.CategoryId;
            lot.Description = entity.Description;
            lot.Name = entity.Name;
            lot.Price = entity.Price;
            lot.Image = entity.Image;
            lot.Status = entity.Status;
            lot.UserId = entity.UserId;
            context.Entry(lot).State = EntityState.Modified;
        }

        public IEnumerable<DalLot> GetUserLots(int userId)
        {
            return context.Set<Lot>()
                .Where(lot => lot.UserId == userId)
                .ToDalLots();
        }

        public IEnumerable<DalLot> GetByCategory(int categoryId = 0, int excludeUserId = 0)
        {
            return context.Set<Lot>()
                .Where(lot => lot.CategoryId == (categoryId == 0 ? lot.CategoryId : categoryId))
                .Where(lot => lot.User.Id != excludeUserId)
                .Where(lot => lot.Status)
                .ToDalLots();
        }

        public IEnumerable<DalLot> GetByName(string name, int excludeUser = 0)
        {
            return context.Set<Lot>()
                .Where(lot => lot.User.Id != excludeUser)
                .Where(lot => lot.Name.Contains(name.Trim()))
                .Where(lot => lot.Status)
                .ToDalLots();
        }

        public IEnumerable<DalLot> GetByHighPrice(int price, int excludeUser = 0)
        {
            return context.Set<Lot>()
                .Where(lot => lot.User.Id != excludeUser)
                .Where(lot => lot.Price <= price)
                .Where(lot => lot.Status)
                .ToDalLots();
        }

        public IEnumerable<DalLot> GetByLowPrice(int price, int excludeUser = 0)
        {
            return context.Set<Lot>()
              .Where(lot => lot.User.Id != excludeUser)
              .Where(lot => lot.Price >= price)
              .Where(lot => lot.Status)
              .ToDalLots();
        }

        public void UpdateStatus(int id)
        {
            var lot = context.Set<Lot>().Find(id);
            if (lot == null) return;

            lot.Status = !lot.Status;
            context.Entry(lot).Property(x => x.Status).IsModified = true;
        }

        public void AddBet(DalBet bet)
        {
            var lot = context.Set<Lot>().Find(bet?.LotId);
            if (lot == null || bet == null) return;
            lot.Bets.Add(bet.ToOrmBet());

            lot.Price += 1;
            context.Entry(lot).Property(x => x.Price).IsModified = true;
        }

        public int GetLotCountByCategory(int categoryId = 0, int excludeUserId = 0)
        {
            return context.Set<Lot>().Where(lot => lot.User.Id != excludeUserId).
                Where(cid => cid.CategoryId == (categoryId == 0 ? cid.CategoryId : categoryId)).
                Count(lot => lot.Status);
        }
    }
}