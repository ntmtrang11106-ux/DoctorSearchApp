using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BUS_Tier;
using DTO_Tier;

namespace UI_Tier
{
    public partial class ucAdmin_UserManagement : UserControl
    {
        private AdminBUS _adminBUS = new AdminBUS();
        private string _currentTab = "All"; // "All" or "Pending"

        public ucAdmin_UserManagement()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(flpUserList);
        }

        private void ucAdmin_UserManagement_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(pnlSearch, 20);
            UIHelper.ApplyRoundedRegion(btnAllUsers, 20);
            UIHelper.ApplyRoundedRegion(btnPendingDoctors, 20);
            
            cboRoleFilter.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            flpUserList.Controls.Clear();
            
            if (_currentTab == "All")
            {
                string role = cboRoleFilter.SelectedItem?.ToString() ?? "Tất cả";
                var users = _adminBUS.SearchUsers(txtSearch.Text, role);
                foreach (var user in users)
                {
                    ucAdmin_UserItem item = new ucAdmin_UserItem();
                    item.SetUserData(user);
                    item.DataChanged += (s, ev) => LoadData();
                    flpUserList.Controls.Add(item);
                }
            }
            else
            {
                var pendingDocs = _adminBUS.GetPendingDoctors();
                foreach (var doc in pendingDocs)
                {
                    ucAdmin_UserItem item = new ucAdmin_UserItem();
                    item.SetDoctorData(doc);
                    item.DataChanged += (s, ev) => LoadData();
                    flpUserList.Controls.Add(item);
                }
            }
        }

        private void btnAllUsers_Click(object sender, EventArgs e)
        {
            _currentTab = "All";
            UpdateButtonStyles();
            pnlFilters.Visible = true;
            LoadData();
        }

        private void btnPendingDoctors_Click(object sender, EventArgs e)
        {
            _currentTab = "Pending";
            UpdateButtonStyles();
            pnlFilters.Visible = false;
            LoadData();
        }

        private void UpdateButtonStyles()
        {
            bool isAll = _currentTab == "All";
            
            btnAllUsers.BackColor = isAll ? Color.FromArgb(0, 98, 255) : Color.White;
            btnAllUsers.ForeColor = isAll ? Color.White : Color.FromArgb(64, 64, 64);
            
            btnPendingDoctors.BackColor = !isAll ? Color.FromArgb(0, 98, 255) : Color.White;
            btnPendingDoctors.ForeColor = !isAll ? Color.White : Color.FromArgb(64, 64, 64);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_currentTab == "All") LoadData();
        }

        private void cboRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentTab == "All") LoadData();
        }
    }
}
