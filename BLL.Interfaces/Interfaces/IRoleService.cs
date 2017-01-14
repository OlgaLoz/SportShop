using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<BllRole> GetAll();
        BllRole GetById(int? id);
        IEnumerable<BllRole> GetUserRoles(BllUser user);
        IEnumerable<BllUser> GetByName(string name);
        void AddUserRole(BllUser user, BllRole role);
        void DeleteUserRole(BllUser user, BllRole role);
    }
}