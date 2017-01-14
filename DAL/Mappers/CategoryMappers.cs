using System.Net.NetworkInformation;
using DAL.Interfaces.Entities;
using ORM;

namespace DAL.Mappers
{
    public static class CategoryMappers
    {
        public static Category ToOrmCategory(this DalCategory dalCategory )
        {
            if (dalCategory == null) return null;

            return new Category
            {
                Id = dalCategory.Id,
                Name = dalCategory.Name
            };
        }

        public static DalCategory ToDalCategory(this Category category)
        {
            if (category == null) return null;

            return new DalCategory
            {
                Id = category.Id,
                Name = category.Name,
                LotCount = category.Lots.Count
            };
        }
    }
}