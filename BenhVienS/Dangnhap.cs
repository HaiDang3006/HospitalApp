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
        
        public Dangnhap()
        {
            InitializeComponent();
            InitPlaceholder();

        }
        private void InitPlaceholder()
        {
            SetPlaceholder(txtEmail, "Email hoặc tên đăng nhập");
            SetPlaceholder(txtPassword, "Mật khẩu", true);
        }



        private void btDangnhap_Click(object sender, EventArgs e)
        {
           
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
