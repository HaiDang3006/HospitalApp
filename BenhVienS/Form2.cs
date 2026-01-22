using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static BenhVienS.Form2;
using System.Configuration;

namespace BenhVienS
{
    public partial class Form2 : Form
    {
        // Thêm dấu @ và bao quanh bằng dấu ngoặc kép ""
        string connectionString = @"Data Source=localhost\SQLEXPRESS02;Initial Catalog=BenhVienV1;Integrated Security=True;"; 
        public Form2()
        {
            InitializeComponent();



        }

        //code của trang tổng quan//

        private void LoadTongBenhNhanHomNay()
        {
            string sql = "SELECT COUNT(DISTINCT MaBenhNhan) FROM LichHen WHERE CAST(NgayHen AS DATE) = CAST(GETDATE() AS DATE)";
            lbltongsobenhnhan.Text = GetScalarInt(sql).ToString();
        }

        private void LoadDoanhThuHomNay()
        {
            string sql = "SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE DaThanhToan = 1 AND CAST(NgayThanhToan AS DATE) = CAST(GETDATE() AS DATE)";
            decimal doanhThu = GetScalarDecimal(sql);
            lbldoanhthu23.Text = doanhThu.ToString("N0") + " VNĐ";
        }

        private int GetScalarInt(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private decimal GetScalarDecimal(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                object res = cmd.ExecuteScalar();
                return res != DBNull.Value ? Convert.ToDecimal(res) : 0;
            }
        }

