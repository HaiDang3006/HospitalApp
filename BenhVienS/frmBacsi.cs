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
using static System.Windows.Forms.AxHost;

namespace BenhVienS
{
    
    public partial class frmBacsi : Form
    {
        public string State { get; set; }
        public int MaBacSi { get; set; }
        
        public frmBacsi()
        {
            InitializeComponent();
        }
        private void frmBacsi_Load(object sender, EventArgs e)
        {
            LoadChuyenKhoa(); // ✅ BẮT BUỘC TRƯỚC

            if (State == "Them")
            {
                Text = "Thêm mới Bác sĩ";
                btnLuu.Text = "Thêm";
            }
            else
            {
                LoadChiTietBacSi(); // ✅ SAU KHI CÓ DATASOURCE

                if (State == "Sua")
                {
                    Text = "Cập nhật Bác sĩ";
                    btnLuu.Text = "Cập nhật";
                    txtID.Text = MaBacSi.ToString();
                    txtID.ReadOnly = true;
                }
                else if (State == "Xoa")
                {
                    Text = "Xóa Bác sĩ";
                    btnLuu.Text = "Xóa";
                    VôHiệuHóaCacO(false);
                }
            }
        }

        private void LoadChuyenKhoa()
        {
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT MaChuyenKhoa, TenChuyenKhoa FROM ChuyenKhoa", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cbChuyenkhoa.DataSource = dt;
                cbChuyenkhoa.DisplayMember = "TenChuyenKhoa";
                cbChuyenkhoa.ValueMember = "MaChuyenKhoa";
                cbChuyenkhoa.SelectedIndex = -1; // ⭐ tránh auto chọn
            }
        }
        private void LoadChiTietBacSi()
        {
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                string sql = @"
                SELECT nd.*, bs.*
                FROM BacSi bs
                JOIN NguoiDung nd ON bs.MaNguoiDung = nd.MaNguoiDung
                WHERE bs.MaBacSi = @Ma";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Ma", MaBacSi);

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtHoten.Text = rd["HoTen"].ToString();
                    txtEmail.Text = rd["Email"].ToString();
                    txtSDT.Text = rd["SoDienThoai"].ToString();
                    txtTrinhdo.Text = rd["BangCap"].ToString();
                    txtKinhnghiem.Text = rd["NamKinhNghiem"].ToString();
                    dateNgaysinh.Value = Convert.ToDateTime(rd["NgaySinh"]);
                    radNam.Checked = (bool)rd["GioiTinh"];
                    radNu.Checked = !(bool)rd["GioiTinh"];
                    cbChuyenkhoa.SelectedValue = rd["MaChuyenKhoa"];
                }
            }
        }

        private void cbChuyenkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtHoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateNgaysinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtTrinhdo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKinhnghiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    if (State == "Them")
                    {
                        int maND = ThemNguoiDung(conn, tran);
                        ThemBacSi(conn, tran, maND);
                    }
                    else if (State == "Sua")
                    {
                        CapNhatBacSi(conn, tran);
                    }
                    else if (State == "Xoa")
                    {
                        XoaBacSi(conn, tran);
                    }

                    tran.Commit();
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        
        // ================= CÁC HÀM XỬ LÝ =================
        private int ThemNguoiDung(SqlConnection conn, SqlTransaction tran)
        {
            SqlCommand cmd = new SqlCommand(@"
            INSERT INTO NguoiDung
            (TenDangNhap, MatKhauHash, HoTen, Email, SoDienThoai, GioiTinh, MaVaiTro, TrangThai, NgaySinh)
            OUTPUT INSERTED.MaNguoiDung
            VALUES
            (@TenDN,'123456',@HoTen,@Email,@SDT,@GT,2,1,@NgaySinh)",
            conn, tran);

            cmd.Parameters.AddWithValue("@TenDN", "bs_" + DateTime.Now.Ticks);
            cmd.Parameters.AddWithValue("@HoTen", txtHoten.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
            cmd.Parameters.AddWithValue("@GT", radNam.Checked);
            cmd.Parameters.AddWithValue("@NgaySinh", dateNgaysinh.Value);

            return (int)cmd.ExecuteScalar();
        }

        private void ThemBacSi(SqlConnection conn, SqlTransaction tran, int maND)
        {
            SqlCommand cmd = new SqlCommand(@"
            INSERT INTO BacSi
            (MaNguoiDung, MaChuyenKhoa, BangCap, NamKinhNghiem, TrangThai)
            VALUES
            (@ND,@CK,@BC,@KN,1)",
            conn, tran);

            cmd.Parameters.AddWithValue("@ND", maND);
            cmd.Parameters.AddWithValue("@CK", cbChuyenkhoa.SelectedValue);
            cmd.Parameters.AddWithValue("@BC", txtTrinhdo.Text);
            cmd.Parameters.AddWithValue("@KN", txtKinhnghiem.Text);

            cmd.ExecuteNonQuery();
        }

        private void CapNhatBacSi(SqlConnection conn, SqlTransaction tran)
        {
            SqlCommand cmd = new SqlCommand(@"
            UPDATE BacSi SET
                MaChuyenKhoa=@CK,
                BangCap=@BC,
                NamKinhNghiem=@KN
            WHERE MaBacSi=@Ma",
            conn, tran);

            cmd.Parameters.AddWithValue("@CK", cbChuyenkhoa.SelectedValue);
            cmd.Parameters.AddWithValue("@BC", txtTrinhdo.Text);
            cmd.Parameters.AddWithValue("@KN", txtKinhnghiem.Text);
            cmd.Parameters.AddWithValue("@Ma", MaBacSi);

            cmd.ExecuteNonQuery();
        }

        private void XoaBacSi(SqlConnection conn, SqlTransaction tran)
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE BacSi SET TrangThai = 0 WHERE MaBacSi=@Ma",
                conn, tran);
            cmd.Parameters.AddWithValue("@Ma", MaBacSi);
            cmd.ExecuteNonQuery();
        }







        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VôHiệuHóaCacO(bool status)
        {
            txtHoten.Enabled = status;
            txtEmail.Enabled = status;
            txtSDT.Enabled = status;
            txtTrinhdo.Enabled = status;
            txtKinhnghiem.Enabled = status;
            dateNgaysinh.Enabled = status;
            radNam.Enabled = status;
            radNu.Enabled = status;
            cbChuyenkhoa.Enabled = status;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
