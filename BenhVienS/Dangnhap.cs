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

                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                    txtEmail.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
                    txtPassword.Focus();
                    return;
                }

                var authService = new AuthService();

                var user = authService.Login(username, password);

                if (user)
                {
                    NavigationService.RedirectByRole(this);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi đăng nhập",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
