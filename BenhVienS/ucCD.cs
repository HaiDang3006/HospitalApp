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
        private int maNguoiDungHienTai=9;
        public ucCD(string maDuocSi)
        {
            InitializeComponent();
            this.maDuocSiHienTai = maDuocSi;
            LoadDataDuocSi();
        }
        public void ThietLapThongTin(int maSo)
        {
            // Chuyển int sang string để khớp với biến maDuocSiHienTai bạn đang khai báo
            this.maDuocSiHienTai = maSo.ToString();

            // Gọi hàm tải dữ liệu của bạn
            LoadDataDuocSi();
        }
        public ucCD()
        {
            InitializeComponent();
        }

        #region 1. Tải dữ liệu Dược sĩ (Profile)
        private void LoadDataDuocSi()
        {
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Join bảng DuocSi và NguoiDung để lấy đủ thông tin
                    string query = @"
                        SELECT d.MaDuocSi, d.BangCap, d.ChungChiHanhNghe, 
                               n.MaNguoiDung,n.TenDangNhap ,n.HoTen, n.NgaySinh, n.SoDienThoai, n.Email, n.DiaChi 
                        FROM DuocSi d
                        JOIN NguoiDung n ON d.MaNguoiDung = n.MaNguoiDung
                        WHERE d.MaDuocSi = @MaDuocSi";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDuocSi", maDuocSiHienTai);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Lưu MaNguoiDung để dùng cho lệnh Update sau này
                        maNguoiDungHienTai = Convert.ToInt32(reader["MaNguoiDung"]);

                        // Tab Thông tin cá nhân
                        txtMaDuocSi.Text = reader["MaDuocSi"].ToString();
                        txtTenDangNhap.Text = reader["TenDangNhap"].ToString();
                        txtHoTen.Text = reader["HoTen"].ToString();

                        // Xử lý ngày sinh (Hiển thị dd/MM/yyyy)
                        if (reader["NgaySinh"] != DBNull.Value)
                        {
                            DateTime ns = Convert.ToDateTime(reader["NgaySinh"]);
                            txtNgaySinh.Text = ns.ToString("dd/MM/yyyy");
                        }

                        txtSDT.Text = reader["SoDienThoai"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtDiaChi.Text = reader["DiaChi"].ToString();

                        // Tab Chuyên môn
                        txtBangCap.Text = reader["BangCap"].ToString();
                        txtChungChiHanhNghe.Text = reader["ChungChiHanhNghe"].ToString();

                        // Khóa các trường không được sửa theo yêu cầu
                        txtMaDuocSi.ReadOnly = true;
                        txtTenDangNhap.ReadOnly = true;
                        txtNgaySinh.ReadOnly = true; // Hoặc Enabled = false
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }
        }
        
        #endregion

        #region 2. Cập nhật thông tin cá nhân (NguoiDung)
        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE NguoiDung 
                                     SET HoTen = @HoTen, 
                                         SoDienThoai = @SDT, 
                                         Email = @Email, 
                                         DiaChi = @DiaChi,
                                         NgayCapNhat = GETDATE()
                                     WHERE MaNguoiDung = @MaNguoiDung";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDungHienTai);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0) MessageBox.Show("Cập nhật thông tin cá nhân thành công!");
                    else MessageBox.Show("Không thể cập nhật.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        #endregion

        #region 3. Cập nhật thông tin nghề nghiệp (DuocSi)
        private void btCapNhatChuyenMon_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE DuocSi 
                                     SET BangCap = @BangCap, 
                                         ChungChiHanhNghe = @ChungChi 
                                     WHERE MaDuocSi = @MaDuocSi";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BangCap", txtBangCap.Text);
                    cmd.Parameters.AddWithValue("@ChungChi", txtChungChiHanhNghe.Text);
                    cmd.Parameters.AddWithValue("@MaDuocSi", maDuocSiHienTai);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0) MessageBox.Show("Cập nhật chuyên môn thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        #endregion

        #region 4. Đổi mật khẩu (MatKhauHash)
        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            // Kiểm tra hợp lệ form
            if (string.IsNullOrEmpty(txtMatKhauCu.Text) || string.IsNullOrEmpty(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mật khẩu.");
                return;
            }

            if (txtMatKhauMoi.Text != txtNhapLaiMKM.Text)
            {
                MessageBox.Show("Mật khẩu mới và nhập lại không khớp.");
                return;
            }

            using (SqlConnection conn = dbUtils.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Bước 1: Kiểm tra mật khẩu cũ có đúng không
                    string checkQuery = "SELECT COUNT(*) FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung AND MatKhauHash = @MatKhauCu";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDungHienTai);
                    checkCmd.Parameters.AddWithValue("@MatKhauCu", txtMatKhauCu.Text); // Lưu ý: Nếu thực tế có mã hóa thì phải mã hóa text này trước khi so sánh

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Bước 2: Cập nhật mật khẩu mới
                        string updateQuery = "UPDATE NguoiDung SET MatKhauHash = @MatKhauMoi WHERE MaNguoiDung = @MaNguoiDung";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@MatKhauMoi", txtMatKhauMoi.Text);
                        updateCmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDungHienTai);

                        updateCmd.ExecuteNonQuery();
                        MessageBox.Show("Đổi mật khẩu thành công!");

                        // Xóa trắng các ô mật khẩu
                        txtMatKhauCu.Clear();
                        txtMatKhauMoi.Clear();
                        txtNhapLaiMKM.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
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