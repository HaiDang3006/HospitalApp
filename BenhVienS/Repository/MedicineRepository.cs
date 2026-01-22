using BenhVienS.MapperSql;
using BenhVienS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Repository
{
    static class MedicineRepository
    {
        public static List<Medicine> findAll()
        {
            List<Medicine> medicineList = new List<Medicine>();
            string sql = @"
                            SELECT * FROM Thuoc
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            medicineList = MedicineMapper.MapToMedicineList(reader);
                        }
                    }
                }
            }
            return medicineList;
        }

        public static List<Medicine> searchMedicine( string key)
        {
            List<Medicine> medicineList = new List<Medicine>();
            string sql = @"
                            SELECT *
                            FROM Thuoc
                            WHERE name LIKE '%' + @key + '%';
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@key", key);
                using (SqlDataReader reader = cmd.ExecuteReader())
                    if (reader.Read())
                {
                    medicineList = MedicineMapper.MapToMedicineList(reader);
                }
            }
            return medicineList;
        }
    }
}
