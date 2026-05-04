using DTO_Tier;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucReviewItem : UserControl
    {
        public ucReviewItem()
        {
            InitializeComponent();
        }

        public void SetReviewData(ReviewsDTO review)
        {
            if (review == null) return;

            // 1. Tên bệnh nhân
            string patientName = review.Patient?.User?.FullName ?? "Bệnh nhân";
            lblName.Text = patientName;

            // 2. Avatar placeholder (Lấy chữ cái đầu)
            if (!string.IsNullOrWhiteSpace(patientName))
            {
                lblAvatar.Text = patientName.Substring(0, 1).ToUpper();
            }

            // 3. Số sao
            string stars = "";
            for (int i = 0; i < 5; i++)
            {
                stars += (i < review.Rating) ? "★" : "☆";
            }
            lblRating.Text = stars;

            // 4. Ngày đánh giá
            lblDate.Text = review.CreatedAt.ToString("yyyy-MM-dd");

            // 5. Nội dung bình luận
            lblComment.Text = review.Comment ?? "Không có bình luận.";
        }

        private void ucReviewItem_Load(object sender, EventArgs e)
        {
            // Bo tròn avatar placeholder
            UIHelper.ApplyRoundedRegion(lblAvatar, lblAvatar.Width / 2);
            
            // Random màu nền nhẹ cho avatar để trông sinh động hơn
            Color[] softColors = { Color.MistyRose, Color.LightBlue, Color.LightCyan, Color.Lavender, Color.Honeydew };
            Random rnd = new Random(lblName.Text.GetHashCode());
            lblAvatar.BackColor = softColors[rnd.Next(softColors.Length)];
        }
    }
}
