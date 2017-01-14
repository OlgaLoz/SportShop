using DAL.Interfaces.Entities;
using ORM;

namespace DAL.Mappers
{
    public static class RoleMappers
    {
        public static Role ToOrmRole(this DalRole dalRole)
        {
            if (dalRole == null) return null;

            return new Role
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static DalRole ToDalRole(this Role role)
        {
            if (role == null) return null;

            return new DalRole
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}