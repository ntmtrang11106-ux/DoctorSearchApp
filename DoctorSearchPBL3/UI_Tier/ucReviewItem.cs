using BUS_Tier;
using DTO_Tier;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucReviewItem : UserControl
    {
        // ──────────────────────────────────────────────────────────────
        // Sự kiện để ucPatient_DocProfile đăng ký và tải lại danh sách
        // ──────────────────────────────────────────────────────────────
        public event EventHandler ReviewDeleted;
        public event EventHandler ReviewEdited;

        private ReviewsDTO _review;
        private DoctorDTO  _doctor;   // cần để cập nhật rating bác sĩ
        private readonly ReviewBUS _reviewBUS = new ReviewBUS();

        public ucReviewItem()
        {
            InitializeComponent();
        }

        // ────────────────────────────────────────────────────────────────────
        // SetReviewData – truyền review + doctor + patientId đang đăng nhập
        // ────────────────────────────────────────────────────────────────────
        public void SetReviewData(ReviewsDTO review, DoctorDTO doctor, int currentPatientId)
        {
            if (review == null) return;
            _review = review;
            _doctor = doctor;

            // 1. Tên bệnh nhân
            string patientName = review.Patient?.User?.FullName ?? "Bệnh nhân";
            lblName.Text = patientName;

            // 2. Avatar placeholder (lấy chữ cái đầu)
            if (!string.IsNullOrWhiteSpace(patientName))
                lblAvatar.Text = patientName.Substring(0, 1).ToUpper();

            // 3. Số sao
            string stars = "";
            for (int i = 0; i < 5; i++)
                stars += (i < review.Rating) ? "★" : "☆";
            lblRating.Text = stars;

            // 4. Ngày đánh giá
            lblDate.Text = review.CreatedAt.ToString("dd/MM/yyyy");

            // 5. Nội dung bình luận
            lblComment.Text = review.Comment ?? "Không có bình luận.";

            // 6. Nếu đây là đánh giá của mình → hiện badge + 2 nút
            bool isOwner = (review.PatientId == currentPatientId);
            lblYourReview.Visible = isOwner;
            lblEdit.Visible       = isOwner;
            lblDelete.Visible     = isOwner;
            
            // 8. Ẩn các thành phần admin (nếu có)
            lblArrow.Visible = false;
            lblDoctorName.Visible = false;

            // 7. Wire-up sự kiện (tránh đăng ký nhiều lần)
            lblEdit.Click   -= BtnEdit_Click;
            lblDelete.Click -= BtnDelete_Click;
            lblEdit.Click   += BtnEdit_Click;
            lblDelete.Click += BtnDelete_Click;
        }

        // ── Overload tương thích ngược (không cần owner check) ──
        public void SetReviewData(ReviewsDTO review)
        {
            SetReviewData(review, null, -1);
        }

        // ────────────────────────────────────────────────────────────────────
        // SetAdminReviewData – dành cho Admin (hiện Patient -> Doctor)
        // ────────────────────────────────────────────────────────────────────
        public void SetAdminReviewData(ReviewsDTO review)
        {
            if (review == null) return;
            _review = review;

            // 1. Tên bệnh nhân
            string patientName = review.Patient?.User?.FullName ?? "Bệnh nhân";
            lblName.Text = patientName;
            
            // 2. Mũi tên & Tên bác sĩ
            string doctorName = "BS. " + (review.Doctor?.User?.FullName ?? "Bác sĩ");
            lblDoctorName.Text = doctorName;
            
            lblArrow.Visible = true;
            lblDoctorName.Visible = true;
            // Cập nhật vị trí để nằm sát nhau
            lblArrow.Left = lblName.Right + 5;
            lblDoctorName.Left = lblArrow.Right + 5;

            // Tránh đè lên phần đánh giá (stars) nếú lblRating hiển thị ở bên phải
            int maxNameWidth = lblRating.Left - lblDoctorName.Left - 20;
            if (maxNameWidth > 100) {
                lblDoctorName.MaximumSize = new Size(maxNameWidth, 0);
            }

            // 3. Avatar (bệnh nhân)
            if (!string.IsNullOrWhiteSpace(patientName))
                lblAvatar.Text = patientName.Substring(0, 1).ToUpper();

            // 4. Số sao
            string stars = "";
            for (int i = 0; i < 5; i++)
                stars += (i < review.Rating) ? "★" : "☆";
            lblRating.Text = stars;

            // 5. Ngày
            lblDate.Text = review.CreatedAt.ToString("dd/MM/yyyy");

            // 6. Nội dung
            lblComment.Text = review.Comment ?? "Không có bình luận.";

            // 7. Admin có quyền xóa đánh giá (nút xóa hiện ra)
            lblYourReview.Visible = false;
            lblEdit.Visible       = false;
            lblDelete.Visible     = true;

            // Wire-up sự kiện xóa (tránh đăng ký nhiều lần)
            lblDelete.Click -= BtnDelete_Click;
            lblDelete.Click += BtnDelete_Click;
        }

        // ────────────────────────────────────────────────────────────────────
        // Load – bo tròn avatar, áp dụng màu ngẫu nhiên
        // ────────────────────────────────────────────────────────────────────
        private void ucReviewItem_Load(object sender, EventArgs e)
        {
            // Xóa dòng ApplyRoundedRegion(this, 15) để tự vẽ trong Paint cho chuẩn
            UIHelper.ApplyRoundedRegion(lblAvatar, lblAvatar.Width / 2);
            UIHelper.ApplyRoundedRegion(lblDelete, 12);
            UIHelper.ApplyRoundedRegion(lblEdit, 12);

            this.Paint += (s, ev) => {
                ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                
                // Vẽ nền trắng bo tròn (thay cho Region)
                using (System.Drawing.Drawing2D.GraphicsPath path = UIHelper.GetRoundedPath(rect, 15)) {
                    using (SolidBrush brush = new SolidBrush(this.BackColor)) {
                        ev.Graphics.FillPath(brush, path);
                    }
                    // Vẽ viền khép kín
                    using (Pen pen = new Pen(Color.FromArgb(220, 220, 220), 1)) {
                        pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                        ev.Graphics.DrawPath(pen, path);
                    }
                }
            };

            Color[] softColors = {
                Color.FromArgb(239, 246, 255),
                Color.FromArgb(240, 253, 244),
                Color.FromArgb(254, 242, 242),
                Color.FromArgb(255, 251, 235),
                Color.FromArgb(250, 245, 255)
            };
            Color[] textColors = {
                Color.FromArgb(37, 99, 235),
                Color.FromArgb(22, 163, 74),
                Color.FromArgb(220, 38, 38),
                Color.FromArgb(217, 119, 6),
                Color.FromArgb(147, 51, 234)
            };

            Random rnd = new Random(lblName.Text.GetHashCode());
            int index = rnd.Next(softColors.Length);
            lblAvatar.BackColor = softColors[index];
            lblAvatar.ForeColor = textColors[index];
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Vẽ viền cực nhẹ
            using (Pen p = new Pen(Color.FromArgb(240, 242, 245), 1))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(p, UIHelper.GetRoundedPath(new Rectangle(0, 0, this.Width - 1, this.Height - 1), 15));
            }
        }

        // ────────────────────────────────────────────────────────────────────
        // Xử lý nút Sửa – mở ucWriteReview ở chế độ Edit
        // ────────────────────────────────────────────────────────────────────
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_review == null || _doctor == null) return;

            // Tìm ucPatient_DocProfile cha để overlay lên đó
            Control parent = this.Parent;
            while (parent != null && !(parent is ucPatient_DocProfile))
                parent = parent.Parent;

            if (parent == null) return;
            var docProfile = (ucPatient_DocProfile)parent;

            var uc = new ucWriteReview(_doctor, _review); // constructor edit mode

            uc.Location = new Point(
                (docProfile.Width  - uc.Width)  / 2,
                (docProfile.Height - uc.Height) / 2
            );

            uc.ReviewSubmitted += (s, ev) =>
            {
                ReviewEdited?.Invoke(this, EventArgs.Empty);
            };

            uc.CloseRequested += (s, ev) =>
            {
                docProfile.Controls.Remove(uc);
                uc.Dispose();
            };

            docProfile.Controls.Add(uc);
            uc.BringToFront();
        }

        // ────────────────────────────────────────────────────────────────────
        // Xử lý nút Xóa – xác nhận rồi soft-delete
        // ────────────────────────────────────────────────────────────────────
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_review == null) return;

            var result = MessageBox.Show(
                "Bạn có chắc muốn xóa đánh giá này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            int doctorId = _doctor?.Id ?? _review.DoctorId;
            bool success = _reviewBUS.DeleteReview(_review.Id, doctorId);

            if (success)
            {
                ReviewDeleted?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show(
                    "Xóa đánh giá thất bại. Vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
