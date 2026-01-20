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
            LoadComboBox();
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

            // Mở khóa hoàn toàn để gõ trực tiếp
            dgvLichHen.ReadOnly = false;
            dgvLichHen.AllowUserToAddRows = true;
            dgvLichHen.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in dgvLichHen.Columns)
            {
                col.ReadOnly = false;
            }
        }

        // --- NÚT ĐẶT LỊCH HẸN MỚI: NHẤN LÀ PHẢI HIỆN MESSBOX VÀ LƯU ---
        private void btnDatLichMoi_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Ép bảng lưu dữ liệu đang gõ
                dgvLichHen.EndEdit();
                if (this.BindingContext[dtLichHen] != null)
                {
                    this.BindingContext[dtLichHen].EndCurrentEdit();
                }

                // 2. Ghi file vĩnh viễn
                dtLichHen.WriteXml(filePath);

                // 3. HIỆN THÔNG BÁO XÁC NHẬN (Để bạn biết là code đã chạy)
                MessageBox.Show("✅ Đã đặt lịch và lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Tạo dòng trống mới để nhập tiếp
                DataRow newRow = dtLichHen.NewRow();
                newRow["MaLichHen"] = "LH" + (dtLichHen.Rows.Count + 1).ToString("000");
                newRow["NgayHen"] = DateTime.Now.ToShortDateString();
                newRow["TrangThai"] = "Chờ khám";
                dtLichHen.Rows.Add(newRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi lưu dữ liệu: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                dgvLichHen.EndEdit();
                dtLichHen.WriteXml(filePath);
                MessageBox.Show("✅ Đã cập nhật các thay đổi!", "Thông báo");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dgvLichHen.CurrentRow != null && !dgvLichHen.CurrentRow.IsNewRow)
            {
                if (MessageBox.Show("Xóa lịch hẹn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            if (!string.IsNullOrEmpty(cboMaBenhNhan.Text))
                filter += string.Format("MaBenhNhan LIKE '%{0}%'", cboMaBenhNhan.Text);
            if (!string.IsNullOrEmpty(cboTrangThai.Text))
            {
                if (filter.Length > 0) filter += " AND ";
                filter += string.Format("TrangThai LIKE '%{0}%'", cboTrangThai.Text);
            }
            dtLichHen.DefaultView.RowFilter = filter;
        }

        private void LoadComboBox()
        {
            cboMaBenhNhan.Items.Clear();
            cboMaBenhNhan.Items.AddRange(new object[] { "111", "222", "BN001" });
            cboMaBacSi.Items.Clear();
            cboMaBacSi.Items.AddRange(new object[] { "BS001", "BS002" });
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Chờ khám", "Đã khám", "Hủy" });
        }
    }
}