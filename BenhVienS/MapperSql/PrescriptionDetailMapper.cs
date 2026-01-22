using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hospital.MapperSql
{
    public static class PrescriptionDetailMapper
    {
        // Map a single PrescriptionDetail from SqlDataReader
        public static PrescriptionDetail MapPrescriptionDetail(SqlDataReader reader)
        {
            var prescriptionDetail = new PrescriptionDetail
            {
                PrescriptionDetailId = Convert.ToInt32(reader["MaChiTiet"]),
                PrescriptionId = Convert.ToInt32(reader["MaDonThuoc"]),
                MedicineId = Convert.ToInt32(reader["MaThuoc"]),
                Quantity = Convert.ToInt32(reader["SoLuong"]),
                UnitPrice = Convert.ToDecimal(reader["DonGia"]),
                UsageInstructions = reader["CachDung"]?.ToString(),
                Morning = reader["Sang"]?.ToString(),
                Noon = reader["Trua"]?.ToString(),
                Afternoon = reader["Chieu"]?.ToString(),
                Evening = reader["Toi"]?.ToString(),
                BeforeMeal = Convert.ToBoolean(reader["TruocAn"]),
                AfterMeal = Convert.ToBoolean(reader["SauAn"]),
                DaysOfUse = Convert.ToInt32(reader["SoNgayDung"]),
                TotalAmount = Convert.ToDecimal(reader["ThanhTien"])
            };

            return prescriptionDetail;
        }

        // Map a list of PrescriptionDetails from SqlDataReader
        public static List<PrescriptionDetail> MapPrescriptionDetailList(SqlDataReader reader)
        {
            var list = new List<PrescriptionDetail>();
            while (reader.Read())
            {
                list.Add(MapPrescriptionDetail(reader));
            }
            return list;
        }
    }
}
