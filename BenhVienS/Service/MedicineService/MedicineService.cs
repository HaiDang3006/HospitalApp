using BenhVienS.Models;
using BenhVienS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Service.MedicineService
{
    internal class MedicineService
    {
        public List<Medicine> getMedicineList()
        {
            try
            {
                return MedicineRepository.findAll();
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

        public List<Medicine> searchMedicineByName( string key)
        {
            try
            {
                return MedicineRepository.searchMedicine(key);
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
