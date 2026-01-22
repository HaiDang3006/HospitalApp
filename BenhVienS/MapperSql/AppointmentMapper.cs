using BenhVienS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BenhVienS.Service
{
    public static class AppointmentMapper
    {
        public static Appointment AppointmentToMap(SqlDataReader reader)
        {
            var appointment = new Appointment
            {
                Id = Convert.ToInt32(reader["MaLichHen"]),
                PatientId = Convert.ToInt32(reader["MaBenhNhan"]),
                DoctorId = Convert.ToInt32(reader["MaBacSi"]),
                WorkScheduleId = Convert.ToInt32(reader["MaLichLamViec"]),

                DateAppointment = Convert.ToDateTime(reader["NgayHen"]),
                Reasion = reader["LyDoKham"]?.ToString(),

                ReceptionId = reader["MaLeTan"] != DBNull.Value
                                ? Convert.ToInt32(reader["MaLeTan"])
                                : 0,

                Note = reader["GhiChu"]?.ToString(),

                CreateDate = reader["NgayTao"] != DBNull.Value
                                ? Convert.ToDateTime(reader["NgayTao"])
                                : DateTime.Now
            };

            appointment.SetOrderType(reader["HinhThucDat"]?.ToString());
            appointment.SetStatus(reader["TrangThai"]?.ToString());

            return appointment;
        }

        public static List<Appointment> AppointmentListToMap(SqlDataReader reader)
        {
            var list = new List<Appointment>();

            while (reader.Read())
            {
                list.Add(AppointmentToMap(reader));
            }

            return list;
        }
    }
}
