using BenhVienS.Models;
using BenhVienS.Service.AppointmentService;
using BenhVienS.Service.PatientService;
using BenhVienS.Service.UserService;
using System;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class khbenh : UserControl
    {
        private ExaminationForm examinationForm;
        PatientService patientService = new PatientService();
        UserService userService = new UserService();
        AppointmentService appointmentService = new AppointmentService();
        public khbenh() : this(new ExaminationForm())
        {
        }
        public khbenh(ExaminationForm examinationForm)
        {
            InitializeComponent();
            this.examinationForm = examinationForm;
             init();
        }

        private void init()
        {
            loadData();

        }

        private void loadData()
        {
            txtNamePatient.Text = userService.UserByExaminaId(examinationForm.Id).FullName ?? "Chưa có tên";
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
