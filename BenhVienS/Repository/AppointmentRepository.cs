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
        public static List<Appointment> AppointmentListByDoctor(int id)
        {
            string sql = @"
                            SELECT *
                            FROM LichHen
                            WHERE MaBacSi = @DoctorId
                            AND CAST(NgayHen AS DATE) = CAST(GETDATE() AS DATE)
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DoctorId", id);
                SqlDataReader result = cmd.ExecuteReader();
                return AppointmentMapper.AppointmentListToMap(result);
            }
        }
    }
}
