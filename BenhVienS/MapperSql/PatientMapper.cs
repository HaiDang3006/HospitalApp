using BenhVienS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BenhVienS.MapperSql
{
    public static class PatientMapper
    {
        // Map một Patient
        public static Patient PatientToMap(SqlDataReader reader)
        {
            var patient = new Patient
            {
                Id = Convert.ToInt32(reader["MaBenhNhan"]),
                UserId = Convert.ToInt32(reader["MaNguoiDung"]),
                IdentityNumber = reader["SoCCCD"]?.ToString(),
                BloodGroup = reader["NhomMau"]?.ToString(),
                Weight = reader["CanNang"] == DBNull.Value
                            ? 0
                            : Convert.ToDecimal(reader["CanNang"]),
                Height = reader["ChieuCao"] == DBNull.Value
                            ? 0
                            : Convert.ToDecimal(reader["ChieuCao"]),
                Job = reader["NgheNghiep"]?.ToString(),
                Status = Convert.ToBoolean(reader["TrangThai"]),
                RegisterDate = Convert.ToDateTime(reader["NgayDangKy"])
            };

            return patient;
        }

        // Map danh sách Patient
        public static List<Patient> PatientListToMap(SqlDataReader reader)
        {
            var list = new List<Patient>();
            while (reader.Read())
            {
                list.Add(PatientToMap(reader));
            }
            return list;
        }
    }
}
