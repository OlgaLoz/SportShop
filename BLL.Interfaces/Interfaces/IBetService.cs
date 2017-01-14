using System;
using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IBetService
    {
        BllBet GetLastBet(int lotId);
        void Create(BllBet bet);
        IEnumerable<BllBet> GetLotBets(int lotId);
        IEnumerable<BllBet> Search(int userId, string name, DateTime? low, DateTime? high);
    }
}