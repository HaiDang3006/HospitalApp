using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Repository
{
    internal class PrescriptionRepository
    {
        public static int Insert(Prescription prescription)
        {
            int newId = -1;
            string sql = @"
                INSERT INTO [dbo].[DonThuoc] 
                (
                    MaPhieuKham, 
                    MaBacSi, 
                    LoiDan, 
                    TrangThai, 
                    NgayKeDon
                )
                OUTPUT INSERTED.MaDonThuoc
                VALUES 
                (
                    @MaPhieuKham, 
                    @MaBacSi, 
                    @LoiDan, 
                    @TrangThai, 
                    @NgayKeDon
                );
            ";

            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Thêm parameters (tránh SQL Injection)
                    cmd.Parameters.AddWithValue("@MaPhieuKham", prescription.ExaminationTicketId);
                    cmd.Parameters.AddWithValue("@MaBacSi", prescription.DoctorId);
                    cmd.Parameters.AddWithValue("@LoiDan", (object)prescription.DoctorNote ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TrangThai", prescription.Status ?? "ChuaLay"); // mặc định nếu null
                    cmd.Parameters.AddWithValue("@NgayKeDon", prescription.PrescriptionDate);

                    // Thực thi và lấy ID vừa insert
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        newId = Convert.ToInt32(result);
                    }
                }
            }

            return newId; // trả về MaDonThuoc mới tạo, hoặc -1 nếu thất bại
        }
    }
}
