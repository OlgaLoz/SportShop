using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IUserService
    {
        void Create(BllUser user);
        BllUser GetById(int id);
        BllUser GetByLogin(string email);
        void Delete(int id);
        void ChangePassword(int id, string password);
        void ChangeLogin(int id, string login);

        IEnumerable<BllUser> GetAll();
        int GetCount();
    }
}