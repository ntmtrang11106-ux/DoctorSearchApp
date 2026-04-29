using DTO_Tier;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucArticleDetail : UserControl
    {
        public ucArticleDetail()
        {
            InitializeComponent();
        }

        public void SetData(ContentDTO art)
        {
            if (art == null) return;

            // 1. Gán thông tin chữ
            lblTitle.Text = art.Title ?? "Không có tiêu đề";
            lblAuthor.Text = "Tác giả: " + (art.AuthorAdmin?.User?.FullName ?? "Quản trị viên");
            lblDate.Text = "Ngày đăng: " + art.CreatedAt.ToString("dd/MM/yyyy");
            lblSpecialities.Text = "Chuyên khoa: " + (art.Department?.DepartmentName ?? "Chung");
            lblViews.Text = art.ViewCount.ToString();
            txtBody.Text = art.Body;

            // 2. Xử lý ảnh
            LoadThumbnail(art.Thumbnail);

            // 3. Tự động giãn chiều cao RichTextBox theo nội dung Body
            AdjustBodyHeight();

            btnBack.BringToFront(); // Đưa nút back lên lớp trên cùng để có thể click
            btnBack.Cursor = Cursors.Hand; // Hiện bàn tay khi rê chuột vàoquay
        }

        private void LoadThumbnail(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    picThumbnail.Visible = false;
                    return;
                }

                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images", fileName);
                if (File.Exists(imagePath))
                {
                    if (picThumbnail.Image != null) picThumbnail.Image.Dispose();
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        picThumbnail.Image = new Bitmap(fs);
                        picThumbnail.Visible = true;
                    }
                }
                else { picThumbnail.Visible = false; }
            }
            catch { picThumbnail.Visible = false; }
        }

        private void AdjustBodyHeight()
        {
            // Ép nội dung RichTextBox tính toán lại vùng hiển thị
            int padding = 100;
            using (Graphics g = txtBody.CreateGraphics())
            {
                Size size = TextRenderer.MeasureText(txtBody.Text, txtBody.Font,
                    new Size(txtBody.Width, int.MaxValue), TextFormatFlags.WordBreak);

                txtBody.Height = size.Height + padding;
            }

            // Đặt txtBody nằm dưới picThumbnail một khoảng 30px
            int topOffset = picThumbnail.Visible ? picThumbnail.Bottom + 30 : pnlHeader.Bottom + 30;
            txtBody.Location = new Point(txtBody.Location.X, topOffset);

            // Refresh lại cuộn trang của toàn bộ User Control
            this.AutoScrollMinSize = new Size(0, txtBody.Bottom + 50);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Tìm Form chứa User Control này (chính là frmPatient)
            Form parentForm = this.FindForm();

            if (parentForm is frmPatient mainForm)
            {
                // Gọi hàm quay lại trang danh sách bài viết
                mainForm.BackToHome();
            }
        }
    }
}