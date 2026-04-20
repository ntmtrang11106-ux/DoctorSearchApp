using BUS_Tier;
using DTO_Tier;
using System.Drawing.Drawing2D;

namespace UI_Tier
{
    public partial class UCCardDoctor : UserControl
    {

        public UCCardDoctor()
        {
            InitializeComponent();
            // Bo góc cho toàn bộ Card (nếu muốn)
            UIHelper.ApplyRoundedRegion(this, 15);

            // Bo góc cho Button Đăng nhập
            UIHelper.ApplyRoundedRegion(btnBook, 10);

            // Bo góc cho PictureBox (nếu bạn muốn bo nhẹ 4 góc)
            UIHelper.ApplyRoundedRegion(picDoctor, 15);

            UIHelper.ApplyRoundedRegion(pnlContainer, 20);

        }


        // Hàm này dùng để "đổ" dữ liệu từ đối tượng Doctor vào các Label
        // Trong UCCardDoctor.cs

        public void SetDoctorData(DoctorDTO doctor, bool isGuess)

        {
            lblFullName.Text = doctor.User.FullName;
            lblWorkPlace.Text = doctor.ClinicName;
            // 3. Địa chỉ (Kết hợp địa chỉ chi tiết và tên khu vực)
            lblSpecificAdress.Text = $"{doctor.ClinicAddress}, {doctor.Location.LocationName}";

            // 4. Thời gian làm việc (Nếu trong DTO bạn có trường Status hoặc WorkingTime)
            // Giả sử Status chứa chuỗi "Thứ 2 - Thứ 6, 8:00 - 16:00"
            lblWorkingTime.Text = doctor.User.Status;

            // 5. Giá tiền (Định dạng tiền tệ VNĐ: 500.000đ)
            lblPrice.Text = UIHelper.FormatVND(doctor.Price);

            // 6. Đánh giá (Số sao và tổng lượt review)
            lblRating.Text = $"{doctor.AverageRating}";
            lblTotalReviews.Text = $"({doctor.TotalReviews} đánh giá)";

            // 7. Kinh nghiệm
            lblEx.Text = $"{doctor.Experience_Years} năm kinh nghiệm";

            // 8. Chuyên khoa (Cái nhãn màu xanh góc trên cùng bên phải)
            BindData(doctor);

            // 9. Hình ảnh (Nếu có đường dẫn hoặc Image)
            // 9. Hình ảnh
            string fileName = doctor.User.Picture?.Trim(); // Thêm Trim() để xóa khoảng trắng thừa

            // Thử in ra console hoặc Debug để xem đường dẫn thực tế mà app đang tìm
            string imageFolder = Path.Combine(Application.StartupPath, "Resources_Images");
            string imagePath = Path.Combine(imageFolder, fileName ?? "");

            // Dòng này cực kỳ quan trọng để bạn tự kiểm tra lỗi
            System.Diagnostics.Debug.WriteLine("Đường dẫn tìm ảnh: " + imagePath);

            if (!string.IsNullOrEmpty(fileName) && File.Exists(imagePath))
            {
                // Giải phóng ảnh cũ nếu có để tránh tràn bộ nhớ
                if (picDoctor.Image != null) picDoctor.Image.Dispose();

                // Dùng FileStream để tránh việc file bị khóa (Lock)
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    picDoctor.Image = Image.FromStream(fs);
                }
            }
            else
            {
                // Nếu không tìm thấy, gán ảnh mặc định từ Resource (nếu bạn đã add vào Resources.resx)
                // Hoặc tạm thời để trống để biết là không tìm thấy file
                picDoctor.Image = null;
                System.Diagnostics.Debug.WriteLine("KHÔNG TÌM THẤY FILE ẢNH!");
            }

            // 10. Button
            if(isGuess)
                btnBook.Text = "Đăng nhập để đặt lịch";
            else
                btnBook.Text = "Đặt lịch";
        }

        private void UCCardDoctor_Paint(object sender, PaintEventArgs e)
        {
            Control paintControl = (Control)sender;
            // Cấu hình màu viền (Xám nhạt) và độ dày (1px)
            Color borderColor = Color.FromArgb(224, 224, 224);
            int borderWidth = 1;
            int borderRadius = 20; // Khớp với độ bo góc bạn đã làm

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Vẽ đường viền theo khung đã bo góc
                using (var path = UIHelper.GetRoundedPath(paintControl.ClientRectangle, borderRadius))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
        public void BindData(DoctorDTO doctor)
        {
            // 1. Dọn dẹp các ô cũ (tránh bị hiện trùng lặp khi load lại)
            flpSpecialties.Controls.Clear();

            // 2. Duyệt qua danh sách chuyên khoa N-N đã chốt ở DAL/BUS
            foreach (var ds in doctor.DoctorSpecialties)
            {
                // Tạo một Label mới "tại chỗ"
                Label lblTag = new Label();

                // Thiết lập nội dung và kích thước
                lblTag.Text = ds.Specialty.SpecialtyName;
                lblTag.AutoSize = true; // Để ô tự dài ra theo tên chuyên khoa

                // --- Trang trí cho giống cái "label1" màu xanh của bạn ---
                lblTag.BackColor = Color.FromArgb(0, 120, 215); // Màu xanh dương đậm
                lblTag.ForeColor = Color.White;                // Chữ trắng
                lblTag.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                lblTag.Padding = new Padding(5, 2, 5, 2);      // Tạo khoảng cách chữ với viền cho đẹp
                lblTag.Margin = new Padding(3, 0, 0, 0);       // Khoảng cách giữa các ô
                lblTag.TextAlign = ContentAlignment.MiddleCenter;

                // 3. Vứt ô này vào khay chứa FlowLayoutPanel
                flpSpecialties.Controls.Add(lblTag);
            }
        }

    }
}
