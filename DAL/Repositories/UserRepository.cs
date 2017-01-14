using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.Entities;
using DAL.Interfaces.Interfaces.Repositories;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public void Update(DalUser user)
        {
            var entity = context.Set<User>().Find(user.Id);
            entity.Login = user.Login;
            entity.Password = user.Password;
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Create(DalUser user)
        {
            if(user.Id != 0) return;
            context.Set<User>().Add(user.ToOrmUser());
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().ToDalUsers();
        }

        public DalUser GetById(int id)
        {
            return context.Set<User>().Find(id).ToDalUser();
        }

        public DalUser GetByLogin(string login)
        {
            return context.Set<User>()
                     .FirstOrDefault(user => user.Login.Equals(login))
                     .ToDalUser();
        }

        public void Delete(int id)
        {
            User user = context.Set<User>().Find(id);
            if (user != null)
            {
                context.Set<User>().Remove(user);
            }
        }

        public int GetCount()
        {
            return context.Set<User>().Count();
        }
    }
}