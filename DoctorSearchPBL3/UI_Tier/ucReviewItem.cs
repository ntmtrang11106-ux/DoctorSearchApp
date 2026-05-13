using BUS_Tier;
using DTO_Tier;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucReviewItem : UserControl
    {
        public event EventHandler? ReviewDeleted;
        public event EventHandler? ReviewEdited;

        private ReviewsDTO _review;
        private DoctorDTO _doctor;
        private readonly ReviewBUS _reviewBUS = new ReviewBUS();

        public ucReviewItem()
        {
            InitializeComponent();
        }

        public void SetReviewData(ReviewsDTO review, DoctorDTO doctor, int currentPatientId)
        {
            if (review == null) return;
            _review = review;
            _doctor = doctor;

            lblName.Text = review.Patient?.User?.FullName ?? "Bệnh nhân";
            if (!string.IsNullOrWhiteSpace(lblName.Text))
                lblAvatar.Text = lblName.Text.Substring(0, 1).ToUpper();

            string stars = "";
            for (int i = 0; i < 5; i++) stars += (i < review.Rating) ? "★" : "☆";
            lblRating.Text = stars;
            lblDate.Text = review.CreatedAt.ToString("dd/MM/yyyy");

            // Chỉ hiện comment của bệnh nhân, không hiện phản hồi
            string fullComment = (review.Comment ?? "").Replace("|ADMIN_REPLY|", "|CHAT_MSG|");
            if (fullComment.Contains("|CHAT_MSG|"))
                fullComment = fullComment.Split(new string[] { "|CHAT_MSG|" }, StringSplitOptions.None)[0];

            lblComment.Text = string.IsNullOrEmpty(fullComment) ? "Không có bình luận." : fullComment.Trim();

            bool isOwner = (review.PatientId == currentPatientId);
            if (lblYourReview != null) lblYourReview.Visible = isOwner;
            if (btnEdit != null) btnEdit.Visible = isOwner;
            if (btnRemove != null) btnRemove.Visible = isOwner;
            
            if (lblArrow != null) lblArrow.Visible = false;
            if (lblDoctorName != null) lblDoctorName.Visible = false;

            this.Height = 220;
        }

        public void SetReviewData(ReviewsDTO review) => SetReviewData(review, null, -1);

        public void SetAdminReviewData(ReviewsDTO review, bool hideButtons = false)
        {
            if (review == null) return;
            _review = review;

            lblName.Text = review.Patient?.User?.FullName ?? "Bệnh nhân";
            lblDoctorName.Text = "BS. " + (review.Doctor?.User?.FullName ?? "Bác sĩ");
            
            // Xử lý hiển thị tên dài (Dịch chuyển mũi tên và tên bác sĩ linh hoạt)
            lblArrow.Visible = true;
            lblDoctorName.Visible = true;
            
            // Cập nhật vị trí sau khi tên đã AutoSize
            lblName.Refresh(); 
            lblArrow.Left = lblName.Right + 10;
            lblDoctorName.Left = lblArrow.Right + 10;

            if (!string.IsNullOrWhiteSpace(lblName.Text))
                lblAvatar.Text = lblName.Text.Substring(0, 1).ToUpper();

            string stars = "";
            for (int i = 0; i < 5; i++) stars += (i < review.Rating) ? "★" : "☆";
            lblRating.Text = stars;
            lblDate.Text = review.CreatedAt.ToString("dd/MM/yyyy");

            string fullComment = (review.Comment ?? "").Replace("|ADMIN_REPLY|", "|CHAT_MSG|");
            if (fullComment.Contains("|CHAT_MSG|"))
                fullComment = fullComment.Split(new string[] { "|CHAT_MSG|" }, StringSplitOptions.None)[0];
            lblComment.Text = string.IsNullOrEmpty(fullComment) ? "Không có bình luận." : fullComment.Trim();

            if (btnRemove != null) btnRemove.Visible = !hideButtons;
            if (btnHide != null) {
                btnHide.Visible = !hideButtons;
                btnHide.Text = review.IsVisible ? "" : ""; 
                btnHide.ForeColor = review.IsVisible ? Color.FromArgb(75, 85, 99) : Color.FromArgb(239, 68, 68);
            }
            if (btnEdit != null) btnEdit.Visible = false;

            this.Height = 220;
        }

        private void ucReviewItem_Load(object sender, EventArgs e)
        {
            if (btnRemove != null) btnRemove.Click += BtnDelete_Click;
            if (btnHide != null) btnHide.Click += BtnToggleVisibility_Click;
            if (btnEdit != null) btnEdit.Click += BtnEdit_Click;

            this.Paint += (s, ev) => {
                ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                using (System.Drawing.Drawing2D.GraphicsPath path = UIHelper.GetRoundedPath(rect, 15)) {
                    using (SolidBrush brush = new SolidBrush(this.BackColor)) ev.Graphics.FillPath(brush, path);
                    using (Pen pen = new Pen(Color.FromArgb(220, 220, 220), 1)) {
                        pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                        ev.Graphics.DrawPath(pen, path);
                    }
                }
            };
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_review == null || _doctor == null) return;
            Control parent = this.Parent;
            while (parent != null && !(parent is ucPatient_DocProfile)) parent = parent.Parent;
            if (parent == null) return;
            var docProfile = (ucPatient_DocProfile)parent;
            var uc = new ucWriteReview(_doctor, _review);
            uc.Location = new Point((docProfile.Width - uc.Width) / 2, (docProfile.Height - uc.Height) / 2);
            uc.ReviewSubmitted += (s, ev) => ReviewEdited?.Invoke(this, EventArgs.Empty);
            uc.CloseRequested += (s, ev) => { docProfile.Controls.Remove(uc); uc.Dispose(); };
            docProfile.Controls.Add(uc);
            uc.BringToFront();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_review == null) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa đánh giá này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            if (_reviewBUS.DeleteReview(_review.Id, _doctor?.Id ?? _review.DoctorId)) ReviewDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void BtnToggleVisibility_Click(object sender, EventArgs e)
        {
            if (_review == null) return;
            bool newStatus = !_review.IsVisible;
            if (_reviewBUS.UpdateReviewVisibility(_review.Id, newStatus)) {
                _review.IsVisible = newStatus;
                if (btnHide != null) {
                    btnHide.Text = newStatus ? "" : "";
                    btnHide.ForeColor = newStatus ? Color.FromArgb(75, 85, 99) : Color.FromArgb(239, 68, 68);
                }
                ReviewEdited?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
