using BenhVienS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BenhVienS.MapperSql
{
    internal static class ExaminationFormMapper
    {
        // Map về 1 model ExaminationForm
        public static ExaminationForm ExaminationFormToMap(SqlDataReader reader)
        {
            var examForm = new ExaminationForm
            {
                Id = Convert.ToInt32(reader["MaPhieuKham"]),
                AppointmentId = Convert.ToInt32(reader["MaLichHen"]),
                Diagnosis = reader["ChanDoan"]?.ToString(),
                Advice = reader["LoiKhuyen"]?.ToString(),
                ExamDate = Convert.ToDateTime(reader["NgayKham"])
            };

            return examForm;
        }

        // Map về danh sách ExaminationForm
        public static List<ExaminationForm> ExaminationFormListToMap(SqlDataReader reader)
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
