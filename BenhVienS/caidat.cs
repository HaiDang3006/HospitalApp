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
            _defaultPanelControls = panelmenu.Controls.Cast<Control>().ToList();
            btdashboard.Click += button4_Click;
        }

        private void showControl(Control control)
        {

            panelmenu.Controls.Clear();


            control.Dock = DockStyle.Fill;


            panelmenu.Controls.Add(control);
        }
        private void RestorePanelmenu()
        {
            // Remove any runtime control(s)
            panelmenu.Controls.Clear();

            // Re-add the original controls in the same order they were captured.
            // Controls keep their properties (Location, Dock, Size, etc.), so they will appear as designed.
            foreach (var ctrl in _defaultPanelControls)
            {
                panelmenu.Controls.Add(ctrl);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            RestorePanelmenu();
        }

        private void caidat_Load(object sender, EventArgs e)
        {

        }

        private void panelmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btmatkhau_Click(object sender, EventArgs e)
        {
            panelmenu.Controls.Clear();

            ucdoimkadmin f = new ucdoimkadmin();
            f.TopLevel = false;              // ⭐ BẮT BUỘC
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;

            panelmenu.Controls.Add(f);
            f.Show();
        }

        private void btqltkvpq_Click(object sender, EventArgs e)
        {
            ucqltaikhoanvaphanquyen uc = new ucqltaikhoanvaphanquyen();
            showControl(uc);
        }
    }
}
