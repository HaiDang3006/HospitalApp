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
    public partial class Thungan : Form
    {
        public Thungan()
        {
            InitializeComponent();
        }

        private void dgvBenhNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }
        private void FrmThuNgan_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Thungan_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ttvphi uc = new ttvphi();
            ShowControl(uc);
        }

        // Add this method to show a UserControl in the form
        private void ShowControl(UserControl control)
        {
            control.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(control);
            control.BringToFront();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}