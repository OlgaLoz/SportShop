using BLL.Interfaces.Entities;
using DAL.Interfaces.Entities;

namespace BLL.Mappers
{
    public static class CategoryMappers
    {
        public static BllCategory ToBllCategory(this DalCategory dalCategory)
        {
            if (dalCategory == null) return null;

            return new BllCategory
            {
                Id = dalCategory.Id,
                Name = dalCategory.Name,
                LotCount = dalCategory.LotCount
            };
        }

        public static DalCategory ToDalCategory(this BllCategory bllCategory)
        {
            if (bllCategory == null) return null;

            return new DalCategory
            {
                Id = bllCategory.Id,
                Name = bllCategory.Name
            };
        }
    }
}