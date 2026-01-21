using BenhVienS.Enums;
using BenhVienS.Models;
using BenhVienS.Service.UserService;
using System;
using System.Linq;
using System.Windows.Forms;

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

        public User getInfoUserLogin(UserSession session)
        {
            if (session != null && session.ExpiredAt > DateTime.Now)
            {
                UserService userService = new UserService();
                return userService.UserById(session.UserId);
            } else
            {
                MessageBox.Show("Phiên bản đăng nhập không hợp lệ");
                Application.Restart();
                return null;
            }
        }

        public bool Require(params RoleEnum[] roles)
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
