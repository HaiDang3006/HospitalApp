using BenhVienS.Models;
using BenhVienS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Service.ExaminationFormService
{
    internal class ExaminationFormService
    {
        public ExaminationForm ExaminationFormByAppointmentId(int appointmentId)
        {
            try
            {
                return ExaminationFormRepository.ExaminationFormByAppointmentId(appointmentId);
            }
            catch (SqlException ex)
            {
                return null;
                throw new Exception("Lỗi khi lấy số lượng lịch hẹn hôm nay của bác sĩ", ex);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
    }
}
