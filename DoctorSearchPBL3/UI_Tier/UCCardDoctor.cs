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

            UIHelper.SetDoubleBuffered(this); // Kích hoạt Double Buffering cho UserControl để giảm nhấp nháy
        }


        // Hàm này dùng để "đổ" dữ liệu từ đối tượng Doctor vào các Label
        // Trong UCCardDoctor.cs

        //public void SetDoctorData(DoctorDTO doctor)

        {
            lblFullName.Text = doctor.User.FullName;
            //lblWorkPlace.Text = doctor.ClinicName;
            // 3. Địa chỉ (Kết hợp địa chỉ chi tiết và tên khu vực)
            //lblSpecificAdress.Text = $"{doctor.ClinicAddress}, {doctor.Location.LocationName}";

            // 4. Thời gian làm việc (Nếu trong DTO bạn có trường Status hoặc WorkingTime)
            lblWorkingTime.Text = $"Lịch: {doctor.JoinDate}";

            // 5. Giá tiền (Định dạng tiền tệ VNĐ: 500.000đ)
            lblPrice.Text = UIHelper.FormatVND(doctor.ConsultationFee);

        //    // 6. Đánh giá (Số sao và tổng lượt review)
        //    lblRating.Text = doctor.AverageRating.ToString("0.0"); // Ví dụ: 4.5
        //    lblTotalReviews.Text = $"{doctor.TotalReviews} đánh giá";

            // 7. Kinh nghiệm
            lblEx.Text = $"{doctor.ExperienceYears} năm kinh nghiệm";

        //    // 8. Chuyên khoa
        //    // --- XỬ LÝ CHUYÊN KHOA (CÁCH 2) ---

        //    // 9. Hình ảnh
        //    // --- XỬ LÝ HÌNH ẢNH ---
        //    // Kiểm tra null hoặc rỗng để dùng ảnh mặc định
        //    string fileName = string.IsNullOrWhiteSpace(doctor.User.Picture) ? "default.jpg" : doctor.User.Picture.Trim();

        //    // Đường dẫn trỏ vào folder Resources_Images trong thư mục chạy app
        //    string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images");
        //    string imagePath = Path.Combine(imageFolder, fileName);

        //    if (File.Exists(imagePath))
        //    {
        //        try
        //        {
        //            if (picDoctor.Image != null) picDoctor.Image.Dispose();
        //            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        //            {
        //                picDoctor.Image = new Bitmap(fs); // Dùng Bitmap để không bị khóa file
        //            }
        //        }
        //        catch (Exception ex) { }
        //    }
        //}

        private void UCCardDoctor_Load(object sender, EventArgs e)
        {
            // Bo góc cho toàn bộ Card (nếu muốn)
            UIHelper.ApplyRoundedRegion(this, 15);

            // Bo góc cho Label chuyên khoa ở góc phải
            UIHelper.ApplyRoundedRegion(lblSpecialtyTag, 8);

            // Bo góc cho PictureBox (nếu bạn muốn bo nhẹ 4 góc)
            UIHelper.ApplyRoundedRegion(picDoctor, 15);

            // Vẽ border cho Card (nếu muốn)
            this.Paint += (sender, e) => UIHelper.uc_Paint(sender, e, 20, Color.FromArgb(224, 224, 224), 2);
        }
    }
}
