using BenhVienS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BenhVienS.MapperSql
{
    public static class UserMapper
    {
        public static User UserToMap(SqlDataReader reader)
        {
            var user = new User
            {
                UserId = Convert.ToInt32(reader["MaNguoiDung"]),
                Username = reader["TenDangNhap"]?.ToString(),
                PasswordHash = reader["MatKhauHash"]?.ToString(),
                FullName = reader["HoTen"]?.ToString(),
                Email = reader["Email"]?.ToString(),
                PhoneNumber = reader["SoDienThoai"]?.ToString(),
                Address = reader["DiaChi"]?.ToString(),
                DateOfBirth = Convert.ToDateTime(reader["NgaySinh"]),
                Gender = Convert.ToBoolean(reader["GioiTinh"]),
                RoleId = Convert.ToInt32(reader["MaVaiTro"]),
                Status = Convert.ToBoolean(reader["TrangThai"]),
                CreatedAt = Convert.ToDateTime(reader["NgayTao"]),
                UpdatedAt = Convert.ToDateTime(reader["NgayCapNhat"])
            };

            return user;
        }
        public static List<User> UserListToMap(SqlDataReader reader)
        {
            var list = new List<User>();
            while (reader.Read())
            {
                list.Add(UserToMap(reader));
            }
            return list;
        }
    }
}
