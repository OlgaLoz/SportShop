using System;
using DAL.Interfaces.Interfaces.Repositories;

namespace DAL.Interfaces.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        ILotRepository Lots { get; }
        IBetRepository Bets { get; }
        ICategoryRepository Categories { get; }

        void Commit();
    }
}