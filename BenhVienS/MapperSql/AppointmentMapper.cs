using BenhVienS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BenhVienS.Service
{
    public static class AppointmentMapper
    {
        // map dìa một model 
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
                ReceptionId = Convert.ToInt32(reader["MaLeTen"]),
                Note = reader["GhiChu"]?.ToString(),
                CreateDate = Convert.ToDateTime(reader["NgayTao"]),
            };
            appointment.SetOrderType(reader["HinhThucDat"].ToString());
            appointment.SetStatus(reader["TrangThai"].ToString());
            return appointment;
        }
        // map dìa một danh sách model 
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
