using BLL.Interfaces.Entities;
using DAL.Interfaces.Entities;

namespace BLL.Mappers
{
    public static class RoleMappers
    {
        public static BllRole ToBllRole(this DalRole dalRole)
        {
            if (dalRole == null) return null;

            return new BllRole
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static DalRole ToDalRole(this BllRole bllRole)
        {
            if (bllRole == null) return null;

            return new DalRole
            {
                Id = bllRole.Id,
                Name = bllRole.Name
            };
        }
    }
}