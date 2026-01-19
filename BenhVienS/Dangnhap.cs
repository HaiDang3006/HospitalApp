using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BenhVienS
{
    public partial class Dangnhap : Form
    {
        string connectionString =
    @"Server=localhost\SQLEXPRESS02;
      Database=HospitalManagementSystem;
      Trusted_Connection=True;
      TrustServerCertificate=True;";

        public Dangnhap()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {
            cobVaitro.Items.Add("ADMIN");
            cobVaitro.Items.Add("Bác sĩ");
            cobVaitro.Items.Add("Dược sĩ");
            cobVaitro.Items.Add("Nhân viên");
            cobVaitro.Items.Add("Bệnh nhân");
            // Chọn mặc định mục đầu tiên
            cobVaitro.SelectedIndex = 0;
        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btDangnhap_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            if (email == "" || matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            using (SqlConnection conn = dbUtils.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT MaVaiTro 
            FROM NguoiDung
            WHERE Email = @Email AND MatKhau = @MatKhau";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                    return;
                }

                int maVaiTro = Convert.ToInt32(result);

                // ADMIN
                if (maVaiTro == 1)
                {
                    Form2 f = new Form2();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền Admin");
                }
            }
        }

        private void linkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var forgotForm = new QuenMK())
            {
                forgotForm.ShowDialog(this);
            }
        }

        private void cobVaitro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
