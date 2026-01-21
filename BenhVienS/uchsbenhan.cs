using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.ComponentModel;

namespace BenhVienS
{
    public partial class uchsbenhan : UserControl
    {
        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DataHoSoBenhAn.xml");

        // Sử dụng BindingList để đồng bộ hóa dữ liệu với DataGridView
        private BindingList<HoSoBenhAn> danhSachHoSo = new BindingList<HoSoBenhAn>();

        public uchsbenhan()
        {
            InitializeComponent();
            // Khấu hình bảng để không tự đẻ thêm cột thừa
            dgvHoSoBenhAn.AutoGenerateColumns = false;
            dgvHoSoBenhAn.DataSource = danhSachHoSo;
        }

        private void uchsbenhan_Load(object sender, EventArgs e)
        {
            DocTuFile();
            dtpNgayTao.Value = DateTime.Now;
        }

        // NÚT LƯU
        public void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoSoID.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập Mã hồ sơ!", "Thông báo");
                return;
            }

            var hs = new HoSoBenhAn
            {
                MaHoSo = txtHoSoID.Text.Trim(),
                MaBenhNhan = txtBenhNhanID.Text.Trim(),
                MaPhieuKham = txtPhieuKhamID.Text.Trim(),
                NgayTao = dtpNgayTao.Value,
                TienSuBenh = txtTienSuBenh.Text.Trim(),
                DiUng = txtDiUng.Text.Trim(),
                TienSuGiaDinh = txtTienSuGiaDinh.Text.Trim()
            };

            danhSachHoSo.Add(hs);
            LuuVaoFile();
            MessageBox.Show("✅ Đã lưu và hiển thị lên bảng!");
            ClearForm();
        }

        // NÚT XÓA - Đã sửa lỗi MessageBox hiện mà không xóa được
        public void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoSoBenhAn.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Hãy chọn một dòng trên bảng để xóa!", "Thông báo");
                return;
            }

            // Lấy mã hồ sơ từ dòng đang chọn trên bảng
            string maXoa = dgvHoSoBenhAn.CurrentRow.Cells[0].Value?.ToString();

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa hồ sơ: {maXoa}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                var hs = danhSachHoSo.FirstOrDefault(x => x.MaHoSo == maXoa);
                if (hs != null)
                {
                    danhSachHoSo.Remove(hs); // Xóa trong danh sách
                    LuuVaoFile();           // Lưu vào file

                    // Ép bảng cập nhật lại giao diện ngay lập tức
                    danhSachHoSo.ResetBindings();

                    ClearForm();
                    MessageBox.Show("✅ Đã xóa thành công!");
                }
            }
        }

        // NÚT SỬA
        public void btnSua_Click(object sender, EventArgs e)
        {
            var hs = danhSachHoSo.FirstOrDefault(x => x.MaHoSo == txtHoSoID.Text.Trim());
            if (hs != null)
            {
                hs.MaBenhNhan = txtBenhNhanID.Text.Trim();
                hs.MaPhieuKham = txtPhieuKhamID.Text.Trim();
                hs.NgayTao = dtpNgayTao.Value;
                hs.TienSuBenh = txtTienSuBenh.Text.Trim();
                hs.DiUng = txtDiUng.Text.Trim();
                hs.TienSuGiaDinh = txtTienSuGiaDinh.Text.Trim();

                danhSachHoSo.ResetBindings(); // Cập nhật lại bảng
                LuuVaoFile();
                MessageBox.Show("✅ Đã cập nhật dữ liệu!");
            }
        }

        private void LuuVaoFile()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<HoSoBenhAn>));
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    ser.Serialize(sw, danhSachHoSo.ToList());
                }
            }
            catch { }
        }

        private void DocTuFile()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<HoSoBenhAn>));
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        var data = (List<HoSoBenhAn>)ser.Deserialize(sr);
                        danhSachHoSo.Clear();
                        foreach (var item in data) danhSachHoSo.Add(item);
                    }
                }
                catch { }
            }
        }

        private void ClearForm()
        {
            txtHoSoID.Clear(); txtBenhNhanID.Clear(); txtPhieuKhamID.Clear();
            txtTienSuBenh.Clear(); txtDiUng.Clear(); txtTienSuGiaDinh.Clear();
            dtpNgayTao.Value = DateTime.Now;
        }

        // Khi click vào bảng, hiện thông tin lên các ô bên trái
        private void dgvHoSoBenhAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                HoSoBenhAn hs = danhSachHoSo[e.RowIndex];
                txtHoSoID.Text = hs.MaHoSo;
                txtBenhNhanID.Text = hs.MaBenhNhan;
                txtPhieuKhamID.Text = hs.MaPhieuKham;
                dtpNgayTao.Value = hs.NgayTao;
                txtTienSuBenh.Text = hs.TienSuBenh;
                txtDiUng.Text = hs.DiUng;
                txtTienSuGiaDinh.Text = hs.TienSuGiaDinh;
            }
        }

        private void btnSuaHoSo_Click(object sender, EventArgs e)
        {
            // 1. Lấy mã hồ sơ đang hiển thị trong ô nhập liệu
            string maHoSoHienTai = txtHoSoID.Text.Trim();

            if (string.IsNullOrWhiteSpace(maHoSoHienTai))
            {
                MessageBox.Show("⚠️ Vui lòng chọn một hồ sơ từ bảng để sửa!", "Thông báo");
                return;
            }

            // 2. Tìm đối tượng trong danh sách có Mã hồ sơ trùng khớp
            var hs = danhSachHoSo.FirstOrDefault(x => x.MaHoSo == maHoSoHienTai);

            if (hs != null)
            {
                // 3. Cập nhật các thông tin mới từ TextBox vào đối tượng đó
                hs.MaBenhNhan = txtBenhNhanID.Text.Trim();
                hs.MaPhieuKham = txtPhieuKhamID.Text.Trim();
                hs.NgayTao = dtpNgayTao.Value;
                hs.TienSuBenh = txtTienSuBenh.Text.Trim();
                hs.DiUng = txtDiUng.Text.Trim();
                hs.TienSuGiaDinh = txtTienSuGiaDinh.Text.Trim();

                // 4. Ép BindingList thông báo cho bảng vẽ lại dữ liệu mới
                danhSachHoSo.ResetBindings();

                // 5. Lưu xuống file XML để không bị mất khi tắt app
                LuuVaoFile();

                MessageBox.Show("✅ Đã cập nhật hồ sơ thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("⚠️ Không tìm thấy hồ sơ có mã này. Lưu ý: Không nên sửa Mã hồ sơ!", "Lỗi");
            }
        }
    }

    // Đặt class này ở đây để hết lỗi CS0246
    [Serializable]
    public class HoSoBenhAn
    {
        public string MaHoSo { get; set; }
        public string MaBenhNhan { get; set; }
        public string MaPhieuKham { get; set; }
        public DateTime NgayTao { get; set; }
        public string TienSuBenh { get; set; }
        public string DiUng { get; set; }
        public string TienSuGiaDinh { get; set; }
    }
}