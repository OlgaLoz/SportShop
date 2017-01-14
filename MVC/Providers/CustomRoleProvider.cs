using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;

namespace MVC.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public IUserService UserService
             => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));
        
        public override bool IsUserInRole(string email, string roleName)
        {
            BllUser user = UserService.GetAll().FirstOrDefault(u => u.Login == email);
            if (user == null) return false;
            IEnumerable<BllRole> userRoles = RoleService.GetUserRoles(user);
            return userRoles != null && userRoles.Any(role => role.Name == roleName);
        }

        public override string[] GetRolesForUser(string email)
        {
            BllUser user = UserService.GetAll().FirstOrDefault(u => u.Login == email);
            if (user == null) return new string[] { };
            IEnumerable<BllRole> userRoles = RoleService.GetUserRoles(user);
            return userRoles.Select(role => role.Name).ToArray();
         }

        #region Stubs
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
#endregion
    }
}