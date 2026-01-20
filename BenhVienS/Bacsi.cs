using BenhVienS.Service.AppointmentService;
using BenhVienS.Service.DoctorSerice;
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
        DoctorService doctorService = new DoctorService();
        AppointmentService appointmentService = new AppointmentService();
        private List<Control> _defaultPanelControls;
        string connectionString = @"Data Source=Huynhnhu;Initial Catalog = benhvienvs; Integrated Security = True; Trust Server Certificate=True";
        public Bacsi()
        {
            InitializeComponent();
            _defaultPanelControls = panelMain.Controls.Cast<Control>().ToList();
            btnHome.Click += button5_Click;
            //
            Load += init;
        }

        private void showControl(Control control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        private void RestorePanelMenu()
        {
            // Remove any runtime control(s)
            panelMain.Controls.Clear();
            // Re-add the original controls in the same order they were captured.
            // Controls keep their properties (Location, Dock, Size, etc.), so they will appear as designed.
            foreach (var ctrl in _defaultPanelControls)
            {
                panelMain.Controls.Add(ctrl);
            }
        }

        private void init(object sender, EventArgs e)
        {
            appointmentInit();
            //LoadCongViec();
            //LoadNhatKy();
            //LoadThongTinBacSi();
        }

        private void appointmentInit()
        {
            int doctorId = 1; // thay bằng token đăng nhập
            // check id null o day
            if (doctorService.DoctorById(doctorId) == null)
                // sau nay xoa cookie va chuyen ra dang nhap
                return;
            // hàm này là set giá trị lên label trên giao diện 
            // appointmentService.CountAppointmentTodayByDoctor là gọi hàm đè ctrl vào CountAppointmentTodayByDoctor để coi hàm được gọi
            lblQuantityAppointment.Text = Convert.ToString(appointmentService.CountAppointmentTodayByDoctor(doctorId)); ;
        }





        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            /*dgvLichkhambenh.Columns.Add("BenhNhan", "Bệnh Nhân");
            dgvLichkhambenh.Columns.Add("ThoiGian", "Thời Gian");
            dgvLichkhambenh.Columns.Add("LoaiKham", "Loại Khám");
            dgvLichkhambenh.Columns.Add("PhongKham", "Phòng Khám");
            dgvLichkhambenh.Columns.Add("TrangThai", "Trạng Thái");
            dgvLichkhambenh.Rows.Add("Nguyễn Văn B", "08:00", "Nội Khoa", "Phòng 101", "Đã Khám");
            dgvLichkhambenh.Rows.Add("Trần Thị C", "08:45", "Nội Khoa", "Phòng 101", "Chờ Khám");
            dgvLichkhambenh.Rows.Add("Hoàng Văn D", "09:30", "Nội Khoa", "Phòng 101", "Chưa Khám");



            foreach (DataGridViewRow row in dgvLichkhambenh.Rows)
            {
                string status = row.Cells["TrangThai"].Value?.ToString();
                if (status == "Đã Khám")
                    row.Cells["TrangThai"].Style.BackColor = Color.LightGreen;
                else if (status == "Chờ Khám")
                    row.Cells["TrangThai"].Style.BackColor = Color.Orange;
                else
                    row.Cells["TrangThai"].Style.BackColor = Color.LightBlue;
            }*/
            }

     

        private void button5_Click(object sender, EventArgs e)
        {
            RestorePanelMenu();
        }

        private void LoadLichKham()
        {
            /*dgvLichkhambenh.Columns.Clear();
            dgvLichkhambenh.Rows.Clear();

            dgvLichkhambenh.Columns.Add("BenhNhan", "Bệnh Nhân");
            dgvLichkhambenh.Columns.Add("ThoiGian", "Thời Gian");
            dgvLichkhambenh.Columns.Add("LoaiKham", "Loại Khám");
            dgvLichkhambenh.Columns.Add("PhongKham", "Phòng Khám");
            dgvLichkhambenh.Columns.Add("TrangThai", "Trạng Thái");

            dgvLichkhambenh.Rows.Add("Nguyễn Văn B", "08:00", "Nội Khoa", "Phòng 101", "Đã Khám");
            dgvLichkhambenh.Rows.Add("Trần Thị C", "08:45", "Nội Khoa", "Phòng 101", "Chờ Khám");
            dgvLichkhambenh.Rows.Add("Hoàng Văn D", "09:30", "Nội Khoa", "Phòng 101", "Chưa Khám");

            foreach (DataGridViewRow row in dgvLichkhambenh.Rows)
            {
                if (row.Cells["TrangThai"].Value == null) continue;

                string status = row.Cells["TrangThai"].Value.ToString();
                if (status == "Đã Khám")
                    row.Cells["TrangThai"].Style.BackColor = Color.LightGreen;
                else if (status == "Chờ Khám")
                    row.Cells["TrangThai"].Style.BackColor = Color.Orange;
                else
                    row.Cells["TrangThai"].Style.BackColor = Color.LightBlue;
            }*/
        }


        private void LoadCongViec()
        {
           /* listView1.Clear();
            listView1.View = View.Details;

            listView1.Columns.Add("Công Việc", 350);

            listView1.Items.Add("Xử lý kết quả xét nghiệm cho bệnh nhân Phạm Thị H");
            listView1.Items.Add("Đọc kết quả siêu âm tim của Trần Văn E");
            listView1.Items.Add("Trao đổi với bệnh nhân Lê Thị F đã nhập viện hôm qua");
            listView1.Items.Add("Kiểm tra phản ứng thuốc của bệnh nhân Nguyễn Văn B");*/
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

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ucqllichkham uc = new ucqllichkham();
            showControl(uc);
        }

        private void btnPatientList_Click(object sender, EventArgs e)
        {
            dskham uc = new dskham();
            showControl(uc);
        }

        private void btnExamine_Click(object sender, EventArgs e)
        {
            khbenh uc = new khbenh();
            showControl(uc);
        }

        private void btnPrescription_Click(object sender, EventArgs e)
        {
            kdthuoc uc = new kdthuoc();
            showControl(uc);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }
    }
}
