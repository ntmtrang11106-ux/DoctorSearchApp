using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BUS_Tier;
using DTO_Tier;
using System.Runtime.InteropServices;
using System.Linq;

namespace UI_Tier
{
    public partial class ucAdmin_UserManagement : UserControl
    {
        private AdminBUS _adminBUS = new AdminBUS();
        private string _currentTab = "All"; // "All", "Pending", "Patient", "Doctor"
        private string _currentStatus = StatusAll; // StatusAll, StatusActive, StatusPending, StatusBlocked
        private int _pageSize = 6;
        private int _currentPage = 1;
        private int _totalItems = 0;

        private const int EM_SETCUEBANNER = 0x1501;
        private const string StatusAll = "Tất cả trạng thái";
        private const string StatusActive = "Hoạt động";
        private const string StatusPending = "Chờ duyệt";
        private const string StatusBlocked = "Bị khóa";

        public ucAdmin_UserManagement()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            //UIHelper.SetDoubleBuffered(pnlMain);
            UIHelper.SetupScrollableContainer(flpUserList);
            UIHelper.SetDoubleBuffered(pnlSearch);
            
            flpUserList.Resize += (s, e) => {
                foreach (Control ctrl in flpUserList.Controls)
                {
                    ctrl.Width = flpUserList.ClientSize.Width - 10;
                }
            };

