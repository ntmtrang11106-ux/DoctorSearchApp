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
        }
        public void SetData(ArticlesDTO article)
        {
            if (article == null) return;

            try
            {
                // 1. Tiêu đề - Luôn đưa lên trên cùng (BringToFront) để không bị Panel đè
                lblTitle.Text = article.Title ?? "Tiêu đề trống";
                lblTitle.BringToFront();

                // 2. Tóm tắt nội dung
                if (!string.IsNullOrEmpty(article.Content))
                {
                    lblSummary.Text = article.Content.Length > 100
                        ? article.Content.Substring(0, 100) + "..."
                        : article.Content;
                }
                else { lblSummary.Text = "Không có nội dung tóm tắt"; }
                lblSummary.BringToFront();

                // 3. Thông tin phụ
                lblViews.Text = article.Views.ToString() + " lượt xem";
                lblDate.Text = article.CreatedAt.ToString("dd/MM/yyyy");

                // 4. Tác giả - DÙNG ?. ĐỂ CHẶN LỖI MẤT BÀI THỨ 5
                lblAuthor.Text = article.Author?.FullName ?? "Admin hệ thống";
                lblAuthor.BringToFront();

                // 5. Xử lý ảnh (Thumbnail)
                if (!string.IsNullOrEmpty(article.Thumbnail))
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
    }
}
