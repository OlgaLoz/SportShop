using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interfaces.Interfaces.UnitOfWork;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<BllCategory> GetAll()
        {
            return unitOfWork.Categories.GetAll()
                .Select(c => c.ToBllCategory()).ToList();
        }

        public void Create(BllCategory entity)
        {
            unitOfWork.Categories.Create(entity.ToDalCategory());
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            unitOfWork.Categories.Delete(id);
            unitOfWork.Commit();
        }

        public BllCategory GetById(int id)
        {
            return unitOfWork.Categories.GetById(id).ToBllCategory();
        }

        public int GetLotCount(int categoryId = 0, int excludeUserId = 0)
        {
            return unitOfWork.Categories.GetLotCount(categoryId, excludeUserId);
        }
    }
}