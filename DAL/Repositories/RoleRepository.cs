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
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalRole> GetAll()
        {
            var roles = context.Set<Role>().ToList();
            return roles.Select(role => role.ToDalRole()).ToList();
        }

        public DalRole GetById(int id)
        {
            return context.Set<Role>()
                .Find(id)
                ?.ToDalRole();
        }

        public IEnumerable<DalRole> GetUserRoles(DalUser user)
        {
            var userEntity = context.Set<User>().Find(user.Id);
            return userEntity.Roles.Select(role => role.ToDalRole());
        }

        public void AddUserRole(DalUser user, DalRole role)
        {
            var userEntity = context.Set<User>().Find(user.Id);
            var roleEntity = context.Set<Role>().Find(role.Id);
            userEntity.Roles.Add(roleEntity);
        }

        public void DeleteUserRole(DalUser user, DalRole role)
        {
            var userEntity = context.Set<User>().Find(user.Id);
            var roleEntity = context.Set<Role>().Find(role.Id);
            userEntity.Roles.Remove(roleEntity);
        }

        public IEnumerable<DalUser> GetByName(string name)
        {
            return context.Set<User>().Where(user => user.Login.Contains(name.Trim())).ToDalUsers();
        }

        public void Create(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole entity)
        {
            throw new NotImplementedException();
        }
    }
}