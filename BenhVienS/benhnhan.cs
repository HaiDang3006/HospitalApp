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
    public partial class benhnhan : Form
    {
        private List<Control> _defaultPanelControls;
        public benhnhan()
        {
            InitializeComponent();
            LoadDataToGrid();
            RegisterAllEvents();
            _defaultPanelControls = panethongtin.Controls.Cast<Control>().ToList();
            btnTrang.Click += btnTrang_Click;

            // Tự động hiện Form2 (Trang chủ) ngay khi vừa mở ứng dụng
            this.Load += (s, e) => {
                Form2 f2 = new Form2();
                hienThiFormCon(f2);
            };
        }
        private void showControl(Control control)
        {

            panethongtin.Controls.Clear();


            control.Dock = DockStyle.Fill;


            panethongtin.Controls.Add(control);
        }
        private void RestorePanelThongTin()
        {
            // Remove any runtime control(s)
            panethongtin.Controls.Clear();

            // Re-add the original controls in the same order they were captured.
            // Controls keep their properties (Location, Dock, Size, etc.), so they will appear as designed.
            foreach (var ctrl in _defaultPanelControls)
            {
                panethongtin.Controls.Add(ctrl);
            }
        }

        // --- HÀM QUAN TRỌNG: NHÚNG FORM VÀO PANEL ---
        private void hienThiFormCon(Form formCon)
        {
            // Xóa nội dung cũ trong pnlContent (Bạn nhớ tạo Panel tên pnlContent ở Design nhé)
            if (panethongtin.Controls.Count > 0)
                panethongtin.Controls.Clear();

            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;

            panethongtin.Controls.Add(formCon);
            panethongtin.Tag = formCon;
            formCon.Show();
        }

        // --- 1. NẠP DỮ LIỆU MẪU VÀO BẢNG ---
        private void LoadDataToGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // --- 2. KÍCH HOẠT TẤT CẢ CÁC NÚT BẤM ---
        private void RegisterAllEvents()
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label24_Click(object sender, EventArgs e) { }

        private void btnLichHen_Click(object sender, EventArgs e)
        {
            ucqllichhen uc = new ucqllichhen();
            showControl(uc);
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTrang_Click(object sender, EventArgs e)
        {
            RestorePanelThongTin();
        }

        private void btnHoSo_Click(object sender, EventArgs e)
        {
            uchsbenhan uc = new uchsbenhan();
            showControl(uc);
        }

        private void btnDonThuoc_Click(object sender, EventArgs e)
        {
            uckedonthuoc uc = new uckedonthuoc();
            showControl(uc);
        }

        private void benhnhan_Load(object sender, EventArgs e)
        {

        }

        private void btnThongTinBV_Click(object sender, EventArgs e)
        {
            ucttbv uc = new ucttbv();
            showControl(uc);
        }

        private void btnHoTro_Click(object sender, EventArgs e)
        {
            uchotro uc = new uchotro();
            showControl(uc);
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            ucttbenhnhan uc = new ucttbenhnhan();
            showControl(uc);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void btnXemTatCaLich_Click(object sender, EventArgs e)
        {
            uclichhensaptoi uc = new uclichhensaptoi();
            showControl(uc);
        }

        private void btnGoLichHen_Click(object sender, EventArgs e)
        {
            ucqllichhen uc = new ucqllichhen();
            showControl(uc);
        }

        private void btnGoDonThuoc_Click(object sender, EventArgs e)
        {
            uckedonthuoc uc = new uckedonthuoc();
            showControl(uc);
        }

        private void btnGoHoSo_Click(object sender, EventArgs e)
        {
            uchsbenhan uc = new uchsbenhan();
            showControl(uc);
        }

        private void btnGoThongTinBV_Click(object sender, EventArgs e)
        {
            ucttbv uc = new ucttbv();
            showControl(uc);
        }
    }
}