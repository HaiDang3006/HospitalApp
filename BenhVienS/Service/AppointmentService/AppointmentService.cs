using BenhVienS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Service.AppointmentService
{
    internal class AppointmentService
    {
        // bên đây cũng vậy đè ctrl để coi hàm tiếp theo được gọi 
        public int CountAppointmentTodayByDoctor(int id)
        {
            try
            {
                return AppointmentRepository.CountTodayByDoctor(id);
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
    }
}
