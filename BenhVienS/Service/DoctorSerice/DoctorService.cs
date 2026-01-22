using BenhVienS.Models;
using BenhVienS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Service.DoctorSerice
{
    internal class DoctorService
    {
        public Doctor DoctorById(int id)
        {
            try
            {
                return DoctorRepository.DoctorById(id);
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
        public Doctor DoctorByUserId(int userId)
        {
            try
            {
                return DoctorRepository.DoctorByUserId(userId);
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
