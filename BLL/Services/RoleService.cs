using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interfaces.Interfaces.UnitOfWork;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<BllRole> GetAll()
        {
            return unitOfWork.Roles.GetAll()
                .Select(role => role.ToBllRole())
                .ToList();
        }

        public BllRole GetById(int? id)
        {
            if (id == null) return null;

            return unitOfWork.Roles
                .GetById(id.Value)
                .ToBllRole();
        }

        public IEnumerable<BllRole> GetUserRoles(BllUser user)
        {
            return unitOfWork.Roles
                .GetUserRoles(user.ToDalUser())
                .Select(u => u.ToBllRole())
                .ToList();
        }

        public IEnumerable<BllUser> GetByName(string name)
        {
            return unitOfWork.Roles.GetByName(name).ToBllUsers();
        }

        public void AddUserRole(BllUser user, BllRole role)
        {
            unitOfWork.Roles.AddUserRole(user.ToDalUser(), role.ToDalRole());
            unitOfWork.Commit();
        }

        public void DeleteUserRole(BllUser user, BllRole role)
        {
            unitOfWork.Roles.DeleteUserRole(user.ToDalUser(), role.ToDalRole());
            unitOfWork.Commit();
        }
    }
}