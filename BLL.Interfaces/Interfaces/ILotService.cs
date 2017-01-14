using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface ILotService
    {
        BllLot GetById(int id);
        void Create(BllLot lot);
        void Delete(int id);
        void Update(BllLot lot);

        IEnumerable<BllLot> GetAll();
        IEnumerable<BllLot> GetUserLots(int userId);
        IEnumerable<BllLot> GetByCategory(int categoryId = 0, int excludeUser = 0);
        IEnumerable<BllLot> GetByName(string name, int excludeUser = 0);
        IEnumerable<BllLot> GetByNameAndPrice(string name, int? start, int? end, int excludeUser = 0);

        void UpdateStatus(int id);
        void UpdateImage(int id, byte[] newImage);
        void ChangeOwner(int id);
        void AddBet(BllBet bet);
    }
}