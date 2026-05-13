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
            InitData();
        }

        public void InitData()
        {
            _allDepts = _deptBUS.GetAllDepartments();
            if (cboStatusFilter.SelectedIndex == -1) cboStatusFilter.SelectedIndex = 0;
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string keyword = txtSearch.Text.ToLower().Trim();
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
                item.Width = flpList.Width - 45;
                flpList.Controls.Add(item);
            }

            int totalPages = (int)Math.Ceiling((double)_filteredDepts.Count / _pageSize);
            lblPageInfo.Text = $"Trang {_currentPage} / {Math.Max(1, totalPages)}";
            
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < totalPages;

            flpList.ResumeLayout();
        }

        private void flpList_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpList.Controls)
            {
                ctrl.Width = flpList.Width - 45;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form f = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White,
                Size = new Size(800, 700),
                ControlBox = false
            };

            ucAdmin_AddDepartment uc = new ucAdmin_AddDepartment();
            uc.Dock = DockStyle.Fill;
            uc.SetData(null);
            uc.OnCancel += (s, ev) => f.Close();
            uc.OnSuccess += (s, ev) => {
                f.Close();
                InitData();
            };

            f.Controls.Add(uc);
            UIHelper.ApplyRoundedRegion(f, 15);
            f.ShowDialog();
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
