using BenhVienS.Models;
using BenhVienS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Service.UserService
{
    internal class UserService
    {
        public User UserById(int id)
        {
            try
            {
                return UserRepository.UserById(id);
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
