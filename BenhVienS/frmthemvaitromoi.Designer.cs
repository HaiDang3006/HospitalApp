namespace BenhVienS
{
    partial class frmthemvaitromoi
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvvaitro = new System.Windows.Forms.DataGridView();
            this.btlammoi = new System.Windows.Forms.Button();
            this.btxoa = new System.Windows.Forms.Button();
            this.txtsua = new System.Windows.Forms.Button();
            this.btthem = new System.Windows.Forms.Button();
            this.cbtrangthai = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmota = new System.Windows.Forms.TextBox();
            this.txttenvaitro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmavaitro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvvaitro)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvvaitro);
            this.groupBox1.Controls.Add(this.btlammoi);
            this.groupBox1.Controls.Add(this.btxoa);
            this.groupBox1.Controls.Add(this.txtsua);
            this.groupBox1.Controls.Add(this.btthem);
            this.groupBox1.Controls.Add(this.cbtrangthai);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtmota);
            this.groupBox1.Controls.Add(this.txttenvaitro);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtmavaitro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(782, 468);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin vai trò";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvvaitro
            // 
            this.dgvvaitro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvvaitro.Location = new System.Drawing.Point(20, 212);
            this.dgvvaitro.Name = "dgvvaitro";
            this.dgvvaitro.RowHeadersWidth = 51;
            this.dgvvaitro.RowTemplate.Height = 24;
            this.dgvvaitro.Size = new System.Drawing.Size(745, 198);
            this.dgvvaitro.TabIndex = 12;
            this.dgvvaitro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvvaitro_CellContentClick);
            // 
            // btlammoi
            // 
            this.btlammoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btlammoi.Location = new System.Drawing.Point(640, 416);
            this.btlammoi.Name = "btlammoi";
            this.btlammoi.Size = new System.Drawing.Size(136, 46);
            this.btlammoi.TabIndex = 11;
            this.btlammoi.Text = "Làm mới";
            this.btlammoi.UseVisualStyleBackColor = true;
            this.btlammoi.Click += new System.EventHandler(this.btlammoi_Click);
            // 
            // btxoa
            // 
            this.btxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btxoa.Location = new System.Drawing.Point(544, 416);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(90, 46);
            this.btxoa.TabIndex = 10;
            this.btxoa.Text = "Xóa";
            this.btxoa.UseVisualStyleBackColor = true;
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
            // 
            // txtsua
            // 
            this.txtsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsua.Location = new System.Drawing.Point(448, 416);
            this.txtsua.Name = "txtsua";
            this.txtsua.Size = new System.Drawing.Size(90, 46);
            this.txtsua.TabIndex = 9;
            this.txtsua.Text = "Sửa";
            this.txtsua.UseVisualStyleBackColor = true;
            this.txtsua.Click += new System.EventHandler(this.txtsua_Click);
            // 
            // btthem
            // 
            this.btthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthem.Location = new System.Drawing.Point(352, 416);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(90, 46);
            this.btthem.TabIndex = 8;
            this.btthem.Text = "Thêm ";
            this.btthem.UseVisualStyleBackColor = true;
            this.btthem.Click += new System.EventHandler(this.btthem_Click);
            // 
            // cbtrangthai
            // 
            this.cbtrangthai.AutoSize = true;
            this.cbtrangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtrangthai.Location = new System.Drawing.Point(392, 165);
            this.cbtrangthai.Name = "cbtrangthai";
            this.cbtrangthai.Size = new System.Drawing.Size(122, 29);
            this.cbtrangthai.TabIndex = 7;
            this.cbtrangthai.Text = "Trạng thái";
            this.cbtrangthai.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(387, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mô tả";
            // 
            // txtmota
            // 
            this.txtmota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmota.Location = new System.Drawing.Point(468, 45);
            this.txtmota.Multiline = true;
            this.txtmota.Name = "txtmota";
            this.txtmota.Size = new System.Drawing.Size(298, 104);
            this.txtmota.TabIndex = 4;
            // 
            // txttenvaitro
            // 
            this.txttenvaitro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenvaitro.Location = new System.Drawing.Point(118, 97);
            this.txttenvaitro.Name = "txttenvaitro";
            this.txttenvaitro.Size = new System.Drawing.Size(182, 30);
            this.txttenvaitro.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên vai trò";
            // 
            // txtmavaitro
            // 
            this.txtmavaitro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmavaitro.Location = new System.Drawing.Point(118, 44);
            this.txtmavaitro.Name = "txtmavaitro";
            this.txtmavaitro.ReadOnly = true;
            this.txtmavaitro.Size = new System.Drawing.Size(100, 30);
            this.txtmavaitro.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã vai trò";
            // 
            // frmthemvaitromoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 492);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmthemvaitromoi";
            this.Text = "frmthemvaitromoi";
            this.Load += new System.EventHandler(this.frmthemvaitromoi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvvaitro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmota;
        private System.Windows.Forms.TextBox txttenvaitro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmavaitro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvvaitro;
        private System.Windows.Forms.Button btlammoi;
        private System.Windows.Forms.Button btxoa;
        private System.Windows.Forms.Button txtsua;
        private System.Windows.Forms.Button btthem;
        private System.Windows.Forms.CheckBox cbtrangthai;
    }
}