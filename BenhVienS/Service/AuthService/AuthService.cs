using BenhVienS.Common;
using BenhVienS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenhVienS.Service.AuthService
{
    public class AuthService
    {

        public bool Login(string username, string password, bool rememberMe = false)
        {
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT MaNguoiDung, TenDangNhap, MaVaiTro
                    FROM NguoiDung
                    WHERE TenDangNhap = @u AND MatKhauHash = @p AND TrangThai = 1";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!",
                                      "Đăng nhập thất bại",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                        return false;
                    }

                    UserSession user = new UserSession
                    {
                        UserId = (int)reader["MaNguoiDung"],
                        Username = reader["TenDangNhap"].ToString(),
                        Role = (int)reader["MaVaiTro"],
                        ExpiredAt = DateTime.Now.AddDays(7)
                    };

                    AppContextCustom.Instance.Auth.Set(user);

                    return true;
                }
            }
        }

    }
}
