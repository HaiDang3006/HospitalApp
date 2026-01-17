using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BenhVienS
{
    public partial class Form2 : Form

    {
        void LoadDanhSachBenhNhan()
        {
            

           /* using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT MaBenhNhan, HoTen, GioiTinh, NgaySinh, SoDienThoai, DiaChi FROM BenhNhan",
                    conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvbenhnhan.AutoGenerateColumns = true;
                dgvbenhnhan.DataSource = dt;
            }*/
        }
        // Thêm dấu @ và bao quanh bằng dấu ngoặc kép ""
       

        public Form2()
        {
            InitializeComponent();
            
        }

        
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e) { 


        }

        private void btQlibenhnhan_Click(object sender, EventArgs e)
        {


           

        }

        private void btQlibacsi_Click(object sender, EventArgs e)
        {
            
        }

        private void btTongquan_Click(object sender, EventArgs e)
        {
            
        }

        private void btQlilichkham_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            LoadDanhSachBenhNhan();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            thembenhnhan f = new thembenhnhan();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachBenhNhan();
            }

        }

        private void btsua_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Ltlmoi_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

