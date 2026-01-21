using System;
using System.Drawing;
using System.Windows.Forms;

namespace BenhVienS
{
    partial class Dangnhap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelEmail = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.picIconEmail = new System.Windows.Forms.PictureBox();
            this.panelPassword = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.picIconPassword = new System.Windows.Forms.PictureBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.btDangnhap = new System.Windows.Forms.Button();
            this.linkQuenMK = new System.Windows.Forms.LinkLabel();
            this.lblSignupPrompt = new System.Windows.Forms.Label();
            this.linkDangky = new System.Windows.Forms.LinkLabel();

            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconEmail)).BeginInit();
            this.panelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconPassword)).BeginInit();
            this.SuspendLayout();

            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelLeft.Controls.Add(this.picLogo);
            this.panelLeft.Controls.Add(this.lblWelcome);
            this.panelLeft.Controls.Add(this.lblSubTitle);
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(400, 600);
            this.panelLeft.TabIndex = 0;

            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(125, 150);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(150, 150);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;

            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(30, 320);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(340, 50);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Chào mừng";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.White;
            this.lblSubTitle.Location = new System.Drawing.Point(30, 370);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(340, 80);
            this.lblSubTitle.TabIndex = 2;
            this.lblSubTitle.Text = "Đăng nhập để tiếp tục sử dụng hệ thống quản lý bệnh viện";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.lblTitle);
            this.panelRight.Controls.Add(this.panelEmail);
            this.panelRight.Controls.Add(this.panelPassword);
            this.panelRight.Controls.Add(this.chkShowPassword);
            this.panelRight.Controls.Add(this.linkQuenMK);
            this.panelRight.Controls.Add(this.btDangnhap);
            this.panelRight.Controls.Add(this.lblSignupPrompt);
            this.panelRight.Controls.Add(this.linkDangky);
            this.panelRight.Location = new System.Drawing.Point(400, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(500, 600);
            this.panelRight.TabIndex = 1;

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitle.Location = new System.Drawing.Point(50, 80);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đăng nhập";

            // 
            // panelEmail
            // 
            this.panelEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelEmail.Controls.Add(this.picIconEmail);
            this.panelEmail.Controls.Add(this.txtEmail);
            this.panelEmail.Location = new System.Drawing.Point(50, 170);
            this.panelEmail.Name = "panelEmail";
            this.panelEmail.Size = new System.Drawing.Size(400, 50);
            this.panelEmail.TabIndex = 1;

            // 
            // picIconEmail
            // 
            this.picIconEmail.Location = new System.Drawing.Point(15, 12);
            this.picIconEmail.Name = "picIconEmail";
            this.picIconEmail.Size = new System.Drawing.Size(25, 25);
            this.picIconEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEmail.TabIndex = 0;
            this.picIconEmail.TabStop = false;

            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.txtEmail.Location = new System.Drawing.Point(50, 13);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(335, 25);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Text = "Email hoặc tên đăng nhập";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);

            // 
            // panelPassword
            // 
            this.panelPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelPassword.Controls.Add(this.picIconPassword);
            this.panelPassword.Controls.Add(this.txtPassword);
            this.panelPassword.Location = new System.Drawing.Point(50, 240);
            this.panelPassword.Name = "panelPassword";
            this.panelPassword.Size = new System.Drawing.Size(400, 50);
            this.panelPassword.TabIndex = 2;

            // 
            // picIconPassword
            // 
            this.picIconPassword.Location = new System.Drawing.Point(15, 12);
            this.picIconPassword.Name = "picIconPassword";
            this.picIconPassword.Size = new System.Drawing.Size(25, 25);
            this.picIconPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPassword.TabIndex = 0;
            this.picIconPassword.TabStop = false;

            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.txtPassword.Location = new System.Drawing.Point(50, 13);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(335, 25);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "Mật khẩu";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);

            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.chkShowPassword.Location = new System.Drawing.Point(50, 305);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(130, 24);
            this.chkShowPassword.TabIndex = 3;
            this.chkShowPassword.Text = "Hiển thị mật khẩu";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);

            // 
            // linkQuenMK
            // 
            this.linkQuenMK.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.linkQuenMK.AutoSize = true;
            this.linkQuenMK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linkQuenMK.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.linkQuenMK.Location = new System.Drawing.Point(340, 306);
            this.linkQuenMK.Name = "linkQuenMK";
            this.linkQuenMK.Size = new System.Drawing.Size(110, 20);
            this.linkQuenMK.TabIndex = 4;
            this.linkQuenMK.TabStop = true;
            this.linkQuenMK.Text = "Quên mật khẩu?";
            //this.linkQuenMK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkQuenMK_LinkClicked);

            // 
            // btDangnhap
            // 
            this.btDangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btDangnhap.FlatAppearance.BorderSize = 0;
            this.btDangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDangnhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btDangnhap.ForeColor = System.Drawing.Color.White;
            this.btDangnhap.Location = new System.Drawing.Point(50, 360);
            this.btDangnhap.Name = "btDangnhap";
            this.btDangnhap.Size = new System.Drawing.Size(400, 50);
            this.btDangnhap.TabIndex = 5;
            this.btDangnhap.Text = "ĐĂNG NHẬP";
            this.btDangnhap.UseVisualStyleBackColor = false;
            this.btDangnhap.Click += new System.EventHandler(this.btDangnhap_Click);
            this.btDangnhap.MouseEnter += new System.EventHandler(this.btDangnhap_MouseEnter);
            this.btDangnhap.MouseLeave += new System.EventHandler(this.btDangnhap_MouseLeave);

            // 
            // lblSignupPrompt
            // 
            this.lblSignupPrompt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSignupPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSignupPrompt.Location = new System.Drawing.Point(80, 480);
            this.lblSignupPrompt.Name = "lblSignupPrompt";
            this.lblSignupPrompt.Size = new System.Drawing.Size(180, 25);
            this.lblSignupPrompt.TabIndex = 6;
            this.lblSignupPrompt.Text = "Chưa có tài khoản?";
            this.lblSignupPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // linkDangky
            // 
            this.linkDangky.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.linkDangky.AutoSize = true;
            this.linkDangky.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.linkDangky.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.linkDangky.Location = new System.Drawing.Point(265, 482);
            this.linkDangky.Name = "linkDangky";
            this.linkDangky.Size = new System.Drawing.Size(115, 23);
            this.linkDangky.TabIndex = 7;
            this.linkDangky.TabStop = true;
            this.linkDangky.Text = "Đăng ký ngay";
            //this.linkDangky.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDangky_LinkClicked);

            // 
            // Dangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Hệ thống Bệnh viện";

            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelEmail.ResumeLayout(false);
            this.panelEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconEmail)).EndInit();
            this.panelPassword.ResumeLayout(false);
            this.panelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconPassword)).EndInit();
            this.ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelEmail;
        private System.Windows.Forms.PictureBox picIconEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel panelPassword;
        private System.Windows.Forms.PictureBox picIconPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.LinkLabel linkQuenMK;
        private System.Windows.Forms.Button btDangnhap;
        private System.Windows.Forms.Label lblSignupPrompt;
        private System.Windows.Forms.LinkLabel linkDangky;
    }
}