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
            txtmabn.Enabled = false;

            txthoten.Text = hoTen;
            dtpngaysinh.Value = ngaySinh;

            if (gioiTinh == "Nam")
                rdoNam.Checked = true;
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
