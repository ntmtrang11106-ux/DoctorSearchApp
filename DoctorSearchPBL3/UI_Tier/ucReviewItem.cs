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
        private readonly ToolTip _toolTip = new ToolTip();

        public ucReviewItem()
        {
            InitializeComponent();
            SetupToolTips();
        }

        private void SetupToolTips()
        {
            _toolTip.SetToolTip(btnEdit, "Chỉnh sửa đánh giá");
            _toolTip.SetToolTip(btnRemove, "Xóa đánh giá");
            // ToolTip của btnHide sẽ được Set linh hoạt trong SetReviewData và BtnToggleVisibility
        }



        public void SetReviewData(ReviewsDTO review, DoctorDTO doctor, int currentPatientId)
        {
            if (review == null) return;
            _review = review;
            _doctor = doctor;

            lblName.Text = review.Patient?.User?.FullName ?? "Bệnh nhân";
            if (!string.IsNullOrWhiteSpace(lblName.Text))
            {
                lblAvatar.Text = lblName.Text.Substring(0, 1).ToUpper();
                SetAvatarColor(lblName.Text);
            }

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
            if (btnHide != null) btnHide.Visible = false; // Luôn ẩn nút Ẩn bài ở form bệnh nhân
            
            if (lblArrow != null) lblArrow.Visible = false;
            if (lblDoctorName != null) lblDoctorName.Visible = false;

            this.Height = 220;
        }

        public void SetReviewData(ReviewsDTO review) => SetReviewData(review, null, -1);

        public void SetAdminReviewData(ReviewsDTO review, bool hideButtons = false)
        {
            if (review == null) return;
            _review = review;

            string pName = review.Patient?.User?.FullName ?? "Bệnh nhân";
            string dName = review.Doctor?.User?.FullName ?? "Bác sĩ";

            lblName.Text = pName;
            lblDoctorName.Text = "BS. " + dName;
            
            // Xử lý hiển thị tên dài (Dịch chuyển mũi tên và tên bác sĩ linh hoạt)
            lblArrow.Visible = true;
            lblDoctorName.Visible = true;
            
            // Cập nhật vị trí sau khi tên đã AutoSize
            lblName.Refresh(); 
            lblArrow.Left = lblName.Right + 10;
            lblDoctorName.Left = lblArrow.Right + 10;

            lblAvatar.Text = string.IsNullOrEmpty(pName) ? "?" : pName.Substring(0, 1).ToUpper();
            
            // Đổ màu avatar ngẫu nhiên dựa trên tên để đẹp hơn
            Color[] premiumColors = {
                Color.FromArgb(127, 85, 240), // Tím
                Color.FromArgb(24, 112, 255), // Xanh dương
                Color.FromArgb(40, 199, 111), // Xanh lá
                Color.FromArgb(255, 159, 67), // Cam
                Color.FromArgb(234, 84, 85),  // Đỏ
                Color.FromArgb(0, 207, 232)   // Xanh lơ
            };
            int colorIndex = Math.Abs(pName.GetHashCode()) % premiumColors.Length;
            lblAvatar.BackColor = premiumColors[colorIndex];
            lblAvatar.ForeColor = Color.White;
            UIHelper.ApplyRoundedRegion(lblAvatar, 8);

            lblDate.Text = review.CreatedAt.ToString("dd/MM/yyyy");
            lblRating.Text = new string('★', (int)review.Rating) + new string('☆', 5 - (int)review.Rating);
            
            string fullComment = (review.Comment ?? "").Replace("|ADMIN_REPLY|", "|CHAT_MSG|");
            if (fullComment.Contains("|CHAT_MSG|"))
                fullComment = fullComment.Split(new string[] { "|CHAT_MSG|" }, StringSplitOptions.None)[0];
            lblComment.Text = string.IsNullOrEmpty(fullComment) ? "Không có bình luận." : fullComment.Trim();

            if (lblStatus != null) {
                lblStatus.Visible = !hideButtons;
                if (lblStatus.Visible)
                {
                    if (review.IsDeleted) {
                        lblStatus.Text = "Đã xóa";
                        lblStatus.BackColor = Color.FromArgb(254, 242, 242);
                        lblStatus.ForeColor = Color.FromArgb(220, 38, 38);
                    } else if (!review.IsVisible) {
                        lblStatus.Text = "Đang ẩn";
                        lblStatus.BackColor = Color.FromArgb(243, 244, 246);
                        lblStatus.ForeColor = Color.FromArgb(107, 114, 128);
                    } else {
                        lblStatus.Text = "Đang hiển thị";
                        lblStatus.BackColor = Color.FromArgb(236, 253, 245);
                        lblStatus.ForeColor = Color.FromArgb(5, 150, 105);
                    }
                    UIHelper.ApplyRoundedRegion(lblStatus, 10);
                    lblStatus.Left = (this.Width - lblStatus.Width) / 2;
                    lblStatus.Anchor = AnchorStyles.Top;
                }
            }

            if (btnRemove != null) btnRemove.Visible = !hideButtons && !review.IsDeleted;
            if (btnHide != null) {
                btnHide.Visible = !hideButtons && !review.IsDeleted;
                btnHide.Text = review.IsVisible ? "\uE890" : "\uED1A"; 
                // btnHide.ForeColor = review.IsVisible ? Color.FromArgb(75, 85, 99) : Color.FromArgb(239, 68, 68);
                btnHide.ForeColor = review.IsVisible ? Color.FromArgb(75, 85, 99) : Color.FromArgb(75, 85, 99);

                // Sử dụng _toolTip chung
                _toolTip.SetToolTip(btnHide, review.IsVisible ? "Ẩn đánh giá" : "Hiện đánh giá");
            }
            if (btnEdit != null) btnEdit.Visible = false;

            this.Height = 220;
        }

        private void ucReviewItem_Load(object sender, EventArgs e)
        {
            if (btnRemove != null) btnRemove.Click += BtnDelete_Click;
            if (btnHide != null) btnHide.Click += BtnToggleVisibility_Click;
            if (btnEdit != null) btnEdit.Click += BtnEdit_Click;

            this.Paint += (s, ev) => UIHelper.DrawControlBorder(this, ev, 15, Color.FromArgb(220, 220, 220), 1);
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
                    btnHide.Text = newStatus ? "\uE890" : "\uED1A";
                    btnHide.ForeColor = newStatus ? Color.FromArgb(75, 85, 99) : Color.FromArgb(239, 68, 68);
                    
                    _toolTip.SetToolTip(btnHide, newStatus ? "Ẩn đánh giá" : "Hiện đánh giá");
                }
                ReviewEdited?.Invoke(this, EventArgs.Empty);
            }
        }
        private void SetAvatarColor(string name)
        {
            if (string.IsNullOrEmpty(name)) return;
            
            // Bảng màu Pastel/Vibrant cho Avatar
            Color[] colors = {
                Color.FromArgb(239, 68, 68),  // Red
                Color.FromArgb(249, 115, 22), // Orange
                Color.FromArgb(245, 158, 11), // Amber
                Color.FromArgb(16, 185, 129), // Emerald
                Color.FromArgb(6, 182, 212),  // Cyan
                Color.FromArgb(59, 130, 246), // Blue
                Color.FromArgb(99, 102, 241), // Indigo
                Color.FromArgb(139, 92, 246), // Violet
                Color.FromArgb(236, 72, 153)  // Pink
            };

            int index = Math.Abs(name.GetHashCode()) % colors.Length;
            lblAvatar.BackColor = colors[index];
            lblAvatar.ForeColor = Color.White; // Chữ trắng trên nền màu cho sang
        }
    }
}
