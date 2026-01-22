using BenhVienS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BenhVienS.MapperSql
{
    internal static class ExaminationFormMapper
    {
        // Map 1 record -> ExaminationForm
        public static ExaminationForm ExaminationFormToMap(SqlDataReader reader)
        {
            return new ExaminationForm
            {
                Id = Convert.ToInt32(reader["MaPhieuKham"]),
                AppointmentId = Convert.ToInt32(reader["MaLichHen"]),
                DoctorId = Convert.ToInt32(reader["MaBacSi"]),
                ExaminationDate = Convert.ToDateTime(reader["NgayKham"]),

                Symptoms = reader["TrieuChung"]?.ToString(),
                Height = reader["ChieuCao"] != DBNull.Value ? Convert.ToDecimal(reader["ChieuCao"]) : 0,
                Weight = reader["CanNang"] != DBNull.Value ? Convert.ToDecimal(reader["CanNang"]) : 0,
                Temperature = reader["NhietDo"] != DBNull.Value ? Convert.ToDecimal(reader["NhietDo"]) : 0,

                BloodPressure = reader["HuyetAp"]?.ToString(),
                HeartRate = reader["Mach"] != DBNull.Value ? Convert.ToInt32(reader["Mach"]) : 0,
                RespiratoryRate = reader["NhipTho"] != DBNull.Value ? Convert.ToInt32(reader["NhipTho"]) : 0,

                PreliminaryDiagnosis = reader["ChanDoanSoBo"]?.ToString(),
                Status = reader["TrangThai"]?.ToString()
            };
        }

        // Map nhiều record -> List<ExaminationForm>
        public static List<ExaminationForm> ExaminationListFormToMap(SqlDataReader reader)
        {
            var list = new List<ExaminationForm>();

            while (reader.Read())
            {
                list.Add(ExaminationFormToMap(reader));
            }

            return list;
        }
    }
}