using DTO_Tier;
using BUS_Tier;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UI_Tier
{
    /// <summary>
    /// Giao diện UserControl hiển thị chi tiết bài viết y tế, hướng dẫn quy trình hoặc thông báo.
    /// Đối với Admin, hỗ trợ thêm các hành động chỉnh sửa, ẩn/hiện hoặc xóa bài viết.
    /// </summary>
    public partial class ucArticleDetail : UserControl
    {
        // Khởi tạo đối tượng ToolTip để tạo chú giải khi người dùng rê chuột vào các nút hành động
        private ToolTip _tip = new ToolTip();

        // Đối tượng chứa thông tin bài viết hiện tại
        private ContentDTO _art;

        public ucArticleDetail()
        {
            InitializeComponent();
            
            // Thiết lập chú giải ToolTip cho các nút bấm hành động của Admin
            _tip.SetToolTip(btnEdit, "Chỉnh sửa bài viết");
            _tip.SetToolTip(btnRemove, "Xóa bài viết");

            // Kiểm tra phân quyền: Chỉ hiển thị thanh hành động (Sửa, Xóa, Ẩn) nếu người đăng nhập là Admin
            flpAction.Visible = (GlobalAccount.GetRole() == "Admin");

            // Tối ưu hóa thanh cuộn và chống giật/nháy giao diện bằng helper chuyên dụng
            UIHelper.SetupScrollableContainer(this);
        }

        /// Điền dữ liệu của bài viết lên các thành phần giao diện
        public void SetData(ContentDTO art)
        {
            if (art == null) return;
            _art = art;

            // 1. Gán thông tin văn bản cơ bản
            lblTitle.Text = art.Title ?? "Không có tiêu đề";
            lblAuthor.Text = "Tác giả: " + (art.AuthorAdmin?.User?.FullName ?? "Quản trị viên");
            lblDate.Text = "Ngày đăng: " + art.CreatedAt.ToString("dd/MM/yyyy");
            lblSpecialities.Text = "Chuyên khoa: " + (art.Department?.DepartmentName ?? "Chung");
            lblViews.Text = art.ViewCount.ToString();
            txtBody.Text = art.Body;

            // Thiết lập trạng thái Ẩn/Hiện bằng cách đổi ký tự Icon (Segoe MDL2 Assets) và ToolTip tương ứng
            if (art.Status == "Hidden")
            {
                btnHide.Text = "\uE7B3"; // Icon hình mắt (Hiển thị lại)
                _tip.SetToolTip(btnHide, "Hiện bài viết");
            }
            else
            {
                btnHide.Text = "\uE890"; // Icon hình mắt có gạch chéo (Ẩn đi)
                _tip.SetToolTip(btnHide, "Ẩn bài viết");
            }

            // 2. Gọi hàm tải hình ảnh đại diện của bài viết
            LoadThumbnail(art.Thumbnail);

            // 3. Tự động tính toán lại chiều cao hộp thoại nội dung văn bản và thanh cuộn để tránh mất chữ
            AdjustBodyHeight();

            // Đưa nút Quay lại (Back) lên lớp trên cùng để đảm bảo không bị các điều khiển khác che mất
            btnBack.BringToFront();
        }

        /// Tải hình ảnh đại diện từ thư mục tài nguyên của ứng dụng lên PictureBox
        private void LoadThumbnail(string fileName)
        {
            try
            {
                // Nếu không có ảnh đại diện, ẩn khung chứa ảnh đi
                if (string.IsNullOrEmpty(fileName))
                {
                    picThumbnail.Visible = false;
                    return;
                }

                // Xây dựng đường dẫn vật lý đến thư mục Resources_Images
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images", fileName);
                if (File.Exists(imagePath))
                {
                    // Giải phóng ảnh cũ đang chiếm dụng trong bộ nhớ (nếu có) trước khi nạp ảnh mới
                    if (picThumbnail.Image != null) picThumbnail.Image.Dispose();
                    
                    // Sử dụng FileStream để đọc tệp tránh việc khóa file ảnh gốc trên ổ cứng
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        picThumbnail.Image = new Bitmap(fs);
                        picThumbnail.Visible = true; // Hiển thị khung ảnh đại diện lên
                    }
                }
                else 
                { 
                    picThumbnail.Visible = false; // Ẩn đi nếu tệp không tồn tại
                }
            }
            catch 
            { 
                picThumbnail.Visible = false; // Ẩn đi nếu có bất kỳ ngoại lệ nào xảy ra
            }
        }

        /// <summary>
        /// Tự động giãn chiều cao của RichTextBox (chứa nội dung bài viết) theo độ dài văn bản thực tế
        /// </summary>
        private void AdjustBodyHeight()
        {
            int padding = 100; // Khoảng đệm phòng ngừa
            using (Graphics g = txtBody.CreateGraphics())
            {
                // Đo đạc kích thước vùng vẽ chữ thực tế của RichTextBox dựa trên Font chữ và chiều rộng hiện tại
                Size size = TextRenderer.MeasureText(txtBody.Text, txtBody.Font,
                    new Size(txtBody.Width, int.MaxValue), TextFormatFlags.WordBreak);

                txtBody.Height = size.Height + padding;
            }

            // Xác định vị trí Top cho nội dung: Nếu có ảnh thì nằm dưới ảnh 30px, ngược lại nằm dưới header 30px
            int topOffset = picThumbnail.Visible ? picThumbnail.Bottom + 30 : pnlHeader.Bottom + 30;
            txtBody.Location = new Point(txtBody.Location.X, topOffset);

            // Cập nhật lại phạm vi cuộn tối thiểu của UserControl để người dùng có thể cuộn hết bài viết
            this.AutoScrollMinSize = new Size(0, txtBody.Bottom + 50);
        }

        /// <summary>
        /// Xử lý sự kiện khi bấm nút Quay lại (Back)
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Tìm kiếm Form gốc chứa UserControl hiện hành để gọi hàm quay lại trang trước
            Form parentForm = this.FindForm();

            if (parentForm is frmPatient mainForm)
            {
                // Đối với bệnh nhân: Quay lại trang chủ danh sách bài viết chính
                mainForm.BackToHome();
            }
            else if (parentForm is frmDoctor docForm)
            {
                // Đối với bác sĩ: Quay lại trang danh sách bài viết
                docForm.BackToArticleList();
            }
            else if (parentForm is frmGuest guestForm)
            {
                // Đối với khách vãng lai: Quay lại giao diện tìm kiếm tổng hợp
                guestForm.BackToSearch();
            }
            else if (parentForm is frmAdmin adminForm)
            {
                // Đối với Admin: Ẩn lớp phủ chi tiết bài viết (chuyền null) để trở lại bảng quản trị
                adminForm.OpenArticleDetail(null);
            }
        }

        /// <summary>
        /// Xử lý sự kiện bấm nút Chỉnh sửa bài viết dành cho Admin
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm is frmAdmin adminForm)
            {
                // Truy cập UserControl quản lý bài viết hiện tại của Admin và gọi giao diện Thêm/Sửa bài viết
                if (adminForm.GetCurrentUC() is ucAdmin_ArticleManagement artMgmt)
                {
                    artMgmt.ShowAddArticle(_art); // Chuyển sang màn hình chỉnh sửa bài viết đã chọn
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện bấm nút Xóa bài viết dành cho Admin
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_art == null) return;

            // Hiện hộp thoại cảnh báo xác nhận trước khi thực hiện hành động xóa
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bài viết này?", "Xác nhận xóa", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ContentBUS bus = new ContentBUS();
                // Thực hiện xóa bài viết thông qua tầng BUS
                if (bus.DeleteArticle(_art.Id))
                {
                    MessageBox.Show("Đã xóa bài viết thành công!", "Thông báo");
                    
                    // Làm mới lại danh sách bài viết và đóng bảng chi tiết bài viết
                    Form parentForm = this.FindForm();
                    if (parentForm is frmAdmin adminForm && adminForm.GetCurrentUC() is ucAdmin_ArticleManagement artMgmt)
                    {
                        artMgmt.RefreshList();
                        artMgmt.HideOverlay(); // Ẩn lớp phủ hiển thị chi tiết bài viết
                    }
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Vui lòng thử lại.", "Lỗi");
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện bấm nút Ẩn hoặc Hiển thị lại bài viết dành cho Admin
        /// </summary>
        private void btnHide_Click(object sender, EventArgs e)
        {
            if (_art == null) return;
            
            // Trạng thái được lưu trong CSDL dưới dạng chuỗi tiếng Anh: Published, Hidden, Draft
            bool isCurrentlyHidden = (_art.Status == "Hidden");
            string newStatus = isCurrentlyHidden ? "Published" : "Hidden";
            string confirmMsg = isCurrentlyHidden ? "Bạn có muốn hiển thị lại bài viết này?" : "Bạn có muốn ẩn bài viết này?";

            // Xác nhận hành động ẩn/hiện từ người dùng
            if (MessageBox.Show(confirmMsg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ContentBUS bus = new ContentBUS();
                _art.Status = newStatus; // Gán trạng thái mới
                
                // Gọi lớp BUS cập nhật lại dữ liệu bài viết
                if (bus.UpdateArticle(_art))
                {
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo");
                    SetData(_art); // Nạp lại dữ liệu ngay lập tức để cập nhật nhãn trạng thái và Icon trên giao diện
                    
                    // Làm mới danh sách bài viết hiển thị ở bảng quản lý bên dưới
                    Form parentForm = this.FindForm();
                    if (parentForm is frmAdmin adminForm && adminForm.GetCurrentUC() is ucAdmin_ArticleManagement artMgmt)
                    {
                        artMgmt.RefreshList();
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi");
                }
            }
        }

        #region Kéo thả di chuyển UserControl bằng giữ chuột trái ở tiêu đề (Header)
        private Point _mouseLoc;

        // Lưu vị trí chuột ban đầu khi nhấn giữ xuống
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e) => _mouseLoc = e.Location;
        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _mouseLoc.X;
                this.Top += e.Y - _mouseLoc.Y;
            }
        }
        #endregion
    }
}