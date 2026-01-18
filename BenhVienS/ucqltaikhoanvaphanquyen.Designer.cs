namespace BenhVienS
{
    partial class ucqltaikhoanvaphanquyen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vaitro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btkhoamo = new System.Windows.Forms.Button();
            this.btxoa = new System.Windows.Forms.Button();
            this.btsua = new System.Windows.Forms.Button();
            this.btthem = new System.Windows.Forms.Button();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.cbvaitro = new System.Windows.Forms.ComboBox();
            this.lblvaitro = new System.Windows.Forms.Label();
            this.lblhoten = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lblname = new System.Windows.Forms.Label();
            this.ckbkichhoat = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btluu = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ckbxoa = new System.Windows.Forms.CheckBox();
            this.ckbsua = new System.Windows.Forms.CheckBox();
            this.ckbthem = new System.Windows.Forms.CheckBox();
            this.ckbxem = new System.Windows.Forms.CheckBox();
            this.lblphanquyen = new System.Windows.Forms.Label();
            this.lbltk = new System.Windows.Forms.Label();
            this.lblDash = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.username,
            this.hoten,
            this.vaitro,
            this.trangthai});
            this.dataGridView1.Location = new System.Drawing.Point(6, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(552, 200);
            this.dataGridView1.TabIndex = 0;
            // 
            // username
            // 
            this.username.HeaderText = "Username";
            this.username.MinimumWidth = 6;
            this.username.Name = "username";
            this.username.Width = 125;
            // 
            // hoten
            // 
            this.hoten.HeaderText = "Họ tên";
            this.hoten.MinimumWidth = 6;
            this.hoten.Name = "hoten";
            this.hoten.Width = 125;
            // 
            // vaitro
            // 
            this.vaitro.HeaderText = "Vai trò";
            this.vaitro.MinimumWidth = 6;
            this.vaitro.Name = "vaitro";
            this.vaitro.Width = 125;
            // 
            // trangthai
            // 
            this.trangthai.HeaderText = "Trạng thái";
            this.trangthai.MinimumWidth = 6;
            this.trangthai.Name = "trangthai";
            this.trangthai.Width = 125;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(3, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 227);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách tài khoản";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btkhoamo);
            this.groupBox2.Controls.Add(this.btxoa);
            this.groupBox2.Controls.Add(this.btsua);
            this.groupBox2.Controls.Add(this.lblname);
            this.groupBox2.Controls.Add(this.btthem);
            this.groupBox2.Controls.Add(this.txthoten);
            this.groupBox2.Controls.Add(this.cbvaitro);
            this.groupBox2.Controls.Add(this.lblvaitro);
            this.groupBox2.Controls.Add(this.lblhoten);
            this.groupBox2.Controls.Add(this.txtname);
            this.groupBox2.Controls.Add(this.ckbkichhoat);
            this.groupBox2.Location = new System.Drawing.Point(3, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(569, 279);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin tài khoản";
            // 
            // btkhoamo
            // 
            this.btkhoamo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btkhoamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btkhoamo.Location = new System.Drawing.Point(357, 237);
            this.btkhoamo.Name = "btkhoamo";
            this.btkhoamo.Size = new System.Drawing.Size(111, 36);
            this.btkhoamo.TabIndex = 11;
            this.btkhoamo.Text = "Khóa/ Mở";
            this.btkhoamo.UseVisualStyleBackColor = false;
            // 
            // btxoa
            // 
            this.btxoa.BackColor = System.Drawing.Color.DarkRed;
            this.btxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btxoa.ForeColor = System.Drawing.Color.White;
            this.btxoa.Location = new System.Drawing.Point(240, 237);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(111, 36);
            this.btxoa.TabIndex = 10;
            this.btxoa.Text = "Xóa";
            this.btxoa.UseVisualStyleBackColor = false;
            // 
            // btsua
            // 
            this.btsua.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsua.ForeColor = System.Drawing.Color.White;
            this.btsua.Location = new System.Drawing.Point(123, 237);
            this.btsua.Name = "btsua";
            this.btsua.Size = new System.Drawing.Size(111, 36);
            this.btsua.TabIndex = 9;
            this.btsua.Text = "Sửa";
            this.btsua.UseVisualStyleBackColor = false;
            // 
            // btthem
            // 
            this.btthem.BackColor = System.Drawing.Color.ForestGreen;
            this.btthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthem.ForeColor = System.Drawing.Color.White;
            this.btthem.Location = new System.Drawing.Point(6, 237);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(111, 36);
            this.btthem.TabIndex = 8;
            this.btthem.Text = "Thêm";
            this.btthem.UseVisualStyleBackColor = false;
            // 
            // txthoten
            // 
            this.txthoten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthoten.Location = new System.Drawing.Point(104, 85);
            this.txthoten.Multiline = true;
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(266, 30);
            this.txthoten.TabIndex = 7;
            // 
            // cbvaitro
            // 
            this.cbvaitro.FormattingEnabled = true;
            this.cbvaitro.Location = new System.Drawing.Point(104, 135);
            this.cbvaitro.Name = "cbvaitro";
            this.cbvaitro.Size = new System.Drawing.Size(121, 24);
            this.cbvaitro.TabIndex = 6;
            // 
            // lblvaitro
            // 
            this.lblvaitro.AutoSize = true;
            this.lblvaitro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvaitro.ForeColor = System.Drawing.Color.Black;
            this.lblvaitro.Location = new System.Drawing.Point(6, 133);
            this.lblvaitro.Name = "lblvaitro";
            this.lblvaitro.Size = new System.Drawing.Size(62, 22);
            this.lblvaitro.TabIndex = 5;
            this.lblvaitro.Text = "Vai trò";
            // 
            // lblhoten
            // 
            this.lblhoten.AutoSize = true;
            this.lblhoten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhoten.ForeColor = System.Drawing.Color.Black;
            this.lblhoten.Location = new System.Drawing.Point(6, 85);
            this.lblhoten.Name = "lblhoten";
            this.lblhoten.Size = new System.Drawing.Size(70, 22);
            this.lblhoten.TabIndex = 4;
            this.lblhoten.Text = "Họ Tên";
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(104, 26);
            this.txtname.Multiline = true;
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(266, 30);
            this.txtname.TabIndex = 3;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.BackColor = System.Drawing.Color.Transparent;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.Black;
            this.lblname.Location = new System.Drawing.Point(6, 29);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(92, 22);
            this.lblname.TabIndex = 2;
            this.lblname.Text = "Username";
            // 
            // ckbkichhoat
            // 
            this.ckbkichhoat.AutoSize = true;
            this.ckbkichhoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbkichhoat.ForeColor = System.Drawing.Color.Black;
            this.ckbkichhoat.Location = new System.Drawing.Point(10, 193);
            this.ckbkichhoat.Name = "ckbkichhoat";
            this.ckbkichhoat.Size = new System.Drawing.Size(185, 26);
            this.ckbkichhoat.TabIndex = 1;
            this.ckbkichhoat.Text = "Kích hoạt tài khoản";
            this.ckbkichhoat.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.btluu);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.ckbxoa);
            this.groupBox3.Controls.Add(this.ckbsua);
            this.groupBox3.Controls.Add(this.ckbthem);
            this.groupBox3.Controls.Add(this.ckbxem);
            this.groupBox3.Controls.Add(this.lblphanquyen);
            this.groupBox3.Controls.Add(this.lbltk);
            this.groupBox3.Controls.Add(this.lblDash);
            this.groupBox3.Enabled = false;
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(578, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(409, 221);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Phân quyền";
            // 
            // btluu
            // 
            this.btluu.BackColor = System.Drawing.Color.Firebrick;
            this.btluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btluu.ForeColor = System.Drawing.Color.White;
            this.btluu.Location = new System.Drawing.Point(275, 179);
            this.btluu.Name = "btluu";
            this.btluu.Size = new System.Drawing.Size(85, 36);
            this.btluu.TabIndex = 12;
            this.btluu.Text = "Lưu";
            this.btluu.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.ForeColor = System.Drawing.Color.Black;
            this.checkBox3.Location = new System.Drawing.Point(190, 139);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(53, 20);
            this.checkBox3.TabIndex = 22;
            this.checkBox3.Text = "Sửa";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.Color.Black;
            this.checkBox2.Location = new System.Drawing.Point(115, 139);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(54, 20);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.Text = "xem";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(115, 89);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(54, 20);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "xem";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ckbxoa
            // 
            this.ckbxoa.AutoSize = true;
            this.ckbxoa.ForeColor = System.Drawing.Color.Black;
            this.ckbxoa.Location = new System.Drawing.Point(337, 89);
            this.ckbxoa.Name = "ckbxoa";
            this.ckbxoa.Size = new System.Drawing.Size(53, 20);
            this.ckbxoa.TabIndex = 19;
            this.ckbxoa.Text = "Xóa";
            this.ckbxoa.UseVisualStyleBackColor = true;
            // 
            // ckbsua
            // 
            this.ckbsua.AutoSize = true;
            this.ckbsua.ForeColor = System.Drawing.Color.Black;
            this.ckbsua.Location = new System.Drawing.Point(275, 89);
            this.ckbsua.Name = "ckbsua";
            this.ckbsua.Size = new System.Drawing.Size(53, 20);
            this.ckbsua.TabIndex = 18;
            this.ckbsua.Text = "Sửa";
            this.ckbsua.UseVisualStyleBackColor = true;
            // 
            // ckbthem
            // 
            this.ckbthem.AutoSize = true;
            this.ckbthem.ForeColor = System.Drawing.Color.Black;
            this.ckbthem.Location = new System.Drawing.Point(190, 89);
            this.ckbthem.Name = "ckbthem";
            this.ckbthem.Size = new System.Drawing.Size(64, 20);
            this.ckbthem.TabIndex = 17;
            this.ckbthem.Text = "Thêm";
            this.ckbthem.UseVisualStyleBackColor = true;
            // 
            // ckbxem
            // 
            this.ckbxem.AutoSize = true;
            this.ckbxem.ForeColor = System.Drawing.Color.Black;
            this.ckbxem.Location = new System.Drawing.Point(115, 39);
            this.ckbxem.Name = "ckbxem";
            this.ckbxem.Size = new System.Drawing.Size(54, 20);
            this.ckbxem.TabIndex = 16;
            this.ckbxem.Text = "xem";
            this.ckbxem.UseVisualStyleBackColor = true;
            // 
            // lblphanquyen
            // 
            this.lblphanquyen.AutoSize = true;
            this.lblphanquyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblphanquyen.ForeColor = System.Drawing.Color.Black;
            this.lblphanquyen.Location = new System.Drawing.Point(3, 135);
            this.lblphanquyen.Name = "lblphanquyen";
            this.lblphanquyen.Size = new System.Drawing.Size(106, 22);
            this.lblphanquyen.TabIndex = 14;
            this.lblphanquyen.Text = "Phân quyền";
            // 
            // lbltk
            // 
            this.lbltk.AutoSize = true;
            this.lbltk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltk.ForeColor = System.Drawing.Color.Black;
            this.lbltk.Location = new System.Drawing.Point(6, 85);
            this.lbltk.Name = "lbltk";
            this.lbltk.Size = new System.Drawing.Size(90, 22);
            this.lbltk.TabIndex = 13;
            this.lbltk.Text = "Tài khoản";
            this.lbltk.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDash.ForeColor = System.Drawing.Color.Black;
            this.lblDash.Location = new System.Drawing.Point(6, 35);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(103, 22);
            this.lblDash.TabIndex = 12;
            this.lblDash.Text = "Dashboard ";
            // 
            // ucqltaikhoanvaphanquyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucqltaikhoanvaphanquyen";
            this.Size = new System.Drawing.Size(990, 555);
            this.Load += new System.EventHandler(this.ucqltaikhoanvaphanquyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.ComboBox cbvaitro;
        private System.Windows.Forms.Label lblvaitro;
        private System.Windows.Forms.Label lblhoten;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.CheckBox ckbkichhoat;
        private System.Windows.Forms.Button btkhoamo;
        private System.Windows.Forms.Button btxoa;
        private System.Windows.Forms.Button btsua;
        private System.Windows.Forms.Button btthem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ckbxoa;
        private System.Windows.Forms.CheckBox ckbsua;
        private System.Windows.Forms.CheckBox ckbthem;
        private System.Windows.Forms.CheckBox ckbxem;
        private System.Windows.Forms.Label lblphanquyen;
        private System.Windows.Forms.Label lbltk;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn vaitro;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
        private System.Windows.Forms.Button btluu;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
