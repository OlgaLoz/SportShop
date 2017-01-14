using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interfaces.Interfaces.Entity;

namespace DAL.Interfaces.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
    }
}