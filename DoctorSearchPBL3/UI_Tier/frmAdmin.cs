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
        private UserControl _currentUC = null;

        public frmAdmin()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            InitTabs();
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

            if (!_tabMapping.ContainsKey(clickedPanel))
            {
                UserControl uc = (UserControl)Activator.CreateInstance(_tabTypeMapping[clickedPanel]);
                uc.Dock = DockStyle.Fill;
                uc.Visible = false;
                pnMain.Controls.Add(uc);
                _tabMapping.Add(clickedPanel, uc);
            }

            UserControl selectedUC = _tabMapping[clickedPanel];
            if (_currentUC == selectedUC) return;

            if (_currentUC != null) _currentUC.Visible = false;
            selectedUC.Visible = true;
            selectedUC.BringToFront();
            _currentUC = selectedUC;

            UpdateLabelStyles(clickedPanel);
        }

        public UserControl GetCurrentUC() => _currentUC;

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

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Chào mừng, {GlobalAccount.GetFullName()}!";
            UIHelper.ApplyRoundedRegion(btnLogout, 20);
            PanelTab_Click(pnlOverview, EventArgs.Empty);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DTO_Tier.GlobalAccount.Logout();
            this.Close();
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
