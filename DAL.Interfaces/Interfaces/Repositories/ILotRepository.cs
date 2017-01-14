using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interfaces.Entities;

namespace DAL.Interfaces.Interfaces.Repositories
{
    public interface ILotRepository : IRepository<DalLot>
    {
        IEnumerable<DalLot> GetUserLots(int userId);
        IEnumerable<DalLot> GetByCategory(int categoryId = 0, int excludeUser = 0);
        IEnumerable<DalLot> GetByName(string name, int excludeUser = 0);
        IEnumerable<DalLot> GetByHighPrice(int price, int excludeUser = 0);
        IEnumerable<DalLot> GetByLowPrice(int price, int excludeUser = 0);

        void UpdateStatus(int id);
        void AddBet(DalBet bet);
    }
}