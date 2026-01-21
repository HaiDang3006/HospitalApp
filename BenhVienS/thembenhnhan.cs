using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace BenhVienS
{
   

    public partial class thembenhnhan : Form
    {
        public void SetBenhNhanData(int maBenhNhan, int maNguoiDung, string hoTen, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi)

        int _maBenhNhan = 0;
        int _maNguoiDung = 0;
        bool _isEdit = false;

        string connStr = ConfigurationManager
            .ConnectionStrings["BenhVienV1ConnectionString"]
            .ConnectionString;
        public void SetBenhNhanData(
            int maBenhNhan,
            int maNguoiDung,
            string hoTen,
            DateTime ngaySinh,
            string gioiTinh,
            string soDienThoai,
            string diaChi)
        {
            _isEdit = true;
            _maBenhNhan = maBenhNhan;
            _maNguoiDung = maNguoiDung;

            txtmabn.Text = maBenhNhan.ToString();
            // If you have a field for MaNguoiDung, set it here (e.g., txtMaNguoiDung.Text = maNguoiDung.ToString();)
            txtmabn.Enabled = false;

            txthoten.Text = hoTen;
            dtpngaysinh.Value = ngaySinh;

            if (gioiTinh == "Nam")
                rdoNam.Checked = true;
            else if (gioiTinh == "Nữ")
            else
                rdoNu.Checked = true;

            txtSDT.Text = soDienThoai;
            txtdiachi.Text = diaChi;
        }
        public thembenhnhan()
        {
            InitializeComponent();
        }

        private void lbldiachi_Click(object sender, EventArgs e)
        {

        }

        private void ckbbhyt_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void thembenhnhan_Load(object sender, EventArgs e)
        {
           
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            string connStr = @"Data Source=localhost\SQLEXPRESS02;Initial Catalog=benhvienvs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // ===============================
                    // 1. THÊM NGƯỜI DÙNG
                    // ===============================
                    string sqlNguoiDung = @"
            INSERT INTO NguoiDung
            (TenDangNhap, MatKhauHash, HoTen, SoDienThoai, DiaChi, NgaySinh, GioiTinh, MaVaiTro)
            VALUES
            (@TenDangNhap, @MatKhau, @HoTen, @SDT, @DiaChi, @NgaySinh, @GioiTinh, 5);
            SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdND = new SqlCommand(sqlNguoiDung, conn, tran);
                    cmdND.Parameters.AddWithValue("@TenDangNhap", txtSDT.Text);
                    cmdND.Parameters.AddWithValue("@MatKhau", "123456"); // demo
                    cmdND.Parameters.AddWithValue("@HoTen", txthoten.Text);
                    cmdND.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmdND.Parameters.AddWithValue("@DiaChi", txtdiachi.Text);
                    cmdND.Parameters.AddWithValue("@NgaySinh", dtpngaysinh.Value.Date);
                    cmdND.Parameters.AddWithValue("@GioiTinh",
                        rdoNam.Checked ? "Nam" : "Nữ");

                    int maNguoiDung = Convert.ToInt32(cmdND.ExecuteScalar());

                    // ===============================
                    // 2. THÊM BỆNH NHÂN
                    // ===============================
                    string sqlBenhNhan = @"
            INSERT INTO BenhNhan
            (MaNguoiDung, HoTen, NgaySinh, GioiTinh, SoDienThoai, DiaChi)
            VALUES
            (@MaNguoiDung, @HoTen, @NgaySinh, @GioiTinh, @SDT, @DiaChi);";

                    SqlCommand cmdBN = new SqlCommand(sqlBenhNhan, conn, tran);
                    cmdBN.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                    cmdBN.Parameters.AddWithValue("@HoTen", txthoten.Text);
                    cmdBN.Parameters.AddWithValue("@NgaySinh", dtpngaysinh.Value.Date);
                    cmdBN.Parameters.AddWithValue("@GioiTinh",
                        rdoNam.Checked ? "Nam" : "Nữ");
                    cmdBN.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmdBN.Parameters.AddWithValue("@DiaChi", txtdiachi.Text);

                    cmdBN.ExecuteNonQuery();

                    // ===============================
                    // 3. NẾU CÓ BHYT
                    // ===============================
                    if (ckbbhyt.Checked)
                    {
                        string sqlBHYT = @"
                INSERT INTO BaoHiemYTe
                (MaBenhNhan, SoTheBHYT, NgayBatDau, NgayHetHan)
                VALUES
                ((SELECT MaBenhNhan FROM BenhNhan WHERE MaNguoiDung = @MaNguoiDung),
                 @SoThe, @NgayBD, @NgayHH);";

                        SqlCommand cmdBHYT = new SqlCommand(sqlBHYT, conn, tran);
                        cmdBHYT.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                        cmdBHYT.Parameters.AddWithValue("@SoThe", txtSoTheBHYT.Text);
                        cmdBHYT.Parameters.AddWithValue("@NgayBD", dtpBHYT_Tu.Value.Date);
                        cmdBHYT.Parameters.AddWithValue("@NgayHH", dtpBHYT_Den.Value.Date);

                        cmdBHYT.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("✅ Thêm bệnh nhân thành công!");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("❌ Lỗi: " + ex.Message);
                }
            }
        }

        private void dtpngaysinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (_isEdit)
                CapNhatBenhNhan();
            else
                ThemBenhNhanMoi();

            this.Close();
        }

        void CapNhatBenhNhan()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                UPDATE NguoiDung SET
                    HoTen = @HoTen,
                    SoDienThoai = @SDT,
                    DiaChi = @DiaChi,
                    NgaySinh = @NgaySinh,
                    GioiTinh = @GioiTinh,
                    NgayCapNhat = GETDATE()
                WHERE MaNguoiDung = @MaNguoiDung";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@HoTen", txthoten.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtdiachi.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpngaysinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", rdoNam.Checked);
                cmd.Parameters.AddWithValue("@MaNguoiDung", _maNguoiDung);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật bệnh nhân thành công");
            }
        }
        void ThemBenhNhanMoi()
        {
            MessageBox.Show("Chức năng thêm sẽ xử lý sau");
        }
    }
}
