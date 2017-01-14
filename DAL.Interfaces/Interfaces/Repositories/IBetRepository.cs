using System;
using System.Collections.Generic;
using DAL.Interfaces.Entities;

namespace DAL.Interfaces.Interfaces.Repositories
{
    public interface IBetRepository : IRepository<DalBet>
    {
        DalBet GetLastBet(int lotId);
        IEnumerable<DalBet> GetByUserId(int id);
        IEnumerable<DalBet> GetLotBets(int lotId);
        IEnumerable<DalBet> GetByLotName(string name);
        IEnumerable<DalBet> GetByLowDate(DateTime date);
        IEnumerable<DalBet> GetByHighDate(DateTime date);
    }
}