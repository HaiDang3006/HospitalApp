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
    public partial class ucDanhMucThuoc : UserControl
    {
        public ucDanhMucThuoc()
        {
            InitializeComponent();
            LoadData();
        }
            // Thay đổi Server Name cho đúng với máy của bạn
            string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENS;Trusted_Connection=True;TrustServerCertificate=True;";

            // Hàm tải dữ liệu lên DataGridView
            public void LoadData()
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // Truy vấn đúng các cột tương ứng với Winform
                        string query = "SELECT MaThuoc, TenThuoc, HoatChat, DonViTinh, LoaiThuoc, GiaBan FROM Thuoc WHERE TrangThai = N'ConHang'";

                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Giả sử DataGridView của bạn tên là dgvThuoc
                        dgvDonThuoc.DataSource = dt;

                    // Đặt lại tên cột hiển thị cho đẹp
                        dgvDonThuoc.Columns["MaThuoc"].HeaderText = "Mã Thuốc";
                        dgvDonThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                        dgvDonThuoc.Columns["HoatChat"].HeaderText = "Hoạt Chất";
                        dgvDonThuoc.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
                        dgvDonThuoc.Columns["LoaiThuoc"].HeaderText = "Loại Thuốc";
                        dgvDonThuoc.Columns["GiaBan"].HeaderText = "Giá Bán";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
    }
}

