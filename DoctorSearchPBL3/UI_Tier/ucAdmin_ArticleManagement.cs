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
            
            // Initialize search article control
            ucSearchArticle.SetAdminMode(true);
            ucSearchArticle.InitData();

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

            addForm.Location = new Point((this.Width - addForm.Width) / 2, (this.Height - addForm.Height) / 2);
            
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
                
                ucSearchArticle.InitData(); 
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
            ucSearchArticle.InitData();
            LoadStats();
        }
    }
}
