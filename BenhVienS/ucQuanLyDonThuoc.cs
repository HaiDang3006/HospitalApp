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
                    // Lấy thêm MaPhieuKham và MaBacSi (cột gốc) để dùng cho việc Thêm/Sửa
                    string query = @"SELECT dt.MaDonThuoc, bn.HoTen AS HoTenBN, dt.NgayKeDon, 
                                    nd.HoTen AS TenBacSi, dt.TrangThai,
                                    dt.MaPhieuKham, dt.MaBacSi
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

                    // Cấu hình để nhấp vào nhập liệu được
                    dgvQuanLyDonThuoc.AllowUserToAddRows = true;
                    dgvQuanLyDonThuoc.ReadOnly = false;

                    // Đặt tiêu đề an toàn (chỉ đổi tên nếu cột tồn tại)
                    Dictionary<string, string> mapping = new Dictionary<string, string> {
                { "MaDonThuoc", "Mã Đơn" }, { "HoTenBN", "Họ Tên BN" },
                { "NgayKeDon", "Ngày Kê Đơn" }, { "TenBacSi", "Bác Sĩ" }, { "TrangThai", "Trạng Thái" }
            };

                    foreach (var item in mapping)
                    {
                        if (dgvQuanLyDonThuoc.Columns.Contains(item.Key))
                            dgvQuanLyDonThuoc.Columns[item.Key].HeaderText = item.Value;
                    }

                    // Ẩn các cột ID gốc để tránh rối mắt, nhưng vẫn dùng để lưu dữ liệu
                    if (dgvQuanLyDonThuoc.Columns.Contains("MaPhieuKham")) dgvQuanLyDonThuoc.Columns["MaPhieuKham"].Visible = false;
                    if (dgvQuanLyDonThuoc.Columns.Contains("MaBacSi")) dgvQuanLyDonThuoc.Columns["MaBacSi"].Visible = false;
                    if (dgvQuanLyDonThuoc.Columns.Contains("MaDonThuoc")) dgvQuanLyDonThuoc.Columns["MaDonThuoc"].ReadOnly = true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dòng cuối cùng người dùng vừa gõ thông tin
                int index = dgvQuanLyDonThuoc.Rows.Count - 2;
                if (index < 0) return;
                DataGridViewRow row = dgvQuanLyDonThuoc.Rows[index];

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // KHÔNG chèn MaDonThuoc
                    string sql = @"INSERT INTO DonThuoc (NgayKeDon, TrangThai, MaPhieuKham, MaBacSi) 
                           VALUES (@ngay, @tt, @maPK, @maBS)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ngay", row.Cells["NgayKeDon"].Value ?? DateTime.Now);
                    cmd.Parameters.AddWithValue("@tt", row.Cells["TrangThai"].Value ?? "dang cho");

                    // CẦN nhập mã số ID thực tế vào ô ẩn hoặc lấy mặc định để tránh lỗi FK
                    // Ví dụ này lấy ID = 1 (Bác sĩ/Phiếu khám có sẵn), bạn nên thay bằng ID thực tế
                    cmd.Parameters.AddWithValue("@maPK", row.Cells["MaPhieuKham"].Value ?? 1);
                    cmd.Parameters.AddWithValue("@maBS", row.Cells["MaBacSi"].Value ?? 1);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm đơn thuốc thành công!");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (dgvQuanLyDonThuoc.CurrentRow == null || dgvQuanLyDonThuoc.CurrentRow.IsNewRow) return;
            try
            {
                DataGridViewRow row = dgvQuanLyDonThuoc.CurrentRow;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE DonThuoc SET TrangThai=@tt, NgayKeDon=@ngay WHERE MaDonThuoc=@ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", row.Cells["MaDonThuoc"].Value);
                    cmd.Parameters.AddWithValue("@tt", row.Cells["TrangThai"].Value ?? "");
                    cmd.Parameters.AddWithValue("@ngay", row.Cells["NgayKeDon"].Value ?? DateTime.Now);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvQuanLyDonThuoc.CurrentRow == null || dgvQuanLyDonThuoc.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Xóa đơn thuốc này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM DonThuoc WHERE MaDonThuoc=@ma", conn);
                        cmd.Parameters.AddWithValue("@ma", dgvQuanLyDonThuoc.CurrentRow.Cells["MaDonThuoc"].Value);
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
                    // Tìm theo Họ tên bệnh nhân hoặc Mã đơn
                    string sql = @"SELECT dt.MaDonThuoc, bn.HoTen AS HoTenBN, dt.NgayKeDon, 
                                  nd.HoTen AS TenBacSi, dt.TrangThai
                           FROM DonThuoc dt
                           INNER JOIN PhieuKham pk ON dt.MaPhieuKham = pk.MaPhieuKham
                           INNER JOIN LichHen lh ON pk.MaLichHen = lh.MaLichHen
                           INNER JOIN BenhNhan bn ON lh.MaBenhNhan = bn.MaBenhNhan
                           INNER JOIN BacSi bs ON dt.MaBacSi = bs.MaBacSi
                           INNER JOIN NguoiDung nd ON bs.MaNguoiDung = nd.MaNguoiDung
                           WHERE bn.HoTen LIKE @key OR dt.MaDonThuoc LIKE @key";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@key", "%" + txtTimKiem.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvQuanLyDonThuoc.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
        }
    }
}

