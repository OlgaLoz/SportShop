using System.Collections.Generic;
using DAL.Interfaces.Entities;

namespace DAL.Interfaces.Interfaces.Repositories
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        IEnumerable<DalRole> GetUserRoles(DalUser user);
        void AddUserRole(DalUser user, DalRole role);
        void DeleteUserRole(DalUser user, DalRole role);
        IEnumerable<DalUser> GetByName(string name);
    }
}