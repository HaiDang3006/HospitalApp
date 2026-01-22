using BenhVienS.Common;
using BenhVienS.Enums;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BenhVienS
{
    partial class Bacsi
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

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelUser = new System.Windows.Forms.Panel();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnPatientList = new System.Windows.Forms.Button();
            this.btnExamine = new System.Windows.Forms.Button();
            this.btnPrescription = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cardNew = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.lblQuantityAppointment = new System.Windows.Forms.Label();
            this.cardReturning = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.picReturning = new System.Windows.Forms.PictureBox();
            this.lblReturning = new System.Windows.Forms.Label();
            this.lblReturningCount = new System.Windows.Forms.Label();
            this.cardDone = new System.Windows.Forms.Panel();
            this.picDone = new System.Windows.Forms.PictureBox();
            this.lblDone = new System.Windows.Forms.Label();
            this.lblQuantityWaiting = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelListWaitng = new System.Windows.Forms.Panel();
            this.CardWaitingExam = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblReasonsExamination = new System.Windows.Forms.Label();
            this.lblNamePatient = new System.Windows.Forms.Label();
            this.panelHeaderWaiting = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cardNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            this.cardReturning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReturning)).BeginInit();
            this.cardDone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDone)).BeginInit();
            this.panelContent.SuspendLayout();
            this.panelListWaitng.SuspendLayout();
            this.CardWaitingExam.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panelHeaderWaiting.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.panelUser);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1400, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(305, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁC SĨ BỆNH VIỆN S";
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.picUser);
            this.panelUser.Controls.Add(this.lblUserName);
            this.panelUser.Controls.Add(this.lblUserRole);
            this.panelUser.Controls.Add(this.btnLogout);
            this.panelUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelUser.Location = new System.Drawing.Point(788, 0);
            this.panelUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(349, 70);
            this.panelUser.TabIndex = 1;
            // 
            // picUser
            // 
            this.picUser.Location = new System.Drawing.Point(15, 8);
            this.picUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(51, 50);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.TabIndex = 0;
            this.picUser.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(80, 15);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(135, 23);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Bs. Nguyễn PiPi";
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserRole.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUserRole.Location = new System.Drawing.Point(80, 38);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(115, 20);
            this.lblUserRole.TabIndex = 2;
            this.lblUserRole.Text = "Bác Sĩ Nội Khoa";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(172, 16);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelLeft.Controls.Add(this.btnHome);
            this.panelLeft.Controls.Add(this.btnSchedule);
            this.panelLeft.Controls.Add(this.btnPatientList);
            this.panelLeft.Controls.Add(this.btnExamine);
            this.panelLeft.Controls.Add(this.btnPrescription);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 57);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panelLeft.Size = new System.Drawing.Size(188, 552);
            this.panelLeft.TabIndex = 1;
            this.panelLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeft_Paint);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(8, 16);
            this.btnHome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(229, 46);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "🏠  Trang Chủ";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseMnemonic = false;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.White;
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSchedule.Location = new System.Drawing.Point(8, 61);
            this.btnSchedule.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(229, 46);
            this.btnSchedule.TabIndex = 1;
            this.btnSchedule.Text = "📅  Lịch Hẹn Khám";
            this.btnSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnPatientList
            // 
            this.btnPatientList.BackColor = System.Drawing.Color.White;
            this.btnPatientList.FlatAppearance.BorderSize = 0;
            this.btnPatientList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPatientList.Location = new System.Drawing.Point(8, 106);
            this.btnPatientList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPatientList.Name = "btnPatientList";
            this.btnPatientList.Size = new System.Drawing.Size(229, 46);
            this.btnPatientList.TabIndex = 2;
            this.btnPatientList.Text = "📋  Danh Sách Bệnh Nhân";
            this.btnPatientList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatientList.UseVisualStyleBackColor = false;
            this.btnPatientList.Click += new System.EventHandler(this.btnPatientList_Click);
            // 
            // btnExamine
            // 
            this.btnExamine.BackColor = System.Drawing.Color.White;
            this.btnExamine.FlatAppearance.BorderSize = 0;
            this.btnExamine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamine.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExamine.Name = "btnExamine";
            this.btnExamine.Size = new System.Drawing.Size(229, 46);
            this.btnExamine.TabIndex = 3;
            this.btnExamine.Text = "🩺  Khám Bệnh";
            this.btnExamine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExamine.UseVisualStyleBackColor = false;
            // 
            // btnPrescription
            // 
            this.btnPrescription.BackColor = System.Drawing.Color.White;
            this.btnPrescription.FlatAppearance.BorderSize = 0;
            this.btnPrescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPrescription.Location = new System.Drawing.Point(8, 195);
            this.btnPrescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrescription.Name = "btnPrescription";
            this.btnPrescription.Size = new System.Drawing.Size(229, 46);
            this.btnPrescription.TabIndex = 4;
            this.btnPrescription.Text = "💊  Kê Đơn Thuốc";
            this.btnPrescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrescription.UseVisualStyleBackColor = false;
            this.btnPrescription.Click += new System.EventHandler(this.btnPrescription_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.panelMain.Controls.Add(this.panelStats);
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(188, 57);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.panelMain.Size = new System.Drawing.Size(1149, 680);
            this.panelMain.TabIndex = 2;
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.panel1);
            this.panelStats.Controls.Add(this.cardNew);
            this.panelStats.Controls.Add(this.cardReturning);
            this.panelStats.Controls.Add(this.cardDone);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(15, 16);
            this.panelStats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(1109, 100);
            this.panelStats.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(637, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 95);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(143, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dùng DV";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(250)))), ((int)(((byte)(229)))));
            this.pictureBox1.Image = global::BenhVienS.Properties.Resources.calendar__1_1;
            this.pictureBox1.Location = new System.Drawing.Point(15, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(141, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "BN đang";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(79, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 54);
            this.label2.TabIndex = 2;
            this.label2.Text = "0";
            // 
            // cardNew
            // 
            this.cardNew.BackColor = System.Drawing.Color.White;
            this.cardNew.Controls.Add(this.label5);
            this.cardNew.Controls.Add(this.picNew);
            this.cardNew.Controls.Add(this.lblNew);
            this.cardNew.Controls.Add(this.lblQuantityAppointment);
            this.cardNew.Location = new System.Drawing.Point(0, 0);
            this.cardNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cardNew.Name = "cardNew";
            this.cardNew.Size = new System.Drawing.Size(260, 95);
            this.cardNew.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(149, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Hôm Nay";
            // 
            // picNew
            // 
            this.picNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(205)))));
            this.picNew.Location = new System.Drawing.Point(15, 20);
            this.picNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picNew.Name = "picNew";
            this.picNew.Size = new System.Drawing.Size(45, 46);
            this.picNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picNew.TabIndex = 0;
            this.picNew.TabStop = false;
            this.picNew.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawClockIcon);
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNew.ForeColor = System.Drawing.Color.Gray;
            this.lblNew.Location = new System.Drawing.Point(149, 25);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(81, 23);
            this.lblNew.TabIndex = 1;
            this.lblNew.Text = "Lịch Hẹn ";
            // 
            // lblQuantityAppointment
            // 
            this.lblQuantityAppointment.AutoSize = true;
            this.lblQuantityAppointment.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblQuantityAppointment.Location = new System.Drawing.Point(80, 18);
            this.lblQuantityAppointment.Name = "lblQuantityAppointment";
            this.lblQuantityAppointment.Size = new System.Drawing.Size(46, 54);
            this.lblQuantityAppointment.TabIndex = 2;
            this.lblQuantityAppointment.Text = "3";
            // 
            // cardReturning
            // 
            this.cardReturning.BackColor = System.Drawing.Color.White;
            this.cardReturning.Controls.Add(this.label4);
            this.cardReturning.Controls.Add(this.picReturning);
            this.cardReturning.Controls.Add(this.lblReturning);
            this.cardReturning.Controls.Add(this.lblReturningCount);
            this.cardReturning.Location = new System.Drawing.Point(210, 0);
            this.cardReturning.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cardReturning.Name = "cardReturning";
            this.cardReturning.Size = new System.Drawing.Size(260, 95);
            this.cardReturning.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(135, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Đang Khám";
            // 
            // picReturning
            // 
            this.picReturning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.picReturning.Location = new System.Drawing.Point(15, 20);
            this.picReturning.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picReturning.Name = "picReturning";
            this.picReturning.Size = new System.Drawing.Size(45, 46);
            this.picReturning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picReturning.TabIndex = 0;
            this.picReturning.TabStop = false;
            this.picReturning.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawRefreshIcon);
            // 
            // lblReturning
            // 
            this.lblReturning.AutoSize = true;
            this.lblReturning.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReturning.ForeColor = System.Drawing.Color.Gray;
            this.lblReturning.Location = new System.Drawing.Point(135, 26);
            this.lblReturning.Name = "lblReturning";
            this.lblReturning.Size = new System.Drawing.Size(101, 23);
            this.lblReturning.TabIndex = 1;
            this.lblReturning.Text = "Bệnh Nhân ";
            // 
            // lblReturningCount
            // 
            this.lblReturningCount.AutoSize = true;
            this.lblReturningCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblReturningCount.Location = new System.Drawing.Point(77, 20);
            this.lblReturningCount.Name = "lblReturningCount";
            this.lblReturningCount.Size = new System.Drawing.Size(46, 54);
            this.lblReturningCount.TabIndex = 2;
            this.lblReturningCount.Text = "0";
            // 
            // cardDone
            // 
            this.cardDone.BackColor = System.Drawing.Color.White;
            this.cardDone.Controls.Add(this.picDone);
            this.cardDone.Controls.Add(this.lblDone);
            this.cardDone.Controls.Add(this.lblQuantityWaiting);
            this.cardDone.Location = new System.Drawing.Point(427, 0);
            this.cardDone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cardDone.Name = "cardDone";
            this.cardDone.Size = new System.Drawing.Size(260, 95);
            this.cardDone.TabIndex = 2;
            // 
            // picDone
            // 
            this.picDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(250)))), ((int)(((byte)(229)))));
            this.picDone.Location = new System.Drawing.Point(15, 20);
            this.picDone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picDone.Name = "picDone";
            this.picDone.Size = new System.Drawing.Size(45, 46);
            this.picDone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picDone.TabIndex = 0;
            this.picDone.TabStop = false;
            this.picDone.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawCheckIcon);
            // 
            // lblDone
            // 
            this.lblDone.AutoSize = true;
            this.lblDone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDone.ForeColor = System.Drawing.Color.Gray;
            this.lblDone.Location = new System.Drawing.Point(139, 36);
            this.lblDone.Name = "lblDone";
            this.lblDone.Size = new System.Drawing.Size(90, 23);
            this.lblDone.TabIndex = 1;
            this.lblDone.Text = "Chờ Khám";
            // 
            // lblQuantityWaiting
            // 
            this.lblQuantityWaiting.AutoSize = true;
            this.lblQuantityWaiting.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblQuantityWaiting.Location = new System.Drawing.Point(76, 18);
            this.lblQuantityWaiting.Name = "lblQuantityWaiting";
            this.lblQuantityWaiting.Size = new System.Drawing.Size(46, 54);
            this.lblQuantityWaiting.TabIndex = 2;
            this.lblQuantityWaiting.Text = "0";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelListWaitng);
            this.panelContent.Controls.Add(this.panel2);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(15, 16);
            this.panelContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1109, 640);
            this.panelContent.TabIndex = 1;
            // 
            // panelListWaitng
            // 
            this.panelListWaitng.BackColor = System.Drawing.Color.White;
            this.panelListWaitng.Controls.Add(this.CardWaitingExam);
            this.panelListWaitng.Controls.Add(this.panelHeaderWaiting);
            this.panelListWaitng.Location = new System.Drawing.Point(0, 86);
            this.panelListWaitng.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelListWaitng.Name = "panelListWaitng";
            this.panelListWaitng.Size = new System.Drawing.Size(541, 534);
            this.panelListWaitng.TabIndex = 5;
            this.panelListWaitng.Paint += new System.Windows.Forms.PaintEventHandler(this.panelListWaitng_Paint);
            // 
            // CardWaitingExam
            // 
            this.CardWaitingExam.BackColor = System.Drawing.Color.White;
            this.CardWaitingExam.Controls.Add(this.panel8);
            this.CardWaitingExam.Location = new System.Drawing.Point(1, 48);
            this.CardWaitingExam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CardWaitingExam.Name = "CardWaitingExam";
            this.CardWaitingExam.Padding = new System.Windows.Forms.Padding(0, 10, 11, 0);
            this.CardWaitingExam.Size = new System.Drawing.Size(539, 78);
            this.CardWaitingExam.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            // this.panel8.Controls.Add(this.btnCallExam);
            this.panel8.Controls.Add(this.lblReasonsExamination);
            this.panel8.Controls.Add(this.lblNamePatient);
            this.panel8.Location = new System.Drawing.Point(7, 7);
            this.panel8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(521, 59);
            this.panel8.TabIndex = 4;
            // 
            // btnCallExam
            // 
            // this.btnCallExam.BackColor = System.Drawing.Color.Blue;
            // this.btnCallExam.FlatAppearance.BorderSize = 0;
            // this.btnCallExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // this.btnCallExam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // this.btnCallExam.ForeColor = System.Drawing.Color.White;
            // this.btnCallExam.Location = new System.Drawing.Point(302, 12);
            // this.btnCallExam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // this.btnCallExam.Name = "btnCallExam";
            // this.btnCallExam.Size = new System.Drawing.Size(75, 24);
            // this.btnCallExam.TabIndex = 4;
            // this.btnCallExam.Text = "Gọi Khám";
            // this.btnCallExam.UseVisualStyleBackColor = false;
            // 
            // lblReasonsExamination
            // 
            this.lblReasonsExamination.AutoSize = true;
            this.lblReasonsExamination.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReasonsExamination.ForeColor = System.Drawing.Color.Gray;
            this.lblReasonsExamination.Location = new System.Drawing.Point(21, 32);
            this.lblReasonsExamination.Name = "lblReasonsExamination";
            this.lblReasonsExamination.Size = new System.Drawing.Size(284, 23);
            this.lblReasonsExamination.TabIndex = 3;
            this.lblReasonsExamination.Text = "Đau nữa đầu, sốt nhẹ, chóng mặt ...";
            // 
            // lblNamePatient
            // 
            this.lblNamePatient.AutoSize = true;
            this.lblNamePatient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamePatient.ForeColor = System.Drawing.Color.Black;
            this.lblNamePatient.Location = new System.Drawing.Point(20, 5);
            this.lblNamePatient.Name = "lblNamePatient";
            this.lblNamePatient.Size = new System.Drawing.Size(147, 28);
            this.lblNamePatient.TabIndex = 2;
            this.lblNamePatient.Text = "Nguyễn Văn A";
            // 
            // panelHeaderWaiting
            // 
            this.panelHeaderWaiting.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelHeaderWaiting.Controls.Add(this.label12);
            this.panelHeaderWaiting.Location = new System.Drawing.Point(2, 0);
            this.panelHeaderWaiting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelHeaderWaiting.Name = "panelHeaderWaiting";
            this.panelHeaderWaiting.Size = new System.Drawing.Size(401, 46);
            this.panelHeaderWaiting.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(16, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(233, 28);
            this.label12.TabIndex = 5;
            this.label12.Text = "🕐 Hàng đợi chờ khám";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(427, 86);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(541, 534);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(1, 54);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 10, 11, 0);
            this.panel4.Size = new System.Drawing.Size(539, 78);
            this.panel4.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(7, 7);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(394, 48);
            this.panel5.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(279, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Chuẩn đoán";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(21, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tên div";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(20, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 28);
            this.label8.TabIndex = 2;
            this.label8.Text = "Nguyễn Văn A";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 46);
            this.panel3.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(10, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(288, 21);
            this.label7.TabIndex = 4;
            this.label7.Text = "🧪 Bệnh Nhân đã có kết quả dịch vụ\r\n";
            // 
            // Bacsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Bacsi";
            this.Text = "Hệ Thống Bác Sĩ - Bệnh Viện S";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cardNew.ResumeLayout(false);
            this.cardNew.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            this.cardReturning.ResumeLayout(false);
            this.cardReturning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReturning)).EndInit();
            this.cardDone.ResumeLayout(false);
            this.cardDone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDone)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelListWaitng.ResumeLayout(false);
            this.CardWaitingExam.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panelHeaderWaiting.ResumeLayout(false);
            this.panelHeaderWaiting.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        // Drawing methods for icons
        private void DrawClockIcon(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(255, 193, 7), 3))
            {
                g.DrawEllipse(pen, 10, 10, 25, 25);
                g.DrawLine(pen, 22, 22, 22, 15);
                g.DrawLine(pen, 22, 22, 28, 22);
            }
        }

        private void DrawRefreshIcon(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(138, 43, 226), 3))
            {
                g.DrawArc(pen, 10, 10, 25, 25, 45, 270);
                System.Drawing.Point[] arrow1 = { new System.Drawing.Point(12, 12), new System.Drawing.Point(18, 10), new System.Drawing.Point(15, 16) };
                g.FillPolygon(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(138, 43, 226)), arrow1);
            }
        }

        private void DrawCheckIcon(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(34, 197, 94), 3))
            {
                g.DrawEllipse(pen, 10, 10, 25, 25);
                g.DrawLine(pen, 16, 22, 20, 26);
                g.DrawLine(pen, 20, 26, 28, 16);
            }
        }

        // Sample method to add patient cards
        private void AddPatientCard(FlowLayoutPanel flow, string name, string symptom, bool hasButton = true)
        {
            var card = new System.Windows.Forms.Panel
            {
                Size = new System.Drawing.Size(460, 80),
                BackColor = System.Drawing.Color.FromArgb(249, 250, 251),
                Margin = new System.Windows.Forms.Padding(10),
                Padding = new System.Windows.Forms.Padding(15)
            };

            var lblName = new System.Windows.Forms.Label
            {
                Text = name,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(15, 15),
                AutoSize = true
            };

            var lblSymptom = new System.Windows.Forms.Label
            {
                Text = symptom,
                Font = new System.Drawing.Font("Segoe UI", 9F),
                ForeColor = System.Drawing.Color.Gray,
                Location = new System.Drawing.Point(15, 40),
                AutoSize = true
            };

            card.Controls.Add(lblName);
            card.Controls.Add(lblSymptom);

            if (hasButton)
            {
                var btnCall = new System.Windows.Forms.Button
                {
                    Text = "Gọi khám",
                    Size = new System.Drawing.Size(100, 35),
                    Location = new System.Drawing.Point(340, 22),
                    BackColor = System.Drawing.Color.FromArgb(59, 130, 246),
                    ForeColor = System.Drawing.Color.White,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold),
                    Cursor = System.Windows.Forms.Cursors.Hand
                };
                btnCall.FlatAppearance.BorderSize = 0;
                card.Controls.Add(btnCall);
            }

            flow.Controls.Add(card);
        }

        //private void Bacsi_Load(object sender, System.EventArgs e)
        //{
        //    // Add sample patient data
        //    AddPatientCard(flowQueue, "Nguyễn Văn An", "Đau đầu, sốt nhẹ kéo dài 2 ngày");
        //    AddPatientCard(flowQueue, "Trần Thị Bình", "Kiểm tra sức khỏe định kỳ");
        //    AddPatientCard(flowQueue, "Lê Hoàng Cường", "Đau tức ngực, khó thở khi vận động mạnh");

        //    // If no results, show empty message
        //    if (flowResults.Controls.Count == 0)
        //    {
        //        lblEmptyResults.Visible = true;
        //    }
        //}
        // Declare all controls
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnPatientList;
        private System.Windows.Forms.Button btnExamine;
        private System.Windows.Forms.Button btnPrescription;

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel cardNew;
        private System.Windows.Forms.Label lblQuantityAppointment;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.PictureBox picNew;

        private System.Windows.Forms.Panel cardReturning;
        private System.Windows.Forms.Label lblReturningCount;
        private System.Windows.Forms.Label lblReturning;
        private System.Windows.Forms.PictureBox picReturning;

        private System.Windows.Forms.Panel cardDone;
        private System.Windows.Forms.Label lblQuantityWaiting;
        private System.Windows.Forms.Label lblDone;
        private System.Windows.Forms.PictureBox picDone;

        private System.Windows.Forms.Panel panelContent;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panelListWaitng;
        private Panel CardWaitingExam;
        private Panel panel8;
        private Label lblReasonsExamination;
        private Label lblNamePatient;
        private Panel panelHeaderWaiting;
        private Label label12;
        private Panel panel2;
        private Panel panel4;
        private Panel panel5;
        private Button button1;
        private Label label6;
        private Label label8;
        private Panel panel3;
        private Label label7;
    }


}