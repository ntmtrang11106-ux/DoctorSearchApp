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
        // Load – bo tròn avatar, áp dụng màu ngẫu nhiên
        // ────────────────────────────────────────────────────────────────────
        private void ucReviewItem_Load(object sender, EventArgs e)
        {
            this.Margin = new Padding(5, 5, 5, 10);
            UIHelper.ApplyRoundedRegion(this, 15);
            UIHelper.ApplyRoundedRegion(lblAvatar, lblAvatar.Width / 2);

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
            // Vẽ viền nhẹ cho từng ô đánh giá
            UIHelper.DrawControlBorder(this, e, 15, Color.FromArgb(235, 238, 242), 2);
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
