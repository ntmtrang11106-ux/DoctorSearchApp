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
            UIHelper.SetupScrollableContainer(flpReview);
            UIHelper.SetupScrollableContainer(flpAppItem);

            // Bo góc cho các nút
            UIHelper.ApplyRoundedRegion(btnWriteReview, 15);
            UIHelper.ApplyRoundedRegion(btnBook, 15);

            // Vẽ đường kẻ trên cùng cho thanh phân trang (Dùng code để Designer không bị lỗi)
            pnlReviewPagination.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.Gainsboro, 1), 0, 0, pnlReviewPagination.Width, 0);
            };
            pnlAppPagination.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.Gainsboro, 1), 0, 0, pnlAppPagination.Width, 0);
            };

            // Hiệu ứng hover sử dụng Helper
            UIHelper.SetupHoverEffect(lblReviewPrev, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));
            UIHelper.SetupHoverEffect(lblReviewNext, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));
            UIHelper.SetupHoverEffect(lblAppPrev, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));
            UIHelper.SetupHoverEffect(lblAppNext, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));

            lblReviewPrev.Click += lblReviewPrev_Click;
            lblReviewNext.Click += lblReviewNext_Click;
            lblAppPrev.Click += lblAppPrev_Click;
            lblAppNext.Click += lblAppNext_Click;
        }



        // Hàm này dùng để "đổ" dữ liệu từ đối tượng Doctor vào các Label

        private int _doctorId; // Lưu ID bác sĩ để dùng cho việc lấy lịch trình sau này
        private DoctorDTO _currentDoctor; // Lưu để truyền cho Form đánh giá

        private int _reviewPageSize = 4;
        private int _reviewCurrentPage = 1;
        private List<ReviewsDTO> _allReviews = new List<ReviewsDTO>();

        private int _appPageSize = 3;
        private int _appCurrentPage = 1;
        private List<AppointmentsDTO> _allAppointments = new List<AppointmentsDTO>();
        private List<AppointmentsDTO> _filteredAppointments = new List<AppointmentsDTO>();

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
            _reviewCurrentPage = 1;
            LoadReviews();
            
            // Đăng ký sự kiện nút Đặt lịch ngay
            btnBook.Click += btnBook_Click;
        }

        private void ucPatient_DocProfile_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(picDoctor, 175); // Bo tròn ảnh bác sĩ
            UIHelper.ApplyRoundedRegion(btnWriteReview, 8); // Bo tròn nhẹ nút đánh giá

            // Áp dụng bo góc cho 2 mảng chính (Reviews bên trái, Lịch hẹn bên phải)
            UIHelper.ApplyRoundedRegion(panel4, 25);
            UIHelper.ApplyRoundedRegion(panel5, 25);

            // Đảm bảo các panel luôn bám sát khung khi khởi tạo
            flpAppItem.Dock = DockStyle.Top;
            flpReview.Dock = DockStyle.Top;

            // Kết nối sự kiện lọc (Lọc ngay khi thay đổi giá trị)
            dateTimePicker3.ValueChanged += (s, e) => InitData();
            dateTimePicker4.ValueChanged += (s, e) => InitData();
            dtpStartTime.ValueChanged += (s, e) => InitData();
            dtpEndTime.ValueChanged += (s, e) => InitData();

            InitData();

            // Cập nhật bo góc và kích thước item khi Resize
            this.Resize += (s, ev) =>
            {
                UIHelper.ApplyRoundedRegion(panel4, 25);
                UIHelper.ApplyRoundedRegion(panel5, 25);

                foreach (Control ctrl in flpAppItem.Controls)
                {
                    if (ctrl is ucAppItem card)
                    {
                        card.Width = flpAppItem.ClientSize.Width - (flpAppItem.Padding.Left + flpAppItem.Padding.Right);
                    }
                }

                // Cập nhật độ rộng cho các đánh giá khi resize
                foreach (Control ctrl in flpReview.Controls)
                {
                    if (ctrl is ucReviewItem review)
                    {
                        review.Width = flpReview.ClientSize.Width - (flpReview.Padding.Left + flpReview.Padding.Right);
                    }
                }
                UpdateListLayout(flpReview, pnlReviewPagination, panel5, panel16.Height + lblNoReviews.Height + 20);
                UpdateListLayout(flpAppItem, pnlAppPagination, panel4, pnlAppHeader.Height + lblNoApp.Height + 20);
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

        public void InitData()
        {
            try
            {
                // 1. Kiểm tra và gán giá trị mặc định nếu cần
                if (dtpStartTime.Value.TimeOfDay == TimeSpan.Zero && dtpEndTime.Value.TimeOfDay == TimeSpan.Zero)
                {
                    dtpStartTime.Value = DateTime.Today; // 00:00
                    dtpEndTime.Value = DateTime.Today.AddHours(23).AddMinutes(59); // 23:59
                }

                // 2. Lấy thông tin từ giao diện
                DateTime fromDate = dateTimePicker3.Value.Date;
                DateTime toDate = dateTimePicker4.Value.Date;
                TimeSpan fromTime = dtpStartTime.Value.TimeOfDay;
                TimeSpan toTime = dtpEndTime.Value.TimeOfDay;

                // 2. Lấy ID bệnh nhân đang đăng nhập
                int currentPatientId = GlobalAccount.GetProfileId();

                // 3. Lấy danh sách lịch hẹn của TÔI với bác sĩ NÀY
                _allAppointments = _appBus.GetFilteredAppointmentsForPatient(currentPatientId, _doctorId, fromDate, toDate, fromTime, toTime) ?? new List<AppointmentsDTO>();
                _appCurrentPage = 1;
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
                flpAppItem.Controls.Clear();

                if (_allAppointments == null || _allAppointments.Count == 0)
                {
                    lblNoApp.Visible = true;
                    pnlAppPagination.Visible = false;
                    return;
                }

                lblNoApp.Visible = false;

                pnlAppPagination.Visible = _allAppointments.Count > 0;
                int totalPages = (int)Math.Ceiling((double)_allAppointments.Count / _appPageSize);
                if (_appCurrentPage > totalPages) _appCurrentPage = totalPages;
                if (_appCurrentPage < 1) _appCurrentPage = 1;

                lblAppPageStatus.Text = $"Trang {_appCurrentPage} / {totalPages}";
                
                // Luôn để màu xanh và cho phép hover
                lblAppPrev.Enabled = true;
                lblAppNext.Enabled = true;
                lblAppPrev.ForeColor = Color.FromArgb(0, 120, 212);
                lblAppNext.ForeColor = Color.FromArgb(0, 120, 212);
                lblAppPageStatus.ForeColor = Color.FromArgb(75, 85, 99);

                var pageItems = _allAppointments.Skip((_appCurrentPage - 1) * _appPageSize).Take(_appPageSize);

                // 2. Đổ card lịch hẹn
                foreach (var app in pageItems)
                {
                    ucAppItem card = new ucAppItem();
                    card.ShowDoctorInfo = false;
                    card.SetupCard(app, ucAppItem.AppCardMode.PatientView);
                    
                    card.AppointmentDeleted += (s, ev) => InitData();
                    card.AppointmentEdited += (s, appData) => {
                        if (_currentDoctor == null) return;
                        ucBookingDialog editUc = new ucBookingDialog(_currentDoctor);
                        editUc.SetEditData(appData);
                        editUc.Location = new Point((this.Width - editUc.Width) / 2, (this.Height - editUc.Height) / 2);
                        editUc.AppointmentBooked += (s2, ev2) => InitData();
                        editUc.CloseRequested += (s2, ev2) => { this.Controls.Remove(editUc); editUc.Dispose(); };
                        this.Controls.Add(editUc);
                        editUc.BringToFront();
                    };

                    card.Width = flpAppItem.ClientSize.Width - (flpAppItem.Padding.Left + flpAppItem.Padding.Right);
                    flpAppItem.Controls.Add(card);
                }

                pnlAppPagination.Visible = _allAppointments.Count > 0;
                UpdateListLayout(flpAppItem, pnlAppPagination, panel4, pnlAppHeader.Height + lblNoApp.Height + 20);
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DisplayPage: " + ex.Message); }
            finally { flpAppItem.ResumeLayout(); }
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
                _allReviews = docBus.GetDoctorReviews(_doctorId) ?? new List<ReviewsDTO>();

                // Cập nhật lại số liệu trên Header (dựa trên toàn bộ reviews)
                if (_allReviews.Any())
                {
                    double avg = _allReviews.Average(r => r.Rating);
                    lblRating.Text = avg.ToString("0.0");
                    lblTotalReviews.Text = $"{_allReviews.Count} đánh giá";
                }
                else
                {
                    lblRating.Text = "0.0";
                    lblTotalReviews.Text = "0 đánh giá";
                }

                DisplayReviews();
            }
            catch (Exception ex) { Console.WriteLine("Lỗi LoadReviews: " + ex.Message); }
            finally { flpReview.ResumeLayout(); }
        }

        private void DisplayReviews()
        {
            try
            {
                flpReview.SuspendLayout();
                flpReview.Controls.Clear();

                if (_allReviews == null || !_allReviews.Any())
                {
                    lblNoReviews.Visible = true;
                    pnlReviewPagination.Visible = false;
                    return;
                }

                lblNoReviews.Visible = false;

                pnlReviewPagination.Visible = true;
                int totalPages = (int)Math.Ceiling((double)_allReviews.Count / _reviewPageSize);
                if (_reviewCurrentPage > totalPages) _reviewCurrentPage = totalPages;
                if (_reviewCurrentPage < 1) _reviewCurrentPage = 1;

                lblReviewPageStatus.Text = $"Trang {_reviewCurrentPage} / {totalPages}";
                
                // Luôn để màu xanh và cho phép hover
                lblReviewPrev.Enabled = true;
                lblReviewNext.Enabled = true;
                lblReviewPrev.ForeColor = Color.FromArgb(0, 120, 212);
                lblReviewNext.ForeColor = Color.FromArgb(0, 120, 212);
                lblReviewPageStatus.ForeColor = Color.FromArgb(75, 85, 99);

                var pageItems = _allReviews.Skip((_reviewCurrentPage - 1) * _reviewPageSize).Take(_reviewPageSize);

                // ID bệnh nhân đang đăng nhập
                int currentPatientId = GlobalAccount.GetProfileId();

                foreach (var rev in pageItems)
                {
                    ucReviewItem item = new ucReviewItem();
                    item.SetReviewData(rev, _currentDoctor, currentPatientId);
                    item.ReviewDeleted += (s, ev) => LoadReviews();
                    item.ReviewEdited += (s, ev) => LoadReviews();
                    item.Width = flpReview.ClientSize.Width - (flpReview.Padding.Left + flpReview.Padding.Right);
                    flpReview.Controls.Add(item);
                }

                pnlReviewPagination.Visible = _allReviews.Count > 0;
                UpdateListLayout(flpReview, pnlReviewPagination, panel5, panel16.Height + lblNoReviews.Height + 20);
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DisplayReviews: " + ex.Message); }
            finally { flpReview.ResumeLayout(); }
        }

        #region Pagination Events
        private void lblReviewPrev_Click(object sender, EventArgs e)
        {
            if (_reviewCurrentPage > 1) { _reviewCurrentPage--; DisplayReviews(); }
        }

        private void lblReviewNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_allReviews.Count / _reviewPageSize);
            if (_reviewCurrentPage < totalPages) { _reviewCurrentPage++; DisplayReviews(); }
        }

        private void lblAppPrev_Click(object sender, EventArgs e)
        {
            if (_appCurrentPage > 1) { _appCurrentPage--; DisplayPage(); }
        }

        private void lblAppNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_filteredAppointments.Count / _appPageSize);
            if (_appCurrentPage < totalPages) { _appCurrentPage++; DisplayPage(); }
        }
        #endregion

        private void UpdateListLayout(FlowLayoutPanel flp, Panel pnlPagination, Panel container, int reservedHeight)
        {
            flp.Padding = new Padding(flp.Padding.Left, flp.Padding.Top, flp.Padding.Right, 0);
            int totalItemsHeight = flp.Padding.Top + flp.Padding.Bottom;
            foreach (Control ctrl in flp.Controls)
            {
                if (ctrl.Visible && ctrl != pnlPagination) 
                    totalItemsHeight += ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom;
            }

            int availableHeight = container.Height - reservedHeight;

            if (totalItemsHeight + pnlPagination.Height < availableHeight)
            {
                // Danh sách ngắn: Thanh phân trang bám sát UC cuối
                pnlPagination.Dock = DockStyle.Top;
                pnlPagination.Margin = new Padding(0, 10, 0, 0); // Thêm khoảng cách 10px
                flp.Dock = DockStyle.Top;
                flp.Height = totalItemsHeight;
                flp.AutoScroll = false;
            }
            else
            {
                // Danh sách dài: Thanh phân trang đứng yên ở đáy
                pnlPagination.Dock = DockStyle.Bottom;
                pnlPagination.Margin = new Padding(0);
                flp.Dock = DockStyle.Fill;
                flp.AutoScroll = true;
                
                // Thêm Panel đệm vật lý để đảm bảo không bị che
                Panel pnlBuffer = new Panel { Height = 15, Width = flp.Width, Name = "pnlBuffer" };
                flp.Controls.Add(pnlBuffer);
            }
            
            // Đảm bảo Z-order đúng để Dock hoạt động
            container.Controls.SetChildIndex(pnlPagination, 0); 
        }
    }
}
