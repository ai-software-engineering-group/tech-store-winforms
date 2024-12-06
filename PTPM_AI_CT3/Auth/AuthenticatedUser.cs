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

        public static void SetAuthenticatedUser(User pUser, List<Function> pAuthorizedFuntions)
        {
            User = pUser;
            AuthorizedFuntions = pAuthorizedFuntions;
        }

        public static void ClearAuthenticatedUser()
        {
            User = null;
            AuthorizedFuntions = new List<Function>();
        }
    }
}
