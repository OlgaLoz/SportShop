using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces.Entities;
using MVC.ViewModels.Role;

namespace MVC.Infrastructure.Mappers
{
    public static class RoleMappers
    {
        public static RoleViewModel ToRoleViewModel(this BllRole role)
        {
            return new RoleViewModel
            {
                 Name = role.Name,
                 Id = role.Id
            };
        }

        public static UserRoleViewModel ToUserRoleViewModel(this IEnumerable<BllRole> roles, IEnumerable<BllRole> userRoles, int userId, string userName)
        {
            return new UserRoleViewModel
            {
                Roles = roles.Select(role => new SelectListItem
                {
                    Text = role.Name,
                    Value = role.Id.ToString()
                }),
                UserRoles = userRoles.Select(role => new SelectListItem
                {
                    Text = role.Name,
                    Value = role.Id.ToString()
                }),
                UserId = userId, 
                UserName = userName
            };
        }
    }
}