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
                Id = Convert.ToInt32(reader["Id"]),
                PatientId = Convert.ToInt32(reader["PatientId"]),
                DoctorId = Convert.ToInt32(reader["DoctorId"]),
                WorkScheduleId = Convert.ToInt32(reader["WorkScheduleId"]),
                DateAppointment = Convert.ToDateTime(reader["DateAppointment"]),
                Reasion = reader["Reasion"]?.ToString(),
                ReceptionId = Convert.ToInt32(reader["ReceptionId"]),
                Note = reader["Note"]?.ToString(),
                CreateDate = Convert.ToDateTime(reader["CreateDate"]),
            };
            appointment.SetOrderType(reader["OrderType"].ToString());
            appointment.SetStatus(reader["Status"].ToString());
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
