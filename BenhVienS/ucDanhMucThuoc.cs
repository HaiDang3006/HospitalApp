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
                    string query = "SELECT MaThuoc, TenThuoc, HoatChat, DonViTinh, LoaiThuoc, GiaBan FROM Thuoc WHERE TrangThai = N'ConHang'";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDanhMucThuoc.DataSource = dt;

                    // --- THÊM 2 DÒNG NÀY ĐỂ NHẬP LIỆU ĐƯỢC ---
                    dgvDanhMucThuoc.AllowUserToAddRows = true;
                    dgvDanhMucThuoc.ReadOnly = false;
                    // ----------------------------------------

                    // Đặt tên Header an toàn
                    if (dgvDanhMucThuoc.Columns.Count > 0)
                    {
                        dgvDanhMucThuoc.Columns["MaThuoc"].HeaderText = "Mã Thuốc";
                        dgvDanhMucThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                        dgvDanhMucThuoc.Columns["HoatChat"].HeaderText = "Hoạt Chất";
                        dgvDanhMucThuoc.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
                        dgvDanhMucThuoc.Columns["LoaiThuoc"].HeaderText = "Loại Thuốc";
                        dgvDanhMucThuoc.Columns["GiaBan"].HeaderText = "Giá Bán";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dòng người dùng vừa nhập (dòng sát cuối)
                int index = dgvDanhMucThuoc.Rows.Count - 2;
                if (index < 0) return;
                DataGridViewRow row = dgvDanhMucThuoc.Rows[index];

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // KHÔNG liệt kê MaThuoc trong câu lệnh INSERT
                    string sql = @"INSERT INTO Thuoc (TenThuoc, HoatChat, DonViTinh, LoaiThuoc, GiaBan, TrangThai) 
                           VALUES (@ten, @hc, @dvt, @loai, @gia, N'ConHang')";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    // Bỏ cmd.Parameters cho MaThuoc
                    cmd.Parameters.AddWithValue("@ten", row.Cells["TenThuoc"].Value ?? "");
                    cmd.Parameters.AddWithValue("@hc", row.Cells["HoatChat"].Value ?? "");
                    cmd.Parameters.AddWithValue("@dvt", row.Cells["DonViTinh"].Value ?? "");
                    cmd.Parameters.AddWithValue("@loai", row.Cells["LoaiThuoc"].Value ?? "");
                    cmd.Parameters.AddWithValue("@gia", row.Cells["GiaBan"].Value ?? 0);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công! Mã thuốc sẽ tự động được cấp.");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
        private void btSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhMucThuoc.CurrentRow == null || dgvDanhMucThuoc.CurrentRow.IsNewRow) return;

            try
            {
                DataGridViewRow row = dgvDanhMucThuoc.CurrentRow;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE Thuoc 
                           SET TenThuoc=@ten, HoatChat=@hc, DonViTinh=@dvt, LoaiThuoc=@loai, GiaBan=@gia 
                           WHERE MaThuoc=@ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", row.Cells["MaThuoc"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ten", row.Cells["TenThuoc"].Value ?? "");
                    cmd.Parameters.AddWithValue("@hc", row.Cells["HoatChat"].Value ?? "");
                    cmd.Parameters.AddWithValue("@dvt", row.Cells["DonViTinh"].Value ?? "");
                    cmd.Parameters.AddWithValue("@loai", row.Cells["LoaiThuoc"].Value ?? "");
                    cmd.Parameters.AddWithValue("@gia", row.Cells["GiaBan"].Value ?? 0);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã cập nhật thay đổi!");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi sửa: " + ex.Message); }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhMucThuoc.CurrentRow == null || dgvDanhMucThuoc.CurrentRow.IsNewRow) return;

            string ma = dgvDanhMucThuoc.CurrentRow.Cells["MaThuoc"].Value.ToString();
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa thuốc {ma}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Thuoc WHERE MaThuoc=@ma", conn);
                        cmd.Parameters.AddWithValue("@ma", ma);
                        cmd.ExecuteNonQuery();
                        LoadData();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        private void btTimkiem_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Tìm theo mã hoặc tên thuốc
                    string sql = @"SELECT MaThuoc, TenThuoc, HoatChat, DonViTinh, LoaiThuoc, GiaBan 
                           FROM Thuoc 
                           WHERE (MaThuoc LIKE @k OR TenThuoc LIKE @k) AND TrangThai = N'ConHang'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@k", "%" + txtTimKiem.Text.Trim() + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDanhMucThuoc.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
        }
    }
}

