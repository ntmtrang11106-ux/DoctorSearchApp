using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class frmGuest : Form
    {
        // Khai báo một lần ở cấp độ class để tái sử dụng
        private DoctorBUS _bus = new DoctorBUS();

        public frmGuest()
        {
            InitializeComponent();
            // Đăng ký sự kiện Load của Form
            this.Load += frmHome_Load;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void LoadDoctorData()
        {
            // 1. Xóa sạch các control cũ để tránh trùng lặp khi load lại
            flpDoctors.Controls.Clear();

            try
            {
                // 2. Lấy danh sách từ tầng BUS
                List<DoctorDTO> list = _bus.GetListDoctors();

                // Kiểm tra nếu danh sách rỗng thì thoát
                if (list == null || list.Count == 0) return;

                // 3. Duyệt danh sách và thêm vào FlowLayoutPanel
                foreach (var doc in list)
                {
                    // Khởi tạo UserControl Card
                    UCCardDoctor card = new UCCardDoctor();

                    // Truyền dữ liệu vào Card (Hàm này bạn đã viết ở UCCardDoctor)
                    card.SetDoctorData(doc);

                    // Chỉnh khoảng cách giữa các card cho đẹp
                    card.Margin = new Padding(15);

                    // THÊM VÀO flpDoctors
                    flpDoctors.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bác sĩ: " + ex.Message);
            }
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            // Chỉ gọi load dữ liệu một lần duy nhất khi Form vừa mở lên
            LoadDoctorData();
        }

        // Hàm bo góc
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void btn_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            int borderRadius = 20; // Độ bo góc, chỉnh số này theo ý muốn

            // 1. Cắt khung Button (Region)
            btn.Region = new Region(GetRoundedPath(btn.ClientRectangle, borderRadius));

            // 2. Vẽ lại viền cho mịn (Khử răng cưa)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Nếu muốn có viền thì thêm đoạn Pen ở đây, không thì thôi
            using (Pen pen = new Pen(btn.BackColor, 1))
            {
                e.Graphics.DrawPath(pen, GetRoundedPath(btn.ClientRectangle, borderRadius));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo Form Login
            frmLogin loginForm = new frmLogin();

            // 2. Ẩn Form hiện tại (frmGuest)
            this.Hide();

            // 3. Hiển thị Form Login
            loginForm.ShowDialog();
            // Dùng ShowDialog để nó chặn không cho tương tác với Form cũ 
            // hoặc dùng loginForm.Show() nếu muốn mở tự do.

            // 4. (Tùy chọn) Sau khi đóng Login thì hiện lại Guest
            this.Show();
        }
    }
}
