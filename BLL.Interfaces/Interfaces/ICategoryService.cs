using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<BllCategory> GetAll();
        void Create(BllCategory entity);
        void Delete(int id);
        BllCategory GetById(int id);
        int GetLotCount(int categoryId = 0, int excludeUserId = 0);
    }
}
