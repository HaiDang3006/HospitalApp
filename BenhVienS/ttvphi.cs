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
    public partial class ttvphi : UserControl
    {
        public ttvphi()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBenhNhan.Columns.Add("STT", "STT");
            dgvBenhNhan.Columns.Add("MaBN", "Mã BN");
            dgvBenhNhan.Columns.Add("TenBN", "Tên Bệnh Nhân");
            dgvBenhNhan.Columns.Add("GioiTinh", "Giới Tính");
            dgvBenhNhan.Columns.Add("NgayRaVien", "Ngày Ra Viện");

            dgvBenhNhan.Rows.Add(1, "MA002", "Nguyễn Văn A", "Nam", "24/04/2024");
            dgvBenhNhan.Rows.Add(2, "MA003", "Trần Thị B", "Nữ", "24/04/2024");
            dgvBenhNhan.Rows.Add(3, "MA004", "Lê Văn C", "Nam", "24/04/2024");
            dgvBenhNhan.Rows.Add(4, "MA005", "Lê Minh C", "Nam", "24/04/2024");

        }
    }
}
