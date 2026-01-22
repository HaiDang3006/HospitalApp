using BenhVienS.Models;
using System;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class khbenh : UserControl
    {
        public khbenh() : this(new ExaminationForm())
        {
        }
        public khbenh(ExaminationForm examinationForm)
        {
            InitializeComponent();
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hsbnhan hsbnhan = new hsbnhan();
            //showControl; 
            //hsbnhan.ShowDialog();
        }
    }
}
