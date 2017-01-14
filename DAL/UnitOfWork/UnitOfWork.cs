using System.Data.Entity;
using DAL.Interfaces.Interfaces.Repositories;
using DAL.Interfaces.Interfaces.UnitOfWork;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private LotRepository lotRepository;
        private BetRepository betRepository;
        private CategoryRepository categoryRepository;

        public IUserRepository Users => userRepository ?? (userRepository = new UserRepository(context));

        public IRoleRepository Roles => roleRepository ?? (roleRepository = new RoleRepository(context));

        public ILotRepository Lots => lotRepository ?? (lotRepository = new LotRepository(context));

        public IBetRepository Bets => betRepository ?? (betRepository = new BetRepository(context));

        public ICategoryRepository Categories => categoryRepository ?? (categoryRepository = new CategoryRepository(context));

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context?.SaveChanges();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}