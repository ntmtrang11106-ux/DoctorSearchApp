using DTO_Tier;
using BUS_Tier;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucArticleDetail : UserControl
    {
        private ToolTip _tip = new ToolTip();
        public ucArticleDetail()
        {
            InitializeComponent();
            SetupAdminActions();
            
            // Thêm chú giải ToolTip cho các nút hành động
            _tip.SetToolTip(btnEdit, "Chỉnh sửa bài viết");
            _tip.SetToolTip(btnRemove, "Xóa bài viết");

            // Hide admin actions if the user is not an Admin
            flpAction.Visible = (GlobalAccount.GetRole() == "Admin");

            // Tối ưu thanh cuộn và chống nháy cho nội dung bài viết
            this.AutoScroll = true;
            UIHelper.SetupScrollableContainer(this);
        }

        private void SetupAdminActions()
        {
            // For dragging
            pnlHeader.MouseDown += pnlHeader_MouseDown;
            pnlHeader.MouseMove += pnlHeader_MouseMove;
            
            // Register actions
            btnEdit.Click += btnEdit_Click;
            btnHide.Click += btnHide_Click;
            btnRemove.Click += btnRemove_Click;
        }

        public void SetData(ContentDTO art)
        {
            if (art == null) return;
            _art = art;

            // 1. Gán thông tin chữ
            lblTitle.Text = art.Title ?? "Không có tiêu đề";
            lblAuthor.Text = "Tác giả: " + (art.AuthorAdmin?.User?.FullName ?? "Quản trị viên");
            lblDate.Text = "Ngày đăng: " + art.CreatedAt.ToString("dd/MM/yyyy");
            lblSpecialities.Text = "Chuyên khoa: " + (art.Department?.DepartmentName ?? "Chung");
            lblViews.Text = art.ViewCount.ToString();
            txtBody.Text = art.Body;

            // Update Hide/View icon based on status (Stored as English in DB)
            if (art.Status == "Hidden")
            {
                btnHide.Text = "\uE7B3"; // View icon
                _tip.SetToolTip(btnHide, "Hiện bài viết");
            }
            else
            {
                btnHide.Text = "\uE890"; // Hide icon
                _tip.SetToolTip(btnHide, "Ẩn bài viết");
            }

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
            // Tìm Form chứa User Control này
            Form parentForm = this.FindForm();

            if (parentForm is frmPatient mainForm)
            {
                // Gọi hàm quay lại trang danh sách bài viết bên bệnh nhân
                mainForm.BackToHome();
            }
            else if (parentForm is frmDoctor docForm)
            {
                // Gọi hàm quay lại trang danh sách bài viết bên bác sĩ
                docForm.BackToArticleList();
            }
            else if (parentForm is frmGuest guestForm)
            {
                // Gọi hàm quay lại trang tìm kiếm bên Guest
                guestForm.BackToSearch();
            }
            else if (parentForm is frmAdmin adminForm)
            {
                // In Admin, we handle it via the Article Management overlay
                adminForm.OpenArticleDetail(null); // Passing null to hide overlay
            }
        }

        private ContentDTO _art;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm is frmAdmin adminForm)
            {
                if (adminForm.GetCurrentUC() is ucAdmin_ArticleManagement artMgmt)
                {
                    artMgmt.ShowAddArticle(_art); // Switch to edit mode
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_art == null) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bài viết này?", "Xác nhận xóa", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ContentBUS bus = new ContentBUS();
                if (bus.DeleteArticle(_art.Id))
                {
                    MessageBox.Show("Đã xóa bài viết thành công!", "Thông báo");
                    
                    // Refresh danh sách và đóng overlay
                    Form parentForm = this.FindForm();
                    if (parentForm is frmAdmin adminForm && adminForm.GetCurrentUC() is ucAdmin_ArticleManagement artMgmt)
                    {
                        artMgmt.RefreshList();
                        artMgmt.HideOverlay(); // Cần public method này hoặc tương tự
                    }
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Vui lòng thử lại.", "Lỗi");
                }
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (_art == null) return;
            
            // Database stores English: Published, Hidden, Draft
            bool isCurrentlyHidden = (_art.Status == "Hidden");
            string newStatus = isCurrentlyHidden ? "Published" : "Hidden";
            string confirmMsg = isCurrentlyHidden ? "Bạn có muốn hiển thị lại bài viết này?" : "Bạn có muốn ẩn bài viết này?";

            if (MessageBox.Show(confirmMsg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ContentBUS bus = new ContentBUS();
                _art.Status = newStatus;
                
                if (bus.UpdateArticle(_art))
                {
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo");
                    SetData(_art); // Cập nhật Badge ngay lập tức
                    
                    // Refresh danh sách bên dưới
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

        #region Draggable Logic
        private Point _mouseLoc;
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