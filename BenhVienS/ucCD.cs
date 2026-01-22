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

        #region 1. Tải dữ liệu Dược sĩ (Profile)
        private void LoadDataDuocSi()
        {
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Query sửa đổi: Thay KhoaPhong, ChuyenMon bằng ChungChiHanhNghe cho khớp SQL
                    string query = @"SELECT ds.MaDuocSi, nd.HoTen, nd.SoDienThoai, nd.Email, nd.DiaChi, 
                                            ds.BangCap, ds.ChungChiHanhNghe
                                     FROM DuocSi ds
                                     INNER JOIN NguoiDung nd ON ds.MaNguoiDung = nd.MaNguoiDung
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
                        // Ánh xạ ChungChiHanhNghe vào ô Chuyên môn trên giao diện
                        txtChuyenMon.Text = reader["ChungChiHanhNghe"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu cá nhân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 2. Cập nhật thông tin cá nhân (NguoiDung)
        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            // Kiểm tra trống
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Thông báo");
                return;
            }

            using (SqlConnection conn = dbUtils.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Cập nhật các trường liên lạc và cập nhật luôn thời gian NgayCapNhat
                    string sql = @"UPDATE NguoiDung 
                                   SET SoDienThoai = @sdt, Email = @email, DiaChi = @dc, NgayCapNhat = GETDATE()
                                   WHERE MaNguoiDung = (SELECT MaNguoiDung FROM DuocSi WHERE MaDuocSi = @MaDS)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sdt", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaDS", maDuocSiHienTai);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin cá nhân thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 3. Cập nhật thông tin nghề nghiệp (DuocSi)
        private void btCapNhatChuyenMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBangCap.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin Bằng cấp!", "Thông báo");
                return;
            }

            using (SqlConnection conn = dbUtils.GetConnection())
            {
                try
                {
                    conn.Open();
                    // SQL sửa đổi: Chỉ cập nhật BangCap và ChungChiHanhNghe (vì bảng DuocSi chỉ có 2 cột này)
                    string sql = @"UPDATE DuocSi 
                                   SET BangCap = @bc, 
                                       ChungChiHanhNghe = @cc
                                   WHERE MaDuocSi = @maDS";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@bc", txtBangCap.Text.Trim());
                    cmd.Parameters.AddWithValue("@cc", txtChuyenMon.Text.Trim()); // Lấy từ ô chuyên môn
                    cmd.Parameters.AddWithValue("@maDS", maDuocSiHienTai);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật hồ sơ nghề nghiệp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã dược sĩ phù hợp.", "Lỗi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }
        #endregion

        #region 4. Đổi mật khẩu (MatKhauHash)
        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            // Kiểm tra hợp lệ form
            if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text) || string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu cũ và mới!");
                return;
            }

            if (txtMatKhauMoi.Text != txtNhapLaiMKM.Text)
            {
                MessageBox.Show("Mật khẩu mới nhập lại không khớp!", "Lỗi xác nhận");
                return;
            }

            using (SqlConnection conn = dbUtils.GetConnection())
            {
                try
                {
                    conn.Open();
                    // 1. Kiểm tra mật khẩu cũ (Sửa cột MatKhau thành MatKhauHash)
                    string checkSql = @"SELECT COUNT(*) FROM NguoiDung nd 
                                        INNER JOIN DuocSi ds ON nd.MaNguoiDung = ds.MaNguoiDung 
                                        WHERE ds.MaDuocSi = @MaDS AND nd.MatKhauHash = @oldPass";

                    SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@MaDS", maDuocSiHienTai);
                    checkCmd.Parameters.AddWithValue("@oldPass", txtMatKhauCu.Text);

                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        // 2. Cập nhật mật khẩu mới và thời gian thay đổi
                        string updateSql = @"UPDATE NguoiDung 
                                             SET MatKhauHash = @newPass, NgayCapNhat = GETDATE()
                                             WHERE MaNguoiDung = (SELECT MaNguoiDung FROM DuocSi WHERE MaDuocSi = @MaDS)";

                        SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                        updateCmd.Parameters.AddWithValue("@newPass", txtMatKhauMoi.Text);
                        updateCmd.Parameters.AddWithValue("@MaDS", maDuocSiHienTai);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                        // Xóa trắng ô nhập
                        txtMatKhauCu.Clear(); txtMatKhauMoi.Clear(); txtNhapLaiMKM.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi bảo mật: " + ex.Message); }
            }
        }
        #endregion

        #region 5. Đăng xuất
        private void btdangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất khỏi hệ thống không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Lấy form chứa UserControl này và đóng nó
                Form parentForm = this.FindForm();
                if (parentForm != null)
                {
                    parentForm.Hide(); // Ẩn form chính

                    // Giả sử Form đăng nhập của bạn tên là Form1
                    // Bạn nên khởi tạo mới để reset lại các session
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is Form1) // Nếu form login đã mở thì hiện lại
                        {
                            f.Show();
                            parentForm.Close();
                            return;
                        }
                    }

                    // Nếu chưa có form login nào đang mở
                    Form1 frmLogin = new Form1();
                    frmLogin.Show();
                    parentForm.Close();
                }
            }
        }
        #endregion
    }
}