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
    public partial class uclichhensaptoi : UserControl
    {
        public uclichhensaptoi()
        {
            InitializeComponent();
        }

        private void lblSubTitle_Click(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            benhnhan frmBenhNhan = new benhnhan();
            frmBenhNhan.Show();
           
        }

    }
}
