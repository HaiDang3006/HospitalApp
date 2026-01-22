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
    
    public partial class frmThemBS : Form
    {
      
        public frmThemBS()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThembacsi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoten.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên");
                return;
            }

            if (cboChuyenKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chuyên khoa");
                return;
            }

            string connStr = ConfigurationManager
                .ConnectionStrings["BenhVienV1ConnectionString"]
                .ConnectionString;

            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    bool gioiTinh = rbtnam.Checked;

                    SqlCommand cmdND = new SqlCommand(@"
                INSERT INTO NguoiDung
                (TenDangNhap, MatKhauHash, HoTen, Email, SoDienThoai,
                 GioiTinh, MaVaiTro, TrangThai, NgayTao)
                OUTPUT INSERTED.MaNguoiDung
                VALUES
                (@TenDN,@MK,@HoTen,@Email,@SDT,
                 @GioiTinh,2,1,GETDATE())",
                        conn, tran);

                    cmdND.Parameters.AddWithValue("@TenDN", "bs_" + DateTime.Now.Ticks);
                    cmdND.Parameters.AddWithValue("@MK", "123456");
                    cmdND.Parameters.AddWithValue("@HoTen", txtHoten.Text);
                    cmdND.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmdND.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmdND.Parameters.AddWithValue("@GioiTinh", gioiTinh);

                    int maNguoiDung = (int)cmdND.ExecuteScalar();

                    SqlCommand cmdBS = new SqlCommand(@"
                INSERT INTO BacSi
                (MaNguoiDung, MaChuyenKhoa, BangCap, TrangThai)
                VALUES
                (@MaND,@MaCK,@BangCap,@TrangThai)",
                        conn, tran);

                    cmdBS.Parameters.AddWithValue("@MaND", maNguoiDung);
                    cmdBS.Parameters.AddWithValue("@MaCK", cboChuyenKhoa.SelectedValue);
                    cmdBS.Parameters.AddWithValue("@BangCap", txtTrinhdo.Text);
                    cmdBS.Parameters.AddWithValue("@TrangThai", cbCapnhatbacsi.Checked);

                    cmdBS.ExecuteNonQuery();

                    tran.Commit();

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        void LoadChuyenKhoa()
        {
            
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT MaChuyenKhoa, TenChuyenKhoa FROM ChuyenKhoa",
                    conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cboChuyenKhoa.DataSource = dt;
                cboChuyenKhoa.DisplayMember = "TenChuyenKhoa";
                cboChuyenKhoa.ValueMember = "MaChuyenKhoa";
                cboChuyenKhoa.SelectedIndex = -1;
            }

        }      
            

        private void frmThemBS_Load(object sender, EventArgs e)
        {
            LoadChuyenKhoa();
              rbtnam.Checked = true;
        }
    }
}
