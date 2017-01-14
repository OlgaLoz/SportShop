using DAL.Interfaces.Entities;

namespace DAL.Interfaces.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<DalCategory>
    {
        int GetLotCount(int categoryId = 0, int excludeUserId = 0);
    }
}