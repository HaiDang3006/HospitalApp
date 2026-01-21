using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BenhVienS
{
    public partial class ucttbenhnhan : UserControl
    {
        // Đường dẫn file lưu ngay trong thư mục chạy App
        private string pathFile = Application.StartupPath + @"\du_lieu_benh_nhan.xml";

        public ucttbenhnhan()
        {
            InitializeComponent();
        }

        private void ucttbenhnhan_Load(object sender, EventArgs e)
        {
            LoadThongTinDaLuu();
        }

        // ================= NÚT SỬA ĐỔI (LƯU DỮ LIỆU) =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng chứa dữ liệu từ các TextBox bạn đã đổi tên
                BenhNhan bn = new BenhNhan()
                {
                    MaBN = txtMaBN.Text.Trim(),
                    MaND = txtMaND.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    NgaySinh = txtNgaySinh.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    NgayDK = txtNgayDK.Text.Trim(),
                    NgheNghiep = txtNgheNghiep.Text.Trim(),
                    CanNang = txtCanNang.Text.Trim(),
                    GioiTinh = txtGioiTinh.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    NhomMau = txtNhomMau.Text.Trim(),
                    ChieuCao = txtChieuCao.Text.Trim(),
                    TrangThai = txtTrangThai.Text.Trim()
                };

                // Ghi file XML
                XmlSerializer serializer = new XmlSerializer(typeof(BenhNhan));
                using (StreamWriter writer = new StreamWriter(pathFile))
                {
                    serializer.Serialize(writer, bn);
                }

                MessageBox.Show("Hệ thống: Đã lưu thông tin vào file thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kỹ thuật khi lưu: " + ex.Message);
            }
        }

        // ================= HÀM NẠP DỮ LIỆU TỰ ĐỘNG =================
        private void LoadThongTinDaLuu()
        {
            if (!File.Exists(pathFile)) return;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BenhNhan));
                using (FileStream fs = new FileStream(pathFile, FileMode.Open))
                {
                    BenhNhan bn = (BenhNhan)serializer.Deserialize(fs);

                    // Điền dữ liệu vào các ô
                    txtMaBN.Text = bn.MaBN;
                    txtMaND.Text = bn.MaND;
                    txtHoTen.Text = bn.HoTen;
                    txtNgaySinh.Text = bn.NgaySinh;
                    txtCCCD.Text = bn.CCCD;
                    txtSDT.Text = bn.SDT;
                    txtEmail.Text = bn.Email;
                    txtNgayDK.Text = bn.NgayDK;
                    txtNgheNghiep.Text = bn.NgheNghiep;
                    txtCanNang.Text = bn.CanNang;
                    txtGioiTinh.Text = bn.GioiTinh;
                    txtDiaChi.Text = bn.DiaChi;
                    txtNhomMau.Text = bn.NhomMau;
                    txtChieuCao.Text = bn.ChieuCao;
                    txtTrangThai.Text = bn.TrangThai;
                }
            }
            catch { }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn trang hiện tại
        }
    }

    // Class cấu trúc dữ liệu
    public class BenhNhan
    {
        public string MaBN { get; set; }
        public string MaND { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string NgayDK { get; set; }
        public string NgheNghiep { get; set; }
        public string CanNang { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string NhomMau { get; set; }
        public string ChieuCao { get; set; }
        public string TrangThai { get; set; }
    }
}