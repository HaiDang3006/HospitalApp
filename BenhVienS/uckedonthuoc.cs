using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Linq;

namespace BenhVienS
{
    public partial class uckedonthuoc : UserControl
    {
        // Đường dẫn file xml lưu tại thư mục cài đặt ứng dụng
        private string filePath = Path.Combine(Application.StartupPath, "donthuoc.xml");
        private List<DonThuoc> danhSachDon = new List<DonThuoc>();

        public uckedonthuoc()
        {
            InitializeComponent();
        }

        private void uckedonthuoc_Load(object sender, EventArgs e)
        {
            KhoiTaoBang();
            LoadFromFile(); // Tự động tải dữ liệu cũ lên bảng
            dtpNgayKeDon.Value = DateTime.Now;
        }

        private void KhoiTaoBang()
        {
            dgvThuoc.Columns.Clear();
            dgvThuoc.Columns.Add("MaDon", "Mã đơn");
            dgvThuoc.Columns.Add("MaPK", "Mã phiếu khám");
            dgvThuoc.Columns.Add("MaBS", "Mã bác sĩ");
            dgvThuoc.Columns.Add("Ngay", "Ngày kê");
            dgvThuoc.Columns.Add("TrangThai", "Trạng thái");

            // --- XÓA Ô ĐẦU TRỐNG VÀ DÒNG CUỐI TRỐNG ---
            dgvThuoc.RowHeadersVisible = false;      // Ẩn cột trống bên trái ngoài cùng
            dgvThuoc.AllowUserToAddRows = false;    // Ẩn dòng trống cuối bảng (dòng dấu *)

            // Tối ưu giao diện bảng
            dgvThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThuoc.BackgroundColor = System.Drawing.Color.White;
            dgvThuoc.ReadOnly = true; // Chỉ cho phép xem, sửa qua các TextBox phía trên
        }

        // --- HÀM LƯU DỮ LIỆU XUỐNG FILE XML ---
        private void LuuXuongFile()
        {
            try
            {
                var listToSave = new List<DonThuoc>();
                foreach (DataGridViewRow row in dgvThuoc.Rows)
                {
                    listToSave.Add(new DonThuoc()
                    {
                        MaDonThuoc = row.Cells[0].Value?.ToString() ?? "",
                        MaPhieuKham = row.Cells[1].Value?.ToString() ?? "",
                        MaBacSi = row.Cells[2].Value?.ToString() ?? "",
                        NgayKeDon = DateTime.TryParse(row.Cells[3].Value?.ToString(), out DateTime d) ? d : DateTime.Now,
                        TrangThai = row.Cells[4].Value?.ToString() ?? ""
                    });
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<DonThuoc>));
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, listToSave);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu file: " + ex.Message); }
        }

        // --- NÚT LƯU: Nhập ở trên -> Hiện xuống bảng -> Lưu file ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDonThuoc.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập Mã đơn thuốc!", "Thông báo");
                return;
            }

            // Thêm dữ liệu từ TextBox vào bảng
            dgvThuoc.Rows.Add(
                txtMaDonThuoc.Text.Trim(),
                txtMaPhieuKham.Text.Trim(),
                txtMaBacSi.Text.Trim(),
                dtpNgayKeDon.Value.ToShortDateString(),
                cmbTrangThai.Text
            );

            LuuXuongFile(); // Ghi file ngay lập tức
            MessageBox.Show("✅ Đã lưu đơn thuốc thành công!", "Thông báo");
            ClearInput();
        }

        // --- NÚT SỬA: Cập nhật lại dòng đang chọn trong bảng ---
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThuoc.CurrentRow != null)
            {
                int i = dgvThuoc.CurrentRow.Index;
                dgvThuoc.Rows[i].Cells[0].Value = txtMaDonThuoc.Text.Trim();
                dgvThuoc.Rows[i].Cells[1].Value = txtMaPhieuKham.Text.Trim();
                dgvThuoc.Rows[i].Cells[2].Value = txtMaBacSi.Text.Trim();
                dgvThuoc.Rows[i].Cells[3].Value = dtpNgayKeDon.Value.ToShortDateString();
                dgvThuoc.Rows[i].Cells[4].Value = cmbTrangThai.Text;

                LuuXuongFile();
                MessageBox.Show("✅ Đã cập nhật thành công!");
            }
        }

        // --- NÚT XÓA ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThuoc.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgvThuoc.Rows.RemoveAt(dgvThuoc.CurrentRow.Index);
                    LuuXuongFile();
                    ClearInput();
                }
            }
        }

        // --- TẢI DỮ LIỆU KHI MỞ APP ---
        private void LoadFromFile()
        {
            if (!File.Exists(filePath)) return;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<DonThuoc>));
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    var data = (List<DonThuoc>)serializer.Deserialize(fs);
                    dgvThuoc.Rows.Clear();
                    foreach (var d in data)
                    {
                        dgvThuoc.Rows.Add(d.MaDonThuoc, d.MaPhieuKham, d.MaBacSi, d.NgayKeDon.ToShortDateString(), d.TrangThai);
                    }
                }
            }
            catch { }
        }

        private void ClearInput()
        {
            txtMaDonThuoc.Clear();
            txtMaPhieuKham.Clear();
            txtMaBacSi.Clear();
            dtpNgayKeDon.Value = DateTime.Now;
        }

        // --- TÌM KIẾM DỮ LIỆU TRÊN BẢNG ---
        private void LocDuLieu()
        {
            string fDon = txtMaDonThuoc.Text.ToLower();
            string fPK = txtMaPhieuKham.Text.ToLower();
            string fBS = txtMaBacSi.Text.ToLower();

            dgvThuoc.CurrentCell = null;
            foreach (DataGridViewRow row in dgvThuoc.Rows)
            {
                string vDon = row.Cells[0].Value?.ToString().ToLower() ?? "";
                string vPK = row.Cells[1].Value?.ToString().ToLower() ?? "";
                string vBS = row.Cells[2].Value?.ToString().ToLower() ?? "";
                row.Visible = vDon.Contains(fDon) && vPK.Contains(fPK) && vBS.Contains(fBS);
            }
        }

        // Gán các sự kiện TextChanged để tìm kiếm tự động
        private void txtMaPhieuKham_TextChanged_1(object sender, EventArgs e) { LocDuLieu(); }
        private void txtMaDonThuoc_TextChanged(object sender, EventArgs e) { LocDuLieu(); }
        private void txtMaBacSi_TextChanged(object sender, EventArgs e) { LocDuLieu(); }

        // --- KHI CLICK VÀO BẢNG: Hiện dữ liệu lên các ô ở trên ---
        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvThuoc.Rows[e.RowIndex];
                txtMaDonThuoc.Text = r.Cells[0].Value?.ToString();
                txtMaPhieuKham.Text = r.Cells[1].Value?.ToString();
                txtMaBacSi.Text = r.Cells[2].Value?.ToString();
                if (DateTime.TryParse(r.Cells[3].Value?.ToString(), out DateTime d)) dtpNgayKeDon.Value = d;
                cmbTrangThai.Text = r.Cells[4].Value?.ToString();
            }
        }

        private void btnDong_Click_1(object sender, EventArgs e) { this.Visible = false; }
    }

    [Serializable]
    public class DonThuoc
    {
        public string MaDonThuoc { get; set; }
        public string MaPhieuKham { get; set; }
        public string MaBacSi { get; set; }
        public DateTime NgayKeDon { get; set; }
        public string TrangThai { get; set; }
    }
}