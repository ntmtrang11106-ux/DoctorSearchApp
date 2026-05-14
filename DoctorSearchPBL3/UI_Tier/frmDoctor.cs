using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class frmDoctor : Form
    {
        public frmDoctor()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
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

        #region Xử lý các click trên menu (Tabs)

        private Color _activeBack = Color.FromArgb(206, 225, 255); // Màu xanh nhạt
        private Color _normalBack = Color.Transparent;
        private Color _activeText = Color.FromArgb(0, 98, 255); // Màu xanh đậm
        private Color _normalText = SystemColors.ControlDarkDark;

        private Dictionary<Panel, Type> _tabTypeMapping = new Dictionary<Panel, Type>();
        private Dictionary<Panel, UserControl> _tabMapping = new Dictionary<Panel, UserControl>();
        private UserControl _currentUC = null;

        private void InitTabs()
        {
            _tabTypeMapping.Add(pnlOverview, typeof(ucDoctor_Overview));
            _tabTypeMapping.Add(pnlArticle, typeof(ucGuest_IntegratedSearch));
            _tabTypeMapping.Add(pnlAppointment, typeof(ucDoctor_Appointment));
            _tabTypeMapping.Add(pnlChat, typeof(ucPatient_Chat));
            _tabTypeMapping.Add(pnlProfile, typeof(ucDoctor_Profile));

            foreach (var pnl in _tabTypeMapping.Keys)
            {
                pnl.Click += PanelTab_Click;
                pnl.Cursor = Cursors.Hand;
                foreach (Control child in pnl.Controls)
                {
                    child.Click += PanelTab_Click;
                    child.Cursor = Cursors.Hand;
                }
            }
        }

        private void PanelTab_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Panel clickedPanel = (ctrl is Panel) ? (Panel)ctrl : (Panel)ctrl.Parent;

            if (clickedPanel == null || !_tabTypeMapping.ContainsKey(clickedPanel)) return;

            if (!_tabMapping.ContainsKey(clickedPanel))
            {
                UserControl uc = (UserControl)Activator.CreateInstance(_tabTypeMapping[clickedPanel]);
                
                // Cấu hình ban đầu cho UC
                if (uc is ucDoctor_Overview overview)
                {
                    int docId = GlobalAccount.GetProfileId();
                    DoctorBUS bus = new DoctorBUS();
                    var doctor = bus.GetDoctorById(docId);
                    if (doctor != null) overview.SetDoctorData(doctor);
                }
                else if (uc is ucDoctor_Appointment appointment)
                {
                    int docId = GlobalAccount.GetProfileId();
                    appointment.SetDoctorId(docId);
                }

                uc.Dock = DockStyle.Fill;
                uc.Visible = false;
                pnMain.Controls.Add(uc);
                _tabMapping.Add(clickedPanel, uc);
            }

            UserControl selectedUC = _tabMapping[clickedPanel];

            // Cấu hình nếu là bộ tìm kiếm tích hợp
            if (selectedUC is ucGuest_IntegratedSearch search)
            {
                search.HideTabs(); // Ẩn tab nội bộ
                search.SetActiveTab(false); // Luôn hiện tab Bài viết cho trang này
                search.SetPlaceholder(""); // Xóa dòng chữ "Nhập tên bác sĩ hoặc bài viết..."
            }

            if (_currentUC == selectedUC && selectedUC is not ucGuest_IntegratedSearch) return;

            if (_currentUC != null) _currentUC.Visible = false;
            selectedUC.Visible = true;
            selectedUC.BringToFront();
            _currentUC = selectedUC;

            UpdateLabelStyles(clickedPanel);
        }

        public void SwitchToTab(string tabName)
        {
            Panel targetPanel = null;
            if (tabName == "Overview") targetPanel = pnlOverview;
            else if (tabName == "Article") targetPanel = pnlArticle;
            else if (tabName == "Appointment") targetPanel = pnlAppointment;
            else if (tabName == "Chat") targetPanel = pnlChat;
            else if (tabName == "Profile") targetPanel = pnlProfile;

            if (targetPanel != null)
            {
                PanelTab_Click(targetPanel, EventArgs.Empty);
            }
        }

        private void UpdateLabelStyles(Panel activePanel)
        {
            foreach (var panel in _tabTypeMapping.Keys)
            {
                if (panel == activePanel)
                {
                    panel.BackColor = _activeBack;
                    foreach (Control child in panel.Controls)
                    {
                        if (child is Label label) label.ForeColor = _activeText;
                    }
                }
                else
                {
                    panel.BackColor = _normalBack;
                    foreach (Control child in panel.Controls)
                    {
                        if (child is Label label) label.ForeColor = _normalText;
                    }
                }
            }
        }
        #endregion

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DTO_Tier.GlobalAccount.Logout();
            this.Close();
        }

        private void frmDoctor_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(btnLogout, 15);
            UIHelper.ApplyRoundedRegion(pnlOverview, 20);
            UIHelper.ApplyRoundedRegion(pnlAppointment, 20);

            InitTabs();
            PanelTab_Click(pnlOverview, EventArgs.Empty); // Mặc định mở Tổng quan
        }

        public void ShowOverlay(UserControl ucDialog)
        {
            foreach (Control ctrl in pnMain.Controls) { ctrl.Enabled = false; }

            if (ucDialog is ucTimeSlotDialog dialog)
            {
                dialog.OnCloseModal += CloseModalLogic;
            }

            ucDialog.Name = "ucDialog";
            ucDialog.Location = new Point(
                (this.ClientSize.Width - ucDialog.Width) / 2,
                (this.ClientSize.Height - ucDialog.Height) / 2
            );
            ucDialog.Anchor = AnchorStyles.None;

            this.Controls.Add(ucDialog);
            ucDialog.BringToFront();
        }

        private void CloseModalLogic(object sender, EventArgs e)
        {
            UserControl uc = sender as UserControl;
            if (uc != null)
            {
                if (uc is ucTimeSlotDialog ucTS) ucTS.OnCloseModal -= CloseModalLogic;
                
                this.Controls.Remove(uc);
                uc.Dispose();
                
                // Re-enable all panels in pnMain
                foreach (Control ctrl in pnMain.Controls) { ctrl.Enabled = true; }
            }
        }
        public async void OpenArticleDetail(ContentDTO art)
        {
            try
            {
                if (art == null) return;

                // 1. Hide current UC
                if (_currentUC != null) _currentUC.Visible = false;

                ucArticleDetail detail = new ucArticleDetail();
                detail.Dock = DockStyle.Fill;

                // Increase virtual view count for immediate feedback
                art.ViewCount++;
                detail.SetData(art);

                pnMain.Controls.Add(detail);
                detail.BringToFront();

                // 2. Background update for view count
                ContentBUS bus = new ContentBUS();
                await Task.Run(() => bus.IncrementViewAsync(art.Id));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening article detail: " + ex.Message);
                if (pnMain.Controls.Count == 0 && _currentUC != null) _currentUC.Visible = true;
            }
        }

        public void BackToArticleList()
        {
            // 1. Find and remove Article Detail UC
            ucArticleDetail currentArt = null;
            foreach (Control ctrl in pnMain.Controls)
            {
                if (ctrl is ucArticleDetail)
                {
                    currentArt = (ucArticleDetail)ctrl;
                    break;
                }
            }

            if (currentArt != null)
            {
                pnMain.Controls.Remove(currentArt);
                currentArt.Dispose();
            }

            // 2. Show Article List tab
            if (_tabMapping.ContainsKey(pnlArticle))
            {
                _currentUC = _tabMapping[pnlArticle];
                
                if (_currentUC is ucGuest_IntegratedSearch search)
                {
                    search.ExecuteSearch();
                }

                _currentUC.Visible = true;
                _currentUC.BringToFront();
                UpdateLabelStyles(pnlArticle);
            }
        }
    }
}
