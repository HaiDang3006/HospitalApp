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
    public partial class Bacsi : Form
    {
        private List<Control> _defaultPanelControls;
        string connectionString = @"Data Source=Huynhnhu;Initial Catalog = benhvienvs; Integrated Security = True; Trust Server Certificate=True";
        public Bacsi()
        {
            InitializeComponent();
            _defaultPanelControls = panelmenu.Controls.Cast<Control>().ToList();
            bttrangchu.Click += button5_Click;
        }
        private void showControl(Control control)
        {

            panelmenu.Controls.Clear();


            control.Dock = DockStyle.Fill;


            panelmenu.Controls.Add(control);
        }
        private void RestorePanelMenu()
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

        


        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dgvLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void lblChuyenKhoa_Click(object sender, EventArgs e)
        {

        }

        private void lblTen_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        

       

       
     

        private void button5_Click(object sender, EventArgs e)
        {
            RestorePanelMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ucqllichkham uc = new ucqllichkham();
            showControl(uc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dskham uc = new dskham();
            showControl(uc);
        }

        private void button8_Click(object sender, EventArgs e)
        {
           khbenh uc = new khbenh();
            showControl(uc);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            kdthuoc uc = new kdthuoc();
            showControl(uc);
        }

        private void button10_Click(object sender, EventArgs e)
        {

           hsbnhan uc = new hsbnhan();
            showControl(uc);
        }

        private void button11_Click(object sender, EventArgs e)
        {

            ttcnhan uc = new ttcnhan();
            showControl(uc);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            đmkhau uc = new đmkhau();
            showControl(uc);
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint_1(object sender, PaintEventArgs e)
        {

        }

        


       


        private void LoadNhatKy()
        {
            //dgvLog.Columns.Clear();
            //dgvLog.Rows.Clear();

            //dgvLog.Columns.Add("Time", "Thời Gian");
            //dgvLog.Columns.Add("NoiDung", "Hoạt Động");

            //dgvLog.Rows.Add("08:30", "Kê đơn thuốc cho Nguyễn Văn B");
            //dgvLog.Rows.Add("07:45", "Trần Văn E đã xuất viện");
            //dgvLog.Rows.Add("17:20", "Hồ Thị C tiến hành siêu âm tim");
        }


        private void LoadThongTinBacSi()
        {
            //txtHoten.Text = "Bs. Nguyễn Văn A";
            //txtChuyenkhoa.Text = "Bác Sĩ Nội Khoa";
            //txtSDT.Text = "0123 456 789";
            //txtEmail.Text = "nguyenvanabc@benhvienabc.com";
        }

        private void dgvLog_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