        private void LoadDoanhThuTheoNam(int nam)
        {
            chartDoanhthu.Series.Clear();
            Series series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Column;

            string sql = @"
          WITH Thang AS (
              SELECT 1 AS T UNION ALL SELECT T+1 FROM Thang WHERE T < 12
          )
          SELECT T.T as Thang, ISNULL(SUM(h.TongTien), 0) AS DoanhThu
          FROM Thang T
          LEFT JOIN HoaDon h ON MONTH(h.NgayThanhToan) = T.T AND YEAR(h.NgayThanhToan) = @Nam AND h.DaThanhToan = 1
          GROUP BY T.T ORDER BY T.T";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nam", nam);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    series.Points.AddXY("Tháng " + rd["Thang"], rd["DoanhThu"]);
                }
            }
            chartDoanhthu.Series.Add(series);
            series.LabelFormat = "#,##0";
        }

        public void LoadLichHenHomNay()
        {
            string query = @"SELECT LH.MaLichHen, BN.SoCCCD, LH.NgayHen, LH.LyDoKham, LH.TrangThai 
             FROM LichHen LH 
             JOIN BenhNhan BN ON LH.MaBenhNhan = BN.MaBenhNhan 
             WHERE CAST(LH.NgayHen AS DATE) = CAST(GETDATE() AS DATE)
             ORDER BY LH.NgayHen ASC";

            DataTable dt = new DataTable();
            try
            {
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                dgvLichhenhomnay.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNam.SelectedItem != null)
                LoadDoanhThuTheoNam(Convert.ToInt32(cboNam.SelectedItem));
        }

        //code của trang tổng quan//


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



     
        


        private void Form2_Load(object sender, EventArgs e)
        {
            LoadChuyenmon();

            // Tải toàn bộ danh sách bác sĩ khi form mở
            LoadDanhSachBacSi();

            // Tải lịch làm việc hôm nay
            LoadLichLamHomNay();
            LoadDanhSachBenhNhan();
            
            //load dịch vụ//
            LoadLoaiDichVu();
            LoadDichVu();

            //Trang tổng quan//
            LoadTongBenhNhanHomNay();
            LoadLichHenHomNay();
            LoadDoanhThuHomNay();
            for (int i = 2020; i <= DateTime.Now.Year; i++)//khởi tạo combo load năm//

            {
                cboNam.Items.Add(i);
            }
            cboNam.SelectedItem = DateTime.Now.Year;
            LoadDoanhThuTheoNam(DateTime.Now.Year);

            //Tab quản lí lịch làm//
            LoadLichLamViec();
            LoadBacSi();

            LoadDanhSachVaiTro();

          
            LoadDanhSachBacSi();
            TaoMaLichTuDong();
            // Gán dữ liệu mặc định cho ComboBox Trạng thái
            cbTragthai.Items.AddRange(new string[] { "Mới", "Đã xác nhận", "Đã khám", "Hủy" });
            cbTragthai.SelectedIndex = 0;
        }

        private void LoadDanhSachLichKham()
        {
           
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
           
        }

        void ExitAddMode()
        {
            //isAddMode = false;

            EnableInput(false);
            dgvLichhenhomnay.Enabled = true;

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
            //isAddMode = true;

            // Cho phép nhập
            EnableInput(true);

            // Xóa dữ liệu cũ
            ClearInput();

            // Khóa bảng danh sách
            dgvLichhenhomnay.Enabled = false;

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

        private void dgvDanhsachkhoanchihomnay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void chartThongketaichinh_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu cũ
            chartThongketaichinh.Series.Clear();
            chartThongketaichinh.Titles.Clear();
            chartThongketaichinh.Titles.Add("Thống kê tài chính hôm nay");

            // Lấy dữ liệu an toàn
            double doanhThu = 0, chiPhi = 0;
            double.TryParse(txtTongdoanhthuhomnay.Text, out doanhThu);
            double.TryParse(txtTongchihomnay.Text, out chiPhi);

            // Tạo Series
            Series series = new Series("VND");
            series.ChartType = SeriesChartType.Column; // Chọn kiểu biểu đồ cột

            // Thêm dữ liệu
            series.Points.AddXY("Doanh thu", doanhThu);
            series.Points.AddXY("Chi phí", chiPhi);

            // Thêm vào biểu đồ
            chartThongketaichinh.Series.Add(series);
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

       /// bool isAddMode = false;

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
            //isAddMode = false;

            EnableInput(false);
            dgvLichhenhomnay.Enabled = true;

            btThem.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;

            btLuuthongtin.Visible = false;
            btHuy.Visible = false;
        }

        private void btnTimkiemBS_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {

        }

        private void txtTongdoanhthuhomnay_TextChanged(object sender, EventArgs e)
        {
            TinhLoiNhuan();
        }

        private void txtTongchihomnay_TextChanged(object sender, EventArgs e)
        {
            TinhLoiNhuan();
        }

        private void btnLoinhuanhomnay_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy dữ liệu từ TextBox và xóa bỏ các ký tự không phải số (nếu có format tiền tệ)
                string strDoanhThu = txtTongdoanhthuhomnay.Text.Trim();
                string strChiPhi = txtTongchihomnay.Text.Trim();

                // 2. Chuyển đổi sang kiểu decimal (phù hợp cho tiền tệ)
                decimal doanhThu = string.IsNullOrEmpty(strDoanhThu) ? 0 : decimal.Parse(strDoanhThu);
                decimal chiPhi = string.IsNullOrEmpty(strChiPhi) ? 0 : decimal.Parse(strChiPhi);

                // 3. Tính toán
                decimal loiNhuan = doanhThu - chiPhi;

                // 4. Hiển thị kết quả (Ví dụ hiển thị lên một Label hoặc chính nó)
                // Format "N0" để hiển thị dấu phân cách hàng nghìn
                MessageBox.Show($"Lợi nhuận hôm nay là: {loiNhuan.ToString("N0")} VNĐ", "Kết quả");
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng chỉ nhập số vào ô Doanh thu và Chi phí!", "Lỗi nhập liệu");
            }

        }
        private void TinhLoiNhuan()
        {
            decimal.TryParse(txtTongdoanhthuhomnay.Text, out decimal dt);
            decimal.TryParse(txtTongchihomnay.Text, out decimal cp);

            decimal ketQua = dt - cp;
            // Giả sử bạn có lblKetQua để hiển thị
            // lblKetQua.Text = ketQua.ToString("N0"); 
        }

        private void btnTongsobacsi_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(*) FROM BacSi";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    btnTongsobacsi.Text = $"Tổng bác sĩ: {count}";
                }
            }
        }


        private void btntongbenhnhna_Click(object sender, EventArgs e)
        {
           
            string query = "SELECT COUNT(*) FROM BenhNhan";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    btntongbenhnhan.Text = $"Tổng bệnh nhân: {count}";
                }
            }
        }

        

        private void btnDoanhthu_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(*) FROM Doanhthu";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    btnDoanhthu.Text = $"Tổng doanh thu: {count}";
                }
            }
        }

        private void chartbaocaolichkham_Click(object sender, EventArgs e)
        {
            
        }

        private void chartsolichkhamdadatdahuy_Click(object sender, EventArgs e)
        {
            chartsolichkhamdadatdahuy.Series.Clear();
            Series s = chartsolichkhamdadatdahuy.Series.Add("Trạng thái");
            s.ChartType = SeriesChartType.Pie; // Biểu đồ tròn

            // Giả sử lấy từ DB
            int daDat = 80; // Truy vấn SQL: WHERE TrangThai = 'DaDat'
            int daHuy = 20; // Truy vấn SQL: WHERE TrangThai = 'DaHuy'

            s.Points.AddXY("Đã đặt", daDat);
            s.Points.AddXY("Đã hủy", daHuy);
        }

        private void chartThongketheodichvu_Click(object sender, EventArgs e)
        {

            chartThongketheodichvu.Series.Clear();
            chartThongketheodichvu.Titles.Clear();
            chartThongketheodichvu.Titles.Add("Thống kê Loại hình khám & Bảo hiểm");

            // 2. Tạo Series cho nhóm Dịch vụ
            Series seriesDichVu = chartThongketheodichvu.Series.Add("Loại hình khám");
            seriesDichVu.ChartType = SeriesChartType.Column; // Biểu đồ cột

            // Giả sử lấy số liệu từ hàm truy vấn (thay số bằng biến từ DB)
            int soCaDichVu = 150;
            int soCaThuong = 90;

            seriesDichVu.Points.AddXY("Có Dịch vụ", soCaDichVu);
            seriesDichVu.Points.AddXY("Không Dịch vụ", soCaThuong);

            // 3. Tạo Series cho nhóm BHYT
            Series seriesBHYT = chartThongketheodichvu.Series.Add("Bảo hiểm");
            seriesBHYT.ChartType = SeriesChartType.Column;

            int soCaBHYT = 200;
            int soCaKhongBHYT = 40;

            seriesBHYT.Points.AddXY("Có BHYT", soCaBHYT);
            seriesBHYT.Points.AddXY("Không BHYT", soCaKhongBHYT);

            // Thêm nhãn số liệu trên đầu cột
            seriesDichVu.IsValueShownAsLabel = true;
            seriesBHYT.IsValueShownAsLabel = true;
        }

        private void chartBaocaothuchi_Click(object sender, EventArgs e)
        {
        }

        private void chartBieudodoanhthu_Click(object sender, EventArgs e)
        {
           
        }

        private void chartBieudoluotkham_Click(object sender, EventArgs e)
        {
            
        }

        private void dateLocngay_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateLocngay.Value.Date;
        }
        void LoadDanhSachBacSi()
        {
            string connStr = ConfigurationManager
                .ConnectionStrings["BenhVienV1ConnectionString"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
            SELECT
                bs.MaBacSi,
                nd.HoTen,
                nd.Email,
                nd.SoDienThoai,
                CASE 
                    WHEN nd.GioiTinh = 1 THEN N'Nam'
                    ELSE N'Nữ'
                END AS GioiTinh,
                ck.TenChuyenKhoa,
                bs.BangCap,
                bs.TrangThai
            FROM BacSi bs
            JOIN NguoiDung nd ON bs.MaNguoiDung = nd.MaNguoiDung
            JOIN ChuyenKhoa ck ON bs.MaChuyenKhoa = ck.MaChuyenKhoa
            WHERE nd.TrangThai = 1",
                    conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvbacsi.DataSource = dt;
            }
        }
        private void dateDenngay_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateDenngay.Value.Date;
        }

        private void btnTimkiemngay_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dateLocngay.Value.Date;
            DateTime denNgay = dateDenngay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Câu lệnh SQL mẫu để lọc dữ liệu trong khoảng ngày
            string query = $"SELECT * FROM KhoanChi WHERE NgayChi BETWEEN '{tuNgay:yyyy-MM-dd}' AND '{denNgay:yyyy-MM-dd}'";

            // Gọi hàm thực thi SQL và đổ dữ liệu vào DataGridView
            // dgvDanhsachkhoanchihomnay.DataSource = dataProvider.ExecuteQuery(query);

            // Sau khi lọc xong, đừng quên cập nhật lại các biểu đồ để khớp với dữ liệu mới
            // CapNhatTatCaBieuDo(tuNgay, denNgay);
        }


        private void panel14_Paint(object sender, PaintEventArgs e)
        { }

        private void bthem_Click(object sender, EventArgs e)

        {

        }

        private void txtnhaphoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }
        //của quản lí bệnh nhân nè//
        private void btnthemmoinguoidung_Click(object sender, EventArgs e)
        {
            frmvaitro f = new frmvaitro();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachBacSi(); // reload dgv
            }
        }
        //của quản lí bệnh nhân nè//
        private void dgvAlldanhsachlichlam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhsachvaitro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvmenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvbacsi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemmoivaitro_Click(object sender, EventArgs e)
        {
            frmthemvaitromoi frm = new frmthemvaitromoi();

            //  đăng ký lắng nghe event
            frm.VaiTroDaThayDoi += LoadDanhSachVaiTro;

            frm.ShowDialog();
        }

        private void LoadDanhSachVaiTro()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT MaVaiTro, TenVaiTro, MoTa, TrangThai FROM VaiTro";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDanhsachvaitro.DataSource = dt;

                // cập nhật số lượng
                lblSoluongvaitro.Text = dt.Rows.Count.ToString();
            }
        }
        

        private void btcaidat_Click(object sender, EventArgs e)
        {
            caidat f = new caidat();
            if (f.ShowDialog() == DialogResult.OK)
            {

            }
        }

        void LoadBenhNhan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM BenhNhan WHERE TrangThai = 1", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvbenhnhan.DataSource = dt;
            }
        }

        void LoadDanhSachBenhNhan()
        {
            string connStr = ConfigurationManager
                .ConnectionStrings["BenhVienV1ConnectionString"]
                .ConnectionString;

            string sql = @"
        SELECT 
            bn.MaBenhNhan,
            bn.MaNguoiDung,
            nd.HoTen,
            nd.SoDienThoai,
            nd.DiaChi,
            nd.NgaySinh,
            CASE WHEN nd.GioiTinh = 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh
        FROM BenhNhan bn
        JOIN NguoiDung nd ON bn.MaNguoiDung = nd.MaNguoiDung
    ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvbenhnhan.AutoGenerateColumns = true; // QUAN TRỌNG
                dgvbenhnhan.DataSource = dt;
            }
        }
        private void btSuaa_Click(object sender, EventArgs e)
        {
            if (dgvbenhnhan.CurrentRow == null)
            {
                MessageBox.Show("Chọn bệnh nhân cần sửa");
                return;
            }

            thembenhnhan frm = new thembenhnhan();

            frm.SetBenhNhanData(
                Convert.ToInt32(dgvbenhnhan.CurrentRow.Cells["MaBenhNhan"].Value),
                Convert.ToInt32(dgvbenhnhan.CurrentRow.Cells["MaNguoiDung"].Value),
                dgvbenhnhan.CurrentRow.Cells["HoTen"].Value.ToString(),
                Convert.ToDateTime(dgvbenhnhan.CurrentRow.Cells["NgaySinh"].Value),
                dgvbenhnhan.CurrentRow.Cells["GioiTinh"].Value.ToString(),
                dgvbenhnhan.CurrentRow.Cells["SoDienThoai"].Value.ToString(),
                dgvbenhnhan.CurrentRow.Cells["DiaChi"].Value.ToString()
            );

            frm.ShowDialog();
            LoadDanhSachBenhNhan(); // reload dgv
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dgvbenhnhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbdsbenhnhan_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimBenhNhan();
        }

        void TimBenhNhan()
        {
            string keyword = txtTim.Text.Trim();

            string connStr = ConfigurationManager
                .ConnectionStrings["BenhVienV1ConnectionString"]
                .ConnectionString;

            string sql = @"
        SELECT 
            bn.MaBenhNhan,
            bn.MaNguoiDung,
            nd.HoTen,
            nd.SoDienThoai,
            nd.DiaChi,
            nd.NgaySinh,
            CASE WHEN nd.GioiTinh = 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh
        FROM BenhNhan bn
        JOIN NguoiDung nd ON bn.MaNguoiDung = nd.MaNguoiDung
        WHERE nd.HoTen LIKE N'%' + @kw + '%'
           OR nd.SoDienThoai LIKE '%' + @kw + '%'
    ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@kw", keyword);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvbenhnhan.DataSource = dt;
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            
                TimBenhNhan();
            
        }

        private void btlammoi_Click(object sender, EventArgs e)
        {
            txtTim.Clear();
            LoadDanhSachBenhNhan();
        }

        ///Quản lí dịch vụ ///
        void LoadDichVu()
        {
            string connStr = ConfigurationManager
                .ConnectionStrings["BenhVienV1ConnectionString"]
                .ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"
            SELECT 
                MaDichVu,
                TenDichVu,
                LoaiDichVu,
                DonGia,
                CASE WHEN ApDungBHYT = 1 THEN N'Có' ELSE N'Không' END AS ApDungBHYT,
                ThoiGianThucHien,
                CASE WHEN TrangThai = 1 THEN N'Đang áp dụng' ELSE N'Ngưng' END AS TrangThai
            FROM DichVu";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDichVu.DataSource = dt;
            }
        }

        private void bthemdv_Click(object sender, EventArgs e)
        {
            themdichvu frm = new themdichvu();
            if (frm.ShowDialog() == DialogResult.OK)
                LoadDichVu();
        }

        private void btsuadv_Click(object sender, EventArgs e)
        {
            int ma = Convert.ToInt32(dgvDichVu.CurrentRow.Cells["MaDichVu"].Value);
            themdichvu frm = new themdichvu(ma);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadDichVu();
        }

        private void btngungdv_Click(object sender, EventArgs e)
        {

            string connStr = ConfigurationManager
               .ConnectionStrings["BenhVienV1ConnectionString"]
               .ConnectionString;
            if (dgvDichVu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ");
                return;
            }

            int ma = Convert.ToInt32(
                dgvDichVu.CurrentRow.Cells["MaDichVu"].Value);

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc muốn NGƯNG dịch vụ này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE DichVu SET TrangThai = 0 WHERE MaDichVu = @Ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Ma", ma);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadDichVu();
        }

        private void bttimdichvu_Click(object sender, EventArgs e)
        {

        }

        private void txtTimTenDV_TextChanged(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager
              .ConnectionStrings["BenhVienV1ConnectionString"]
              .ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"
            SELECT *
            FROM DichVu
            WHERE TenDichVu LIKE @ten";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", "%" + txtTimTenDV.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDichVu.DataSource = dt;
            }
        }

        private void cobtatcadichvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobtatcadichvu.SelectedItem == null) return;

            string loai = cobtatcadichvu.SelectedItem.ToString();

            if (loai == "Tất cả")
            {
                LoadDichVu();
                return;
            }

            using (SqlConnection conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["BenhVienV1ConnectionString"].ConnectionString))
            {
                string sql = "SELECT * FROM DichVu WHERE LoaiDichVu = @Loai";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Loai", loai);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDichVu.DataSource = dt;
            }
        }

        private void chbapdungbhyt_CheckedChanged(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager
              .ConnectionStrings["BenhVienV1ConnectionString"]
              .ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"
            SELECT *
            FROM DichVu
            WHERE ApDungBHYT = @bhyt";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@bhyt", chbapdungbhyt.Checked ? 1 : 0);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDichVu.DataSource = dt;
            }
        }

        private void btlmmoidv_Click(object sender, EventArgs e)
        {
            txtTimTenDV.Clear();
            cobtatcadichvu.SelectedIndex = 0;
            chbapdungbhyt.Checked = false;
            LoadDichVu();
        }

        private void LoadLoaiDichVu()
        {
            cobtatcadichvu.Items.Clear();
            cobtatcadichvu.Items.Add("Tất cả");   // chỉ dùng để load full
            cobtatcadichvu.Items.Add("Kham");
            cobtatcadichvu.Items.Add("XetNghiem");
            cobtatcadichvu.Items.Add("SieuAm");
            cobtatcadichvu.Items.Add("ChupXQuang");
            cobtatcadichvu.Items.Add("NoiSoi");
            cobtatcadichvu.Items.Add("Khac");

            cobtatcadichvu.SelectedIndex = 0;
        }

        private void btkichhoat_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager
             .ConnectionStrings["BenhVienV1ConnectionString"]
             .ConnectionString;
            if (dgvDichVu.CurrentRow == null) return;

            int maDV = Convert.ToInt32(
                dgvDichVu.CurrentRow.Cells["MaDichVu"].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE DichVu SET TrangThai = 1 WHERE MaDichVu = @MaDV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDV", maDV);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadDichVu();
        }

        //code quản lí lịch làm việc//
        private void dgvLichLamViec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btthmlich_Click(object sender, EventArgs e)
        {
            frmThemSuaLichLamViec frm = new frmThemSuaLichLamViec();
            if (frm.ShowDialog() == DialogResult.OK)
                LoadLichLamViec();
        }

        private void btsualich_Click(object sender, EventArgs e)
        {
            if (dgvLichLamViec.CurrentRow == null) return;

            int ma = Convert.ToInt32(
                dgvLichLamViec.CurrentRow.Cells["MaLichLamViec"].Value);

            frmThemSuaLichLamViec frm = new frmThemSuaLichLamViec(ma);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadLichLamViec();
            }
        }

        void LoadLichLamViec()
        {
            string connStr = ConfigurationManager
        .ConnectionStrings["BenhVienV1ConnectionString"]
        .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"
                SELECT
                    llv.MaLichLamViec,
                    bs.MaNguoiDung,
                    pk.TenPhong,
                    c.TenCa,
                    llv.NgayLamViec,
                    llv.TrangThai
                FROM LichLamViec llv
                JOIN BacSi bs ON llv.MaBacSi = bs.MaBacSi
                JOIN PhongKham pk ON llv.MaPhong = pk.MaPhong
                JOIN CaLamViec c ON llv.MaCa = c.MaCa
                ORDER BY llv.NgayLamViec DESC"; 

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvLichLamViec.DataSource = dt;
            }
        }

        void LoadBacSi()
        {
            string connStr = ConfigurationManager
        .ConnectionStrings["BenhVienV1ConnectionString"]
        .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"
        SELECT 
            bs.MaBacSi,
            nd.HoTen
        FROM BacSi bs
        JOIN NguoiDung nd ON bs.MaNguoiDung = nd.MaNguoiDung
        WHERE bs.TrangThai = 1";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbobacsi.DataSource = dt;
                cbobacsi.DisplayMember = "HoTen";   // ✔ có thật
                cbobacsi.ValueMember = "MaBacSi";  // ✔ int
                cbobacsi.SelectedIndex = -1;
            }
        }

        private void cbobacsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbobacsi.SelectedIndex == -1) return;
            if (cbobacsi.SelectedValue == null) return;
            if (!(cbobacsi.SelectedValue is int)) return; // 🔒 chặn DataRowView

            int maBacSi = (int)cbobacsi.SelectedValue;

            string connStr = ConfigurationManager
                .ConnectionStrings["BenhVienV1ConnectionString"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"
        SELECT
            llv.MaLichLamViec,
            bs.MaNguoiDung,
            pk.TenPhong,
            c.TenCa,
            llv.NgayLamViec,
            llv.TrangThai
        FROM LichLamViec llv
        JOIN BacSi bs ON llv.MaBacSi = bs.MaBacSi
        JOIN PhongKham pk ON llv.MaPhong = pk.MaPhong
        JOIN CaLamViec c ON llv.MaCa = c.MaCa
        WHERE llv.MaBacSi = @MaBacSi
        ORDER BY llv.NgayLamViec DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaBacSi", SqlDbType.Int).Value = maBacSi;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvLichLamViec.DataSource = dt;
            }
        }

        private void dtpngay_ValueChanged(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager
        .ConnectionStrings["BenhVienV1ConnectionString"]
        .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"
            SELECT
                llv.MaLichLamViec,
                bs.MaNguoiDung,
                pk.TenPhong,
                c.TenCa,
                llv.NgayLamViec,
                llv.TrangThai
            FROM LichLamViec llv
            JOIN BacSi bs ON llv.MaBacSi = bs.MaBacSi
            JOIN PhongKham pk ON llv.MaPhong = pk.MaPhong
            JOIN CaLamViec c ON llv.MaCa = c.MaCa
            WHERE llv.NgayLamViec = @Ngay
            ORDER BY llv.NgayLamViec DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Ngay", SqlDbType.Date)
                              .Value = dtpngay.Value.Date;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvLichLamViec.DataSource = dt;
            }
        }

        private void btlmoi_Click(object sender, EventArgs e)
        {
            cbobacsi.SelectedIndex = -1;
            dtpngay.Value = DateTime.Today;
            LoadLichLamViec();
        }

        private void btngunglich_Click(object sender, EventArgs e)
        {
            if (dgvLichLamViec.CurrentRow == null) return;

            int ma = Convert.ToInt32(
                dgvLichLamViec.CurrentRow.Cells["MaLichLamViec"].Value);

            string connStr = ConfigurationManager
                .ConnectionStrings["BenhVienV1ConnectionString"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE LichLamViec SET TrangThai = 0 WHERE MaLichLamViec = @Ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Ma", SqlDbType.Int).Value = ma;

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadLichLamViec();
        }

        private void btkkichhoatlich_Click(object sender, EventArgs e)
        {
            if (dgvLichLamViec.CurrentRow == null) return;

            int ma = Convert.ToInt32(
                dgvLichLamViec.CurrentRow.Cells["MaLichLamViec"].Value);

            string connStr = ConfigurationManager
                .ConnectionStrings["BenhVienV1ConnectionString"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE LichLamViec SET TrangThai = 1 WHERE MaLichLamViec = @Ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Ma", SqlDbType.Int).Value = ma;

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadLichLamViec();
        }

        private void dgvLichLamViec_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichLamViec.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                string trangThai = e.Value.ToString();

                if (trangThai == "SanSang")
                    e.Value = "Sẵn sàng";
                else if (trangThai == "DaKham")
                    e.Value = "Đã khám";
                else if (trangThai == "Nghi")
                    e.Value = "Nghỉ";

                e.FormattingApplied = true;
            }
        }
        //quản lí người dùng//
        private void dgvbenhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


























