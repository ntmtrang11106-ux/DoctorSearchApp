using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class UCCardArticle : UserControl
    {
        // Khai báo một biến để lưu trữ dữ liệu của bài viết này
        private ContentDTO _currentArt;

        public UCCardArticle()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
        }
        //public void SetData(ContentDTO content)
        //{
        //    if (content == null) return;

        //    _currentArt = content; // Lưu lại để dùng khi click

        //    try
        //    {
        //        // 1. Tiêu đề - Luôn đưa lên trên cùng (BringToFront) để không bị Panel đè
        //        lblTitle.Text = content.Title ?? "Không có tiêu đề";
        //        lblTitle.BringToFront();

        //        // 2. Chuyên khoa (Department) - Lấy từ quan hệ Content -> Department
        //        // Hiển thị dòng chữ nhỏ dưới tiêu đề như "Ai bt chuyên khoa gì..."
        //        lblSpecialities.Text = content.Department?.DepartmentName ?? "Chưa cập nhật";
        //        lblSpecialities.BringToFront();

        //        // 3. Tóm tắt nội dung
        //        if (!string.IsNullOrEmpty(content.Summary))
        //        {
        //            lblSummary.Text = content.Summary.Length > 100
        //                ? content.Summary.Substring(0, 100) + "...Xem thêm"
        //                : content.Summary;
        //        }
        //        else { lblSummary.Text = "...Xem thêm"; }
        //        lblSummary.BringToFront();

        //        // 4. Thông tin phụ
        //        lblViews.Text = content.ViewCount.ToString();
        //        lblDate.Text = "Ngày đăng: " + content.CreatedAt.ToString("dd/MM/yyyy");

        //        // 5. Tác giả - DÙNG ?. ĐỂ CHẶN LỖI MẤT BÀI THỨ 5
        //        lblAuthor.Text = "Tác giả: " + content.AuthorAdmin?.User.FullName ?? "Admin";
        //        lblAuthor.BringToFront();

        //        // 5. Xử lý ảnh (Thumbnail)
        //        // --- XỬ LÝ HÌNH ẢNH AN TOÀN ---
        //        // --- XỬ LÝ HÌNH ẢNH AN TOÀN TUYỆT ĐỐI ---
        //        try
        //        {
        //            string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images");
        //            if (!Directory.Exists(imageFolder)) Directory.CreateDirectory(imageFolder);

        //            string fileName = content.Thumbnail?.Trim();
        //            string imagePath = !string.IsNullOrEmpty(fileName) ? Path.Combine(imageFolder, fileName) : "";

        //            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
        //            {
        //                if (picThumbnail.Image != null) picThumbnail.Image.Dispose();
        //                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        //                {
        //                    picThumbnail.Image = new Bitmap(fs);
        //                }
        //            }
        //            else
        //            {
        //                // Thay vì gọi Properties.Resources.default_news (đang bị lỗi)
        //                // Chúng ta gán bằng null hoặc một ảnh mặc định có sẵn khác
        //                picThumbnail.Image = null;
        //                picThumbnail.BackColor = Color.LightGray; // Tạo một khung màu xám thay thế ảnh
        //            }

        //            picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
        //        }
        //        catch
        //        {
        //            picThumbnail.Image = null;
        //            picThumbnail.BackColor = Color.LightGray;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Nếu có lỗi, nó sẽ hiện ngay bài nào bị lỗi để Trang sửa DB
        //        Console.WriteLine("Lỗi tại Card Bài Viết: " + ex.Message);
        //    }
        //}

        private void UCCardArticle_Load(object sender, EventArgs e)
        {
            this.Paint+=(s, args) =>
            {
                UIHelper.uc_Paint(s, args, 20, Color.Gray, 2);
            };
        }

        public void SetData(ContentDTO content)
        {
            if (content == null) return;

            _currentArt = content;

            try
            {
                // 1. Đổ dữ liệu văn bản
                lblTitle.Text = content.Title ?? "Không có tiêu đề";
                lblSpecialities.Text = content.Department?.DepartmentName ?? "Chưa cập nhật";

                if (!string.IsNullOrEmpty(content.Summary))
                {
                    lblSummary.Text = content.Summary.Length > 100
                        ? content.Summary.Substring(0, 100) + "...Xem thêm"
                        : content.Summary;
                }
                else { lblSummary.Text = "...Xem thêm"; }

                lblViews.Text = content.ViewCount.ToString();
                lblDate.Text = "Ngày đăng: " + content.CreatedAt.ToString("dd/MM/yyyy");
                lblAuthor.Text = "Tác giả: " + (content.AuthorAdmin?.User?.FullName ?? "Quản trị viên");

                // 2. Xử lý hình ảnh (Giữ nguyên logic an toàn của bạn)
                try
                {
                    string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images");
                    if (!Directory.Exists(imageFolder)) Directory.CreateDirectory(imageFolder);

                    string fileName = content.Thumbnail?.Trim();
                    string imagePath = !string.IsNullOrEmpty(fileName) ? Path.Combine(imageFolder, fileName) : "";

                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        if (picThumbnail.Image != null) picThumbnail.Image.Dispose();
                        using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                        {
                            picThumbnail.Image = new Bitmap(fs);
                        }
                    }
                    else
                    {
                        picThumbnail.Image = null;
                        picThumbnail.BackColor = Color.LightGray;
                    }
                    picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch { /* Xử lý lỗi ảnh ngầm */ }

                // --- PHẦN QUAN TRỌNG: ĐĂNG KÝ SỰ KIỆN CLICK TOÀN DIỆN ---
                // Tạo một danh sách các control cần bắt sự kiện click
                Control[] controls = { this, pnlContainer, lblTitle, lblSummary, lblSpecialities,
                               lblAuthor, lblDate, lblViews, picThumbnail, label4 };

                foreach (var ctrl in controls)
                {
                    if (ctrl == null) continue;

                    // Xóa sự kiện cũ (nếu có) để tránh bị gọi trùng lặp khi Load lại dữ liệu
                    ctrl.Click -= Card_Click;
                    ctrl.Click += Card_Click;

                    // Đổi con trỏ chuột sang hình bàn tay để người dùng biết là kích được
                    ctrl.Cursor = Cursors.Hand;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tại Card Bài Viết: " + ex.Message);
            }
        }

        // Hàm xử lý khi kích vào bất kỳ đâu trên Card
        private void Card_Click(object sender, EventArgs e)
        {
            // Tìm về Form chính để điều hướng trang
            Form parentForm = this.FindForm();
            if (parentForm is frmPatient main)
            {
                main.OpenArticleDetail(_currentArt);
            }
        }
    }
}
