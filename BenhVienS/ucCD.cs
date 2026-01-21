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
    public partial class ucCD : UserControl
    {
        private string maDuocSiHienTai;
        // Sử dụng một chuỗi kết nối duy nhất
        private string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENV1;Trusted_Connection=True;TrustServerCertificate=True;";

        public ucCD(string maDuocSi)
        {
            InitializeComponent();
            maDuocSiHienTai = maDuocSi;
        }

        public ucCD()
        {
            InitializeComponent();
        }

        private void ucCD_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maDuocSiHienTai))
            {
                LoadDataDuocSi();
            }
        }

        private void LoadDataDuocSi()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Sửa lại Query: Bỏ KhoaPhong, ChuyenMon (không có trong SQL) và thêm ChungChiHanhNghe
                    string query = @"SELECT ds.MaDuocSi, nd.HoTen, nd.SoDienThoai, nd.Email, nd.DiaChi, 
                                            ds.BangCap, ds.ChungChiHanhNghe
                                     FROM DuocSi ds
                                     JOIN NguoiDung nd ON ds.MaNguoiDung = nd.MaNguoiDung
                                     WHERE ds.MaDuocSi = @MaDS";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDS", maDuocSiHienTai);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtMaDuocSi.Text = reader["MaDuocSi"].ToString();
                        txtHoTen.Text = reader["HoTen"].ToString();
                        txtSDT.Text = reader["SoDienThoai"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtDiaChi.Text = reader["DiaChi"].ToString();
                        txtBangCap.Text = reader["BangCap"].ToString();
                        // txtChuyenMon giờ sẽ hiển thị Chứng chỉ hành nghề
                        txtChuyenMon.Text = reader["ChungChiHanhNghe"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        // 1. CẬP NHẬT THÔNG TIN CÁ NHÂN (Bảng NguoiDung)
        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Thêm cập nhật NgayCapNhat để đồng bộ với DB
                    string sql = @"UPDATE NguoiDung 
                                   SET SoDienThoai = @sdt, Email = @email, DiaChi = @dc, NgayCapNhat = GETDATE()
                                   WHERE MaNguoiDung = (SELECT MaNguoiDung FROM DuocSi WHERE MaDuocSi = @MaDS)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sdt", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaDS", maDuocSiHienTai);

                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show("Cập nhật thông tin cá nhân thành công!", "Thông báo");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // 2. CẬP NHẬT CHUYÊN MÔN (Bảng DuocSi)
        private void btCapNhatChuyenMon_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Sửa lại theo đúng các cột trong bảng DuocSi (BangCap, ChungChiHanhNghe)
                    string sql = @"UPDATE DuocSi 
                                   SET BangCap = @bc, ChungChiHanhNghe = @cc 
                                   WHERE MaDuocSi = @maDS";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@bc", txtBangCap.Text.Trim());
                    cmd.Parameters.AddWithValue("@cc", txtChuyenMon.Text.Trim()); // Map txtChuyenMon sang ChungChiHanhNghe
                    cmd.Parameters.AddWithValue("@maDS", maDuocSiHienTai);

                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show("Cập nhật chuyên môn thành công!");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // 3. ĐỔI MẬT KHẨU (Dùng cột MatKhauHash trong SQL)
        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text != txtNhapLaiMKM.Text)
            {
                MessageBox.Show("Mật khẩu mới nhập lại không khớp!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Kiểm tra mật khẩu cũ (Sửa tên cột thành MatKhauHash)
                    string checkSql = @"SELECT COUNT(*) FROM NguoiDung nd 
                                        JOIN DuocSi ds ON nd.MaNguoiDung = ds.MaNguoiDung 
                                        WHERE ds.MaDuocSi = @MaDS AND nd.MatKhauHash = @oldPass";

                    SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@MaDS", maDuocSiHienTai);
                    checkCmd.Parameters.AddWithValue("@oldPass", txtMatKhauCu.Text);

                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        string updateSql = @"UPDATE NguoiDung SET MatKhauHash = @newPass, NgayCapNhat = GETDATE()
                                             WHERE MaNguoiDung = (SELECT MaNguoiDung FROM DuocSi WHERE MaDuocSi = @MaDS)";
                        SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                        updateCmd.Parameters.AddWithValue("@newPass", txtMatKhauMoi.Text);
                        updateCmd.Parameters.AddWithValue("@MaDS", maDuocSiHienTai);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Đổi mật khẩu thành công!");
                        txtMatKhauCu.Clear(); txtMatKhauMoi.Clear(); txtNhapLaiMKM.Clear();
                    }
                    else { MessageBox.Show("Mật khẩu cũ không chính xác!"); }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void btdangxuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.FindForm().Close(); // Đóng Form hiện tại
                // Form1 (Login) nên được mở từ Program.cs hoặc Form cha để tránh chồng chéo memory
            }
        }
    }
}