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
        private string _currentStatus = "Tất cả"; // "Tất cả", "Hoạt động", "Bị khóa"
        private int _pageSize = 6;
        private int _currentPage = 1;
        private int _totalItems = 0;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public ucAdmin_UserManagement()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(flpUserList);
            flpUserList.Resize += (s, e) => {
                foreach (Control ctrl in flpUserList.Controls)
                {
                    ctrl.Width = flpUserList.ClientSize.Width - 10;
                }
            };

            // Hiệu ứng hover cho các nút phân trang
            lblPrev.MouseEnter += PaginationLabel_MouseEnter;
            lblPrev.MouseLeave += PaginationLabel_MouseLeave;
            lblNext.MouseEnter += PaginationLabel_MouseEnter;
            lblNext.MouseLeave += PaginationLabel_MouseLeave;
            lblPrev.Cursor = Cursors.Hand;
            lblNext.Cursor = Cursors.Hand;
        }

        private void PaginationLabel_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(0, 90, 158); // Xanh đậm hơn khi hover
                lbl.Top -= 2; // Hiệu ứng "nhảy lên"
            }
        }

        private void PaginationLabel_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(0, 120, 212); // Trở lại màu chuẩn
                lbl.Top += 2;
            }
        }

        private void ucAdmin_UserManagement_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(pnlSearch, 20);
            
            cboStatusFilter.SelectedIndex = 0;
            LoadData();

            // Set placeholder using native Windows API (very stable)
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "🔍 Tìm kiếm theo tên, SĐT...");
            
            this.ActiveControl = lblTitle;
        }

        private void pnlSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void LoadData()
        {
            string keyword = txtSearch.Text.Trim();
            string status = cboStatusFilter.SelectedItem?.ToString() ?? "Tất cả trạng thái";
            
            // Get all users (filtered by keyword, excluding admins)
            var allUsers = _adminBUS.SearchUsers(keyword, "Tất cả");
            
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
            int totalAll = allUsers.Count;
            int totalPatients = allUsers.Count(u => u.Role == "Patient");
            int totalDoctors = allUsers.Count(u => u.Role == "Doctor");

            btnAllUsers.Text = $"Tất cả ({totalAll})";
            btnPatients.Text = $"Bệnh nhân ({totalPatients})";
            btnDoctors.Text = $"Bác sĩ ({totalDoctors})";

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
            if (status == "Chờ duyệt")
            {
                // Only show doctors that are in the pending list
                var pendingUserIds = new HashSet<int>(pendingDocs.Select(d => d.UserId));
                filteredList = allUsers.Where(u => pendingUserIds.Contains(u.Id));
            }
            else if (status == "Hoạt động")
            {
                filteredList = allUsers.Where(u => u.Status == "Active");
            }
            else if (status == "Bị khóa")
            {
                filteredList = allUsers.Where(u => u.Status == "Inactive");
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
            SetActiveTab(btnPatients);
            _currentPage = 1;
            LoadData();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            _currentTab = "Doctor";
            SetActiveTab(btnDoctors);
            _currentPage = 1;
            LoadData();
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
    }
}
