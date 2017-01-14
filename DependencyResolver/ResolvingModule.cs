using System.Data.Entity;
using BLL.Interfaces.Interfaces;
using BLL.Services;
using DAL.Interfaces.Interfaces.Repositories;
using DAL.Interfaces.Interfaces.UnitOfWork;
using DAL.Repositories;
using DAL.UnitOfWork;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class ResolvingModule
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();
           
            #region Services
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ILotService>().To<LotService>();
            kernel.Bind<IBetService>().To<BetService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            #endregion

            #region Repositories
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<ILotRepository>().To<LotRepository>();
            kernel.Bind<IBetRepository>().To<BetRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            #endregion
        }
    }
}
