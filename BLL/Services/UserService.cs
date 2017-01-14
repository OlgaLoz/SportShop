using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interfaces.Interfaces.UnitOfWork;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(BllUser user)
        {
            unitOfWork.Users.Create(user.ToDalUser());
            unitOfWork.Commit();
        }

        public BllUser GetById(int id)
        {
            return unitOfWork.Users.GetById(id).ToBllUser();
        }

        public IEnumerable<BllUser> GetAll()
        {
            return unitOfWork.Users.GetAll()
                .Select(user => user.ToBllUser())
                .ToList();
        }

        public BllUser GetByLogin(string login)
        {
            return unitOfWork.Users
                .GetByLogin(login)
                ?.ToBllUser();
        }

        public void Delete(int id)
        {
            var lots = unitOfWork.Lots.GetUserLots(id);
            var bets = unitOfWork.Bets.GetByUserId(id);

            foreach (var lot in lots)
            {
                unitOfWork.Lots.Delete(lot.Id);
            }

            foreach (var bet in bets)
            {
                unitOfWork.Bets.Delete(bet.Id);
            }

            unitOfWork.Users.Delete(id);
            unitOfWork.Commit();
        }

        public void ChangePassword(int id, string password)
        {
            var user = unitOfWork.Users.GetById(id);
            user.Password = password;
            unitOfWork.Users.Update(user);
            unitOfWork.Commit();
        }

        public void ChangeLogin(int id, string login)
        {
            var user = unitOfWork.Users.GetById(id);
            user.Login = login;
            unitOfWork.Users.Update(user);
            unitOfWork.Commit();
        }

        public int GetCount()
        {
            return unitOfWork.Users.GetCount();
        }
    }
}