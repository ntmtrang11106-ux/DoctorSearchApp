using BUS_Tier;
using DTO_Tier;
using DAL_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucPatient_DocProfile : UserControl
    {

        public ucPatient_DocProfile()
        {
            InitializeComponent();

            UIHelper.SetDoubleBuffered(this); // Kích hoạt Double Buffering cho UserControl để giảm nhấp nháy
        }

        // Hàm này dùng để "đổ" dữ liệu từ đối tượng Doctor vào các Label

        private int _doctorId; // Lưu ID bác sĩ để dùng cho việc lấy lịch trình sau này

        public void SetDoctorData(DoctorDTO doctor)
        {
            _doctorId = doctor.Id; // Lưu ID bác sĩ để sử dụng sau này

            /// 1. Tên Bác sĩ: Kết hợp Chức danh + Họ tên
            // Ví dụ: "Thạc sĩ Nguyễn Văn A" hoặc "Bác sĩ Trần Thị B"
            string position = doctor.Position ?? "";
            string fullName = doctor.User?.FullName ?? "Chưa cập nhật";
            // Nếu có chức danh thì cộng chuỗi, không thì chỉ hiện tên
            lblFullName.Text = string.IsNullOrWhiteSpace(position)
                ? fullName
                : $"{position} {fullName}";

            //2. Nơi làm việc (Tên phòng khám hoặc bệnh viện)
            lblPhone.Text = doctor.User?.PhoneNumber ?? "Chưa cập nhật";

            //3. Chuyên khoa (Tên chuyên khoa hoặc "Chưa cập nhật" nếu không có)
            string deptName = $"Chuyên khoa: {doctor.Department?.DepartmentName ?? "Chưa cập nhật"}";
            lblSpecialties.Text = deptName;

            //4. Giơí tính
            lblGender.Text = $"Giới tính: {doctor.User?.Gender ?? "Chưa cập nhật"}";

            //5. Địa chỉ cụ thể 
            lblSpecificAdress.Text = doctor.User?.Residential_Address ?? "Chưa cập nhật";

            //6.Thời gian làm việc(Nếu trong DTO bạn có trường Status hoặc WorkingTime)
            //lblWorkingTime.Text = $"Lịch: {doctor.JoinDate}";
            //6.Thời gian làm việc
            lblWorkingTime.Text = doctor.JoinDate.HasValue
                ? $"Gia nhập: {doctor.JoinDate.Value:dd/MM/yyyy}"
                : "Lịch: Thứ 2 - Thứ 7";

            // 6. Giá tiền (Đã có cột ConsultationFee trong bảng Doctor)
            decimal price = doctor.ConsultationFee ?? 0;
            lblPrice.Text = price.ToString("N0") + " đ";

            //// 7. Đánh giá (Số sao và tổng lượt review)
            //lblRating.Text = doctor.AverageRating.ToString("0.0"); // Ví dụ: 4.5
            //lblTotalReviews.Text = $"{doctor.TotalReviews} đánh giá";
            // 7. Đánh giá (Tính từ bảng Reviews)
            if (doctor.Reviews != null && doctor.Reviews.Any())
            {
                double avg = doctor.Reviews.Average(r => r.Rating);
                lblRating.Text = avg.ToString("0.0");
                lblTotalReviews.Text = $"{doctor.Reviews.Count} đánh giá";
            }
            else
            {
                lblRating.Text = "0.0";
                lblTotalReviews.Text = "0 đánh giá";
            }

            //8.Kinh nghiệm
            lblEx.Text = $"{doctor.ExperienceYears ?? 0} năm kinh nghiệm";

            // 9. Hình ảnh
            // --- XỬ LÝ HÌNH ẢNH ---
            // Kiểm tra null hoặc rỗng để dùng ảnh mặc định
            string fileName = string.IsNullOrWhiteSpace(doctor.User.Picture) ? "default.jpg" : doctor.User.Picture.Trim();

            // Đường dẫn trỏ vào folder Resources_Images trong thư mục chạy app
            string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images");
            string imagePath = Path.Combine(imageFolder, fileName);

            if (File.Exists(imagePath))
            {
                try
                {
                    if (picDoctor.Image != null) picDoctor.Image.Dispose();
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        picDoctor.Image = new Bitmap(fs); // Dùng Bitmap để không bị khóa file
                    }
                }
                catch (Exception ex) { }
            }
        }

        private void ucPatient_DocProfile_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(picDoctor, 175); // Bo tròn ảnh bác sĩ

            flpAppItem.Dock = DockStyle.None; // Tạm bỏ dock
            //flpAppItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            flpAppItem.Width = panel4.Width;

            InitData();

            DisplayPage();

            //MessageBox.Show($"height: {flpAppItem.Height}, width: {flpAppItem.Width}");

            this.Resize += (s, ev) =>
            {
                foreach (Control ctrl in flpAppItem.Controls)
                {
                    if (ctrl is ucAppItem card)
                    {
                        card.Width = flpAppItem.Width - 80;
                    }
                }
            };
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Tìm về Form chính để điều hướng trang
            Form parentForm = this.FindForm();
            if (parentForm is frmPatient main)
            {
                main.BackToDoctorList();
            }
        }

        #region Xử lí flpAppItem, lưu ý cái này chỉ để thử form chứ chưa lọc, muốn lọc data thì code mấy tầng trên
        private TimeSlotBUS _bus = new TimeSlotBUS();
        private List<TimeSlotsDTO> _allTimes = new List<TimeSlotsDTO>();

        public void InitData()
        {
            try
            {
                // Lấy giá trị từ giao diện
                DateTime fromDate = dateTimePicker3.Value;
                DateTime toDate = dateTimePicker4.Value;

                // Giả sử ông có biến _doctorId từ Form đăng nhập truyền vào
                _allTimes = _bus.GetFilteredSlotsForPatient(_doctorId, fromDate, toDate); // Nên OrderBy StartTime ở đây nếu BUS chưa làm
                                                                                          // Sau khi có dữ liệu mới thì vẽ lại giao diện
                DisplayPage();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi InitData: " + ex.Message);
            }
        }

        public void DisplayPage()
        {
            try
            {
                flpAppItem.SuspendLayout();

                // 1. Dọn dẹp sạch sẽ
                while (flpAppItem.Controls.Count > 0)
                {
                    var control = flpAppItem.Controls[0];
                    flpAppItem.Controls.RemoveAt(0);
                    control.Dispose();
                }

                if (_allTimes == null || _allTimes.Count == 0)
                {
                    Label lblEmpty = new Label();
                    lblEmpty.Text = "Chưa có lịch hẹn"; // Nội dung bạn muốn hiển thị
                    lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                    lblEmpty.ForeColor = Color.Gray;
                    lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
                    lblEmpty.Size = new Size(flpAppItem.Width - 40, 100); // Kích thước khung thông báo

                    flpAppItem.Controls.Add(lblEmpty);
                    return;
                }

                // 2. Đổ card
                foreach (var ts in _allTimes)
                {
                    ucAppItem card = new ucAppItem();

                    // Mode DoctorSchedule sẽ hiện nút Xóa/Quản lý slot trống
                    card.SetupCard(ts, ucAppItem.AppCardMode.DoctorSchedule);

                    card.Margin = new Padding(20, 10, 20, 10);

                    // Dùng ClientSize.Width cho chuẩn xác vùng chứa
                    card.Width = flpAppItem.Width - 80;

                    card.Visible = true;
                    flpAppItem.Controls.Add(card);

                    // Mẹo: Ép lại Width một lần nữa sau khi Add để đảm bảo nó nhận đúng size của cha
                    card.Width = flpAppItem.Width - 80;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị lịch trình: " + ex.Message);
            }
            finally
            {
                flpAppItem.ResumeLayout();
            }
        }
        #endregion

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            InitData();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
