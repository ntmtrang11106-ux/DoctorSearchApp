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
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlMainContainer);
            UIHelper.ApplyRoundedRegion(btnLogin, 15);
            btnLogin.Cursor = Cursors.Hand;
            
            this.Opacity = 0;
            _searchControl = new ucGuest_IntegratedSearch();
            _searchControl.Dock = DockStyle.Fill;
            pnlMainContainer.Controls.Add(_searchControl);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED (0x02000000)
                return cp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            if (loginForm.ShowDialog(this) == DialogResult.OK)
            {
                // 1. Lấy Dashboard đã được Login chuẩn bị sẵn
                Form mainForm = loginForm.LoadedDashboard;

                if (mainForm != null)
                {
                    // 2. Không ẩn Guest vội ở đây (để Dashboard tự ẩn Guest sau khi đã vẽ xong UI)
                    // Việc này giúp tránh bị hở màn hình máy tính (Desktop) lúc chuyển tiếp

                    // 3. Mở Form User (Sử dụng 'this' làm Owner để dễ quản lý)
                    mainForm.ShowDialog(this);

                    // 4. Khi Form User đóng lại:
                    if (DTO_Tier.GlobalAccount.GetUserId() == 0)
                    {
                        // Nếu đã gọi Logout -> Hiện lại Guest ngay lập tức
                        this.Show();
                    }
                    else
                    {
                        // Nếu nhấn nút X -> Đóng hẳn Guest để thoát App
                        this.Close();
                    }
                }
            }
        }

        private async void frmGuest_Load(object sender, EventArgs e)
        {
            _searchControl.ExecuteSearch();
            this.Update(); // Vẽ xong hết rồi mới bắt đầu FadeIn
            await UIHelper.FadeInForm(this, 10);
        }

        public async void OpenArticleDetail(ContentDTO art)
        {
            if (art == null) return;

            ucArticleDetail detail = new ucArticleDetail();
            detail.Dock = DockStyle.Fill;
            detail.SetData(art);
            pnlMainContainer.Controls.Add(detail);

            UIHelper.SwitchControlSmoothly(pnlMainContainer, _searchControl, detail);

            // 3. Tăng view ngầm (không block UI)
            ContentBUS bus = new ContentBUS();
            await System.Threading.Tasks.Task.Run(() => bus.IncrementViewAsync(art.Id));
        }

        public void BackToSearch()
        {
            ucArticleDetail detail = null;
            foreach (Control ctrl in pnlMainContainer.Controls)
            {
                if (ctrl is ucArticleDetail)
                {
                    detail = (ucArticleDetail)ctrl;
                    break;
                }
            }

            if (detail != null)
            {
                UIHelper.SwitchControlSmoothly(pnlMainContainer, detail, _searchControl);
                pnlMainContainer.Controls.Remove(detail);
                detail.Dispose();
            }

            // 2. Hiện lại danh sách tìm kiếm và làm mới
            _searchControl.Visible = true;
            _searchControl.BringToFront();
            _searchControl.ExecuteSearch();
        }
    }
}
