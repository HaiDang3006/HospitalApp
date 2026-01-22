using BenhVienS.Common;
using BenhVienS.Models;
using BenhVienS.Service.AuthService;
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
    public partial class Dangnhap : Form
    {
        UserSession session = SessionManager.Load();

        public Dangnhap()
        {
            InitializeComponent();
            InitPlaceholder();
        }
        string connectionString = "Server=MSI\\SQLPHAT;Database=Benhvienv1;Trusted_Connection=True;TrustServerCertificate=True;";

        private void LoadSessionAndRedirect()
        {
            var session = SessionManager.Load();
            if (session == null) return;
            AppContextCustom.Instance.Auth.Set(session);
            NavigationService.RedirectByRole(this);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadSessionAndRedirect();
        }

        private void InitPlaceholder()
        {
            SetPlaceholder(txtEmail, "Email hoặc tên đăng nhập");
            SetPlaceholder(txtPassword, "Mật khẩu", true);
        }



        private void btDangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtEmail.Text.Trim();
                string password = txtPassword.Text;

                // Bỏ qua placeholder khi kiểm tra
                if (string.IsNullOrEmpty(username) || username == txtEmail.Tag.ToString())
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                    return;
                }

                var authService = new AuthService();
                // Giả sử Login trả về true/false dựa trên kết quả từ SQL
                var isLoginSuccess = authService.Login(username, password);

                if (isLoginSuccess)
                {
                    MessageBox.Show("✅ Đăng nhập thành công!");

                    // Mở Form Bệnh Nhân (Thay 'benhnhan' bằng tên chính xác của Form trong Project)
                    benhnhan formBN = new benhnhan();
                    formBN.Show();

                    this.Hide(); // Ẩn form đăng nhập
                }
                else
                {
                    MessageBox.Show("❌ Sai tên đăng nhập hoặc mật khẩu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối Database: {ex.Message}");
            }
        }

        private void SetPlaceholder(TextBox txt, string text, bool isPassword = false)
        {
            txt.Text = text;
            txt.ForeColor = Color.Gray;
            txt.Tag = text;

            if (isPassword)
                txt.UseSystemPasswordChar = false;
        }


        private void RemovePlaceholder(TextBox txt, bool isPassword = false)
        {
            if (txt.Text == txt.Tag.ToString())
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;

                if (isPassword)
                    txt.UseSystemPasswordChar = true;
            }
        }

        private void AddPlaceholder(TextBox txt, bool isPassword = false)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = txt.Tag.ToString();
                txt.ForeColor = Color.Gray;

                if (isPassword)
                    txt.UseSystemPasswordChar = false;
            }
        }

        // ===== EMAIL =====
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtEmail);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            AddPlaceholder(txtEmail);
        }

        // ===== PASSWORD =====
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtPassword, true);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            AddPlaceholder(txtPassword, true);
        }

        // ===== BUTTON HOVER =====
        private void btDangnhap_MouseEnter(object sender, EventArgs e)
        {
            btDangnhap.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void btDangnhap_MouseLeave(object sender, EventArgs e)
        {
            btDangnhap.BackColor = Color.FromArgb(52, 152, 219);
        }


        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu đang là placeholder thì KHÔNG bật password char
            if (txtPassword.ForeColor == Color.Gray)
            {
                txtPassword.UseSystemPasswordChar = false;
                return;
            }

            // Checked = hiện mật khẩu
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

    }
}
