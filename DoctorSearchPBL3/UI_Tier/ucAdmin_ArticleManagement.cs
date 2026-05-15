using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using BUS_Tier;
using DTO_Tier;

namespace UI_Tier
{
    public partial class ucAdmin_ArticleManagement : UserControl
    {

        public ucAdmin_ArticleManagement()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            SetupUI();
        }

        private void SetupUI()
        {
            UIHelper.ApplyRoundedRegion(btnAddArticle, 12);
            
            // Bo góc và viền cho 4 thẻ thống kê
            Panel[] cards = { pnlCard1, pnlCard2, pnlCard3, pnlCard4 };
            foreach (var card in cards)
            {
                card.Paint += (s, e) => UIHelper.DrawControlBorder(card, e, 10, Color.FromArgb(230, 230, 230), 3);
            }

            // Bo góc cho các panel icon bên trong cho đồng bộ
            UIHelper.ApplyRoundedRegion(pnlIcon1, 20);
            UIHelper.ApplyRoundedRegion(pnlIcon2, 20);
            UIHelper.ApplyRoundedRegion(pnlIcon3, 20);
            UIHelper.ApplyRoundedRegion(pnlIcon4, 20);

            // Cấu hình bộ tìm kiếm tích hợp cho Admin
            ucSearchArticle.SetAdminMode(true);   // Bật chế độ Admin (hiện lọc trạng thái)
            ucSearchArticle.SetActiveTab(false); // Luôn mở tab Bài viết
            ucSearchArticle.HideTabs();          // Ẩn tab nội bộ
            ucSearchArticle.SetPlaceholder("");  // Xóa dòng chữ mờ

            // Hook up events
            btnAddArticle.Click += btnAddArticle_Click;
        }

        private void ucAdmin_ArticleManagement_Load(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            ShowAddArticle();
        }

        private Control _activeOverlay = null;
        public void ShowAddArticle(ContentDTO art = null)
        {
            // We don't hide the detail view if we're switching to edit mode
            // This way the Edit form floats ON TOP of the detail content
            var addForm = new ucAdmin_AddArticle();
            
            if (art != null) addForm.SetData(art);

            addForm.Location = new Point(((this.Width - addForm.Width)-10) / 2, (this.Height - addForm.Height) / 2);
            
            addForm.OnCancel += (s, ev) => {
                this.Controls.Remove(addForm);
                addForm.Dispose();
            };
            
            addForm.OnSuccess += (s, ev) => {
                this.Controls.Remove(addForm);
                addForm.Dispose();
                
                // If there was a detail view underneath, we might want to refresh it or close it
                // For now, let's close the detail view too so we see the updated list
                HideOverlay(); 
                
                ucSearchArticle.ExecuteSearch(); 
                LoadStats();
            };
            
            this.Controls.Add(addForm);
            addForm.BringToFront();
        }

        public void ShowArticleDetail(ContentDTO art)
        {
            HideOverlay();
            if (art == null) return;

            var detailView = new ucArticleDetail();
            _activeOverlay = detailView;
            detailView.SetData(art);

            // Full screen mode for Admin, covering everything including header/stats
            detailView.Location = new Point(0, 0);
            detailView.Size = this.Size;
            detailView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            detailView.BackColor = Color.White;
            
            this.Controls.Add(detailView);
            detailView.BringToFront();
        }

        public void HideOverlay()
        {
            if (_activeOverlay != null)
            {
                this.Controls.Remove(_activeOverlay);
                _activeOverlay.Dispose();
                _activeOverlay = null;
            }
        }

        private void LoadStats()
        {
            ContentBUS bus = new ContentBUS();
            var stats = bus.GetArticleStats();
            
            lblValue1.Text = stats.total.ToString();
            lblValue2.Text = stats.published.ToString();
            lblValue3.Text = stats.draft.ToString();
            lblValue4.Text = stats.totalViews.ToString("N0");
        }
        public void RefreshList()
        {
            ucSearchArticle.ExecuteSearch();
            LoadStats();
        }
    }
}
