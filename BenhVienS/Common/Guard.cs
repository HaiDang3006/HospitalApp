using BenhVienS.Enums;
using System;


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

             if (_auth.CurrentUser.ExpiredAt < DateTime.Now)
                throw new UnauthorizedAccessException("Phiên bản đăng nhập hết hạn");
        }
    }
}
