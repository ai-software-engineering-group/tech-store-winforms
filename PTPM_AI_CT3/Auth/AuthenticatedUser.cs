 using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPM_AI_CT3.Auth
{
    public static class AuthenticatedUser
    {
        public static User User;
        public static List<Function> AuthorizedFuntions = new List<Function>();
        public static Employee Employee;
        public static bool HasAllPermissions;

        public static bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public static void SetAuthenticatedUser(User pUser)
        {
            User = pUser;
            Employee = pUser.Employee;
            HasAllPermissions = pUser.UserGroup?.HasAllPermissions == true;
            AuthorizedFuntions = pUser.UserGroup?.FunctionAuthorizations
                .Select(f => f.Function).ToList();
        }

        public static void ClearAuthenticatedUser()
        {
            User = null;
            Employee = null;
            HasAllPermissions = false;
            AuthorizedFuntions = new List<Function>();
        }
    }
}
