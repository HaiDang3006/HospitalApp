using BenhVienS.Common;
using BenhVienS.Enums;
using BenhVienS.Helper_UI;
using BenhVienS.Models;
using BenhVienS.Service.AppointmentService;
using BenhVienS.Service.DoctorSerice;
using BenhVienS.Service.ExaminationFormService;
using BenhVienS.Service.PatientService;
using BenhVienS.Service.UserService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace BenhVienS
{
    public partial class Bacsi : Form
    {
        DoctorService doctorService = new DoctorService();
        AppointmentService appointmentService = new AppointmentService();
        PatientService patientService = new PatientService();
        UserService userService = new UserService();
        ExaminationFormService examinationFormService = new ExaminationFormService();

        UserSession session = SessionManager.Load();
        private List<Control> _defaultPanelControls;
        public Bacsi()
        {
            try
            {
                new Guard(AppContextCustom.Instance.Auth).Require(RoleEnum.Doctor);
                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;
                _defaultPanelControls = panelMain.Controls.Cast<Control>().ToList();
                btnHome.Click += button5_Click;
                Load += init;
                lblUserName.Text = session.Username;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        private void showControl(Control control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        private void RestorePanelMenu()
        {
            panelMain.Controls.Clear();
            foreach (var ctrl in _defaultPanelControls)
            {
                panelMain.Controls.Add(ctrl);
            }
        }

        private void init(object sender, EventArgs e)
        {
            loadUI();
            appointmentInit();
            WaitingExamInit(); // Gọi để hiển thị danh sách chờ khám
        }

        private void loadUI()
        {
            GraphicsHelpers.SetBorderRadius(cardNew, 10);
            GraphicsHelpers.SetBorderRadius(cardReturning, 10);
            GraphicsHelpers.SetBorderRadius(cardDone, 10);
            GraphicsHelpers.SetBorderRadius(panel1, 10);

            // Bo tròn 2 danh sách
            GraphicsHelpers.SetBorderRadius(panelListWaitng, 12);
            GraphicsHelpers.SetBorderRadius(panel2, 12);
        }

        private void appointmentInit()
        {
            lblQuantityAppointment.Text = Convert.ToString(appointmentService.CountAppointmentTodayByStatusAndDoctor(
                                                                doctorService.DoctorByUserId(SessionManager.Load().UserId).Id, "DaXacNhan"));
        }

        private void WaitingExamInit()
        {
            List<Appointment> appointmentList = appointmentService.AppointmentTodayByStatusAndDoctor(doctorService.DoctorByUserId(session.UserId).Id, "DaDen");

            // Hiển thị danh sách lên giao diện
            FillCardWaiting(appointmentList);
        }

        // Method hiển thị danh sách bệnh nhân
        private void FillCardWaiting(List<Appointment> appointmentList)
        {
            // Ẩn card mẫu ban đầu
            CardWaitingExam.Visible = false;

            // Xóa các card cũ (giữ lại panelHeaderWaiting)
            var cardsToRemove = panelListWaitng.Controls
                .OfType<Panel>()
                .Where(p => p != panelHeaderWaiting && p != CardWaitingExam)
                .ToList();

            foreach (var card in cardsToRemove)
            {
                panelListWaitng.Controls.Remove(card);
                card.Dispose();
            }

            // Kiểm tra nếu không có bệnh nhân
            if (appointmentList == null || appointmentList.Count == 0)
            {
                lblQuantityWaiting.Text = "0";
                return;
            }

            // Tạo card mới cho từng bệnh nhân
            for (int i = 0; i < appointmentList.Count; i++)
            {
                Panel card = CloneCardWaiting(appointmentList[i], i);
                panelListWaitng.Controls.Add(card);
            }

            // Cập nhật số lượng
            lblQuantityWaiting.Text = appointmentList.Count.ToString();

            // Bật AutoScroll nếu có nhiều bệnh nhân
            if (appointmentList.Count > 5)
            {
                panelListWaitng.AutoScroll = true;
            }

        }

        private Panel CloneCardWaiting(Appointment appointment, int viTri)
        {
            // Clone panel chính
            Panel newCard = new Panel
            {
                BackColor = CardWaitingExam.BackColor,
                Size = CardWaitingExam.Size,
                Padding = CardWaitingExam.Padding,
                Location = new Point(1, 48 + (viTri * 60)), // 48 = header height, 70 = card height + margin
                Name = "card_" + viTri
            };

            // Clone panel8 bên trong
            Panel innerPanel = new Panel
            {
                BackColor = panel8.BackColor,
                Size = panel8.Size,
                Location = panel8.Location
            };

            // Clone và cập nhật label tên bệnh nhân
            Label lblTen = new Label
            {
                Text = userService.UserById(patientService.PatientById(appointment.PatientId).Id).FullName ?? "Chưa có tên", // Sử dụng thuộc tính Ten của Appointment
                Font = lblNamePatient.Font,
                ForeColor = lblNamePatient.ForeColor,
                Location = lblNamePatient.Location,
                AutoSize = lblNamePatient.AutoSize
            };

            // Clone và cập nhật label lý do khám
            Label lblLyDo = new Label
            {
                Text = appointment.Reasion ?? "Chưa có lý do", // Sử dụng thuộc tính LyDoKham
                Font = lblReasonsExamination.Font,
                ForeColor = lblReasonsExamination.ForeColor,
                Location = lblReasonsExamination.Location,
                AutoSize = lblReasonsExamination.AutoSize
            };

            // Clone button gọi khám
            Button btnGoi = new Button
            {
                Text = btnCallExam.Text,
                BackColor = btnCallExam.BackColor,
                ForeColor = btnCallExam.ForeColor,
                Font = btnCallExam.Font,
                Size = btnCallExam.Size,
                Location = btnCallExam.Location,
                FlatStyle = btnCallExam.FlatStyle
            };
            btnGoi.FlatAppearance.BorderSize = 0;
            GraphicsHelpers.SetButtonRadius(btnGoi, 5);
            // Thêm event click cho button
            btnGoi.Click += (s, e) => CallExamina(appointment);

            // Thêm controls vào innerPanel
            innerPanel.Controls.Add(lblTen);
            innerPanel.Controls.Add(lblLyDo);
            innerPanel.Controls.Add(btnGoi);
            GraphicsHelpers.SetPanelBorder(newCard, 0, 0, 0, 1, Color.Blue, 1);
            // Thêm innerPanel vào newCard
            newCard.Controls.Add(innerPanel);
            

            return newCard;
        }

        // Xử lý khi click button "Gọi Khám"
        private void CallExamina(Appointment appointment)
        {
            User user = userService.UserById(appointment.PatientId);
            // Hiển thị hộp thoại xác nhận
            var result = MessageBox.Show(
                "Bạn đang gọi?   " + user.FullName.ToUpper() + "    Ngày sinh (" + user.DateOfBirth + ")", // Thông báo
                "Xác nhận", // Tiêu đề
                MessageBoxButtons.YesNo, // Các nút chọn
                MessageBoxIcon.Question // Biểu tượng của hộp thoại
            );

            // Nếu người dùng chọn "Yes"
            if (result == DialogResult.Yes)
            {
                ExaminationForm u = examinationFormService.ExaminationFormByAppointmentId(appointment.Id);
                khbenh khbenh = new khbenh(u);
                showControl(khbenh);
            }
            else
            {
                return;
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            RestorePanelMenu();
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


        private void btnPrescription_Click(object sender, EventArgs e)
        {
            kdthuoc uc = new kdthuoc();
            showControl(uc);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppContextCustom.Instance.Auth.Clear();
            
        }

        private void panelLeft_Paint(object sender, PaintEventArgs e) { }
        

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Refresh lại danh sách khi click Home
           
        }

        private void panelListWaitng_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}