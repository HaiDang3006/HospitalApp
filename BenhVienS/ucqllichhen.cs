using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BenhVienS
{
    public partial class ucqllichhen : UserControl
    {
        private DataTable dtLichHen;
        // Đường dẫn file lưu trữ vĩnh viễn
        private string filePath = Path.Combine(Application.StartupPath, "du_lieu_lich_hen.xml");

        public ucqllichhen()
        {
            InitializeComponent();
            dgvLichHen.AutoGenerateColumns = false;
        }

        private void ucqllichhen_Load(object sender, EventArgs e)
        {
            KhoiTaoBang();
            LoadComboBoxData(); // Đổi tên hàm cho rõ nghĩa
        }

        private void KhoiTaoBang()
        {
            dtLichHen = new DataTable("LichHen");
            dtLichHen.Columns.Add("MaLichHen");
            dtLichHen.Columns.Add("MaBenhNhan");
            dtLichHen.Columns.Add("MaBacSi");
            dtLichHen.Columns.Add("NgayHen");
            dtLichHen.Columns.Add("ThoiGianDen");
            dtLichHen.Columns.Add("LyDoKham");
            dtLichHen.Columns.Add("HinhThucDat");
            dtLichHen.Columns.Add("TrangThai");
            dtLichHen.Columns.Add("GhiChu");

            if (File.Exists(filePath))
            {
                try { dtLichHen.ReadXml(filePath); } catch { }
            }

            dgvLichHen.DataSource = dtLichHen;

            // Cấu hình DataGridView
            dgvLichHen.ReadOnly = false;
            dgvLichHen.AllowUserToAddRows = false; // Tắt tự thêm dòng để tránh dòng trống dư thừa
            dgvLichHen.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in dgvLichHen.Columns)
            {
                col.ReadOnly = false;
            }
        }

        private void LoadComboBoxData()
        {
            // Mã Bệnh Nhân
            cboMaBenhNhan.Items.Clear();
            cboMaBenhNhan.Items.AddRange(new object[] { "111", "222", "BN001" });

            // Mã Bác Sĩ
            cboMaBacSi.Items.Clear();
            cboMaBacSi.Items.AddRange(new object[] { "BS001", "BS002" });

            // Trạng Thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Chờ khám", "Đã khám", "Hủy" });

            // Hình Thức Đặt
            cboHinhThucDat.Items.Clear();
            cboHinhThucDat.Items.AddRange(new object[] { "Trực tiếp", "Qua điện thoại", "Online" });

            // Lý Do Khám
            cboLyDoKham.Items.Clear();
            cboLyDoKham.Items.AddRange(new object[] { "Khám tổng quát", "Tái khám", "Cấp cứu" });

            // Ghi Chú
            cboGhiChu.Items.Clear();
            cboGhiChu.Items.AddRange(new object[] { "Khách quen", "Ưu tiên", "Cần xét nghiệm máu" });
        }

        // --- NÚT ĐẶT LỊCH HẸN MỚI: LẤY TOÀN BỘ DỮ LIỆU TỪ CÁC Ô ---
        private void btnDatLichMoi_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra điều kiện bắt buộc (Ví dụ: phải chọn mã BN và mã BS)
                if (string.IsNullOrEmpty(cboMaBenhNhan.Text) || string.IsNullOrEmpty(cboMaBacSi.Text))
                {
                    MessageBox.Show("Vui lòng chọn Mã bệnh nhân và Mã bác sĩ!", "Nhắc nhở");
                    return;
                }

                // 2. Tạo dòng mới và GÁN ĐẦY ĐỦ DỮ LIỆU từ các control
                DataRow newRow = dtLichHen.NewRow();

                // Cột tự động hoặc lấy từ control
                newRow["MaLichHen"] = "LH" + (dtLichHen.Rows.Count + 1).ToString("000");

                // Cột lấy từ ComboBox / DateTimePicker
                newRow["MaBenhNhan"] = cboMaBenhNhan.Text;
                newRow["MaBacSi"] = cboMaBacSi.Text;
                newRow["NgayHen"] = dtpNgayHen.Value.ToShortDateString(); // Lấy từ ô Ngày hẹn
                newRow["ThoiGianDen"] = dtpThoiGianDen.Value.ToString("HH:mm"); // Lấy từ ô Thời gian đến
                newRow["LyDoKham"] = cboLyDoKham.Text;
                newRow["HinhThucDat"] = cboHinhThucDat.Text;
                newRow["TrangThai"] = cboTrangThai.Text;
                newRow["GhiChu"] = cboGhiChu.Text;

                // 3. Thêm vào DataTable
                dtLichHen.Rows.Add(newRow);

                // 4. Lưu file vĩnh viễn
                dtLichHen.WriteXml(filePath);

                // 5. Thông báo và làm mới giao diện
                MessageBox.Show("✅ Đã đặt lịch và lưu dữ liệu thành công!", "Thông báo");

                // (Tùy chọn) Xóa trắng các ô sau khi nhập xong để nhập ca tiếp theo
                // ResetControls(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                dgvLichHen.EndEdit();
                if (this.BindingContext[dtLichHen] != null)
                    this.BindingContext[dtLichHen].EndCurrentEdit();

                dtLichHen.WriteXml(filePath);
                MessageBox.Show("✅ Đã cập nhật các thay đổi!", "Thông báo");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e) // Đổi tên từ btnHuy thành btnXoa cho khớp ảnh
        {
            if (dgvLichHen.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa lịch hẹn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dgvLichHen.Rows.RemoveAt(dgvLichHen.CurrentRow.Index);
                    dtLichHen.WriteXml(filePath);
                    MessageBox.Show("✅ Đã xóa!");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dtLichHen == null) return;
            string filter = "";

            // Tìm theo mã BN
            if (!string.IsNullOrEmpty(cboMaBenhNhan.Text))
                filter += string.Format("MaBenhNhan LIKE '%{0}%'", cboMaBenhNhan.Text);

            // Tìm theo Trạng thái (Lấy từ ô lọc cboTrangThai)
            if (!string.IsNullOrEmpty(cboTrangThai.Text))
            {
                if (filter.Length > 0) filter += " AND ";
                filter += string.Format("TrangThai LIKE '%{0}%'", cboTrangThai.Text);
            }

            dtLichHen.DefaultView.RowFilter = filter;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }

        private void dgvLichHen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}