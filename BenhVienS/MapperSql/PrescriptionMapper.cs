using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hospital.MapperSql
{
    public static class PrescriptionMapper
    {
        // Map a single Prescription
        public static Prescription MapPrescription(SqlDataReader reader)
        {
            var prescription = new Prescription
            {
                PrescriptionId = Convert.ToInt32(reader["MaDonThuoc"]),
                ExaminationTicketId = Convert.ToInt32(reader["MaPhieuKham"]),
                DoctorId = Convert.ToInt32(reader["MaBacSi"]),
                DoctorNote = reader["LoiDan"]?.ToString(),
                Status = reader["TrangThai"]?.ToString(),
                PrescriptionDate = Convert.ToDateTime(reader["NgayKeDon"])
            };

            return prescription;
        }

        // Map a list of Prescriptions
        public static List<Prescription> MapPrescriptionList(SqlDataReader reader)
        {
            var list = new List<Prescription>();
            while (reader.Read())
            {
                list.Add(MapPrescription(reader));
            }
            return list;
        }
    }
}
