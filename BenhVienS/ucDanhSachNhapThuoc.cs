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

                    dgvDonThuoc.DataSource = dt;

                    // Gán tiêu đề cột
                    dgvDonThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                    dgvDonThuoc.Columns["SoLuongTon"].HeaderText = "Số Lượng";
                    dgvDonThuoc.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                    dgvDonThuoc.Columns["TongTien"].HeaderText = "Thành Tiền";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối SQL: " + ex.Message);
            }
        }
    }
}
        
  
