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

        // Override CreateParams để bật WS_EX_COMPOSITED, giúp giảm nhấp nháy khi vẽ lại Form
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
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
            _tabTypeMapping.Add(pnlAppointment, typeof(ucDoctor_Appointment));

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
                
                // Nếu là tab Tổng quan, nạp dữ liệu bác sĩ ngay
                if (uc is ucDoctor_Overview overview)
                {
                    int docId = GlobalAccount.GetProfileId();
                    DoctorBUS bus = new DoctorBUS();
                    var doctor = bus.GetDoctorById(docId);
                    if (doctor != null) overview.SetDoctorData(doctor);
                }

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

        public void SwitchToTab(string tabName)
        {
            Panel targetPanel = null;
            if (tabName == "Overview") targetPanel = pnlOverview;
            else if (tabName == "Appointment") targetPanel = pnlAppointment;

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
                if (uc is ucTimeSlotDialog ucApp) ucApp.OnCloseModal -= CloseModalLogic;
                this.Controls.Remove(uc);
                uc.Dispose();
                foreach (Control ctrl in pnMain.Controls) { ctrl.Enabled = true; }
            }
        }
    }
}
