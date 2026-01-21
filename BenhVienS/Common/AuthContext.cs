using BenhVienS.Enums;
using BenhVienS.Models;
using System;
using System.Linq;

namespace BenhVienS.Common
{
    public class AuthContext
    {
        public UserSession CurrentUser { get; private set; }

        public bool IsAuthenticated => CurrentUser != null;

        public void Set(UserSession session)
        {
            CurrentUser = session;
            SessionManager.Save(session);
        }   

        public  void Clear()
        {
            CurrentUser = null;
            SessionManager.Clear();
        }

        public  bool Require(params RoleEnum[] roles)
        {
            if (CurrentUser == null)
                return false;

            if (!Enum.IsDefined(typeof(RoleEnum), CurrentUser.Role))
                return false;

            var userRole = (RoleEnum)CurrentUser.Role;
            return roles.Contains(userRole);
        }

    }
}
