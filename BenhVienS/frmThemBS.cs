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
    
    public partial class frmThemBS : Form
    {
        public static class Basics
        {
            public static string connectionString =
                @"Data Source=localhost\SQLEXPRESS02;Initial Catalog=BenhVienV1;Integrated Security=True";
        }
        public frmThemBS()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThembacsi_Click(object sender, EventArgs e)
        {
            if (txtHoten.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên");
                return;
            }

            using (SqlConnection conn = new SqlConnection(Basics.connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // =======================
                    // 1. THÊM NGƯỜI DÙNG
                    // =======================
                    string sqlNguoiDung = @"
            INSERT INTO NguoiDung
            (TenDangNhap, MatKhauHash, HoTen, Email, SoDienThoai, MaVaiTro, TrangThai)
            VALUES
            (@TenDangNhap, @MatKhauHash, @HoTen, @Email, @SDT, @MaVaiTro, @TrangThai);
            SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdND = new SqlCommand(sqlNguoiDung, conn, tran);
                    cmdND.Parameters.AddWithValue("@TenDangNhap", txtEmail.Text.Trim());
                    cmdND.Parameters.AddWithValue("@MatKhauHash", "123456"); // demo
                    cmdND.Parameters.AddWithValue("@HoTen", txtHoten.Text.Trim());
                    cmdND.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmdND.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmdND.Parameters.AddWithValue("@MaVaiTro", 2); // 1 = Bác sĩ
                    cmdND.Parameters.AddWithValue("@TrangThai", cbCapnhatbacsi.Checked);

                    int maNguoiDung = Convert.ToInt32(cmdND.ExecuteScalar());

                    // =======================
                    // 2. THÊM BÁC SĨ
                    // =======================
                    string sqlBacSi = @"
            INSERT INTO BacSi
            (MaNguoiDung, MaChuyenKhoa, BangCap, ChuyenMon, TrangThai)
            VALUES
            (@MaNguoiDung, @MaChuyenKhoa, @BangCap, @ChuyenMon, @TrangThai)";

                    SqlCommand cmdBS = new SqlCommand(sqlBacSi, conn, tran);
                    cmdBS.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                    cmdBS.Parameters.AddWithValue("@MaChuyenKhoa", cboChuyenKhoa.SelectedValue);
                    cmdBS.Parameters.AddWithValue("@BangCap", txtTrinhdo.Text.Trim());
                    cmdBS.Parameters.AddWithValue("@ChuyenMon", txtChuyenkhoa.Text.Trim());
                    cmdBS.Parameters.AddWithValue("@TrangThai", cbCapnhatbacsi.Checked);

                    cmdBS.ExecuteNonQuery();

                    tran.Commit();

                    MessageBox.Show("Thêm bác sĩ thành công");
                    this.Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
