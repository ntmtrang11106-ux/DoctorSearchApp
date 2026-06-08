using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class UCCardArticle : UserControl
    {
        // Biến lưu trữ dữ liệu của bài viết hiện tại hiển thị trên Card
        private ContentDTO _currentArt;
        private bool _isHovered = false;

        public UCCardArticle()
        {
            InitializeComponent();
            
            // Kích hoạt tính năng Double Buffered giúp giảm giật màn hình khi thay đổi kích thước Card hoặc vẽ đè
            UIHelper.SetDoubleBuffered(this);

            // Thêm chú giải ToolTip cho biểu tượng con mắt lượt xem bài viết
            ToolTip tip = new ToolTip();
            tip.SetToolTip(label4, "Lượt xem bài viết");
            
            // Đăng ký vẽ đè tên bài viết để có tính năng tô màu (Highlight) từ khóa tìm kiếm
            lblTitle.Paint += lblTitle_Paint;
            lblTitle.ForeColor = Color.Transparent; // Đặt chữ mặc định trong suốt để tránh in đè 2 lớp chữ khi vẽ highlight
        }

        /// <summary>
        /// Xử lý sự kiện Paint của lblTitle để vẽ chữ nổi bật khớp với từ khóa tìm kiếm.
        /// </summary>
        private void lblTitle_Paint(object sender, PaintEventArgs e)
        {
            if (_currentArt == null) return;
            string title = _currentArt.Title ?? "Không có tiêu đề";

            UIHelper.DrawHighlightText(e.Graphics, lblTitle, title, _searchKeyword, 
                Color.Black, Color.FromArgb(206, 225, 255), Color.FromArgb(0, 98, 255));
        }

        /// <summary>
        /// Xử lý sự kiện Load của User Control.
        /// Định nghĩa viền bo góc khi vẽ lại (Paint).
        /// Đồng thời cấu hình con trỏ chuột dạng bàn tay (Cursors.Hand) và sự kiện Hover/Click một lần duy nhất cho toàn bộ các control con.
        /// </summary>
        private void UCCardArticle_Load(object sender, EventArgs e)
        {
            // Thiết lập vẽ viền bo góc động dựa trên trạng thái Hover
            this.Paint += (s, args) =>
            {
                // Sử dụng màu xanh dương đậm khi hover chuột, màu xám nhạt mặc định khi bình thường
                Color borderColor = _isHovered ? Color.FromArgb(37, 99, 235) : Color.FromArgb(224, 224, 224);
                int borderWidth = _isHovered ? 3 : 2;
                UIHelper.uc_Paint(s, args, 20, borderColor, borderWidth);
            };

            // --- THIẾT LẬP TƯƠNG TÁC CHUỘT VÀ CON TRỎ ---
            // Gom các control con cần tương tác vào một mảng để đăng ký sự kiện tập trung một lần duy nhất khi Load
            Control[] controls = { this, pnlContainer, lblTitle, lblSummary, lblSpecialities,
                                   lblAuthor, lblDate, lblViews, picThumbnail, label4, lblStatus };

            foreach (var ctrl in controls)
            {
                if (ctrl == null) continue;

                // 1. Thay đổi con trỏ chuột thành hình bàn tay (Cursors.Hand) chỉ ngón trỏ để báo hiệu đối tượng có thể click
                ctrl.Cursor = Cursors.Hand;

                // 2. Đăng ký sự kiện MouseEnter/MouseLeave để kích hoạt hiệu ứng nâng/hạ thẻ
                ctrl.MouseEnter -= OnMouseEnter;
                ctrl.MouseEnter += OnMouseEnter;
                ctrl.MouseLeave -= OnMouseLeave;
                ctrl.MouseLeave += OnMouseLeave;

                // 3. Đăng ký sự kiện Click để chuyển tiếp trang chi tiết bài viết
                ctrl.Click -= Card_Click;
                ctrl.Click += Card_Click;
            }
        }

        private string _searchKeyword = "";

        /// <summary>
        /// Nạp dữ liệu bài viết (ContentDTO) và căn chỉnh vị trí (Top) của các nhãn thông tin.
        /// </summary>
        /// <param name="content">Đối tượng bài viết (ContentDTO)</param>
        /// <param name="searchKeyword">Từ khóa tìm kiếm hiện tại để highlight văn bản</param>
        public void SetData(ContentDTO content, string searchKeyword = "")
        {
            if (content == null) return;

            _currentArt = content;
            _searchKeyword = searchKeyword;
            lblTitle.Invalidate(); // Yêu cầu vẽ lại để cập nhật Highlight trên tiêu đề

            try
            {
                // 1. Đổ dữ liệu văn bản tiêu đề
                lblTitle.Text = content.Title ?? "Không có tiêu đề";

                // Tính toán lại vị trí (Top) của các label bên dưới để không bị khoảng trống thừa khi tên ngắn (1 dòng)
                int nextTop = lblTitle.Top + lblTitle.Height + 10;
                lblSpecialities.Top = nextTop;
                lblStatus.Top = nextTop;

                nextTop = lblSpecialities.Top + lblSpecialities.Height + 10;
                lblSummary.Top = nextTop;

                nextTop = lblSummary.Top + lblSummary.Height + 30;
                lblDate.Top = nextTop;

                nextTop = lblDate.Top + lblDate.Height + 10;
                lblAuthor.Top = nextTop;
                lblViews.Top = nextTop;
                label4.Top = nextTop;

                lblSpecialities.Text = content.Department?.DepartmentName ?? "Chưa cập nhật";

                if (!string.IsNullOrEmpty(content.Summary))
                {
                    lblSummary.Text = content.Summary.Length > 100
                        ? content.Summary.Substring(0, 100) + "...Xem thêm"
                        : content.Summary;
                }
                else 
                { 
                    lblSummary.Text = "...Xem thêm"; 
                }

                lblViews.Text = content.ViewCount.ToString();
                
                // Căn chỉnh biểu tượng con mắt nằm sát lề trái của số lượt xem
                label4.Location = new Point(lblViews.Left - label4.Width - 2, lblViews.Top + (lblViews.Height - label4.Height) / 2);

                lblDate.Text = "Ngày đăng: " + content.CreatedAt.ToString("dd/MM/yyyy");
                lblAuthor.Text = "Tác giả: " + (content.AuthorAdmin?.User?.FullName ?? "Quản trị viên");
                
                // 1.1 Trạng thái bài viết (Chỉ hiển thị cho người dùng có vai trò Admin)
                if (GlobalAccount.GetRole() == "Admin")
                {
                    lblStatus.Visible = true;
                    
                    // Chuyển đổi trạng thái tiếng Anh sang tiếng Việt để hiển thị trực quan
                    string status = content.Status ?? "Bản nháp";
                    if (status == "Published") status = "Đã xuất bản";
                    else if (status == "Draft") status = "Bản nháp";
                    else if (status == "Hidden") status = "Đã ẩn";
                    
                    lblStatus.Text = status;
                    
                    // Đặt màu sắc background nổi bật tùy vào trạng thái bài viết
                    if (status == "Đã xuất bản")
                    {
                        lblStatus.BackColor = Color.FromArgb(220, 252, 231); // Xanh lá nhẹ
                        lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
                    }
                    else if (status == "Bản nháp")
                    {
                        lblStatus.BackColor = Color.FromArgb(254, 249, 195); // Vàng nhẹ
                        lblStatus.ForeColor = Color.FromArgb(133, 77, 14);
                    }
                    else // Đã ẩn
                    {
                        lblStatus.BackColor = Color.FromArgb(254, 226, 226); // Đỏ nhẹ
                        lblStatus.ForeColor = Color.FromArgb(153, 27, 27);
                    }
                    UIHelper.ApplyRoundedRegion(lblStatus, 10);
                }
                else
                {
                    lblStatus.Visible = false;
                }

                // 2. Xử lý tải hình ảnh xem trước (Thumbnail) của bài viết
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
                        picThumbnail.Image?.Dispose();
                        picThumbnail.Image = (Bitmap)Properties.Resources.logo.Clone();
                        picThumbnail.BackColor = Color.White;
                    }
                    picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch { /* Xử lý bỏ qua lỗi nếu tệp hình ảnh bị lỗi hoặc không thể đọc */ }

                // Ghi chú: Việc đăng ký các sự kiện chuột (MouseEnter, MouseLeave, Click) và Cursors.Hand 
                // đã được chuyển toàn bộ lên hàm UCCardArticle_Load để chạy duy nhất một lần khi khởi tạo giao diện
                // giúp tối ưu hiệu năng hiển thị và giữ code sạch sẽ.
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tại Card Bài Viết: " + ex.Message);
            }
        }

        /// <summary>
        /// Kích hoạt hiệu ứng di chuột vào vùng của Card (MouseEnter).
        /// Thay đổi padding tạo hiệu ứng "nhấc lên" nhẹ và đổi màu nền nhạt.
        /// </summary>
        private void OnMouseEnter(object sender, EventArgs e)
        {
            if (_isHovered) return;
            _isHovered = true;
            
            // Tạo hiệu ứng nâng thẻ lên nhẹ bằng cách điều chỉnh padding lề trên dưới
            this.Padding = new Padding(13, 8, 13, 18);
            this.BackColor = Color.FromArgb(252, 253, 255); // Nền đổi sang tông màu hơi xanh nhẹ
            this.Refresh(); // Vẽ lại để cập nhật màu viền
        }

        /// <summary>
        /// Khôi phục giao diện mặc định khi di chuột ra khỏi Card (MouseLeave).
        /// </summary>
        private void OnMouseLeave(object sender, EventArgs e)
        {
            // Kiểm tra tránh hiện tượng giật màn hình khi chuyển chuột nhanh qua lại giữa các control con bên trong UC
            if (this.GetChildAtPoint(this.PointToClient(Cursor.Position)) != null) return;

            _isHovered = false;
            this.Padding = new Padding(13); // Khôi phục padding gốc
            this.BackColor = Color.White; // Khôi phục nền trắng
            this.Refresh(); // Vẽ lại viền xám mặc định
        }

        /// <summary>
        /// Sự kiện xử lý chung khi người dùng click vào bất kỳ đâu trên Card.
        /// Xác định Form cha hiện tại và điều hướng mượt mà sang chi tiết bài viết.
        /// </summary>
        private void Card_Click(object sender, EventArgs e)
        {
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
                adminMain.OpenArticleDetail(_currentArt);
            }
        }
    }
}
