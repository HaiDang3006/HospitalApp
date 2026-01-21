using BenhVienS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BenhVienS.Service
{
    public static class DoctorMapper
    {
        // Map một Doctor
        public static Doctor DoctorToMap(SqlDataReader reader)
        {
            var doctor = new Doctor
            {
                Id = Convert.ToInt32(reader["MaBacSi"]),
                UserId = Convert.ToInt32(reader["MaNguoiDung"]),
                DepartmentId = Convert.ToInt32(reader["MaChuyenKhoa"]),
                Degree = reader["BangCap"]?.ToString(),
                Specialty = reader["ChuyenMon"]?.ToString(),
                YearsOfExperience = Convert.ToInt32(reader["NamKinhNghiem"]),
                Rating = reader["DanhGia"] == DBNull.Value
                            ? (byte)0
                            : Convert.ToByte(reader["DanhGia"]),
                Status = Convert.ToInt32(reader["TrangThai"])
            };

            return doctor;
        }

        // Map danh sách Doctor
        public static List<Doctor> DoctorListToMap(SqlDataReader reader)
        {
            var list = new List<Doctor>();
            while (reader.Read())
            {
                list.Add(DoctorToMap(reader));
            }
            return list;
        }
    }
}
