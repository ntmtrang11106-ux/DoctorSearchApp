using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class frmGuest : Form
    {
        private ucGuest_IntegratedSearch _searchControl;

        public frmGuest()
        {
            InitializeComponent();
            
            // Bật tính năng Double Buffered giúp giảm thiểu tình trạng nhấp nháy (flicker) giao diện khi tải hoặc thay đổi kích thước cửa sổ
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlMainContainer);
            
            // Bo tròn các góc của nút Đăng nhập với bán kính 15px (sử dụng GDI+ động nên khai báo ở code-behind)
            UIHelper.ApplyRoundedRegion(btnLogin, 15);
            btnLogin.Cursor = Cursors.Hand;
            
            // Khởi tạo User Control chứa thanh tìm kiếm tích hợp của khách (Guest)
            _searchControl = new ucGuest_IntegratedSearch();
            _searchControl.Dock = DockStyle.Fill;
            pnlMainContainer.Controls.Add(_searchControl);
        }

        /// <summary>
        /// Ghi đè CreateParams để kích hoạt cờ WS_EX_COMPOSITED ở mức Win32.
        /// Giúp toàn bộ các Control con vẽ song song mượt mà hơn, triệt tiêu hiện tượng giật màn hình khi thay đổi kích thước Form.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED (0x02000000)
                return cp;
            }
        }

        /// Xử lý sự kiện khi click nút Đăng nhập.
        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            
            // Ẩn Form Guest trước khi hiện Form Đăng nhập để tránh hiển thị song song cả 2 cửa sổ
            this.Hide();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // 1. Lấy Dashboard đã được Login chuẩn bị sẵn sau khi xác thực thành công
                Form mainForm = loginForm.LoadedDashboard;

                if (mainForm != null)
                {
                    // Đồng bộ vị trí, kích thước và trạng thái (Maximized) để hiển thị như cùng một cửa sổ duy nhất
                    mainForm.StartPosition = FormStartPosition.Manual;
                    mainForm.Location = this.Location;
                    mainForm.Size = this.Size;
                    mainForm.WindowState = this.WindowState;

                    // 3. Mở Form chính của User (Truyền 'this' làm Owner để hỗ trợ hiện lại mượt mà khi logout)
                    mainForm.ShowDialog(this);

                    // 4. Khi Form User đóng lại:
                    if (DTO_Tier.GlobalAccount.GetUserId() == 0)
                    {
                        // Đồng bộ ngược lại vị trí/trạng thái cho Guest khi quay về (nếu người dùng vừa thay đổi kích thước Form chính)
                        this.Location = mainForm.Location;
                        this.Size = mainForm.Size;
                        this.WindowState = mainForm.WindowState;

                        // Nếu đã gọi Logout -> Hiện lại màn hình Guest ngay lập tức
                        this.Show();
                    }
                    else
                    {
                        // Nếu nhấn nút X để đóng ứng dụng -> Đóng hẳn Guest để thoát chương trình hoàn toàn
                        this.Close();
                    }
                }
                else
                {
                    this.Show();
                }
            }
            else
            {
                // Nếu hủy đăng nhập hoặc nhấn nút quay lại -> Hiện lại Form Guest
                this.Show();
            }
        }

        /// Xử lý sự kiện Load Form.
        private void frmGuest_Load(object sender, EventArgs e)
        {
            _searchControl.ExecuteSearch();
        }

        public async void OpenArticleDetail(ContentDTO art)
        {
            if (art == null) return;

            ucArticleDetail detail = new ucArticleDetail();
            detail.Dock = DockStyle.Fill;
            
            // Tăng lượt xem cục bộ trước để cập nhật UI ngay lập tức
            art.ViewCount++;
            detail.SetData(art);
            pnlMainContainer.Controls.Add(detail);

            // Chuyển đổi hiệu ứng mượt mà từ màn hình Tìm kiếm sang màn hình Chi tiết bài viết
            UIHelper.SwitchControlSmoothly(pnlMainContainer, _searchControl, detail);

            // 3. Tăng view ngầm (không block UI)
            ContentBUS bus = new ContentBUS();
            await System.Threading.Tasks.Task.Run(() => bus.IncrementViewAsync(art.Id));
        }

        /// <summary>
        /// Quay trở lại màn hình danh sách tìm kiếm từ màn hình chi tiết bài viết.
        /// Tiến hành làm mới dữ liệu tìm kiếm, chuyển đổi hiệu ứng và giải phóng tài nguyên control chi tiết.
        /// </summary>
        public void BackToSearch()
        {
            // 1. Làm mới dữ liệu từ Database trước khi chuyển màn hình để cập nhật số lượt xem mới
            _searchControl.ExecuteSearch();

            // Tìm kiếm control chi tiết bài viết đang hiển thị trong container
            ucArticleDetail detail = null;
            foreach (Control ctrl in pnlMainContainer.Controls)
            {
                if (ctrl is ucArticleDetail)
                {
                    detail = (ucArticleDetail)ctrl;
                    break;
                }
            }

            // Thực hiện chuyển đổi giao diện mượt mà và giải phóng bộ nhớ của control chi tiết
            if (detail != null)
            {
                UIHelper.SwitchControlSmoothly(pnlMainContainer, detail, _searchControl);
                pnlMainContainer.Controls.Remove(detail);
                detail.Dispose();
            }

            // 2. Đưa danh sách tìm kiếm lên phía trước và hiển thị lại
            _searchControl.Visible = true;
            _searchControl.BringToFront();
        }
    }
}
