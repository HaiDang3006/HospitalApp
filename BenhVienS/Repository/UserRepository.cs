using BenhVienS.MapperSql;
using BenhVienS.Models;
using BenhVienS.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Repository
{
    internal class UserRepository
    {
        public static User UserById(int id)
        {
            string sql = @"
                            SELECT *
                            FROM NguoiDung
                            WHERE MaNguoiDung = @id
                            AND TrangThai = 1
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return UserMapper.UserToMap(reader);
                        }
                    }
                }
            }
            return null;
        }
        public static User UserByExaminaId(int ExaminaId)
        { 

            User user = new User();
            string sql = @"
                            SELECT 
                               ng.*
                            FROM NguoiDung ng
                            JOIN BenhNhan bn on ng.MaNguoiDung = bn.MaNguoiDung
                            JOIN LichHen lh ON bn.MaBenhNhan = lh.MaBenhNhan
                            JOIN PhieuKham pk ON lh.MaLichHen = pk.MaLichHen
                            WHERE pk.MaPhieuKham = @ExaminaId
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ExaminaId", ExaminaId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = UserMapper.UserToMap(reader);
                        }
                    }
                }
            }
            return user;
        }
    }
}
