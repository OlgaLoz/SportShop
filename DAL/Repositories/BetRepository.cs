using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.Entities;
using DAL.Interfaces.Interfaces.Repositories;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly DbContext context;

        public BetRepository(DbContext context)
        {
            this.context = context;
        }

        public DalBet GetLastBet(int lotId)
        {
            return context.Set<Bet>().OrderByDescending(bet => bet.Id).FirstOrDefault
                (bet => bet.LotId == lotId).ToDalBet();
        }

        public IEnumerable<DalBet> GetByUserId(int id)
        {
            return context.Set<Bet>().Where(bet => bet.User.Id == id).ToDalBets();
        }

        public IEnumerable<DalBet> GetLotBets(int lotId)
        {
            return context.Set<Bet>().Where(bet => bet.LotId == lotId).ToDalBets();
        }

        public IEnumerable<DalBet> GetByLotName(string name)
        {
           return context.Set<Bet>().Where(bet => bet.Lot.Name.Contains(name.Trim())).ToDalBets();
        }

        public IEnumerable<DalBet> GetByLowDate(DateTime date)
        {
            return context.Set<Bet>().Where(bet => bet.Time >= date).ToDalBets();
        }

        public IEnumerable<DalBet> GetByHighDate(DateTime date)
        {
            return context.Set<Bet>().Where(bet => bet.Time <= date).ToDalBets();
        }

        public void Create(DalBet entity)
        {
            var lot = context.Set<Lot>().Find(entity.UserId);
            lot.Bets.Add(entity.ToOrmBet());
        }

        public IEnumerable<DalBet> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalBet GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var bet = context.Set<Bet>().Find(id);
            if (bet == null) return;
            context.Set<Bet>().Remove(bet);
        }

        public void Update(DalBet entity)
        {
            throw new NotImplementedException();
        }
    }
}