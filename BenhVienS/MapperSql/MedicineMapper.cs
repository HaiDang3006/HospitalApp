using BenhVienS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BenhVienS.MapperSql
{
    internal static class MedicineMapper
    {
        // Map 1 record -> Medicine
        public static Medicine MapToMedicine(SqlDataReader reader)
        {
            return new Medicine
            {
                Id = Convert.ToInt32(reader["MaThuoc"]),
                Name = reader["TenThuoc"]?.ToString(),
                ActiveIngredient = reader["HoatChat"]?.ToString(),
                Dosage = reader["HamLuong"]?.ToString(),
                Unit = reader["DonViTinh"]?.ToString(),
                Usage = reader["CachDung"]?.ToString(),
                MedicineType = reader["LoaiThuoc"]?.ToString(),
                Manufacturer = reader["NhaSanXuat"]?.ToString(),
                CountryOfOrigin = reader["NuocSanXuat"]?.ToString(),

                ImportPrice = reader["GiaNhap"] != DBNull.Value
                                ? Convert.ToDecimal(reader["GiaNhap"])
                                : 0,

                SalePrice = reader["GiaBan"] != DBNull.Value
                                ? Convert.ToDecimal(reader["GiaBan"])
                                : 0,

                IsCoveredByInsurance = reader["ApDungBHYT"] != DBNull.Value
                                        && Convert.ToBoolean(reader["ApDungBHYT"]),

                ExpiryDate = reader["HanSuDung"] != DBNull.Value
                                ? Convert.ToDateTime(reader["HanSuDung"])
                                : DateTime.MinValue,

                Status = reader["TrangThai"]?.ToString()
            };
        }

        // Map nhiều record -> List<Medicine>
        public static List<Medicine> MapToMedicineList(SqlDataReader reader)
        {
            var list = new List<Medicine>();

            while (reader.Read())
            {
                list.Add(MapToMedicine(reader));
            }

            return list;
        }
    }
}
