using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace BenhVienS
{
    public partial class uchsbenhan : UserControl
    {
        // Sử dụng đường dẫn tuyệt đối để tránh mất file
        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DataHoSoBenhAn.xml");
        private List<HoSoBenhAn> danhSachHoSo = new List<HoSoBenhAn>();

        public uchsbenhan()
        {
            InitializeComponent();
        }

        private void uchsbenhan_Load(object sender, EventArgs e)
        {
            DocTuFile();
            dtpNgayTao.Value = DateTime.Now;

            // HIỂN THỊ DỮ LIỆU CŨ (Nếu có)
            if (danhSachHoSo.Count > 0)
            {
                HienThiHoSo(danhSachHoSo.Last()); // Hiện hồ sơ cuối cùng đã lưu
            }
        }

        private void LuuVaoFile()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<HoSoBenhAn>));
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    ser.Serialize(sw, danhSachHoSo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void DocTuFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<HoSoBenhAn>));
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        danhSachHoSo = (List<HoSoBenhAn>)ser.Deserialize(sr);
                    }
                }
            }
            catch
            {
                danhSachHoSo = new List<HoSoBenhAn>();
            }
        }

        // Hàm hỗ trợ hiển thị dữ liệu lên màn hình
        private void HienThiHoSo(HoSoBenhAn hs)
        {
            if (hs == null) return;
            txtHoSoID.Text = hs.MaHoSo;
            txtBenhNhanID.Text = hs.MaBenhNhan;
            txtPhieuKhamID.Text = hs.MaPhieuKham;
            dtpNgayTao.Value = hs.NgayTao;
            txtTienSuBenh.Text = hs.TienSuBenh;
            txtDiUng.Text = hs.DiUng;
            txtTienSuGiaDinh.Text = hs.TienSuGiaDinh;
        }

        public void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoSoID.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập Mã hồ sơ!", "Nhắc nhở");
                return;
            }

            // Kiểm tra nếu mã đã tồn tại thì không cho lưu mới (tránh trùng)
            if (danhSachHoSo.Any(x => x.MaHoSo == txtHoSoID.Text.Trim()))
            {
                MessageBox.Show("⚠️ Mã hồ sơ này đã tồn tại! Hãy dùng nút Sửa nếu muốn thay đổi.", "Lỗi");
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
            MessageBox.Show("✅ Đã lưu vào máy! Thoát ra vào lại dữ liệu vẫn sẽ còn.", "Thông báo");
        }

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

                LuuVaoFile();
                MessageBox.Show("✅ Đã sửa dữ liệu thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("⚠️ Không tìm thấy Mã hồ sơ này để sửa!", "Lỗi");
            }
        }

        public void btnXoa_Click(object sender, EventArgs e)
        {
            var hs = danhSachHoSo.FirstOrDefault(x => x.MaHoSo == txtHoSoID.Text.Trim());
            if (hs != null)
            {
                if (MessageBox.Show("Xác nhận xóa hồ sơ này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    danhSachHoSo.Remove(hs);
                    LuuVaoFile();
                    ClearForm();
                    MessageBox.Show("✅ Đã xóa thành công!");
                }
            }
        }

        private void ClearForm()
        {
            txtHoSoID.Clear(); txtBenhNhanID.Clear(); txtPhieuKhamID.Clear();
            txtTienSuBenh.Clear(); txtDiUng.Clear(); txtTienSuGiaDinh.Clear();
            dtpNgayTao.Value = DateTime.Now;
        }
    }

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