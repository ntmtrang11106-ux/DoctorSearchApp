using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class UCCardArticle : UserControl
    {
        public UCCardArticle()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
        }
        public void SetData(ContentDTO content)
        {
            if (content == null) return;

            try
            {
                // 1. Tiêu đề - Luôn đưa lên trên cùng (BringToFront) để không bị Panel đè
                lblTitle.Text = content.Title ?? "Không có tiêu đề";
                lblTitle.BringToFront();

                // 2. Tóm tắt nội dung
                if (!string.IsNullOrEmpty(content.Summary))
                {
                    lblSummary.Text = content.Summary.Length > 100
                        ? content.Summary.Substring(0, 100) + "...Xem thêm"
                        : content.Summary;
                }
                else { lblSummary.Text = "...Xem thêm"; }
                lblSummary.BringToFront();

                // 3. Thông tin phụ
                lblViews.Text = content.ViewCount.ToString();
                lblDate.Text = "Ngày đăng: " + content.CreatedAt.ToString("dd/MM/yyyy");

                // 4. Tác giả - DÙNG ?. ĐỂ CHẶN LỖI MẤT BÀI THỨ 5
                lblAuthor.Text = "Tác giả: " + content.AuthorAdmin?.User.FullName ?? "Admin";
                lblAuthor.BringToFront();

                // 5. Xử lý ảnh (Thumbnail)
                if (!string.IsNullOrEmpty(content.Thumbnail))
                {
                    // Tạm thời comment hoặc load ảnh từ resources
                    // picThumbnail.Image = Properties.Resources.default_news; 
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, nó sẽ hiện ngay bài nào bị lỗi để Trang sửa DB
                Console.WriteLine("Lỗi tại Card Bài Viết: " + ex.Message);
            }
        }

        private void UCCardArticle_Load(object sender, EventArgs e)
        {
            this.Paint+=(s, args) =>
            {
                UIHelper.uc_Paint(s, args, 20, Color.Gray, 2);
            };
        }
    }
}
