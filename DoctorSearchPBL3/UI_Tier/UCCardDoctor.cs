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
        /// Thuộc tính xác định thẻ bác sĩ này có cho phép tương tác (Click/Hover) hay không.
        /// </summary>
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Xác định thẻ có thể click và có hiệu ứng hover hay không.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsClickable { get; set; } = true;

        public UCCardDoctor()
        {
            InitializeComponent();
            
            // Kích hoạt Double Buffered để giảm giật hình khi vẽ lại các control con trong Card
            UIHelper.SetDoubleBuffered(this);
            
            // Vẽ lại tên bác sĩ với chữ nổi bật (Highlight) khi có từ khóa tìm kiếm trùng khớp
            lblFullName.Paint += lblFullName_Paint;
        }

        /// <summary>
        /// Xử lý sự kiện Paint của lblFullName để tô màu chữ trùng khớp với từ khóa tìm kiếm.
        /// </summary>
        private void lblFullName_Paint(object sender, PaintEventArgs e)
        {
            if (_currentDoc == null) return;
            string position = NormalizeDoctorTitle(_currentDoc.Position);
            string fullName = NormalizeDoctorName(_currentDoc.User?.FullName);
            string displayName = string.IsNullOrWhiteSpace(position)
                ? $"BS. {fullName}"
                : $"{position} {fullName}";

            // Gọi UIHelper vẽ chữ với từ khóa tìm kiếm được highlight (nền xanh chữ trắng/đen nổi bật)
            UIHelper.DrawHighlightText(e.Graphics, lblFullName, displayName, _searchKeyword, 
                Color.Black, Color.FromArgb(206, 225, 255), Color.FromArgb(0, 98, 255));
        }

        private string _searchKeyword = "";

        /// Nạp dữ liệu của Bác sĩ vào các Control hiển thị trên Card.
        /// Tính toán động lại khoảng cách chiều dọc (Top) giữa các nhãn thông tin để tránh khoảng trống thừa.
        public void SetDoctorData(DoctorDTO doctor, string searchKeyword = "")
        {
            if (doctor == null) return;

            _currentDoc = doctor;
            _searchKeyword = searchKeyword;
            lblFullName.Invalidate(); // Yêu cầu vẽ lại tên bác sĩ để cập nhật Highlight

            // 1. Tên Bác sĩ: Chuẩn hóa chức danh (Position) và Họ tên (FullName)
            string position = NormalizeDoctorTitle(doctor.Position);
            string fullName = NormalizeDoctorName(doctor.User?.FullName);
            lblFullName.Text = string.IsNullOrWhiteSpace(position)
                ? $"BS. {fullName}"
                : $"{position} {fullName}";
            lblFullName.BringToFront();

            // Tính toán lại vị trí (Top) của các label bên dưới để không bị khoảng trống thừa khi tên ngắn (1 dòng)
            int nextTop = lblFullName.Top + lblFullName.Height + 10;
            lblPhone.Top = nextTop;
            
            nextTop = lblPhone.Top + lblPhone.Height + 5;
            lblSpecialties.Top = nextTop;
            
            nextTop = lblSpecialties.Top + lblSpecialties.Height + 5;
            lblGender.Top = nextTop;
            
            nextTop = lblGender.Top + lblGender.Height + 5;
            label3.Top = nextTop;
            lblSpecificAdress.Top = nextTop;
            
            nextTop = lblSpecificAdress.Top + lblSpecificAdress.Height + 15;
            label4.Top = nextTop;
            lblWorkingTime.Top = nextTop;
            
            nextTop = lblWorkingTime.Top + lblWorkingTime.Height + 15;
            label5.Top = nextTop;
            lblPrice.Top = nextTop;
            
            nextTop = lblPrice.Top + lblPrice.Height + 22;
            label2.Top = nextTop;
            
            nextTop = label2.Top + label2.Height + 10;
            label6.Top = nextTop;
            lblRating.Top = nextTop;
            lblTotalReviews.Top = nextTop;
            
            nextTop = label6.Top + label6.Height + 15;
            label7.Top = nextTop;
            lblEx.Top = nextTop;

            // 2. Điện thoại
            lblPhone.Text = doctor.User?.PhoneNumber ?? "Chưa cập nhật";

            // 3. Chuyên khoa
            string deptName = $"Chuyên khoa: {doctor.Department?.DepartmentName ?? "Chưa cập nhật"}";
            lblSpecialties.Text = deptName;

            // 4. Giới tính
            lblGender.Text = $"Giới tính: {doctor.User?.Gender ?? "Chưa cập nhật"}";

            // 5. Địa chỉ chi tiết
            lblSpecificAdress.Text = doctor.User?.Residential_Address ?? "Chưa cập nhật";

            // 6. Thời gian làm việc hoặc ngày gia nhập
            lblWorkingTime.Text = doctor.JoinDate.HasValue
                ? $"Gia nhập: {doctor.JoinDate.Value:dd/MM/yyyy}"
                : "Lịch: Thứ 2 - Thứ 7";

            // 7. Giá khám bệnh
            decimal price = doctor.ConsultationFee ?? 0;
            lblPrice.Text = price.ToString("N0") + " đ";

            // 8. Đánh giá (Điểm trung bình và tổng lượt đánh giá)
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

            // 9. Số năm kinh nghiệm
            lblEx.Text = $"{doctor.ExperienceYears ?? 0} năm kinh nghiệm";

            // 10. Ảnh đại diện của Bác sĩ
            string fileName = doctor.User?.Picture?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(fileName) || fileName.Equals("default.jpg", StringComparison.OrdinalIgnoreCase))
            {
                fileName = "bs_nguyen_van_an.jpg";
            }
            LoadDoctorImage(fileName);
        }

        /// <summary>
        /// Chuẩn hóa chức danh hiển thị của bác sĩ (ví dụ: PGS, GS, TS, ThS, BS, BSCK).
        /// </summary>
        private static string NormalizeDoctorTitle(string? position)
        {
            if (string.IsNullOrWhiteSpace(position)) return "BS.";

            string title = position.Trim();

            // Thay thế các học hàm, học vị, chức danh phổ biến theo thứ tự ưu tiên
            title = System.Text.RegularExpressions.Regex.Replace(title, "(?i)phó giáo sư", "PGS.");
            title = System.Text.RegularExpressions.Regex.Replace(title, "(?i)giáo sư", "GS.");
            title = System.Text.RegularExpressions.Regex.Replace(title, "(?i)tiến sĩ", "TS.");
            title = System.Text.RegularExpressions.Regex.Replace(title, "(?i)thạc sĩ", "ThS.");
            title = System.Text.RegularExpressions.Regex.Replace(title, "(?i)bác sĩ chuyên khoa", "BSCK.");
            title = System.Text.RegularExpressions.Regex.Replace(title, "(?i)bác sĩ", "BS.");

            // Chuẩn hóa khoảng trắng dư thừa
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim();

            return title;
        }

        /// <summary>
        /// Chuẩn hóa tên bác sĩ, loại bỏ các chữ tiền tố lặp lại.
        /// </summary>
        private static string NormalizeDoctorName(string? fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "Chưa cập nhật";

            string name = fullName.Trim();
            if (name.StartsWith("BS.", StringComparison.OrdinalIgnoreCase))
            {
                return name.Substring(3).Trim();
            }
            if (name.StartsWith("Bác sĩ", StringComparison.OrdinalIgnoreCase))
            {
                return name.Substring("Bác sĩ".Length).Trim();
            }

            return name;
        }

        /// <summary>
        /// Tải hình ảnh của Bác sĩ từ các thư mục tài nguyên cục bộ.
        /// Nếu không tồn tại tệp ảnh hoặc xảy ra lỗi, tự động tải ảnh mặc định từ Resources.
        /// </summary>
        private void LoadDoctorImage(string fileName)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] candidatePaths =
            {
                Path.IsPathRooted(fileName) ? fileName : Path.Combine(baseDir, fileName),
                Path.Combine(baseDir, "Resources_Images", fileName),
                Path.Combine(baseDir, "Resources", fileName)
            };

            foreach (string imagePath in candidatePaths)
            {
                if (!File.Exists(imagePath)) continue;

                try
                {
                    picDoctor.Image?.Dispose();
                    using FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                    picDoctor.Image = new Bitmap(fs);
                    return;
                }
                catch
                {
                    // Tiếp tục thử đường dẫn khác hoặc fallback nếu lỗi
                }
            }

            picDoctor.Image?.Dispose();
            picDoctor.Image = Properties.Resources.bs_nguyen_van_an;
        }

        /// <summary>
        /// Tự vẽ viền và bo góc cho Card.
        /// Thay đổi màu sắc và độ dày viền tùy thuộc vào trạng thái Hover (khi di chuột qua).
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (IsClickable)
            {
                // Màu xanh dương khi Hover chuột qua, màu xám nhạt khi ở trạng thái bình thường
                Color borderColor = _isHovered ? Color.FromArgb(37, 99, 235) : Color.FromArgb(224, 224, 224);
                int borderWidth = _isHovered ? 3 : 2;
                UIHelper.uc_Paint(this, e, 20, borderColor, borderWidth);
            }
            else
            {
                // Giữ nguyên viền xám mặc định khi Card không được phép Click
                UIHelper.uc_Paint(this, e, 20, Color.FromArgb(224, 224, 224), 2);
            }
        }

        /// <summary>
        /// Xử lý sự kiện Load của User Control.
        /// Thực hiện bo tròn các vùng hiển thị của Card, Tag chuyên khoa và PictureBox.
        /// Đồng thời cấu hình con trỏ chuột chỉ tay (Cursors.Hand) và đăng ký các sự kiện chuột (Hover/Click) cho các control con.
        /// </summary>
        private void UCCardDoctor_Load(object sender, EventArgs e)
        {
            // Bo tròn toàn bộ khung Card bác sĩ (bán kính 15px)
            UIHelper.ApplyRoundedRegion(this, 15);

            // Bo tròn tag chuyên khoa ở phía trên bên phải (bán kính 8px)
            UIHelper.ApplyRoundedRegion(lblSpecialtyTag, 8);

            // Bo nhẹ các góc của khung hình ảnh bác sĩ (bán kính 15px)
            UIHelper.ApplyRoundedRegion(picDoctor, 15);

            // --- THIẾT LẬP TƯƠNG TÁC CHUỘT VÀ CON TRỎ ---
            // Gom tất cả các control cần tương tác vào một mảng để thiết lập tự động một lần duy nhất tại sự kiện Load
            Control[] interactiveControls = { 
                this, pnlContainer, picDoctor, lblFullName, lblPhone, lblSpecialties, 
                lblGender, lblSpecificAdress, lblWorkingTime, lblPrice, lblRating, 
                lblTotalReviews, lblEx, label1, label2, label3, label4, label5, label6, label7, lblSpecialtyTag 
            };

            foreach (var ctrl in interactiveControls)
            {
                if (ctrl == null) continue;

                // 1. Thay đổi con trỏ chuột thành dạng bàn tay chỉ ngón trỏ (Cursors.Hand) để chỉ thị đối tượng có thể tương tác click
                ctrl.Cursor = Cursors.Hand;

                // 2. Đăng ký sự kiện Hover khi chuột đi vào (đổi màu viền và nâng thẻ lên nhẹ) và đi ra ngoài
                ctrl.MouseEnter -= OnMouseEnter;
                ctrl.MouseEnter += OnMouseEnter;
                ctrl.MouseLeave -= OnMouseLeave;
                ctrl.MouseLeave += OnMouseLeave;

                // 3. Đăng ký sự kiện Click cho mọi control con để dù click ở đâu trên card cũng điều hướng đến profile bác sĩ
                ctrl.Click -= Card_Click;
                ctrl.Click += Card_Click;
            }
        }

        /// <summary>
        /// Xử lý hiệu ứng khi di chuột vào vùng của Card (MouseEnter).
        /// Hiệu ứng giãn cách và đổi màu nền chỉ kích hoạt nếu người dùng đang đăng nhập với vai trò Bệnh nhân.
        /// </summary>
        private void OnMouseEnter(object sender, EventArgs e)
        {
            if (!IsClickable || _isHovered) return;

            // Chỉ cho phép hiệu ứng Hover (viền xanh, đổi lề nhấc thẻ) nếu người dùng hiện tại là Bệnh nhân
            if (GlobalAccount.GetRole() == "Patient")
            {
                _isHovered = true;
                this.Margin = new Padding(15, 10, 15, 20); // Điều chỉnh Margin tạo cảm giác thẻ nhấc lên
                
                Color hoverColor = Color.FromArgb(252, 253, 255);
                this.BackColor = hoverColor;
                if (pnlContainer != null) pnlContainer.BackColor = hoverColor;
                
                this.Refresh(); // Yêu cầu vẽ lại ngay lập tức để hiện viền xanh mới
            }
            else
            {
                // Giữ nguyên giao diện phẳng ở Guest hoặc các vai trò quản trị khác
                _isHovered = false;
            }
        }
        
        /// <summary>
        /// Xử lý khôi phục giao diện khi di chuột ra khỏi vùng của Card (MouseLeave).
        /// </summary>
        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (!IsClickable) return;

            // Kiểm tra thực tế xem con trỏ chuột có thực sự di chuyển ra hẳn bên ngoài ranh giới của Card hay chưa
            Rectangle screenBounds = this.RectangleToScreen(this.ClientRectangle);
            if (screenBounds.Contains(Cursor.Position)) return;

            // Reset lại giao diện về trạng thái ban đầu
            if (_isHovered)
            {
                _isHovered = false;
                this.Margin = new Padding(15);
                this.BackColor = Color.White;
                if (pnlContainer != null) pnlContainer.BackColor = Color.White;
                this.Invalidate(); // Vẽ lại để khôi phục viền xám mặc định
            }
        }

        /// <summary>
        /// Xử lý sự kiện click trên toàn bộ các thành phần của Card.
        /// Điều hướng chuyển tiếp sang trang thông tin chi tiết (Doctor Profile).
        /// </summary>
        private void Card_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm is frmPatient main)
            {
                main.OpenDoctorProfile(_currentDoc);
            }
        }
    }
}
