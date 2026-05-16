using BUS_Tier;
using DTO_Tier;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace UI_Tier
{
    public partial class UCCardDoctor : UserControl
    {
        private DoctorDTO _currentDoc;
        private bool _isHovered = false;

        /// <summary>
        /// Thuộc tính để xác định thẻ này có cho phép tương tác (Click/Hover) hay không.
        /// </summary>
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Xác định thẻ có thể click và có hiệu ứng hover hay không.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsClickable { get; set; } = true;

        public UCCardDoctor()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
        }


        // Hàm này dùng để "đổ" dữ liệu từ đối tượng Doctor vào các Label

        public void SetDoctorData(DoctorDTO doctor)

        {
            if (doctor == null) return;

            _currentDoc = doctor;
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
            lblGender.Text = $"Giới tính: {doctor.User?.Gender ?? "Chưa cập nhật" }";

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

            // --- THIẾT LẬP TƯƠNG TÁC CHUỘT ---
            Control[] interactiveControls = { 
                this, pnlContainer, picDoctor, lblFullName, lblPhone, lblSpecialties, 
                lblGender, lblSpecificAdress, lblWorkingTime, lblPrice, lblRating, 
                lblTotalReviews, lblEx, label1, label2, label3, label4, label5, label6, label7, lblSpecialtyTag 
            };

            foreach (var ctrl in interactiveControls)
            {
                if (ctrl == null) continue;

                // 1. Luôn dùng con trỏ bàn tay
                ctrl.Cursor = Cursors.Hand;

                // 2. Đăng ký sự kiện (Việc kiểm tra IsClickable sẽ thực hiện bên trong hàm xử lý)
                    ctrl.MouseEnter -= OnMouseEnter;
                    ctrl.MouseEnter += OnMouseEnter;
                    ctrl.MouseLeave -= OnMouseLeave;
                    ctrl.MouseLeave += OnMouseLeave;

                    ctrl.Click -= Card_Click;
                    ctrl.Click += Card_Click;
                }
            }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (IsClickable)
            {
                // Màu xanh đậm khi hover, xám nhạt khi bình thường
                Color borderColor = _isHovered ? Color.FromArgb(37, 99, 235) : Color.FromArgb(224, 224, 224);
                int borderWidth = _isHovered ? 3 : 2;
                UIHelper.uc_Paint(this, e, 20, borderColor, borderWidth);
            }
            else
            {
                // Khi không clickable, giữ viền xám mặc định
                UIHelper.uc_Paint(this, e, 20, Color.FromArgb(224, 224, 224), 2);
            }
        }

        private void UCCardDoctor_Load(object sender, EventArgs e)
        {
            // Bo góc cho toàn bộ Card (nếu muốn)
            UIHelper.ApplyRoundedRegion(this, 15);

            // Bo góc cho Label chuyên khoa ở góc phải
            UIHelper.ApplyRoundedRegion(lblSpecialtyTag, 8);

            // Bo góc cho PictureBox (nếu bạn muốn bo nhẹ 4 góc)
            UIHelper.ApplyRoundedRegion(picDoctor, 15);
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            if (!IsClickable || _isHovered) return;

            // CHỈ cho phép hiệu ứng Hover (viền xanh, nhấc thẻ) nếu đang đăng nhập là Bệnh nhân
            if (GlobalAccount.GetRole() == "Patient")
            {
                _isHovered = true;
                this.Margin = new Padding(15, 10, 15, 20);
                
                Color hoverColor = Color.FromArgb(252, 253, 255);
                this.BackColor = hoverColor;
                if (pnlContainer != null) pnlContainer.BackColor = hoverColor;
                
                this.Refresh(); // Vẽ lại viền xanh
            }
            else
            {
                // Ở Guest hoặc các vai trò khác thì giữ nguyên trạng thái tĩnh hoàn toàn
                _isHovered = false;
            }
        }
        
        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (!IsClickable) return;

            // Kiểm tra xem chuột có thực sự rời khỏi vùng của UC không
            Rectangle screenBounds = this.RectangleToScreen(this.ClientRectangle);
            if (screenBounds.Contains(Cursor.Position)) return;

            // Chỉ reset nếu trước đó có hiệu ứng (là Patient)
            if (_isHovered)
            {
                _isHovered = false;
                this.Margin = new Padding(15);
                this.BackColor = Color.White;
                if (pnlContainer != null) pnlContainer.BackColor = Color.White;
                this.Invalidate();
            }
        }

        // Hàm xử lý khi kích vào bất kỳ đâu trên Card
        private void Card_Click(object sender, EventArgs e)
        {
            // Tìm về Form chính để điều hướng trang
            Form parentForm = this.FindForm();
            if (parentForm is frmPatient main)
            {
                main.OpenDoctorProfile(_currentDoc);
            }
        }

    }
}
