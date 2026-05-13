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
        private bool _isHovered = false;

        public UCCardArticle()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
        }

        private void UCCardArticle_Load(object sender, EventArgs e)
        {
            this.Paint += (s, args) =>
            {
                // Sử dụng màu xanh đậm khi hover, màu xám khi bình thường
                Color borderColor = _isHovered ? Color.FromArgb(37, 99, 235) : Color.FromArgb(224, 224, 224);
                int borderWidth = _isHovered ? 3 : 2;
                UIHelper.uc_Paint(s, args, 20, borderColor, borderWidth);
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
                
                // 1.1 Trạng thái (Chỉ hiện cho Admin)
                if (GlobalAccount.GetRole() == "Admin")
                {
                    lblStatus.Visible = true;
                    
                    // Map English to Vietnamese if needed
                    string status = content.Status ?? "Bản nháp";
                    if (status == "Published") status = "Đã xuất bản";
                    else if (status == "Draft") status = "Bản nháp";
                    else if (status == "Hidden") status = "Đã ẩn";
                    
                    lblStatus.Text = status;
                    
                    if (status == "Đã xuất bản")
                    {
                        lblStatus.BackColor = Color.FromArgb(220, 252, 231); // Green
                        lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
                    }
                    else if (status == "Bản nháp")
                    {
                        lblStatus.BackColor = Color.FromArgb(254, 249, 195); // Yellow
                        lblStatus.ForeColor = Color.FromArgb(133, 77, 14);
                    }
                    else // Đã ẩn
                    {
                        lblStatus.BackColor = Color.FromArgb(254, 226, 226); // Red
                        lblStatus.ForeColor = Color.FromArgb(153, 27, 27);
                    }
                    UIHelper.ApplyRoundedRegion(lblStatus, 10);
                }
                else
                {
                    lblStatus.Visible = false;
                }

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
                               lblAuthor, lblDate, lblViews, picThumbnail, label4, lblStatus };

                foreach (var ctrl in controls)
                {
                    if (ctrl == null) continue;

                    // Xóa sự kiện cũ (nếu có) để tránh bị gọi trùng lặp khi Load lại dữ liệu
                    ctrl.Click -= Card_Click;
                    ctrl.Click += Card_Click;

                    // Đổi con trỏ chuột sang hình bàn tay để người dùng biết là kích được
                    // Đổi con trỏ chuột sang hình bàn tay để người dùng biết là kích được
                    ctrl.Cursor = Cursors.Hand;

                    // Thêm hiệu ứng Hover
                    ctrl.MouseEnter -= OnMouseEnter;
                    ctrl.MouseEnter += OnMouseEnter;
                    ctrl.MouseLeave -= OnMouseLeave;
                    ctrl.MouseLeave += OnMouseLeave;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tại Card Bài Viết: " + ex.Message);
            }
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            if (_isHovered) return;
            _isHovered = true;
            
            // Hiệu ứng "Nhấc lên": Giảm padding trên, tăng padding dưới
            this.Padding = new Padding(13, 8, 13, 18);
            this.BackColor = Color.FromArgb(252, 253, 255); // Nền hơi xanh nhạt
            this.Refresh(); // Vẽ lại viền
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            // Kiểm tra xem chuột có thực sự rời khỏi vùng của UC không (tránh flick khi di chuyển giữa các control con)
            if (this.GetChildAtPoint(this.PointToClient(Cursor.Position)) != null) return;

            _isHovered = false;
            this.Padding = new Padding(13); // Trả về padding mặc định
            this.BackColor = Color.White;
            this.Refresh(); // Vẽ lại viền
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
            else if (parentForm is frmDoctor docMain)
            {
                docMain.OpenArticleDetail(_currentArt);
            }
            else if (parentForm is frmGuest guestMain)
            {
                guestMain.OpenArticleDetail(_currentArt);
            }
            else if (parentForm is frmAdmin adminMain)
            {
                // In Admin, we might want to handle this differently, but let's assume it has OpenArticleDetail
                adminMain.OpenArticleDetail(_currentArt);
            }
        }
    }
}
