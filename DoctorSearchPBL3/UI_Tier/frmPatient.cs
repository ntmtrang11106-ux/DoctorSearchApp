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
            // Cả Trang chủ và Tìm bác sĩ đều dùng chung bộ Tìm kiếm tích hợp
            _tabTypeMapping.Add(pnlHome, typeof(ucGuest_IntegratedSearch));
            _tabTypeMapping.Add(pnlSearchDoc, typeof(ucGuest_IntegratedSearch));
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
            Control ctrl = sender as Control;
            Panel clickedPanel = (ctrl is Panel) ? (Panel)ctrl : (Panel)ctrl.Parent;

            if (clickedPanel == null || !_tabTypeMapping.ContainsKey(clickedPanel)) return;

            // 2. LAZY LOADING
            if (!_tabMapping.ContainsKey(clickedPanel))
            {
                UserControl uc = (UserControl)Activator.CreateInstance(_tabTypeMapping[clickedPanel]);
                uc.Dock = DockStyle.Fill;
                uc.Visible = false;
                pnMain.Controls.Add(uc);
                _tabMapping.Add(clickedPanel, uc);
            }

            UserControl selectedUC = _tabMapping[clickedPanel];
            
            // Cấu hình Tab mặc định nếu là bộ tìm kiếm (Mỗi bên giữ trạng thái riêng)
            if (selectedUC is ucGuest_IntegratedSearch search)
            {
                search.HideTabs(); // Ẩn tab nội bộ vì Patient đã có menu ngoài
                search.SetActiveTab(clickedPanel == pnlSearchDoc);
            }
            // Tự động làm mới dữ liệu nếu là tab Lịch hẹn hoặc Hồ sơ
            else if (selectedUC is ucPatient_Appointment appointment)
            {
                appointment.InitData();
            }
            else if (selectedUC is ucPatient_Profile profile)
            {
                profile.InitData();
            }

            if (_currentUC == selectedUC && selectedUC is not ucGuest_IntegratedSearch) return;

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

        public void OpenDoctorProfile(DoctorDTO doctor)
        {
            try
            {
                if (doctor == null) return;

                // 1. Ẩn UC hiện tại (SearchDoc) để giữ lại kết quả tìm kiếm cũ
                if (_currentUC != null)
                {
                    _currentUC.Visible = false;
                }

                // 2. Khởi tạo UC Profile mới
                ucPatient_DocProfile profile = new ucPatient_DocProfile();
                profile.Dock = DockStyle.Fill;

                // 3. Nạp dữ liệu (Bao bọc an toàn trong SetDoctorData của UC nếu cần)
                profile.SetDoctorData(doctor);

                // 4. Hiển thị lên Panel chính
                pnMain.Controls.Add(profile);
                profile.BringToFront();
                profile.Visible = true;
            }
            catch (Exception ex)
            {
                // Nếu lỗi, hiện thông báo cho user và không làm đứng app
                MessageBox.Show("Không thể hiển thị thông tin bác sĩ. Vui lòng thử lại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Lỗi OpenDoctorProfile: " + ex.Message);

                // Hiện lại thằng cũ nếu thằng mới lỗi
                if (_currentUC != null) _currentUC.Visible = true;
            }
        }

        public void BackToDoctorList()
        {
            // 1. Tìm và tiêu diệt thằng Profile đang hiện
            ucPatient_DocProfile currentProfile = null;
            foreach (Control ctrl in pnMain.Controls)
            {
                if (ctrl is ucPatient_DocProfile)
                {
                    currentProfile = (ucPatient_DocProfile)ctrl;
                    break;
                }
            }

            if (currentProfile != null)
            {
                pnMain.Controls.Remove(currentProfile);
                currentProfile.Dispose();
            }

            // 2. Hiện lại thằng SearchDoc (vốn đã được cache trong Dictionary hoặc biến _currentUC)
            // Giả sử cái SearchDoc của bác đang được lưu trong _tabMapping[pnlSearchDoc]
            if (_tabMapping.ContainsKey(pnlSearchDoc))
            {
                _currentUC = _tabMapping[pnlSearchDoc];
                _currentUC.Visible = true;
                _currentUC.BringToFront();

                // Cập nhật lại màu sắc Menu cho chuẩn
                UpdateLabelStyles(pnlSearchDoc);
            }
        }

        public async void OpenArticleDetail(ContentDTO art)
        {
            try
            {
                if (art == null) return;

                // 1. Hiển thị trang chi tiết NGAY LẬP TỨC
                // Ẩn danh sách bài viết hiện tại thay vì Clear
                if (_currentUC != null) _currentUC.Visible = false;

                ucArticleDetail detail = new ucArticleDetail();
                detail.Dock = DockStyle.Fill;

                // Tăng View ảo trong bộ nhớ để user thấy số view nhảy luôn (tăng trải nghiệm)
                art.ViewCount++;
                detail.SetData(art);

                pnMain.Controls.Add(detail);
                detail.BringToFront();

                // 2. Cập nhật Database ngầm (Sử dụng Task để không block UI)
                // Lưu ý: ContentBUS của bác phải có hàm Async tương ứng
                ContentBUS bus = new ContentBUS();

                // Chạy ngầm việc tăng view trên server
                await Task.Run(() => bus.IncrementViewAsync(art.Id));
            }
            catch (Exception ex)
            {
                // Với bài viết, lỗi tăng view ngầm thì kệ nó, đừng hiện Popup làm phiền người đọc
                Console.WriteLine("Lỗi ngầm khi xử lý bài viết: " + ex.Message);

                // Nếu lỗi ngay từ lúc mở trang thì mới báo
                if (pnMain.Controls.Count == 0 && _currentUC != null) _currentUC.Visible = true;
            }
        }
        public void BackToHome()
        {
            // 1. Tìm và tiêu diệt thằng Profile đang hiện
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

            // 2. Hiện lại thằng Home và làm mới dữ liệu
            if (_tabMapping.ContainsKey(pnlHome))
            {
                _currentUC = _tabMapping[pnlHome];
                
                // Ép kiểu để gọi hàm InitData làm mới lượt xem
                if (_currentUC is ucGuest_IntegratedSearch search)
                {
                    search.ExecuteSearch();
                }

                _currentUC.Visible = true;
                _currentUC.BringToFront();

                // Cập nhật lại màu sắc Menu cho chuẩn
                UpdateLabelStyles(pnlHome);
            }
        }
    }
}
