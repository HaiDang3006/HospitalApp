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
    internal class DoctorRepository
    {
        public static Doctor DoctorById(int id)
        {
            string sql = @"
                            SELECT *
                            FROM BacSi
                            WHERE MaBacSi = @DoctorId
                            AND TrangThai = 1
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DoctorId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return DoctorMapper.DoctorToMap(reader);
                        }
                    }
                }
            }
            return null; 
        }

        public static Doctor DoctorByUserId(int userId)
        {
            string sql = @"
                            SELECT *
                            FROM BacSi
                            WHERE MaNguoiDung = @userId
                            AND TrangThai = 1
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return DoctorMapper.DoctorToMap(reader);
                        }
                    }
                }
            }
            return null;
        }

    }
}
