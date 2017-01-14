using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using MVC.ViewModels.Category;
using MVC.ViewModels.Pagging;

namespace MVC.Infrastructure.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryViewModel ToMvcCategory(this BllCategory bllCategory)
        {
            return new CategoryViewModel
            {
                Id = bllCategory.Id,
                Name = bllCategory.Name, 
                LotCount = bllCategory.LotCount
            };
        }

        public static ShortCategoryViewModel ToShortCategoryViewModel(this BllCategory bllCategory)
        {
            return new ShortCategoryViewModel
            {
                Id = bllCategory.Id,
                Name = bllCategory.Name
            };
        }

        public static BllCategory ToBllCategory(this ShortCategoryViewModel category)
        {
            return new BllCategory
            {
                Name = category.Name
            };
        }

        public static CategoryPageViewModel ToCategoryPageViewModel(this IEnumerable<BllCategory> categories, int page)
        {
            int pageSize = 10;
            return new CategoryPageViewModel
            {
                PageInfo = new PageInfo
                {
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalItems = categories.Count()
                },
                Categories = categories.Skip((page - 1) * pageSize).Take(pageSize).Select(category => category.ToShortCategoryViewModel()).ToList()
            };
        }
    }
}