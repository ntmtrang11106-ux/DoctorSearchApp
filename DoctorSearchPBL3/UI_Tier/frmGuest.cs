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
            UIHelper.ApplyRoundedRegion(btnLogin, 15);
            btnLogin.Cursor = Cursors.Hand;
            
            _searchControl = new ucGuest_IntegratedSearch();
            _searchControl.Dock = DockStyle.Fill;
            pnlMainContainer.Controls.Add(_searchControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            this.Hide();
            loginForm.ShowDialog();
            this.Show();
        }

        private void frmGuest_Load(object sender, EventArgs e)
        {
            _searchControl.ExecuteSearch();
        }

        public async void OpenArticleDetail(ContentDTO art)
        {
            if (art == null) return;

            // 1. Ẩn danh sách tìm kiếm
            _searchControl.Visible = false;

            // 2. Tạo UC Chi tiết bài viết
            ucArticleDetail detail = new ucArticleDetail();
            detail.Dock = DockStyle.Fill;
            detail.SetData(art);

            pnlMainContainer.Controls.Add(detail);
            detail.BringToFront();

            // 3. Tăng view ngầm (không block UI)
            ContentBUS bus = new ContentBUS();
            await System.Threading.Tasks.Task.Run(() => bus.IncrementViewAsync(art.Id));
        }

        public void BackToSearch()
        {
            // 1. Tìm và xóa UC Chi tiết bài viết
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
