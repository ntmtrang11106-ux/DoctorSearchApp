using DTO_Tier;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace UI_Tier
{
    public partial class ucWriteReview : UserControl
    {
        private int _selectedRating = 0;
        private DoctorDTO _doctor;
        private ReviewsDTO _existingReview; // null → Add mode, có giá trị → Edit mode
        private BUS_Tier.ReviewBUS _reviewBUS = new BUS_Tier.ReviewBUS();

        public event EventHandler CloseRequested;
        public event EventHandler ReviewSubmitted;

        // ── Constructor: Thêm mới ──────────────────────────────────────
        public ucWriteReview(DoctorDTO doctor)
        {
            InitializeComponent();
            _doctor = doctor;
            _existingReview = null;

            UIHelper.SetDoubleBuffered(this);
            btnSubmit.Click += btnSubmit_Click;
        }

        // ── Constructor: Chỉnh sửa ────────────────────────────────────
        public ucWriteReview(DoctorDTO doctor, ReviewsDTO existingReview)
        {
            InitializeComponent();
            _doctor = doctor;
            _existingReview = existingReview;

            UIHelper.SetDoubleBuffered(this);
            btnSubmit.Click += btnSubmit_Click;
        }

        private void ucWriteReview_Load(object sender, EventArgs e)
        {
            // Bo góc
            UIHelper.ApplyRoundedRegion(this, 20);
            this.BackColor = Color.FromArgb(252, 252, 255); // Màu xanh/xám cực nhạt
            this.Paint += (s, ev) => UIHelper.uc_Paint(s, ev, 20, Color.FromArgb(226, 232, 240), 2); // Viền xám nhạt

            UIHelper.ApplyRoundedRegion(txtComment, 10);
            UIHelper.ApplyRoundedRegion(panelTip, 10);
            UIHelper.ApplyRoundedRegion(btnSubmit, 10);
            UIHelper.ApplyRoundedRegion(btnCancel, 10);

            UIHelper.ApplyRoundedRegion(pnlDoctorInfo, 15);
            UIHelper.ApplyRoundedRegion(pictureBox1, pictureBox1.Width / 2);

            // Đổ dữ liệu bác sĩ
            if (_doctor != null)
            {
                label3.Text = (_doctor.Position + " " + _doctor.User?.FullName).Trim();
                lblDocDept.Text = _doctor.Department?.DepartmentName ?? "Chuyên khoa";

                string fileName = string.IsNullOrWhiteSpace(_doctor.User?.Picture) ? "default.jpg" : _doctor.User.Picture.Trim();
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images", fileName);
                if (File.Exists(imagePath))
                {
                    try
                    {
                        using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                            pictureBox1.Image = new Bitmap(fs);
                    }
                    catch { }
                }
            }

            // Nếu là Edit mode → pre-fill dữ liệu cũ
            if (_existingReview != null)
            {
                lblTitle.Text      = "Chỉnh sửa đánh giá";
                btnSubmit.Text     = "Lưu thay đổi";

                _selectedRating    = _existingReview.Rating;
                HighlightStars(_selectedRating, Color.Gold);

                string[] texts = { "", "Tệ", "Không hài lòng", "Bình thường", "Hài lòng", "Rất hài lòng" };
                lblRatingText.Text     = texts[_selectedRating];
                lblRatingText.ForeColor = Color.OrangeRed;

                if (!string.IsNullOrWhiteSpace(_existingReview.Comment))
                {
                    txtComment.Text      = _existingReview.Comment;
                    txtComment.ForeColor = Color.Black;
                }
            }
        }

        #region Kéo UserControl (Draggable)
        private Point _mouseLoc;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e) => _mouseLoc = e.Location;
        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _mouseLoc.X;
                this.Top  += e.Y - _mouseLoc.Y;
            }
        }
        #endregion

        #region Star Rating
        private void Star_MouseEnter(object sender, EventArgs e)
        {
            int rating = int.Parse(((Label)sender).Name.Replace("lblStar", ""));
            HighlightStars(rating, Color.Gold);
        }

        private void Star_MouseLeave(object sender, EventArgs e) => HighlightStars(_selectedRating, Color.Gold);

        private void Star_Click(object sender, EventArgs e)
        {
            _selectedRating = int.Parse(((Label)sender).Name.Replace("lblStar", ""));
            HighlightStars(_selectedRating, Color.Gold);

            string[] texts = { "", "Tệ", "Không hài lòng", "Bình thường", "Hài lòng", "Rất hài lòng" };
            lblRatingText.Text     = texts[_selectedRating];
            lblRatingText.ForeColor = Color.OrangeRed;
        }

        private void HighlightStars(int rating, Color color)
        {
            Label[] stars = { lblStar1, lblStar2, lblStar3, lblStar4, lblStar5 };
            for (int i = 0; i < 5; i++)
                stars[i].ForeColor = (i < rating) ? color : Color.LightGray;
        }
        #endregion

        #region Comment Placeholder & Count
        private void txtComment_Enter(object sender, EventArgs e)
        {
            if (txtComment.Text == "Chia sẻ trải nghiệm của bạn về bác sĩ...")
            {
                txtComment.Text      = "";
                txtComment.ForeColor = Color.Black;
            }
        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtComment.Text))
            {
                txtComment.Text      = "Chia sẻ trải nghiệm của bạn về bác sĩ...";
                txtComment.ForeColor = Color.Gray;
            }
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            int length = txtComment.Text == "Chia sẻ trải nghiệm của bạn về bác sĩ..." ? 0 : txtComment.Text.Length;
            lblCharCount.Text     = $"{length}/1000 ký tự";
            lblCharCount.ForeColor = length > 1000 ? Color.Red : Color.Gray;
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e) => CloseRequested?.Invoke(this, EventArgs.Empty);

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_selectedRating == 0)
            {
                MessageBox.Show("Vui lòng chọn mức độ hài lòng (số sao)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string comment = txtComment.Text;
            if (comment == "Chia sẻ trải nghiệm của bạn về bác sĩ...") comment = "";

            bool success;

            // ── Edit mode ─────────────────────────────────────────────
            if (_existingReview != null)
            {
                success = _reviewBUS.UpdateReview(
                    _existingReview.Id,
                    _selectedRating,
                    comment,
                    _existingReview.DoctorId);

                if (success)
                {
                    MessageBox.Show("Cập nhật đánh giá thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReviewSubmitted?.Invoke(this, EventArgs.Empty);
                    CloseRequested?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            // ── Add mode ──────────────────────────────────────────────
            int patientId = GlobalAccount.GetProfileId();
            if (patientId <= 0)
            {
                MessageBox.Show("Phiên đăng nhập hết hạn. Vui lòng đăng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReviewsDTO newReview = new ReviewsDTO
            {
                PatientId = patientId,
                DoctorId  = _doctor.Id,
                Rating    = _selectedRating,
                Comment   = comment,
                CreatedAt = DateTime.Now,
                IsVisible = true,
                IsDeleted = false
            };

            success = _reviewBUS.AddReview(newReview);

            if (success)
            {
                MessageBox.Show("Cảm ơn bạn đã gửi đánh giá!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReviewSubmitted?.Invoke(this, EventArgs.Empty);
                CloseRequested?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Gửi đánh giá thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
