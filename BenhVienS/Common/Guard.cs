using BenhVienS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenhVienS.Common
{
    public class Guard
    {
        private readonly AuthContext _auth;
        public Guard(AuthContext auth)
        {
            _auth = auth;
        }
        public void Require(params RoleEnum[] roles)
        {
            if (!_auth.IsAuthenticated)
                throw new UnauthorizedAccessException("Chưa đăng nhập");

            if (!_auth.Require(roles))
                throw new UnauthorizedAccessException("Không có quyền");
        }
    }
}
