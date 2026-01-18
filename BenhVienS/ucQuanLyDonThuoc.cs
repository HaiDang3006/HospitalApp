using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class ucQuanLyDonThuoc : UserControl
    {
        public ucQuanLyDonThuoc()
        {
            InitializeComponent();
            LoadData();
        }
        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENS;Trusted_Connection=True;TrustServerCertificate=True;";
        public void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Query lấy thông tin chi tiết kèm tên bệnh nhân để bảng "dễ xem" hơn
                    // Truy vấn lấy Đơn thuốc kèm tên Bệnh nhân và Bác sĩ
                    string query = @"SELECT dt.MaDonThuoc, 
                        bn.HoTen AS HoTenBN, 
                        dt.NgayKeDon, 
                        nd.HoTen AS TenBacSi,
                        dt.TrangThai
                 FROM DonThuoc dt
                 INNER JOIN PhieuKham pk ON dt.MaPhieuKham = pk.MaPhieuKham
                 INNER JOIN LichHen lh ON pk.MaLichHen = lh.MaLichHen
                 INNER JOIN BenhNhan bn ON lh.MaBenhNhan = bn.MaBenhNhan
                 INNER JOIN BacSi bs ON dt.MaBacSi = bs.MaBacSi
                 INNER JOIN NguoiDung nd ON bs.MaNguoiDung = nd.MaNguoiDung";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvQuanLyDonThuoc.DataSource = dt;

                    dgvQuanLyDonThuoc.Columns["MaDonThuoc"].HeaderText = "Mã Đơn";
                    dgvQuanLyDonThuoc.Columns["HoTenBN"].HeaderText = "Họ Tên BN";
                    dgvQuanLyDonThuoc.Columns["NgayKeDon"].HeaderText = "Ngày Kê Đơn";
                    dgvQuanLyDonThuoc.Columns["TenBacSi"].HeaderText = "Bác Sĩ";
                    dgvQuanLyDonThuoc.Columns["TrangThai"].HeaderText = "Trạng Thái";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}

