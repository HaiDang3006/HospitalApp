using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class hsbnhan : UserControl
    {
        public hsbnhan()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hsbnhan_Load(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            Form mainForm = this.FindForm();
            if (mainForm == null) return;

            // Tìm panel chứa UserControl (đổi tên nếu panel khác)
            Panel panelMain = mainForm.Controls.Find("panelMain", true)
                                              .FirstOrDefault() as Panel;

            if (panelMain != null)
            {
                panelMain.Controls.Clear();

                // Load lại UserControl Khám Bệnh
                hsbnhan kb = new hsbnhan();
                kb.Dock = DockStyle.Fill;
                panelMain.Controls.Add(kb);
            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
