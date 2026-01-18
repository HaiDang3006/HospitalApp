namespace BenhVienS
{
    partial class frmvaitro
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
            this.label1 = new System.Windows.Forms.Label();
            this.radBacsi = new System.Windows.Forms.RadioButton();
            this.radThungan = new System.Windows.Forms.RadioButton();
            this.radLetan = new System.Windows.Forms.RadioButton();
            this.radDuocsi = new System.Windows.Forms.RadioButton();
            this.radBenhnhan = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(57, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vui lòng chọn vai trò muốn thêm mới";
            // 
            // radBacsi
            // 
            this.radBacsi.AutoSize = true;
            this.radBacsi.BackColor = System.Drawing.Color.White;
            this.radBacsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.radBacsi.Location = new System.Drawing.Point(60, 79);
            this.radBacsi.Name = "radBacsi";
            this.radBacsi.Size = new System.Drawing.Size(76, 22);
            this.radBacsi.TabIndex = 1;
            this.radBacsi.TabStop = true;
            this.radBacsi.Text = "Bác sĩ";
            this.radBacsi.UseVisualStyleBackColor = false;
            // 
            // radThungan
            // 
            this.radThungan.AutoSize = true;
            this.radThungan.BackColor = System.Drawing.Color.White;
            this.radThungan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.radThungan.Location = new System.Drawing.Point(60, 124);
            this.radThungan.Name = "radThungan";
            this.radThungan.Size = new System.Drawing.Size(98, 22);
            this.radThungan.TabIndex = 2;
            this.radThungan.TabStop = true;
            this.radThungan.Text = "Thu ngân";
            this.radThungan.UseVisualStyleBackColor = false;
            // 
            // radLetan
            // 
            this.radLetan.AutoSize = true;
            this.radLetan.BackColor = System.Drawing.Color.White;
            this.radLetan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.radLetan.Location = new System.Drawing.Point(61, 168);
            this.radLetan.Name = "radLetan";
            this.radLetan.Size = new System.Drawing.Size(75, 22);
            this.radLetan.TabIndex = 3;
            this.radLetan.TabStop = true;
            this.radLetan.Text = "Lễ tân";
            this.radLetan.UseVisualStyleBackColor = false;
            // 
            // radDuocsi
            // 
            this.radDuocsi.AutoSize = true;
            this.radDuocsi.BackColor = System.Drawing.Color.White;
            this.radDuocsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.radDuocsi.Location = new System.Drawing.Point(61, 208);
            this.radDuocsi.Name = "radDuocsi";
            this.radDuocsi.Size = new System.Drawing.Size(87, 22);
            this.radDuocsi.TabIndex = 4;
            this.radDuocsi.TabStop = true;
            this.radDuocsi.Text = "Dược sĩ";
            this.radDuocsi.UseVisualStyleBackColor = false;
            // 
            // radBenhnhan
            // 
            this.radBenhnhan.AutoSize = true;
            this.radBenhnhan.BackColor = System.Drawing.Color.White;
            this.radBenhnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.radBenhnhan.Location = new System.Drawing.Point(60, 254);
            this.radBenhnhan.Name = "radBenhnhan";
            this.radBenhnhan.Size = new System.Drawing.Size(108, 22);
            this.radBenhnhan.TabIndex = 5;
            this.radBenhnhan.TabStop = true;
            this.radBenhnhan.Text = "Bệnh nhân";
            this.radBenhnhan.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(28, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 262);
            this.panel1.TabIndex = 6;
            // 
            // frmvaitro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(459, 355);
            this.Controls.Add(this.radBenhnhan);
            this.Controls.Add(this.radDuocsi);
            this.Controls.Add(this.radLetan);
            this.Controls.Add(this.radThungan);
            this.Controls.Add(this.radBacsi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmvaitro";
            this.Text = "frmvaitro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radBacsi;
        private System.Windows.Forms.RadioButton radThungan;
        private System.Windows.Forms.RadioButton radLetan;
        private System.Windows.Forms.RadioButton radDuocsi;
        private System.Windows.Forms.RadioButton radBenhnhan;
        private System.Windows.Forms.Panel panel1;
    }
}