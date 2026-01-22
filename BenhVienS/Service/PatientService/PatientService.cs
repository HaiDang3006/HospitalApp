using BenhVienS.Models;
using BenhVienS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Service.PatientService
{
    internal class PatientService
    {
        public Patient PatientById(int id)
        {
            try
            {
                return PatientRepository.PatientById(id);
            }
            catch (SqlException ex)
            {
                return null;
                throw new Exception(" // log error", ex);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }  
    }
}
