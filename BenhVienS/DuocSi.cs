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
        public partial class DuocSi : Form
        {
            // Khai báo biến để lưu nút đang được chọn (để đổi màu)
            private Button currentBtn;
            private Panel leftBorderBtn; // Cái vạch màu bên cạnh nút khi active
        private List<Control> _defaultPanelControls;
        public DuocSi()
            {
                InitializeComponent();
            _defaultPanelControls = panelBody.Controls.Cast<Control>().ToList();
            btTongquan.Click += btTongquan_Click;

            // Tạo cái vạch trang trí bên trái nút (nếu thích)
            leftBorderBtn = new Panel();
                leftBorderBtn.Size = new Size(7, 60); // Kích thước vạch
                panelMenu.Controls.Add(leftBorderBtn); // Thêm vào panelMenu (bạn nhớ đặt tên panel chứa menu là panelMenu nhé)
                
            }
        private void showControl(Control control)
        {

            panelBody.Controls.Clear();


            control.Dock = DockStyle.Fill;


            panelBody.Controls.Add(control);
        }
        private void RestorePanelThongTin()
        {
            // Remove any runtime control(s)
            panelBody.Controls.Clear();

            // Re-add the original controls in the same order they were captured.
            // Controls keep their properties (Location, Dock, Size, etc.), so they will appear as designed.
            foreach (var ctrl in _defaultPanelControls)
            {
                panelBody.Controls.Add(ctrl);
            }
        }
        // --- HÀM 1: Đổi màu nút khi được bấm (Hiệu ứng Active) ---
        private void ActivateButton(object senderBtn)
            {
                if (senderBtn != null)
                {
                    DisableButton(); // Trả các nút khác về màu thường

                    // Chỉnh màu nút được chọn
                    currentBtn = (Button)senderBtn;
                    currentBtn.BackColor = Color.FromArgb(37, 36, 81); // Màu đậm hơn chút để biết đang chọn
                    currentBtn.ForeColor = Color.White;

                    // Hiệu ứng vạch màu bên trái (Giống các app hiện đại)
                    leftBorderBtn.BackColor = Color.Orange; // Hoặc màu xanh tùy bạn
                    leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                    leftBorderBtn.Visible = true;
                    leftBorderBtn.BringToFront();
                }
            }

            // --- HÀM 2: Trả lại màu cũ cho nút không được chọn ---
            private void DisableButton()
            {
                if (currentBtn != null)
                {
                    // Màu nền mặc định của menu (bạn xem mã màu RGB bên design là bao nhiêu thì điền vào đây)
                    // Ví dụ màu xanh menu của bạn là: 
                    currentBtn.BackColor = Color.SteelBlue; // SỬA LẠI MÀU NÀY CHO TRÙNG MÀU MENU CỦA BẠN
                    currentBtn.ForeColor = Color.White;
                }
            }

            // --- HÀM 3: Mở UserControl vào PanelBody (QUAN TRỌNG NHẤT) ---
            private void OpenChildControl(UserControl childControl)
            {
                // Xóa hết các control đang hiển thị cũ
                panelBody.Controls.Clear();

                // Cấu hình control mới
                childControl.Dock = DockStyle.Fill; // Lấp đầy panel
                childControl.BringToFront();

                // Thêm vào panel
                panelBody.Controls.Add(childControl);
            }
        private void btTongquan_Click(object sender, EventArgs e)
        {
            RestorePanelThongTin();
        }
        private void btDMT_Click(object sender, EventArgs e)
        {
            ucDanhMucThuoc uc = new ucDanhMucThuoc();
            showControl(uc);
        }
        private void btQLDT_Click(object sender, EventArgs e)
        {
            ucQuanLyDonThuoc uc = new ucQuanLyDonThuoc();
            showControl(uc);
        }
        private void btDSNT_Click(object sender, EventArgs e)
        {
            ucDanhSachNhapThuoc uc = new ucDanhSachNhapThuoc();
            showControl(uc);
        }

        private void btcaidat_Click(object sender, EventArgs e)
        {
            ucCD uc = new ucCD();
            showControl(uc);
        }
    }
}

