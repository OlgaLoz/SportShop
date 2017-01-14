using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using MVC.ViewModels.Pagging;
using MVC.ViewModels.User;

namespace MVC.Infrastructure.Mappers
{
    public static class UserMappers
    {
        public static UserViewModel ToMvcUser(this BllUser user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Login = user.Login,
                UserRoles = user.Roles
            };
        }

        public static ProfileEditViewModel ToProfileEditViewModel(this BllUser user)
        {
            return new ProfileEditViewModel
            {
                Id = user.Id,
                Login = user.Login    
            };
        }

        public static UserPageViewModel ToUserPageViewModel(this IEnumerable<BllUser> users, int page)
        {
            int pageSize = 10;
            return new UserPageViewModel
            {
                PageInfo = new PageInfo
                {
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalItems = users.Count()
                },
                Users = users.Skip((page - 1) * pageSize).Take(pageSize).Select(user => user.ToMvcUser()).ToList()
            };
        }
    }
}