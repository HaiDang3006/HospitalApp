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
                    // Query lấy thông tin đơn thuốc kèm tên bệnh nhân từ bảng liên quan
                    string query = @"SELECT 
                                dt.MaDonThuoc AS [Mã Đơn], 
                                bn.HoTen AS [Bệnh Nhân], 
                                dt.NgayKeDon AS [Ngày Kê], 
                                dt.TrangThai AS [Trạng Thái], 
                                dt.LoiDan AS [Lời Dặn]
                             FROM DonThuoc dt
                             JOIN PhieuKham pk ON dt.MaPhieuKham = pk.MaPhieuKham
                             JOIN LichHen lh ON pk.MaLichHen = lh.MaLichHen
                             JOIN BenhNhan bn ON lh.MaBenhNhan = bn.MaBenhNhan
                             ORDER BY dt.MaDonThuoc DESC"; // Đơn mới nhất lên đầu

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvQuanLyDonThuoc.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi LoadData: " + ex.Message); }
        }
    
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Câu lệnh INSERT vào bảng DonThuoc
                    // Lưu ý: MaPhieuKham và MaBacSi trong DB của bạn là NOT NULL, 
                    // nên cần có giá trị hợp lệ tồn tại trong bảng PhieuKham và BacSi.
                    string query = @"INSERT INTO DonThuoc (MaPhieuKham, MaBacSi, LoiDan, TrangThai, NgayKeDon) 
                             VALUES (@maPK, @maBS, @loidan, N'ChuaLay', GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thay 'txtLoiDan' bằng tên thực tế của ô nhập liệu trên Form của bạn
                        // Nếu chưa có ô nhập, bạn có thể để tạm một chuỗi trống ""
                        string noiDungLoiDan = "";
                        if (this.Controls.ContainsKey("txtLoiDan"))
                        {
                            noiDungLoiDan = ((TextBox)this.Controls["txtLoiDan"]).Text;
                        }

                        cmd.Parameters.AddWithValue("@maPK", 1); // Cần thay bằng mã Phiếu Khám thực tế
                        cmd.Parameters.AddWithValue("@maBS", 1); // Cần thay bằng mã Bác Sĩ thực tế
                        cmd.Parameters.AddWithValue("@loidan", noiDungLoiDan);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm đơn thuốc thành công và mã đã tự động cập nhật!");
                    LoadData(); // Cập nhật lại lưới hiển thị
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message + "\nLưu ý: Mã PhieuKham và BacSi phải tồn tại trong DB.");
            }
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
            if (dgvQuanLyDonThuoc.CurrentRow == null) return;

            int maDon = Convert.ToInt32(dgvQuanLyDonThuoc.CurrentRow.Cells["Mã Đơn"].Value);

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa đơn thuốc này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // Xóa chi tiết trước để tránh lỗi ràng buộc khóa ngoại (Foreign Key)
                        string deleteDetails = "DELETE FROM ChiTietDonThuoc WHERE MaDonThuoc = @id";
                        SqlCommand cmd1 = new SqlCommand(deleteDetails, conn);
                        cmd1.Parameters.AddWithValue("@id", maDon);
                        cmd1.ExecuteNonQuery();

                        // Sau đó xóa đơn thuốc
                        string deleteMaster = "DELETE FROM DonThuoc WHERE MaDonThuoc = @id";
                        SqlCommand cmd2 = new SqlCommand(deleteMaster, conn);
                        cmd2.Parameters.AddWithValue("@id", maDon);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("Xóa thành công!");
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
                    string query = @"SELECT dt.MaDonThuoc AS [Mã Đơn], bn.HoTen AS [Bệnh Nhân], 
                                    dt.NgayKeDon AS [Ngày Kê], dt.TrangThai AS [Trạng Thái], dt.LoiDan AS [Lời Dặn]
                             FROM DonThuoc dt
                             JOIN PhieuKham pk ON dt.MaPhieuKham = pk.MaPhieuKham
                             JOIN LichHen lh ON pk.MaLichHen = lh.MaLichHen
                             JOIN BenhNhan bn ON lh.MaBenhNhan = bn.MaBenhNhan
                             WHERE bn.HoTen LIKE @key OR CAST(dt.MaDonThuoc AS VARCHAR) LIKE @key";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    // txtSearch là ô "Nhập tên, mã thuốc" trên giao diện của bạn
                    da.SelectCommand.Parameters.AddWithValue("@key", "%" + txtTimKiem.Text.Trim() + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvQuanLyDonThuoc.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
        }
    }
}

