using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DTO_Tier;
using BUS_Tier;
using System.Linq;

namespace UI_Tier
{
    public partial class ucAdmin_DepartmentManagement : UserControl
    {
        private DepartmentBUS _deptBUS = new DepartmentBUS();
        private List<DepartmentDTO> _allDepts = new List<DepartmentDTO>();
        private List<DepartmentDTO> _filteredDepts = new List<DepartmentDTO>();
        private int _pageSize = 10;
        private int _currentPage = 1;

        public ucAdmin_DepartmentManagement()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(flpList);
            
            pnlSearch.Paint += pnlSearch_Paint;
            pnlSearch.Click += (s, e) => txtSearch.Focus();
            lblSearchIcon.Click += (s, e) => txtSearch.Focus();
            UIHelper.SetupInputFocusEffect(txtSearch, pnlSearch, Color.White, Color.White, Color.FromArgb(24, 112, 255));
            UIHelper.RegisterClickToUnfocus(this, lblTitle);

            this.Paint += ucAdmin_DepartmentManagement_Paint;
            this.Resize += (s, e) => UIHelper.ApplyRoundedRegion(this, 15);

            // Wire up pagination
            lblPrev.Click += btnPrev_Click;
            lblNext.Click += btnNext_Click;
            UIHelper.SetupHoverEffect(lblPrev, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));
            UIHelper.SetupHoverEffect(lblNext, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212));

            // Apply rounding to buttons and search
            UIHelper.ApplyRoundedRegion(btnAdd, 12);
            UIHelper.ApplyRoundedRegion(pnlSearch, 15);

            InitData();
            this.Load += (s, e) => ApplyFilters();
        }

        private void ucAdmin_DepartmentManagement_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(this, e, 15, Color.Black, 2);
        }

        private void pnlSearch_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 15, Color.FromArgb(203, 213, 225), 2);
        }

        public void InitData()
        {
            _allDepts = _deptBUS.GetAllDepartments();
            if (cboStatusFilter.SelectedIndex == -1) cboStatusFilter.SelectedIndex = 0;
            
            UIHelper.SetupSearchTextBox(txtSearch, "Tìm kiếm theo tên chuyên khoa, mô tả...");
            
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string keyword = txtSearch.Text.ToLower().Trim();
            if (keyword == "tìm kiếm theo tên chuyên khoa, mô tả...") keyword = "";
            string statusFilter = cboStatusFilter.SelectedItem?.ToString() ?? "Tất cả trạng thái";

            _filteredDepts = _allDepts.Where(d => 
                (string.IsNullOrEmpty(keyword) || d.DepartmentName.ToLower().Contains(keyword) || (d.Description != null && d.Description.ToLower().Contains(keyword))) &&
                (statusFilter == "Tất cả trạng thái" || (statusFilter == "Hiển thị" && d.IsActive) || (statusFilter == "Ẩn" && !d.IsActive))
            ).ToList();

            _currentPage = 1;
            DisplayPage(_currentPage);
        }

        private void DisplayPage(int pageNumber)
        {
            flpList.SuspendLayout();
            flpList.Controls.Clear();

            int startIndex = (pageNumber - 1) * _pageSize;
            var pageItems = _filteredDepts.Skip(startIndex).Take(_pageSize).ToList();

            if (pageItems.Count == 0 && _currentPage > 1)
            {
                _currentPage--;
                DisplayPage(_currentPage);
                return;
            }

            foreach (var dept in pageItems)
            {
                ucAdmin_DepartmentItem item = new ucAdmin_DepartmentItem();
                item.SetData(dept);
                item.DataChanged += (s, ev) => InitData();
                item.Width = flpList.ClientSize.Width - 20;
                flpList.Controls.Add(item);
            }

            int totalPages = (int)Math.Ceiling((double)_filteredDepts.Count / _pageSize);
            lblPageStatus.Text = $"Trang {_currentPage} / {Math.Max(1, totalPages)}";
            
            lblPrev.Enabled = _currentPage > 1;
            lblNext.Enabled = _currentPage < totalPages;
            lblPrev.ForeColor = lblPrev.Enabled ? Color.FromArgb(0, 120, 212) : Color.Gray;
            lblNext.ForeColor = lblNext.Enabled ? Color.FromArgb(0, 120, 212) : Color.Gray;

            flpList.ResumeLayout();
        }

        private void flpList_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpList.Controls)
            {
                ctrl.Width = flpList.ClientSize.Width - 20;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucAdmin_AddDepartment uc = new ucAdmin_AddDepartment();
            uc.SetData(null);
            uc.OnCancel += (s, ev) => this.Controls.Remove(uc);
            uc.OnSuccess += (s, ev) => {
                this.Controls.Remove(uc);
                InitData();
            };

            ShowOverlay(uc);
        }

        public void ShowOverlay(UserControl uc)
        {
            uc.Location = new Point((this.Width - uc.Width) / 2, Math.Max(20, (this.Height - uc.Height) / 2));
            this.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayPage(_currentPage);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_filteredDepts.Count / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
