using System.Collections.Generic;
using DAL.Interfaces.Entities;

namespace DAL.Interfaces.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByLogin(string email);
        int GetCount();
    }
}