            // Hiệu ứng hover cho các nút phân trang sử dụng Helper
            UIHelper.SetupHoverEffect(lblPrev, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));
            UIHelper.SetupHoverEffect(lblNext, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));

            pnlSearch.Paint += pnlSearch_Paint;
            pnlSearch.Click += (s, e) => txtSearch.Focus();
            lblSearchIcon.Click += (s, e) => txtSearch.Focus();
        }

        private void pnlSearch_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 15, Color.FromArgb(203, 213, 225), 2);
        }



        private void ucAdmin_UserManagement_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(pnlSearch, 15);
            // Hiệu ứng Focus cho thanh tìm kiếm
            UIHelper.SetupInputFocusEffect(txtSearch, pnlSearch, Color.White, Color.White, Color.FromArgb(59, 130, 246));
            UIHelper.RegisterClickToUnfocus(this, lblTitle);
            
            ConfigureStatusFilter();
            LoadData();

            UIHelper.SetupSearchTextBox(txtSearch, "Tìm kiếm theo tên, SĐT...");
            
            this.ActiveControl = lblTitle;
        }


        private void LoadData()
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Tìm kiếm theo tên, SĐT...") keyword = "";
            string status = cboStatusFilter.SelectedItem?.ToString() ?? StatusAll;
            
            string searchRole = GetSearchRoleForCurrentTab();
            var counterUsers = _adminBUS.SearchUsers(keyword, "Tất cả");
            var allUsers = _adminBUS.SearchUsers(keyword, searchRole);
            
            // Get pending doctors for the alert subtitle and for "Pending" status filter
            var pendingDocs = _adminBUS.GetPendingDoctors();
            if (!string.IsNullOrEmpty(keyword))
            {
                pendingDocs = pendingDocs.Where(d => 
                    d.User.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) || 
                    d.User.PhoneNumber.Contains(keyword)
                ).ToList();
            }

            // Update UI Counters
            int totalAll = counterUsers.Count;
            int totalPatients = counterUsers.Count(u => u.Role == "Patient");
            int totalDoctors = counterUsers.Count(u => u.Role == "Doctor");

            btnAllUsers.Text = $"Tất cả ({totalAll})";
            btnPatients.Text = $"Bệnh nhân ({totalPatients})";
            btnDoctors.Text = $"Bác sĩ ({totalDoctors})";

            LayoutTabButtons();

            // Update Subtitle Alert
            if (pendingDocs.Count > 0)
            {
                lblSubtitle.Text = $"⚠️ Có {pendingDocs.Count} bác sĩ đang chờ phê duyệt";
                lblSubtitle.Visible = true;
            }
            else
            {
                lblSubtitle.Visible = false;
            }

            // Apply Status Filter
            IEnumerable<UserDTO> filteredList = allUsers;
            if (status == StatusPending)
            {
                var pendingUserIds = new HashSet<int>(pendingDocs.Select(d => d.UserId));
                filteredList = allUsers.Where(u => pendingUserIds.Contains(u.Id));
            }
            else if (status == StatusActive)
            {
                filteredList = allUsers.Where(u => u.Status == "Active");
            }
            else if (status == StatusBlocked)
            {
                filteredList = allUsers.Where(u => u.Status == "Blocked");
            }


            // Apply Tab Filter
            if (_currentTab == "Patient")
            {
                filteredList = filteredList.Where(u => u.Role == "Patient");
            }
            else if (_currentTab == "Doctor")
            {
                filteredList = filteredList.Where(u => u.Role == "Doctor");
            }
            // else if (_currentTab == "Pending") // Handle legacy tab if needed
            // {
            //     var pendingUserIds = new HashSet<int>(pendingDocs.Select(d => d.UserId));
            //     filteredList = filteredList.Where(u => pendingUserIds.Contains(u.Id));
            // }

            var finalUserList = filteredList.ToList();
            _totalItems = finalUserList.Count;

            // Pagination Slicing
            int totalPages = Math.Max(1, (int)Math.Ceiling((double)_totalItems / _pageSize));
            if (_currentPage > totalPages) _currentPage = totalPages;
            int startIndex = (_currentPage - 1) * _pageSize;

            flpUserList.SuspendLayout();
            flpUserList.Controls.Clear();

            int itemWidth = flpUserList.ClientSize.Width;
            if (itemWidth < 1000) itemWidth = 1600; 
            itemWidth -= 40; 

            var pageItems = finalUserList.Skip(startIndex).Take(_pageSize).ToList();
            foreach (var user in pageItems)
            {
                ucAdmin_UserItem item = new ucAdmin_UserItem();
                item.Width = itemWidth;
                
                // If it's a doctor, we might want to load the DoctorDTO for detail view
                if (user.Role == "Doctor")
                {
                    var doc = _adminBUS.GetDoctorByUserId(user.Id);
                    if (doc != null) item.SetDoctorData(doc);
                    else item.SetUserData(user);
                }
                else
                {
                    item.SetUserData(user);
                }

                item.DataChanged += (s, ev) => LoadData();
                flpUserList.Controls.Add(item);
            }

            flpUserList.ResumeLayout();

            lblPageStatus.Text = $"Trang {_currentPage} / {totalPages}";
            
            // Luôn để Enabled = true để bắt hover
            lblPrev.Enabled = true;
            lblNext.Enabled = true;
            lblPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblNext.ForeColor = Color.FromArgb(0, 120, 212);

            flpUserList.AutoScrollPosition = new Point(0, 0);
        }

        private void btnAllUsers_Click(object sender, EventArgs e)
        {
            _currentTab = "All";
            ConfigureStatusFilter();
            SetActiveTab(btnAllUsers);
            _currentPage = 1;
            LoadData();
        }

        private void btnPendingDoctors_Click(object sender, EventArgs e)
        {
            _currentTab = "Pending";
            SetActiveTab(btnPendingDoctors);
            _currentPage = 1;
            LoadData();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            _currentTab = "Patient";
            ConfigureStatusFilter();
            SetActiveTab(btnPatients);
            _currentPage = 1;
            LoadData();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            _currentTab = "Doctor";
            ConfigureStatusFilter();
            SetActiveTab(btnDoctors);
            _currentPage = 1;
            LoadData();
        }

        private void ConfigureStatusFilter()
        {
            cboStatusFilter.SelectedIndexChanged -= cboStatusFilter_SelectedIndexChanged;
            cboStatusFilter.Items.Clear();
            if (_currentTab == "Patient")
            {
                cboStatusFilter.Items.AddRange(new object[] { StatusAll, StatusActive, StatusBlocked });
            }
            else
            {
                cboStatusFilter.Items.AddRange(new object[] { StatusAll, StatusActive, StatusPending, StatusBlocked });
            }

            if (string.IsNullOrWhiteSpace(_currentStatus) || !cboStatusFilter.Items.Contains(_currentStatus))
            {
                _currentStatus = StatusAll;
            }

            cboStatusFilter.SelectedItem = _currentStatus;
            if (cboStatusFilter.SelectedIndex < 0)
            {
                cboStatusFilter.SelectedIndex = 0;
            }

            _currentStatus = cboStatusFilter.SelectedItem?.ToString() ?? StatusAll;
            cboStatusFilter.SelectedIndexChanged += cboStatusFilter_SelectedIndexChanged;
        }

        private void LayoutTabButtons()
        {
            Button[] btns = { btnAllUsers, btnPatients, btnDoctors };
            int left = 0;

            foreach (var btn in btns)
            {
                int width = TextRenderer.MeasureText(btn.Text, btn.Font).Width + 42;
                btn.Width = Math.Max(width, 160);
                btn.Left = left;
                left += btn.Width + 14;
            }

            SetActiveTab(GetActiveTabButton());
        }

        private Button GetActiveTabButton()
        {
            return _currentTab switch
            {
                "Patient" => btnPatients,
                "Doctor" => btnDoctors,
                _ => btnAllUsers
            };
        }

        private string GetSearchRoleForCurrentTab()
        {
            return _currentTab switch
            {
                "Patient" => "Patient",
                "Doctor" => "Doctor",
                _ => "Tất cả"
            };
        }

        private void SetActiveTab(Button activeBtn)
        {
            Button[] btns = { btnAllUsers, btnPatients, btnDoctors };
            foreach (var btn in btns)
            {
                if (btn != null)
                {
                    btn.ForeColor = Color.FromArgb(75, 85, 99);
                }
            }
            if (activeBtn != null)
            {
                activeBtn.ForeColor = Color.FromArgb(59, 130, 246);
                
                // Move indicator
                pnlTabIndicator.Width = activeBtn.Width;
                pnlTabIndicator.Left = activeBtn.Left;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _currentPage = 1;
            LoadData();
        }

        private void cboStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentStatus = cboStatusFilter.SelectedItem.ToString();
            _currentPage = 1;
            LoadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // Logic to open Add User form/control
            MessageBox.Show("Chức năng thêm người dùng đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void lblPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadData();
            }
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_totalItems / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                LoadData();
            }
        }

        public void ShowOverlay(UserControl uc)
        {
            uc.Location = new Point((this.Width - uc.Width) / 2, Math.Max(20, (this.Height - uc.Height) / 2));
            this.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
