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
        private DoctorDTO _currentDoctor; // Lưu để truyền cho Form đánh giá

        public void SetDoctorData(DoctorDTO doctor)
        {
            _currentDoctor = doctor;
            _doctorId = doctor.Id; // Lưu ID bác sĩ để sử dụng sau này

            /// 1. Tên Bác sĩ: Kết hợp Chức danh + Họ tên
            // Ví dụ: "Thạc sĩ Nguyễn Văn A" hoặc "Bác sĩ Trần Thị B"
            string position = doctor.Position ?? "";
            string fullName = doctor.User?.FullName ?? "Chưa cập nhật";
            // Nếu có chức danh thì cộng chuỗi, không thì chỉ hiện tên
            lblFullName.Text = string.IsNullOrWhiteSpace(position)
                ? fullName
                : $"{position} {fullName}";

            //2. Số điện thoại
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

            //Biography
            lblBio.Text = doctor.Biography ?? "Chưa cập nhật";

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

            // 10. Tải danh sách đánh giá
            LoadReviews();
            
            // Đăng ký sự kiện nút Đặt lịch ngay
            btnBook.Click += btnBook_Click;
            
            // Đăng ký sự kiện lọc theo thời gian
            dtpStartTime.ValueChanged += (s, e) => InitData();
            dtpEndTime.ValueChanged += (s, e) => InitData();
        }

        private void ucPatient_DocProfile_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(picDoctor, 175); // Bo tròn ảnh bác sĩ
            UIHelper.ApplyRoundedRegion(btnWriteReview, 8); // Bo tròn nhẹ nút đánh giá

            // Áp dụng bo góc cho 2 mảng chính (Reviews bên trái, Lịch hẹn bên phải)
            UIHelper.ApplyRoundedRegion(panel4, 25);
            UIHelper.ApplyRoundedRegion(panel5, 25);

            flpAppItem.Dock = DockStyle.None; // Tạm bỏ dock
            //flpAppItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            flpAppItem.Width = panel4.Width;

            InitData();

            DisplayPage();

            // Cập nhật bo góc và kích thước item khi Resize
            this.Resize += (s, ev) =>
            {
                UIHelper.ApplyRoundedRegion(panel4, 25);
                UIHelper.ApplyRoundedRegion(panel5, 25);

                foreach (Control ctrl in flpAppItem.Controls)
                {
                    if (ctrl is ucAppItem card)
                    {
                        card.Width = flpAppItem.Width - 40;
                    }
                }

                // Cập nhật độ rộng cho các đánh giá khi resize
                foreach (Control ctrl in flpReview.Controls)
                {
                    if (ctrl is var review)
                    {
                        review.Width = flpReview.ClientSize.Width - 40;
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

        private void btnWriteReview_Click(object sender, EventArgs e)
        {
            if (_currentDoctor == null) return;

            // 1. Tạo UserControl đánh giá
            ucWriteReview uc = new ucWriteReview(_currentDoctor);
            
            // 2. Vị trí ở giữa UserControl hiện tại
            uc.Location = new Point(
                (this.Width - uc.Width) / 2,
                (this.Height - uc.Height) / 2
            );

            // 3. Đăng ký sự kiện
            uc.ReviewSubmitted += (s, ev) => {
                LoadReviews(); // Tải lại danh sách đánh giá
            };

            // 3. Xử lý khi nhấn Hủy/Đóng
            uc.CloseRequested += (s, ev) => {
                this.Controls.Remove(uc);
                uc.Dispose();
            };

            // 4. Thêm vào Controls và đưa lên trên cùng
            this.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (_currentDoctor == null) return;

            ucBookingDialog uc = new ucBookingDialog(_currentDoctor);
            uc.Location = new Point((this.Width - uc.Width) / 2, (this.Height - uc.Height) / 2);
            
            uc.AppointmentBooked += (s, ev) => InitData();
            uc.CloseRequested += (s, ev) => {
                this.Controls.Remove(uc);
                uc.Dispose();
            };

            this.Controls.Add(uc);
            uc.BringToFront();
        }

        #region Xử lí flpAppItem
        private AppointmentBUS _appBus = new AppointmentBUS();
        private List<AppointmentsDTO> _myAppointments = new List<AppointmentsDTO>();

        public void InitData()
        {
            try
            {
                // 1. Lấy thông tin từ giao diện
                DateTime fromDate = dateTimePicker3.Value;
                DateTime toDate = dateTimePicker4.Value;
                TimeSpan fromTime = dtpStartTime.Value.TimeOfDay;
                TimeSpan toTime = dtpEndTime.Value.TimeOfDay;

                // 2. Lấy ID bệnh nhân đang đăng nhập
                int currentPatientId = GlobalAccount.GetProfileId();

                // 3. Lấy danh sách lịch hẹn của TÔI với bác sĩ NÀY
                _myAppointments = _appBus.GetFilteredAppointmentsForPatient(currentPatientId, _doctorId, fromDate, toDate, fromTime, toTime);
                
                DisplayPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu lịch hẹn: " + ex.Message);
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

                if (_myAppointments == null || _myAppointments.Count == 0)
                {
                    Label lblEmpty = new Label();
                    lblEmpty.Text = "Bạn chưa có lịch hẹn nào với bác sĩ này";
                    lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                    lblEmpty.ForeColor = Color.Gray;
                    lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
                    lblEmpty.Size = new Size(flpAppItem.Width - 40, 100);

                    flpAppItem.Controls.Add(lblEmpty);
                    return;
                }

                // 2. Đổ card lịch hẹn
                foreach (var app in _myAppointments)
                {
                    ucAppItem card = new ucAppItem();
                    card.ShowDoctorInfo = false; // Ẩn tên/SĐT bác sĩ vì đang ở trong trang của bác sĩ đó rồi

                    // Sử dụng mode PatientView để xem/sửa/xóa lịch của mình
                    card.SetupCard(app, ucAppItem.AppCardMode.PatientView);

                    // CAN THIỆP BỐ CỤC TỪ BÊN NGOÀI
                    var btnStatus = card.Controls.Find("btnStatus", true).FirstOrDefault();
                    if (btnStatus != null) btnStatus.Location = new Point(400, 95);

                    // Xử lý sự kiện Xóa
                    card.AppointmentDeleted += (s, ev) => InitData();

                    // Xử lý sự kiện Chỉnh sửa
                    card.AppointmentEdited += (s, appData) => {
                        if (_currentDoctor == null) return;
                        ucBookingDialog editUc = new ucBookingDialog(_currentDoctor);
                        editUc.SetEditData(appData); // Chuyển sang chế độ Sửa

                        editUc.Location = new Point((this.Width - editUc.Width) / 2, (this.Height - editUc.Height) / 2);
                        editUc.AppointmentBooked += (s2, ev2) => InitData();
                        editUc.CloseRequested += (s2, ev2) => {
                            this.Controls.Remove(editUc);
                            editUc.Dispose();
                        };
                        this.Controls.Add(editUc);
                        editUc.BringToFront();
                    };

                    card.Margin = new Padding(10, 5, 10, 5);
                    card.Width = flpAppItem.Width - 40;
                    card.Visible = true;
                    flpAppItem.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách lịch hẹn: " + ex.Message);
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

        private void btnBook_Click1(object sender, EventArgs e)
        {
            if (_currentDoctor == null) return;

            ucBookingDialog bookUc = new ucBookingDialog(_currentDoctor);
            bookUc.Location = new Point((this.Width - bookUc.Width) / 2, (this.Height - bookUc.Height) / 2);
            
            // Khi đặt lịch xong thì load lại danh sách
            bookUc.AppointmentBooked += (s2, ev2) => InitData();
            
            bookUc.CloseRequested += (s2, ev2) => {
                this.Controls.Remove(bookUc);
                bookUc.Dispose();
            };

            this.Controls.Add(bookUc);
            bookUc.BringToFront();
        }

        private void LoadReviews()
        {
            try
            {
                flpReview.SuspendLayout();
                flpReview.Controls.Clear();

                DoctorBUS docBus = new DoctorBUS();
                var reviews = docBus.GetDoctorReviews(_doctorId);

                // Cập nhật lại số liệu trên Header
                if (reviews != null && reviews.Any())
                {
                    double avg = reviews.Average(r => r.Rating);
                    lblRating.Text      = avg.ToString("0.0");
                    lblTotalReviews.Text = $"{reviews.Count} đánh giá";
                }
                else
                {
                    lblRating.Text      = "0.0";
                    lblTotalReviews.Text = "0 đánh giá";
                }

                //if (reviews == null || !reviews.Any())
                //{
                //    Label lblNoReview = new Label();
                //    lblNoReview.Text      = "Chưa có đánh giá nào từ bệnh nhân.";
                //    lblNoReview.Font      = new Font("Segoe UI", 10, FontStyle.Italic);
                //    lblNoReview.ForeColor = Color.Gray;
                //    lblNoReview.Size      = new Size(flpReview.Width - 40, 50);
                //    lblNoReview.TextAlign = ContentAlignment.MiddleCenter;
                //    flpReview.Controls.Add(lblNoReview);
                //    return;
                //}

                // ID bệnh nhân đang đăng nhập
                int currentPatientId = GlobalAccount.GetProfileId();

                foreach (var rev in reviews)
                {
                    ucReviewItem item = new ucReviewItem();
                    item.SetReviewData(rev, _currentDoctor, currentPatientId);
                    //item.Width = flpReview.ClientSize.Width - 40;

                    // Tải lại danh sách khi xóa hoặc sửa thành công
                    item.ReviewDeleted += (s, ev) => LoadReviews();
                    item.ReviewEdited  += (s, ev) => LoadReviews();

                    flpReview.Controls.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi LoadReviews: " + ex.Message);
            }
            finally
            {
                flpReview.ResumeLayout();
            }
        }

    }
}
