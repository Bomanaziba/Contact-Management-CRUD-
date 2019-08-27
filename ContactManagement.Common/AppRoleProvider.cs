using ContactManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace ContactManagement.Common
{
    public class AppRoleProvider : RoleProvider
    {

        public override string[] GetAllRoles()
        {
            using (var userContext = new EFDbContext())
            {
                return userContext.Roles.Select(r => r.Name).ToArray();
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var userContext = new EFDbContext())
            {
                var user = userContext.Users.SingleOrDefault(u => u.UserName == username);
                var userRoles = userContext.Roles.Select(r => r.Name);

                if (user == null)
                    return new string[] { };
                return user.Roles == null ? new string[] { } :
                    userRoles.ToArray();
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (var userContext = new EFDbContext())
            {
                var user = userContext.Users.SingleOrDefault(u => u.UserName == username);
                var userRoles = userContext.Roles.Select(r => r.Name);

                if (user == null)
                    return false;
                return user.Roles != null &&
                    userRoles.Any(r => r == roleName);
            }
        }



        //Abstract Methods not implemented from the RoleProvider class
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
