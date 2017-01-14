using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using DAL.Interfaces.Entities;

namespace BLL.Mappers
{
    public static class UserMappers
    {
        public static DalUser ToDalUser(this BllUser userEntity)
        {
            if (userEntity == null) return null;

            return new DalUser()
            {
                Id = userEntity.Id,
                Login = userEntity.Login,
                Password = userEntity.Password
            };
        }

        public static BllUser ToBllUser(this DalUser dalUser)
        {
            if (dalUser == null) return null;

            return new BllUser
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                Password = dalUser.Password,
                Roles = dalUser.Roles
            };
        }

        public static IEnumerable<BllUser> ToBllUsers(this IEnumerable<DalUser> users)
        {
            return users?.Select(lot => lot.ToBllUser()).ToList();
        }
    }
}