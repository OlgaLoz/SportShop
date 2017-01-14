using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.Entities;
using DAL.Interfaces.Interfaces.Repositories;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext context;

        public CategoryRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalCategory> GetAll()
        {
            return context.Set<Category>().AsEnumerable()
                .Select(c => c.ToDalCategory());
        }

        public DalCategory GetById(int id)
        {
            return context.Set<Category>().Find(id).ToDalCategory();
        }

        public void Create(DalCategory entity)
        {
             context.Set<Category>().Add(entity.ToOrmCategory());
        }

        public void Delete(int id)
        {
            var category = context.Set<Category>().Find(id);
            if (category == null) return;

            context.Set<Category>().Remove(category);
        }

        public void Update(DalCategory entity)
        {
            throw new NotImplementedException();
        }

        public int GetLotCount(int categoryId = 0, int excludeUserId = 0)
        {
            return context.Set<Lot>().Where(lot => lot.User.Id != excludeUserId)
                .Where(cid => cid.CategoryId == (categoryId == 0 ? cid.CategoryId : categoryId))
                .Count(lot => lot.Status);
        }
    }
}