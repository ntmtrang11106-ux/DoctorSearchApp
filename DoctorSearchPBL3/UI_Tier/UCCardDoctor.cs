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
            lblWorkingTime.Text = $"Lịch: {doctor.WorkingTime}";

            // 5. Giá tiền (Định dạng tiền tệ VNĐ: 500.000đ)
            lblPrice.Text = UIHelper.FormatVND(doctor.Price);

            // 6. Đánh giá (Số sao và tổng lượt review)
            lblRating.Text = doctor.AverageRating.ToString("0.0"); // Ví dụ: 4.5
            lblTotalReviews.Text = $"{doctor.TotalReviews} đánh giá";

            // 7. Kinh nghiệm
            lblEx.Text = $"{doctor.Experience_Years} năm kinh nghiệm";

            // 8. Chuyên khoa (Cái nhãn màu xanh góc trên cùng bên phải)
            //lblSpecialtyTag.Text = doctor.Specialty.SpecialtyName;

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
            if (isGuess)
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

        private void UCCardDoctor_Load(object sender, EventArgs e)
        {
            // Bo góc cho toàn bộ Card (nếu muốn)
            UIHelper.ApplyRoundedRegion(this, 15);

            // Bo góc cho Label chuyên khoa ở góc phải
            UIHelper.ApplyRoundedRegion(lblSpecialtyTag, 8);

            // Bo góc cho Button Đăng nhập
            UIHelper.ApplyRoundedRegion(btnBook, 10);

            // Bo góc cho PictureBox (nếu bạn muốn bo nhẹ 4 góc)
            UIHelper.ApplyRoundedRegion(picDoctor, 15);

            UIHelper.ApplyRoundedRegion(pnlContainer, 20);
        }
    }
}
