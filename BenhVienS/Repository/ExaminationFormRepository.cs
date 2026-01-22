using BenhVienS.MapperSql;
using BenhVienS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Repository
{
    internal class ExaminationFormRepository
    {
        public static ExaminationForm ExaminationFormByAppointmentId(int appointmentId)
        {
            string sql = @"
                            SELECT *
                            FROM PhieuKham
                            WHERE MaLichHen = @appointmentId
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@appointmentId", appointmentId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ExaminationFormMapper.ExaminationFormToMap(reader);
                        }
                    }
                }
            }
            return null;
        }
    }
}
