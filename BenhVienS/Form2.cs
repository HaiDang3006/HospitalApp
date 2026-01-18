using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BenhVienS
{
    public partial class Form2 : Form
    {
        // Thêm dấu @ và bao quanh bằng dấu ngoặc kép ""
        string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=benhvienvs;Integrated Security=True;TrustServerCertificate=True"; 
        public Form2()
        {
            InitializeComponent();



        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void btQlibenhnhan_Click(object sender, EventArgs e)
        {



        }



        private void btTongquan_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadChuyenmon();

            // Tải toàn bộ danh sách bác sĩ khi form mở
            LoadDanhSachBacSi();

            // Tải lịch làm việc hôm nay
            LoadLichLamHomNay();

            // Tùy chỉnh giao diện DataGridView (tùy chọn)
            dgvDanhsachbacsi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichlamhomnay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadDanhSachBacSi();
            TaoMaLichTuDong();
            // Gán dữ liệu mặc định cho ComboBox Trạng thái
            cbTragthai.Items.AddRange(new string[] { "Mới", "Đã xác nhận", "Đã khám", "Hủy" });
            cbTragthai.SelectedIndex = 0;
        }

        private void LoadDanhSachLichKham()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Câu lệnh SQL Join 2 bảng: LichKham và BacSi
                    string sql = @"SELECT L.MaLich, L.TenBN, B.HoTen, B.ChuyenKhoa, L.NgayKham, L.TrangThai 
                           FROM LichKham L
                           INNER JOIN BacSi B ON L.MaBS = B.MaBS";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Giả sử bạn có một DataGridView tên là dgvLichKham
                    dgvDanhsachlichkham.DataSource = dt;

                    // Tùy chỉnh tiêu đề cột cho đẹp
                    dgvDanhsachlichkham.Columns["MaLich"].HeaderText = "Mã Lịch";
                    dgvDanhsachlichkham.Columns["TenBN"].HeaderText = "Bệnh Nhân";
                    dgvDanhsachlichkham.Columns["HoTen"].HeaderText = "Bác Sĩ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }
        private void LoadBacSiVaoCombo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT HoTen FROM BacSi WHERE TrangThai = N'Đang làm việc'";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbBacsi.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cbBacsi.Items.Add(row["HoTen"].ToString());
                    }
                }
            }
            catch { }
        }




        private void btDangxuat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nút đã được click!");
            // 1. Hiển thị hộp thoại xác nhận (Tùy chọn nhưng nên có)
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. Khởi tạo lại Form đăng nhập của bạn (thay 'LoginForm' bằng tên Form đăng nhập thật của bạn)
                // Ví dụ: Form1 hoặc LoginForm
                Form1 loginForm = new Form1();
                loginForm.Show();

                // 3. Đóng Form hiện tại (Form2)
                this.Close();
            }


        }
        private void TaoMaLichTuDong()
        {
            txtMalich.Text = "DL" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btQlidoanhthu_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chartDoanhthu_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabQlibacsi_Click(object sender, EventArgs e)
        {

        }
        private void LoadChuyenmon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaChuyenKhoa, TenChuyenKhoa FROM ChuyenKhoa";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow row = dt.NewRow();
                row["MaChuyenKhoa"] = 0;
                row["TenChuyenKhoa"] = "Tất cả";
                dt.Rows.InsertAt(row, 0);

                cbChuyenkhoa.DataSource = dt;
                cbChuyenkhoa.DisplayMember = "TenChuyenKhoa";
                cbChuyenkhoa.ValueMember = "MaChuyenKhoa";
            }
        }


        private void txtTimtenbacsi_TextChanged(object sender, EventArgs e)
        {
            string ten = txtTimtenbacsi.Text.Trim();

            int maCK = 0;
            if (cbChuyenkhoa.SelectedValue != null)
                maCK = Convert.ToInt32(cbChuyenkhoa.SelectedValue);

            LoadDanhSachBacSi(ten, maCK);
        }

        private void LoadDanhSachBacSi(string tenTim = "", int maChuyenKhoa = 0)

        {
            

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    bs.MaBacSi,
                    nd.HoTen AS TenBacSi,
                    ck.TenChuyenKhoa,
                    bs.BangCap,
                    bs.ChuyenMon,
                    bs.NamKinhNghiem,
                    bs.DanhGia,
                    CASE WHEN bs.TrangThai = 1 
                         THEN N'Hoạt động' 
                         ELSE N'Ngưng hoạt động' 
                    END AS TrangThai
                FROM BacSi bs
                JOIN NguoiDung nd ON bs.MaNguoiDung = nd.MaNguoiDung
                JOIN ChuyenKhoa ck ON bs.MaChuyenKhoa = ck.MaChuyenKhoa
                WHERE 1 = 1";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (!string.IsNullOrWhiteSpace(tenTim))
                    {
                        query += " AND nd.HoTen LIKE @Ten";
                        cmd.Parameters.AddWithValue("@Ten", "%" + tenTim + "%");
                    }

                    if (maChuyenKhoa > 0)
                    {
                        query += " AND bs.MaChuyenKhoa = @MaChuyenKhoa";
                        cmd.Parameters.AddWithValue("@MaChuyenKhoa", maChuyenKhoa);
                    }

                    cmd.CommandText = query;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDanhsachbacsi.AutoGenerateColumns = false;
                    dgvDanhsachbacsi.DataSource = dt;
                    dgvDanhsachbacsi.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách bác sĩ: " + ex.Message);
            }
        }


        private void cbChuyenkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ten = txtTimtenbacsi.Text.Trim();

            int maCK = 0;
            
            if (cbChuyenkhoa.SelectedValue != null && int.TryParse(cbChuyenkhoa.SelectedValue.ToString(), out int result))
            {
                maCK = result;
            }

            LoadDanhSachBacSi(ten, maCK);

           
        }

        private void LoadLichLamHomNay()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    bs.MaBacSi,
                    nd.HoTen,
                    ck.TenChuyenKhoa,
                    ISNULL(ll.CaSang, 0)  AS CaSang,
                    ISNULL(ll.CaTrua, 0)  AS CaTrua,
                    ISNULL(ll.CaChieu, 0) AS CaChieu
                FROM BacSi bs
                JOIN NguoiDung nd ON bs.MaNguoiDung = nd.MaNguoiDung
                JOIN ChuyenKhoa ck ON bs.MaChuyenKhoa = ck.MaChuyenKhoa
                LEFT JOIN LichLamViec ll 
                    ON bs.MaBacSi = ll.MaBacSi 
                   AND ll.Ngay = @Ngay";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ngay", DateTime.Today);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvLichlamhomnay.AutoGenerateColumns = false;
                    dgvLichlamhomnay.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch làm hôm nay: " + ex.Message);
            }
        }

        private void LoadDanhSachDichVu()
        {

            List<DichVu> ds = new List<DichVu>() {
        new DichVu { MaDV = "DV01", TenDV = "Siêu âm tổng quát", DonGia = 200000, TyLeBHYT = 0.8 },
        new DichVu { MaDV = "DV02", TenDV = "Xét nghiệm máu", DonGia = 150000, TyLeBHYT = 1.0 }
    };
            dgvBangDV.DataSource = ds;
        }
        void ExitAddMode()
        {
            isAddMode = false;

            EnableInput(false);
            dataGridView1.Enabled = true;

            btThem.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;

            btLuuthongtin.Visible = false;
            btHuy.Visible = false;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDanhsachbacsi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLichlamhomnay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       


        private void txtMalich_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbBacsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT HoTen FROM BacSi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbBacsi.Items.Add(reader["HoTen"].ToString());
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải bác sĩ: " + ex.Message); }
        }
            

        private void dtpNgayKham_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void cbKhunggio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTenbenhnhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không phải số
            }
        }

        private void cbTragthai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btThem_Click(object sender, EventArgs e)
        {
            isAddMode = true;

            // Cho phép nhập
            EnableInput(true);

            // Xóa dữ liệu cũ
            ClearInput();

            // Khóa bảng danh sách
            dataGridView1.Enabled = false;

            btThem.Enabled = false;
            btSua.Enabled = false;
            btXoa.Enabled = false;
            btLuuthongtin.Visible = true;
            btHuy.Visible = true;
        }



        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE LichKham SET BacSi=@BS, ChuyenKhoa=@Khoa, NgayKham=@Ngay, " +
                                   "KhungGio=@Gio, TenBenhNhan=@Ten, SDT=@SDT, TrangThai=@TT WHERE MaLich=@Ma";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ma", txtMalich.Text);
                    cmd.Parameters.AddWithValue("@BS", cbBacsi.Text);
                    cmd.Parameters.AddWithValue("@Khoa", cbChuyenkhoa.Text);
                    cmd.Parameters.AddWithValue("@Ngay", dtpNgayKham.Value);
                    cmd.Parameters.AddWithValue("@Gio", cbKhunggio.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtTenbenhnhan.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@TT", cbTragthai.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadDanhSachLichKham();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMalich.Text)) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa lịch này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM LichKham WHERE MaLich = @Ma";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Ma", txtMalich.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Xóa thành công!");
                        LoadDanhSachLichKham();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }

        }

        private void dgvDanhsachlichkham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhsachlichkham.Rows[e.RowIndex];
                txtMalich.Text = row.Cells["MaLich"].Value.ToString();
                txtTenbenhnhan.Text = row.Cells["TenBenhNhan"].Value.ToString();
                cbBacsi.Text = row.Cells["BacSi"].Value.ToString();
                cbChuyenkhoa.Text = row.Cells["ChuyenKhoa"].Value.ToString();
                dtpNgayKham.Value = Convert.ToDateTime(row.Cells["NgayKham"].Value);
                cbKhunggio.Text = row.Cells["KhungGio"].Value.ToString();
                cbTragthai.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }


        private void tabQlithuchi_Click(object sender, EventArgs e)
        {
            LoadDataThuChi();

        }

        private void panelTongthuhomnay_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panelTongthuhomnay.ClientRectangle, Color.Gray, ButtonBorderStyle.Dotted);
        }

        private void panelTongchihomnay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTongloinhuan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDanhsachkhoanthuhomnay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private DataTable GetDanhSachThu(DateTime ngay)
        {
            string query = "SELECT MaPhieuThu, NgayThu, SoTien, HinhThuc FROM PhieuThu WHERE CAST(NgayThu AS DATE) = @ngay";
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ngay", ngay.Date);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách thu: " + ex.Message);
            }
            return dt;
        }

        private void dgvDanhsachkhoanchihomnay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            Series series = new Series("Doanh thu 7 ngày gần nhất");
            series.ChartType = SeriesChartType.Column; // Dạng cột như hình

            // Giả sử lấy dữ liệu từ list hoặc DB
            series.Points.AddXY("10/01", 75);
            series.Points.AddXY("11/01", 82);
            series.Points.AddXY("12/01", 70);
            // ...

            chart1.Series.Add(series);
        }


        private void LoadDataThuChi()
        {

            DateTime today = DateTime.Today;
            dgvDanhsachkhoanthuhomnay.DataSource = GetDanhSachThu(today);


        }
        public class DichVu
        {
            public string MaDV { get; set; }
            public string TenDV { get; set; }
            public decimal DonGia { get; set; }
            public double TyLeBHYT { get; set; } // Ví dụ: 0.8 (80%)
        }
        private void tabQlidichvu_Click(object sender, EventArgs e)
        {
            LoadDanhSachDichVu();
        }

        private void dgvBangDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin hàng vừa click
                DataGridViewRow row = dgvBangDV.Rows[e.RowIndex];
                string maDV = row.Cells["MaDV"].Value.ToString();
                decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                double tyLe = Convert.ToDouble(row.Cells["TyLeBHYT"].Value);

                // Tính toán số tiền
                decimal tienBHYTChiTra = donGia * (decimal)tyLe;
                decimal tienBenhNhanTra = donGia - tienBHYTChiTra;

                // Thêm vào bảng khám bệnh phía dưới
                dgvBangkhambenh.Rows.Add(maDV, (tyLe * 100) + "%", donGia, tienBenhNhanTra, tienBHYTChiTra, "Xóa");
            }


        }

        private void dgvBangkhambenh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                dgvBangkhambenh.Rows.RemoveAt(e.RowIndex);
            }
            if (e.RowIndex < 0) return;


            if (dgvBangkhambenh.Columns[e.ColumnIndex].Name == "btnXoa")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này khỏi danh sách khám?",
                                                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dgvBangkhambenh.Rows.RemoveAt(e.RowIndex);
                    TinhTongTienBenhNhan();
                }
            }
            if (dgvBangkhambenh.Columns[e.ColumnIndex].Name == "btnSua")
            {

                dgvBangkhambenh.CurrentRow.ReadOnly = false;


                dgvBangkhambenh.CurrentCell = dgvBangkhambenh.Rows[e.RowIndex].Cells["colPhantram"];
                dgvBangkhambenh.BeginEdit(true);

                MessageBox.Show("Vui lòng nhập giá trị mới và nhấn Enter để cập nhật.");
            }
        }
        private void TinhTongTienBenhNhan()
        {
            decimal tongCong = 0;

            // Duyệt qua từng dòng trong bảng khám bệnh
            foreach (DataGridViewRow row in dgvBangkhambenh.Rows)
            {
                // Kiểm tra dòng đó không phải dòng trống (NewRow) và có giá trị
                if (row.Cells[3].Value != null)
                {
                    tongCong += Convert.ToDecimal(row.Cells[3].Value);
                }
            }

            // Hiển thị lên Label với định dạng phân cách hàng nghìn
            labelTongtien.Text = tongCong.ToString("N0") + " VNĐ";
        }

        private void tabPageTongquan_Click(object sender, EventArgs e)
        {
            try
            {

                chartThongkelichkham.Series["Lượt khám"].Points.Clear();
                chartThongkelichkham.Series["Lượt khám"].Points.AddXY("T2", 95);
                chartThongkelichkham.Series["Lượt khám"].Points.AddXY("T3", 35);
                chartThongkelichkham.Series["Lượt khám"].Points.AddXY("T4", 25);
                chartThongkelichkham.Series["Lượt khám"].Points.AddXY("T5", 25);
                // ... tương tự cho Doanh thu (đường line)

                // 3. Đổ dữ liệu vào Biểu đồ tròn (Cơ cấu bệnh nhân)
                chart2.Series[0].Points.Clear();
                chart2.Series[0].Points.AddXY("Nội khoa", 40);
                chart2.Series[0].Points.AddXY("Ngoại khoa", 25);
                chart2.Series[0].Points.AddXY("Nhi khoa", 20);
                chart2.Series[0].Points.AddXY("Khác", 15);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void labelTongbenhnhan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTbenhnhan_Click(object sender, EventArgs e)
        {

        }

        private void lblTongbacsi_Click(object sender, EventArgs e)
        {

        }

        private void lblTonglichlam_Click(object sender, EventArgs e)
        {

        }

        private void lblDoanhthu_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }

        private void chartThongkelichkham_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }



        private void UpdateChartsByTime(string timeRange)
        {


            if (timeRange == "ThangNay")
            {

            }
            else if (timeRange == "HomNay")
            {

            }
        }


        private void lblDoanhthuhomnay_Click(object sender, EventArgs e)
        {

        }

        private void lblDoanhthutuan_Click(object sender, EventArgs e)
        {

        }

        private void lblDoanhthuthang_Click(object sender, EventArgs e)
        {

        }

        private void lblDoanhthunam_Click(object sender, EventArgs e)
        {

        }

        private void chartDoanhthutheongay_Click(object sender, EventArgs e)
        {

        }

        private void chartDoanhthutheoDV_Click(object sender, EventArgs e)
        {

        }

        private void dgvBangchitietdoanhthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chartThongkethuchi_Click(object sender, EventArgs e)
        {

        }

        private void dgvTopBScodoanhthucao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPageDoanhthu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

               
                lblDoanhthuhomnay.Text = GetScalarValue(conn, "SELECT SUM(TongTien) FROM HoaDon WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE)");
                lblDoanhthutuan.Text = GetScalarValue(conn, "SELECT SUM(TongTien) FROM HoaDon WHERE DATEPART(week, NgayLap) = DATEPART(week, GETDATE())");
                lblDoanhthuthang.Text = GetScalarValue(conn, "SELECT SUM(TongTien) FROM HoaDon WHERE MONTH(NgayLap) = MONTH(GETDATE())");
                lblDoanhthunam.Text = GetScalarValue(conn, "SELECT SUM(TongTien) FROM HoaDon WHERE YEAR(NgayLap) = YEAR(GETDATE())");

                
                FillChart(conn, chartDoanhthutheongay, "SELECT DAY(NgayLap), SUM(TongTien) FROM HoaDon GROUP BY DAY(NgayLap)");

                // 3. Vẽ biểu đồ Doanh thu theo dịch vụ (PieChart)
                FillPieChart(conn, chartDoanhthutheoDV, "SELECT TenDV, SUM(ThanhTien) FROM ChiTietDichVu GROUP BY TenDV");

                // 4. Đổ dữ liệu vào DataGridView
                FillGrid(conn, dgvTopBScodoanhthucao, "SELECT TOP 5 MaBS, HoTen, SUM(DoanhThu) FROM... GROUP BY...");
            }
        }
            private string GetScalarValue(SqlConnection conn, string query)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != DBNull.Value && result != null ? string.Format("{0:N0} VNĐ", result) : "0 VNĐ";
        }

        private void FillChart(SqlConnection conn, Chart chart, string query)
        {
            chart.Series.Clear();
            Series series = new Series("Doanh thu theo ngày");
            series.ChartType = SeriesChartType.Column;

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string xValue = reader[0].ToString();
                    decimal yValue = reader[1] != DBNull.Value ? Convert.ToDecimal(reader[1]) : 0;
                    series.Points.AddXY(xValue, yValue);
                }
            }
            chart.Series.Add(series);
        }

        private void FillPieChart(SqlConnection conn, Chart chart, string query)
        {
            chart.Series.Clear();
            Series series = new Series("Doanh thu theo dịch vụ");
            series.ChartType = SeriesChartType.Pie;

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string xValue = reader[0].ToString();
                    decimal yValue = reader[1] != DBNull.Value ? Convert.ToDecimal(reader[1]) : 0;
                    series.Points.AddXY(xValue, yValue);
                }
            }
            chart.Series.Add(series);
        }

        private void FillGrid(SqlConnection conn, DataGridView grid, string query)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            grid.DataSource = dt;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btThemBS_Click(object sender, EventArgs e)
        {
            frmBacsi frm = new frmBacsi();
            frm.State = "Them";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachBacSi(); // Load lại GridView ở Form2
            }
        }

        private void btSuaBS_Click(object sender, EventArgs e)
        {
            if (dgvDanhsachbacsi.CurrentRow != null) // Nếu đã chọn một dòng trên GridView
            {
                frmBacsi frm = new frmBacsi();
                frm.State = "Sua";

                // Truyền dữ liệu từ dòng đang chọn sang Form con
                frm.txtID.Text = dgvDanhsachbacsi.CurrentRow.Cells["ID"].Value.ToString();
                frm.txtHoten.Text = dgvDanhsachbacsi.CurrentRow.Cells["HoTen"].Value.ToString();
                frm.cbChuyenkhoa.Text = dgvDanhsachbacsi.CurrentRow.Cells["ChuyenKhoa"].Value.ToString();
                frm.txtTrinhdo.Text = dgvDanhsachbacsi.CurrentRow.Cells["TrinhDo"].Value.ToString();
                frm.txtKinhnghiem.Text = dgvDanhsachbacsi.CurrentRow.Cells["KinhNghiem"].Value.ToString();
                frm.txtSDT.Text = dgvDanhsachbacsi.CurrentRow.Cells["SDT"].Value.ToString();
                frm.txtEmail.Text = dgvDanhsachbacsi.CurrentRow.Cells["Email"].Value.ToString();

                // ... truyền tiếp các trường khác

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachBacSi();
                }
            }
        }

        private void btXoaBS_Click(object sender, EventArgs e)
        {
            
            LoadDanhSachBacSi();
        }

        bool isAddMode = false;

        private void pnQlilichkham_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboChuyenkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btTimkiem_Click(object sender, EventArgs e)
        {
            string key = btTimkiem.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT * 
                       FROM LichKham
                       WHERE TenBN LIKE @key 
                          OR MaBN LIKE @key";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDanhsachlichkham.DataSource = dt;
            }
        }

        void EnableInput(bool enable)
        {
            txtMalich.ReadOnly = !enable;
            cbBacsi.Enabled = enable;
            cbChuyenkhoa.Enabled = enable;
            dtpNgayKham.Enabled = enable;
            cbKhunggio.Enabled = enable;
            txtTenbenhnhan.ReadOnly = !enable;
            txtSDT.ReadOnly = !enable;
            cbTragthai.Enabled = enable;
        }

        void ClearInput()
        {
            txtMalich.Clear();
            txtTenbenhnhan.Clear();
            txtSDT.Clear();

            cbBacsi.SelectedIndex = -1;
            cbChuyenkhoa.SelectedIndex = -1;
            cbKhunggio.SelectedIndex = -1;
            cbTragthai.SelectedIndex = -1;

            dtpNgayKham.Value = DateTime.Now;
        }

        private void btLuuthongtin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO LichKham
                            (MaLich, BacSi, ChuyenKhoa, NgayKham, KhungGio, TenBenhNhan, SDT, TrangThai)
                            VALUES (@Ma,@BS,@Khoa,@Ngay,@Gio,@Ten,@SDT,@TT)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ma", txtMalich.Text);
                    cmd.Parameters.AddWithValue("@BS", cbBacsi.Text);
                    cmd.Parameters.AddWithValue("@Khoa", cbChuyenkhoa.Text);
                    cmd.Parameters.AddWithValue("@Ngay", dtpNgayKham.Value);
                    cmd.Parameters.AddWithValue("@Gio", cbKhunggio.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtTenbenhnhan.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@TT", cbTragthai.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm lịch khám thành công!");
                LoadDanhSachLichKham();

                // Quay về mode xem
                ExitAddMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            isAddMode = false;

            EnableInput(false);
            dataGridView1.Enabled = true;

            btThem.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;

            btLuuthongtin.Visible = false;
            btHuy.Visible = false;
        }

        private void btnTimkiemBS_Click(object sender, EventArgs e)
        {

        }
    }
}


























