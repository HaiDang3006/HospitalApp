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
    public partial class frmvaitro : Form
    {
        public frmvaitro()
        {
            InitializeComponent();
        }

        private void frmvaitro_Load(object sender, EventArgs e)
        {

        }

        private void btnTieptuc_Click(object sender, EventArgs e)
        {
            Form f = null;

            if (radBacsi.Checked)
            {
                f = new frmThemBS();
            }
            else if (radThungan.Checked)
            {
                f = new frmThungan();
            }
            else if (radLetan.Checked)
            {
                f = new frmLetan();
            }
            else if (radDuocsi.Checked)
            {
                f = new frmDuocsi();
            }
            else if (radBenhnhan.Checked)
            {
                f = new frmbenhnhan();
            }
            else
            {
                MessageBox.Show(
                    "Vui lòng chọn vai trò trước khi tiếp tục",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // mở form thêm
            f.ShowDialog();

            // đóng form chọn vai trò
            this.Close();
        }
    }
}
