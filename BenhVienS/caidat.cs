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
    public partial class caidat : Form
    {
        private List<Control> _defaultPanelControls;
        public caidat()
        {
           
            InitializeComponent();

            _defaultPanelControls = panelthongtin.Controls.Cast<Control>().ToList();

            // Wire overview button to restore the original panel content.
            btdashboard.Click += btdashboard_Click;
        }

        private void showControl(Control control)
        {

            panelthongtin.Controls.Clear();


            control.Dock = DockStyle.Fill;


            panelthongtin.Controls.Add(control);
        }
        private void RestorePanelThongTin()
        {
            // Remove any runtime control(s)
            panelthongtin.Controls.Clear();

            // Re-add the original controls in the same order they were captured.
            // Controls keep their properties (Location, Dock, Size, etc.), so they will appear as designed.
            foreach (var ctrl in _defaultPanelControls)
            {
                panelthongtin.Controls.Add(ctrl);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btmatkhau_Click(object sender, EventArgs e)
        {
            ucmkadmin uc = new ucmkadmin();
            showControl(uc);
        }

        private void btqltkvpq_Click(object sender, EventArgs e)
        {
            ucqltaikhoanvaphanquyen uc = new ucqltaikhoanvaphanquyen();
            showControl(uc);
        }

        private void btdashboard_Click(object sender, EventArgs e)
        {
            RestorePanelThongTin();
        }
    }
}
