namespace BenhVienS
{
    partial class ucLetan_Benhnhan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbbenhnhan = new System.Windows.Forms.Label();
            this.lbdanhsachbenhnhan = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lbdanhsachbenhnhan);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 780);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbbenhnhan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1282, 69);
            this.panel2.TabIndex = 0;
            // 
            // lbbenhnhan
            // 
            this.lbbenhnhan.AutoSize = true;
            this.lbbenhnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbenhnhan.Location = new System.Drawing.Point(490, 23);
            this.lbbenhnhan.Name = "lbbenhnhan";
            this.lbbenhnhan.Size = new System.Drawing.Size(141, 29);
            this.lbbenhnhan.TabIndex = 0;
            this.lbbenhnhan.Text = "Bệnh Nhân";
            // 
            // lbdanhsachbenhnhan
            // 
            this.lbdanhsachbenhnhan.AutoSize = true;
            this.lbdanhsachbenhnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdanhsachbenhnhan.Location = new System.Drawing.Point(3, 72);
            this.lbdanhsachbenhnhan.Name = "lbdanhsachbenhnhan";
            this.lbdanhsachbenhnhan.Size = new System.Drawing.Size(213, 22);
            this.lbdanhsachbenhnhan.TabIndex = 1;
            this.lbdanhsachbenhnhan.Text = "Danh Sách Bệnh Nhân";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(7, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(434, 322);
            this.panel3.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(439, 22);
            this.textBox1.TabIndex = 3;
            // 
            // ucLetan_Benhnhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucLetan_Benhnhan";
            this.Size = new System.Drawing.Size(1282, 780);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbbenhnhan;
        private System.Windows.Forms.Label lbdanhsachbenhnhan;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
    }
}
