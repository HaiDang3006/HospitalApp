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
    public partial class ucCD : UserControl
    {
        public ucCD()
        {
            InitializeComponent();

        }

        private void btdangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
   "Bạn có chắc muốn đăng xuất không?",
   "Xác nhận",
   MessageBoxButtons.YesNo,
   MessageBoxIcon.Question
);

            if (result == DialogResult.Yes)
            {
                Form parentForm = this.FindForm(); // LẤY FORM CHA (FormDượcSĩ)

                parentForm.Hide(); // ẨN TOÀN BỘ FORM DƯỢC SĨ

                Form1 frmLogin = new Form1();
                frmLogin.Show();
            }
        }

        private void ucCD_Load(object sender, EventArgs e)
        {

        }
    }
}
