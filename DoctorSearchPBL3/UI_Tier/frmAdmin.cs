using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DTO_Tier;

namespace UI_Tier
{
    public partial class frmAdmin : Form
    {
        private Color _activeBack = Color.FromArgb(242, 247, 255);
        private Color _normalBack = Color.Transparent;
        private Color _hoverBack = Color.FromArgb(230, 242, 255);
        private Color _activeText = Color.FromArgb(0, 98, 255);
        private Color _normalText = Color.Gray;

        private Dictionary<Panel, Type> _tabTypeMapping = new Dictionary<Panel, Type>();
        private Dictionary<Panel, UserControl> _tabMapping = new Dictionary<Panel, UserControl>();
        private UserControl? _currentUC = null;

        public frmAdmin()
        {
            InitializeComponent();
            this.Opacity = 0;
            UIHelper.SetDoubleBuffered(this);
            InitTabs();
            PreLoadTabs(false, false); // CHỈ VẼ UI TAB ĐẦU TIÊN (Mở Form cực nhanh)
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }
        private void PreLoadTabs(bool loadAll = true, bool initData = false)
        {
            UIHelper.PreLoadTabs(pnMain, _tabTypeMapping, _tabMapping, pnlOverview, loadAll, (uc, pnl) => {
                if (!initData) return;
                // Admin hiện tại chưa có logic nạp dữ liệu đặc thù cho từng tab trong lúc preload
            });
        }

        private void InitTabs()
        {
            _tabTypeMapping.Add(pnlOverview, typeof(ucAdmin_Overview));
            _tabTypeMapping.Add(pnlDoctor, typeof(ucAdmin_UserManagement));
            _tabTypeMapping.Add(pnlArticles, typeof(ucAdmin_ArticleManagement));
            _tabTypeMapping.Add(pnlAppointment, typeof(ucAdmin_AppointmentManagement));
            _tabTypeMapping.Add(pnlUser, typeof(ucAdmin_DepartmentManagement));
            _tabTypeMapping.Add(pnlProfile, typeof(ucAdmin_ReviewManagement));
            _tabTypeMapping.Add(pnlAdminProfile, typeof(ucAdmin_Profile));

            foreach (var pnl in _tabTypeMapping.Keys)
            {
                pnl.Click += PanelTab_Click;
                pnl.Cursor = Cursors.Hand;
                UIHelper.SetupTabHover(pnl, _hoverBack, _activeBack, _normalBack);
                UIHelper.ApplyRoundedRegion(pnl, 15); // Bo góc cho tab
                foreach (Control child in pnl.Controls)
                {
                    child.Click += PanelTab_Click;
                    child.Cursor = Cursors.Hand;
                }
            }
            this.Load += frmAdmin_Load;
        }

        private void PanelTab_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Panel clickedPanel = (ctrl is Panel) ? (Panel)ctrl : (Panel)ctrl.Parent;

            if (clickedPanel == null || !_tabTypeMapping.ContainsKey(clickedPanel)) return;

            // Lấy UC đã được vẽ sẵn trong RAM
            if (!_tabMapping.ContainsKey(clickedPanel)) return;

            UserControl selectedUC = _tabMapping[clickedPanel];
            if (_currentUC == selectedUC) return;

            UIHelper.SwitchControlSmoothly(pnMain, _currentUC, selectedUC);
            _currentUC = selectedUC;

            UpdateLabelStyles(clickedPanel);
        }

        public UserControl? GetCurrentUC() => _currentUC;

        private void UpdateLabelStyles(Panel activePanel)
        {
            foreach (var panel in _tabTypeMapping.Keys)
            {
                bool isActive = (panel == activePanel);
                panel.BackColor = isActive ? _activeBack : _normalBack;

                foreach (Control child in panel.Controls)
                {
                    if (child is Label label)
                    {
                        label.ForeColor = isActive ? _activeText : _normalText;
                    }
                }
            }
        }

        private async void frmAdmin_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Chào mừng, {GlobalAccount.GetFullName()}!";
            UIHelper.ApplyRoundedRegion(btnLogout, 20);

            // 1. CHỈ nạp Tab Tổng quan (Priority) để mở Form nhanh nhất
            PreLoadTabs(false, true);
            PanelTab_Click(pnlOverview, EventArgs.Empty);
            
            this.Update(); // Vẽ xong rồi mới hiện

            // 2. Ẩn Guest (Owner) và hiện mình lên ngay lập tức
            if (this.Owner != null) this.Owner.Hide();
            this.Opacity = 1;

            // 3. ÂM THẦM nạp toàn bộ các tab còn lại vào RAM trong lúc người dùng đang xem Tổng quan
            // Việc nạp này diễn ra từng bước (Staggered) để không làm đơ giao diện
            await UIHelper.BackgroundPreLoadTabs(pnMain, _tabTypeMapping, _tabMapping, pnlOverview, (uc, pnl) => {
                // Admin hiện tại chưa cần init data đặc thù lúc preload
            }); 
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Sử dụng Helper để hiện lại Guest mượt mà, không bị lộ desktop
            UIHelper.LogoutAndCleanup(this, _tabMapping);
        }

        public void OpenArticleDetail(ContentDTO art)
        {
            // If we are on the Article Management tab, show detail in its overlay
            if (_currentUC is ucAdmin_ArticleManagement artMgmt)
            {
                artMgmt.ShowArticleDetail(art);
            }
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
