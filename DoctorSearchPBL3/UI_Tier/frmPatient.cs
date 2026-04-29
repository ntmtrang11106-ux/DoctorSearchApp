using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class frmPatient : Form
    {
        public frmPatient()
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

        #region Xử lí các click trên menu

        // Khai báo ở cấp độ Class
        private Color _activeBack = Color.FromArgb(206, 225, 255); // Màu xanh nhạt
        private Color _normalBack = Color.Transparent;
        private Color _activeText = Color.FromArgb(0, 98, 255); // Màu xanh đậm
        private Color _normalText = SystemColors.ControlDarkDark;

        // 1. Dictionary bây giờ chỉ lưu Type để biết cần tạo UC nào (Lazy Loading)
        private Dictionary<Panel, Type> _tabTypeMapping = new Dictionary<Panel, Type>();
        private Dictionary<Panel, UserControl> _tabMapping = new Dictionary<Panel, UserControl>();
        private UserControl _currentUC = null; // Để quản lý UC đang hiển thị

        private void InitTabs()
        {
            // Chỉ đăng ký Type, chưa "new" cái nào hết -> App mở lên cực nhanh!
            _tabTypeMapping.Add(pnlHome, typeof(ucPatient_Article));
            //_tabTypeMapping.Add(pnlSearchDoc, typeof(ucPatient_SearchDoc));
            _tabTypeMapping.Add(pnlAppointment, typeof(ucPatient_Appointment));
            _tabTypeMapping.Add(pnlChat, typeof(ucPatient_Chat));
            _tabTypeMapping.Add(pnlProfile, typeof(ucPatient_Profile));

            foreach (var pnl in _tabTypeMapping.Keys)
            {
                pnl.Click += PanelTab_Click;
                foreach (Control child in pnl.Controls)
                {
                    if (child is Label) child.Click += PanelTab_Click;
                }
            }
        }

        private void PanelTab_Click(object sender, EventArgs e)
        {
            // FIX LỖI CLICK: Tìm ra Panel cha dù bà bấm vào Label hay Panel
            Control ctrl = sender as Control;
            Panel clickedPanel = (ctrl is Panel) ? (Panel)ctrl : (Panel)ctrl.Parent;

            if (clickedPanel == null || !_tabTypeMapping.ContainsKey(clickedPanel)) return;

            // 2. LAZY LOADING: Nếu chưa có Instance thì mới khởi tạo
            if (!_tabMapping.ContainsKey(clickedPanel))
            {
                // Dùng Reflection để tạo instance từ Type (đúng chất dân kỹ thuật)
                UserControl uc = (UserControl)Activator.CreateInstance(_tabTypeMapping[clickedPanel]);
                uc.Dock = DockStyle.Fill;
                uc.Visible = false;
                pnMain.Controls.Add(uc);
                _tabMapping.Add(clickedPanel, uc);
            }

            UserControl selectedUC = _tabMapping[clickedPanel];
            if (_currentUC == selectedUC) return;

            // 3. Hiển thị
            if (_currentUC != null) _currentUC.Visible = false;
            selectedUC.Visible = true;
            selectedUC.BringToFront();
            _currentUC = selectedUC;

            UpdateLabelStyles(clickedPanel);
        }

        private void UpdateLabelStyles(Panel activePanel)
        {
            foreach (var panel in _tabMapping.Keys)
            {
                if (panel == activePanel)
                {
                    panel.BackColor = _activeBack;
                    foreach (Control child in panel.Controls)
                    {
                        if (child is Label label)
                        {
                            label.ForeColor = _activeText;
                        }
                    }
                }
                else
                {
                    panel.BackColor = _normalBack;
                    foreach (Control child in panel.Controls)
                    {
                        if (child is Label label)
                        {
                            label.ForeColor = _normalText;
                        }
                    }
                }
            }
        }
        #endregion

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(btnLogout, 15);
            UIHelper.ApplyRoundedRegion(pnlHome, 20);
            UIHelper.ApplyRoundedRegion(pnlAppointment, 20);
            UIHelper.ApplyRoundedRegion(pnlSearchDoc, 20);
            UIHelper.ApplyRoundedRegion(pnlChat, 20);
            UIHelper.ApplyRoundedRegion(pnlProfile, 20);

            // Khởi tạo các tab và sự kiện click
            InitTabs();
            PanelTab_Click(pnlHome, EventArgs.Empty);
        }
    }
}
