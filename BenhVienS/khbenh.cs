using BenhVienS.Helper_UI;
using BenhVienS.Models;
using BenhVienS.Service.AppointmentService;
using BenhVienS.Service.MedicineService;
using BenhVienS.Service.PatientService;
using BenhVienS.Service.UserService;
using Guna.UI2.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class khbenh : UserControl
    {
        private ExaminationForm examinationForm;
        PatientService patientService = new PatientService();
        UserService userService = new UserService();
        AppointmentService appointmentService = new AppointmentService();
        MedicineService medicineService = new MedicineService();
        public khbenh() : this(new ExaminationForm())
        {
        }
        public khbenh(ExaminationForm examinationForm)
        {
            InitializeComponent();
            this.examinationForm = examinationForm;
             init();
            // Thêm sự kiện cho nút tìm kiếm
            btnSearch.Click += btnSearch_Click;

            // Thêm sự kiện Enter cho ô input (UX tốt hơn)
            intputSearch.KeyPress += intputSearch_KeyPress;

            // Xóa placeholder khi focus
            intputSearch.GotFocus += (s, e) => {
                if (intputSearch.Text == "Tên thuốc...")
                {
                    intputSearch.Text = "";
                    intputSearch.ForeColor = Color.Black;
                }
            };

            // Hiện lại placeholder nếu trống
            intputSearch.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(intputSearch.Text))
                {
                    intputSearch.Text = "Tên thuốc...";
                    intputSearch.ForeColor = Color.Gray;
                }
            };
        }

        private void init()
        {
            loadData();
            LoadUi();
            btnDeleteMedicine.Click += btnDeleteMedicine_Click;
        }

        private void LoadUi()
        {
            GraphicsHelpers.SetButtonBorder(btnDeleteMedicine, 1, 1, 1, 1, Color.Red, 1);
            GraphicsHelpers.SetButtonRadius(btnDeleteMedicine, 3);
            GraphicsHelpers.SetBorderRadius(pnlMedicine, 5);
        }
        private void loadData()
        {
            txtNamePatient.Text = userService.UserByExaminaId(examinationForm.Id).FullName ?? "Chưa có tên";
            lblReason.Text = appointmentService.AppointmentById(examinationForm.AppointmentId).Reasion ?? "Lý do chưa xác định";
            loadMedicine();
        }

        private void loadMedicine()
        {
            List<Medicine> medicineList = medicineService.getMedicineList();

            tableMedicine.DataSource = null;
            tableMedicine.Rows.Clear();
            tableMedicine.Columns.Clear();

            tableMedicine.AutoGenerateColumns = false;

            // Cột Tên thuốc
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Name = "name";
            colName.HeaderText = "Tên thuốc";

            // Cột Đơn vị
            DataGridViewTextBoxColumn colUnit = new DataGridViewTextBoxColumn();
            colUnit.Name = "unit";
            colUnit.HeaderText = "Đơn vị";

            tableMedicine.Columns.Add(colName);
            tableMedicine.Columns.Add(colUnit);
            foreach (var med in medicineList)
            {
                tableMedicine.Rows.Add(med.Name, med.Unit);
               
            }
            tableMedicine.CellClick += tableMedicine_CellClick;
            tableMedicine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Style header
            tableMedicine.EnableHeadersVisualStyles = false;
            tableMedicine.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            tableMedicine.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            // Chỉ cho click, không cho sửa
            tableMedicine.ReadOnly = true;
            tableMedicine.AllowUserToAddRows = false;
            tableMedicine.AllowUserToDeleteRows = false;
            tableMedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableMedicine.MultiSelect = false;

        }
        private void tableMedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string tenThuoc = tableMedicine.Rows[e.RowIndex]
                .Cells["name"].Value?.ToString();

            if (string.IsNullOrEmpty(tenThuoc)) return;

            //
            if (IsMedicineExists(tenThuoc))
            {
                DialogResult result = MessageBox.Show(
                    $"Thuốc \"{tenThuoc}\" đã có trong đơn.\nBạn có chắc muốn thêm tiếp không?",
                    "Thuốc đã tồn tại",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                    return; // ❌ không thêm
            }

            // Click lần 1: panel gốc
            if (string.IsNullOrWhiteSpace(txt_nameMedicine.Text))
            {
                txt_nameMedicine.Text = tenThuoc;
            }
            else
            {
                AddNewMedicinePanel(tenThuoc);
            }
        }


        private void AddNewMedicinePanel(string tenThuoc)
        {
            Panel newPanel = new Panel();
            newPanel.BackColor = Color.White;
            newPanel.Size = new Size(519, 33);

            // Tính vị trí Y (xếp sát nhau)
            int yPosition = 1;
            foreach (Control ctrl in panel5.Controls)
            {
                if (ctrl is Panel)
                {
                    yPosition = Math.Max(yPosition, ctrl.Bottom + 4);
                }
            }
            newPanel.Location = new Point(11, yPosition);

            // TextBox Tên thuốc
            TextBox txtName = new TextBox();
            txtName.Name = "txt_nameMedicine";
            txtName.Text = tenThuoc;
            txtName.Size = new Size(150, 20);
            txtName.Location = new Point(12, 6);

            // TextBox Liều dùng
            TextBox txtDosage = new TextBox();
            txtDosage.Name = "txtDosage";
            txtDosage.Size = new Size(135, 20);
            txtDosage.Location = new Point(183, 6);

            // TextBox Cách dùng
            TextBox txtAdvice = new TextBox();
            txtAdvice.Name = "txtAdvice";
            txtAdvice.Size = new Size(108, 20);
            txtAdvice.Location = new Point(342, 6);

            // Button Xóa
            Button btnDelete = new Button();
            btnDelete.Text = "X";
            btnDelete.ForeColor = Color.Red;
            btnDelete.Size = new Size(28, 22);
            btnDelete.Location = new Point(474, 5);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;

            btnDelete.Click += (s, e) =>
            {
                panel5.Controls.Remove(newPanel);
                newPanel.Dispose();
            };

            newPanel.Controls.Add(txtName);
            newPanel.Controls.Add(txtDosage);
            newPanel.Controls.Add(txtAdvice);
            newPanel.Controls.Add(btnDelete);

            GraphicsHelpers.SetBorderRadius(newPanel, 5);
            GraphicsHelpers.SetButtonRadius(btnDelete, 3);

            panel5.Controls.Add(newPanel);

            txtDosage.Focus(); // UX tốt hơn
        }


        private bool IsMedicineExists(string tenThuoc)
        {
            foreach (Control ctrl in panel5.Controls)
            {
                if (ctrl is Panel pnl)
                {
                    foreach (Control child in pnl.Controls)
                    {
                        if (child is TextBox txt && txt.Name == "txt_nameMedicine")
                        {
                            if (txt.Text.Trim()
                                .Equals(tenThuoc.Trim(), StringComparison.OrdinalIgnoreCase))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        private void btnDeleteMedicine_Click(object sender, EventArgs e)
        {
            // Xóa nội dung panel gốc
            txt_nameMedicine.Clear();
            txtDosage.Clear();
            txtAdvice.Clear();

            // Hoặc nếu muốn ẩn panel gốc khi xóa
            // pnlMedicine.Visible = false;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keySearch = intputSearch.Text.Trim();

            // Bỏ qua nếu là placeholder hoặc rỗng
            if (string.IsNullOrEmpty(keySearch) || keySearch == "Tên thuốc...")
            {
                MessageBox.Show("Vui lòng nhập tên thuốc cần tìm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                intputSearch.Focus();
                return;
            }

            searchMedicineByName(keySearch);
        }
        private void intputSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép tìm kiếm bằng phím Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearch_Click(sender, e);
            }
        }
        private void searchMedicineByName(string keySearch)
        {
            List<Medicine> medicineList = medicineService.getMedicineList();

            // Lọc danh sách thuốc theo từ khóa (không phân biệt hoa thường)
            List<Medicine> filteredList = medicineList.FindAll(m =>
                m.Name.ToLower().Contains(keySearch.ToLower())
            );

            if (filteredList.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy thuốc với từ khóa: \"{keySearch}\"",
                    "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Cập nhật lại bảng với kết quả tìm kiếm
            tableMedicine.Rows.Clear();

            foreach (var med in filteredList)
            {
                tableMedicine.Rows.Add(med.Name, med.Unit);
            }
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

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
