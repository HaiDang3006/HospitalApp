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
    static class AppointmentRepository
    {
        // xem cách viết truy vấn 
        public static int CountTodayByStatusDoctor(int id, string status)
        {
            string sql = @"
                            SELECT COUNT(*)
                            FROM LichHen
                            WHERE MaBacSi = @DoctorId
                            AND TrangThai = @Status
                            AND CAST(NgayHen AS DATE) = CAST(GETDATE() AS DATE)
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DoctorId", id);
                cmd.Parameters.AddWithValue("@Status", status);
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
           
        }
        public static List<Appointment> AppointmentTodayByStatusDoctor(int id, string status)
        {
            string sql = @"
                            SELECT *
                            FROM LichHen
                            WHERE MaBacSi = @DoctorId
                            AND TrangThai = @Status
                            AND CAST(NgayHen AS DATE) = CAST(GETDATE() AS DATE)
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DoctorId", id);
                cmd.Parameters.AddWithValue("@Status", status);
                SqlDataReader result = cmd.ExecuteReader();
                return AppointmentMapper.AppointmentListToMap(result);
            }

        }

        public static Appointment AppointmentById(int id)
        {
            string sql = @"
                            SELECT *
                            FROM LichHen
                            WHERE MaLichHen = @id
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader result = cmd.ExecuteReader();
                return AppointmentMapper.AppointmentToMap(result);
            }

        }
    }
}
