using BenhVienS.Models;
using BenhVienS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BenhVienS.Service.AppointmentService
{
    internal class AppointmentService
    {
        public int CountAppointmentTodayByStatusAndDoctor(int id, string status)
        {
            try
            {
                return AppointmentRepository.CountTodayByStatusDoctor(id, status);
            }
            catch (SqlException ex)
            {
                return 0;
                throw new Exception("Lỗi khi lấy số lượng lịch hẹn hôm nay của bác sĩ", ex);
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }
        }

        public List<Appointment> AppointmentTodayByStatusAndDoctor(int id, string status)
        {
            try
            {
                return AppointmentRepository.AppointmentTodayByStatusDoctor(id, status);
            }
            catch (SqlException ex)
            {
                return new List<Appointment>();
                throw new Exception("Lỗi khi lấy số lượng lịch hẹn hôm nay của bác sĩ", ex);
            }
            catch (Exception ex)
            {
                return new List<Appointment>();
                throw;
            }
        }
    }
}
