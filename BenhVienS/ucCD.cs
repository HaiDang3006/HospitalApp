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
        private string strCon;
        private string maDuocSiHienTai; // Add this field

        public ucCD(string maDuocSi) // Add a constructor to set the value
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
            LoadDataDuocSi();
        }

        string connectionString = "Server=MSI\\SQLEXPRESS;Database=BENHVIENS;Trusted_Connection=True;TrustServerCertificate=True;";

        private void btdangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có chắc muốn đăng xuất không?",
               "Xác nhận",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Form parentForm = this.FindForm(); // LẤY FORM CHA (FormDượcSĩ)

                parentForm.Hide(); // ẨN TOÀN BỘ FORM DƯỢC SĨ

                Form1 frmLogin = new Form1();
                frmLogin.Show();
            }
        }

        private void LoadDataDuocSi()
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT ds.MaDuocSi, nd.HoTen, nd.SoDienThoai, nd.Email, nd.DiaChi, 
                                    ds.KhoaPhong, ds.BangCap, ds.ChuyenMon
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
                        txtKhoaPhong.Text = reader["KhoaPhong"].ToString();
                        txtBangCap.Text = reader["BangCap"].ToString();
                        txtChuyenMon.Text = reader["ChuyenMon"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE NguoiDung 
                           SET SoDienThoai = @sdt, Email = @email, DiaChi = @dc
                           WHERE MaNguoiDung = (SELECT MaNguoiDung FROM DuocSi WHERE MaDuocSi = @MaDS)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sdt", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaDS", maDuocSiHienTai);

                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show("Cập nhật thông tin cá nhân thành công!");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void btCapNhatChuyenMon_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản
            if (string.IsNullOrWhiteSpace(txtBangCap.Text) || string.IsNullOrWhiteSpace(txtChuyenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Bằng cấp và Chuyên môn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(strCon)) // strCon là chuỗi kết nối của bạn
            {
                try
                {
                    conn.Open();

                    // 2. Câu lệnh SQL cập nhật bảng DuocSi
                    string sql = @"UPDATE DuocSi 
                           SET KhoaPhong = @kp, 
                               BangCap = @bc, 
                               ChuyenMon = @cm 
                           WHERE MaDuocSi = @maDS";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // 3. Truyền tham số để bảo mật (chống SQL Injection)
                    cmd.Parameters.AddWithValue("@kp", txtKhoaPhong.Text.Trim());
                    cmd.Parameters.AddWithValue("@bc", txtBangCap.Text.Trim());
                    cmd.Parameters.AddWithValue("@cm", txtChuyenMon.Text.Trim());
                    cmd.Parameters.AddWithValue("@maDS", maDuocSiHienTai); // Mã dược sĩ đang đăng nhập

                    // 4. Thực thi và kiểm tra kết quả
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin chuyên môn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu dược sĩ để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối Database: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text != txtNhapLaiMKM.Text)
            {
                MessageBox.Show("Mật khẩu mới nhập lại không khớp!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();
                    // Kiểm tra mật khẩu cũ
                    string checkSql = @"SELECT COUNT(*) FROM NguoiDung nd 
                                JOIN DuocSi ds ON nd.MaNguoiDung = ds.MaNguoiDung 
                                WHERE ds.MaDuocSi = @MaDS AND nd.MatKhau = @oldPass";
                    SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@MaDS", maDuocSiHienTai);
                    checkCmd.Parameters.AddWithValue("@oldPass", txtMatKhauCu.Text);

                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        // Cập nhật mật khẩu mới
                        string updateSql = @"UPDATE NguoiDung SET MatKhau = @newPass 
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
                catch (Exception ex) { MessageBox.Show("Lỗi bảo mật: " + ex.Message); }
            }
        }
    }
}
