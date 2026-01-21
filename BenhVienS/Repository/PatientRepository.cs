using BenhVienS.MapperSql;
using BenhVienS.Models;
using BenhVienS.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Repository
{
    internal class PatientRepository
    {
        public static Patient PatientById(int id)
        {
            string sql = @"
                            SELECT *
                            FROM BenhNhan
                            WHERE MaBenhNhan = @id
                            AND TrangThai = 1
                        ";
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return PatientMapper.PatientToMap(reader);
                        }
                    }
                }
            }
            return null;
        }
    }
}
