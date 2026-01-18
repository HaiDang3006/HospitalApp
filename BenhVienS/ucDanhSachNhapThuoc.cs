using System;
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
    public partial class ucDanhSachNhapThuoc : UserControl
    {
        public ucDanhSachNhapThuoc()
        {
            InitializeComponent();
            LoadData();
        }
        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENS;Trusted_Connection=True;TrustServerCertificate=True;";

        // Hàm tải dữ liệu lên DataGridView
        public void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Truy vấn lấy thông tin nhập kho và tên thuốc tương ứng
                    string query = @"SELECT tk.MaTonKho, t.TenThuoc, tk.SoLuongTon, t.GiaNhap, 
                        (tk.SoLuongTon * t.GiaNhap) AS TongTien, 
                        tk.NgayNhap, tk.NgayHetHan
                 FROM TonKhoThuoc tk
                 INNER JOIN Thuoc t ON tk.MaThuoc = t.MaThuoc";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDanhSachNhapThuoc.DataSource = dt;

                    // Gán tiêu đề cột
                    dgvDanhSachNhapThuoc.Columns["MaTonKho"].HeaderText = "Mã Tồn Kho";
                    dgvDanhSachNhapThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                    dgvDanhSachNhapThuoc.Columns["SoLuongTon"].HeaderText = "Số Lượng";
                    dgvDanhSachNhapThuoc.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                    dgvDanhSachNhapThuoc.Columns["TongTien"].HeaderText = "Thành Tiền";
                    dgvDanhSachNhapThuoc.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                    dgvDanhSachNhapThuoc.Columns["NgayHetHan"].HeaderText = "Ngày Hết Hạn";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối SQL: " + ex.Message);
            }
        }
    }
}
        
  
