using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucPatient_SearchArticle : UserControl
    {
        private ContentBUS _contentBus = new ContentBUS();
        private DepartmentBUS _deptBus = new DepartmentBUS();
        private List<ContentDTO> _allArticles = new List<ContentDTO>();
        private int _pageSize = 6;
        private int _currentPage = 1;
        private bool _isAdmin = false;

        public ucPatient_SearchArticle()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            SetupUI();
        }

        public void SetAdminMode(bool isAdmin)
        {
            _isAdmin = isAdmin;
            if (isAdmin)
            {
                label1.Visible = false;
                label2.Visible = false;
                
                // Move search and filters up
                pnlSearch.Top = 10;
                pnlFilters.Top = pnlSearch.Bottom + 10;
                pnlHeader.Height = pnlFilters.Bottom + 10;

                lblStatus.Visible = true;
                cboStatus.Visible = true;
            }
        }

        private void SetupUI()
        {
            // Populate Content Type
            cboContentType.Items.Clear();
            cboContentType.Items.Add("Tất cả Loại bài");
            cboContentType.Items.Add("Thông báo");
            cboContentType.Items.Add("Quy trình khám");
            cboContentType.Items.Add("Bài viết chuyên khoa");
            cboContentType.Items.Add("Thông tin y tế");
            cboContentType.SelectedIndex = 0;

            // Populate Sort
            cboSort.Items.Clear();
            cboSort.Items.Add("Mới nhất");
            cboSort.Items.Add("Xem nhiều nhất");
            cboSort.Items.Add("Xem ít nhất");
            cboSort.SelectedIndex = 0;

            // Populate Status
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Tất cả trạng thái");
            cboStatus.Items.Add("Đã xuất bản");
            cboStatus.Items.Add("Bản nháp");
            cboStatus.Items.Add("Đã ẩn");
            cboStatus.SelectedIndex = 0;

            UIHelper.ApplyRoundedRegion(cboContentType, 8);
            UIHelper.ApplyRoundedRegion(cboSort, 8);
            UIHelper.ApplyRoundedRegion(cboStatus, 8);
            UIHelper.ApplyRoundedRegion(pnlSearch, 15);

            LoadDepartments();
        }

        private void LoadDepartments()
        {
            var depts = _deptBus.GetDepartmentsForUI();
            flpDepartments.Controls.Clear();
            
            // Add "All" option
            AddDeptLabel("Tất cả Chuyên khoa", "Tất cả", true);

            foreach (var dept in depts)
            {
                AddDeptLabel(dept.DepartmentName, dept.DepartmentName, false);
            }
        }

        private void AddDeptLabel(string text, string tag, bool isSelected)
        {
            Label lbl = new Label
            {
                Text = text,
                Tag = tag,
                AutoSize = true,
                Padding = new Padding(15, 0, 15, 0),
                Height = 45,
                Margin = new Padding(0, 0, 10, 10),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 13, isSelected ? FontStyle.Bold : FontStyle.Regular)
            };

            UpdateDeptLabelStyle(lbl, isSelected);
            lbl.Click += DeptLabel_Click;
            flpDepartments.Controls.Add(lbl);
        }

        private void DeptLabel_Click(object sender, EventArgs e)
        {
            Label clicked = sender as Label;
            if (clicked == null) return;

            // Toggle logic: If clicking "All", deselect others. If clicking specific, handle "All"
            bool isAll = clicked.Tag.ToString() == "Tất cả";

            if (isAll)
            {
                foreach (Control ctrl in flpDepartments.Controls)
                {
                    if (ctrl is Label lbl) UpdateDeptLabelStyle(lbl, lbl == clicked);
                }
            }
            else
            {
                // Multi-select or single? Image 2 looks like single or limited.
                // Let's implement single select for clarity as per Image 2
                foreach (Control ctrl in flpDepartments.Controls)
                {
                    if (ctrl is Label lbl) UpdateDeptLabelStyle(lbl, lbl == clicked);
                }
            }

            ExecuteSearch();
        }

        private void UpdateDeptLabelStyle(Label lbl, bool isSelected)
        {
            if (isSelected)
            {
                lbl.BackColor = Color.FromArgb(0, 120, 212); // Blue
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            }
            else
            {
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.FromArgb(64, 64, 64);
                lbl.Font = new Font("Segoe UI", 13, FontStyle.Regular);
                // Add a border effect via Paint or just use background
                lbl.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        public void InitData()
        {
            ExecuteSearch();
        }

        private void ExecuteSearch()
        {
            string keyword = txtSearchBar.Text.Trim();
            string selectedType = cboContentType.SelectedItem?.ToString();
            string sortType = cboSort.SelectedItem?.ToString();
            string status = "Published"; // Default for patients

            if (_isAdmin)
            {
                string selectedStatus = cboStatus.SelectedItem?.ToString();
                status = selectedStatus switch
                {
                    "Đã xuất bản" => "Published",
                    "Bản nháp" => "Draft",
                    "Đã ẩn" => "Hidden",
                    _ => "Tất cả"
                };
            }

            // Map Vietnamese labels back to English Enum strings for DAL
            string contentType = selectedType switch
            {
                "Thông báo" => "HospitalNotice",
                "Quy trình khám" => "ProcedureGuide",
                "Bài viết chuyên khoa" => "DepartmentGuide",
                "Thông tin y tế" => "HealthArticle",
                _ => "Tất cả"
            };

            List<string> selectedDepts = new List<string>();
            foreach (Control ctrl in flpDepartments.Controls)
            {
                if (ctrl is Label lbl && lbl.BackColor == Color.FromArgb(0, 120, 212))
                {
                    selectedDepts.Add(lbl.Tag.ToString());
                }
            }

            _allArticles = _contentBus.SearchContents(keyword, selectedDepts, contentType, sortType, status);
            _currentPage = 1;
            DisplayPage(_currentPage);
        }

        private void DisplayPage(int pageNumber)
        {
            flpResults.SuspendLayout();
            flpResults.Controls.Clear();

            if (_allArticles == null || _allArticles.Count == 0)
            {
                Label lblNoResult = new Label
                {
                    Text = "Không tìm thấy bài viết nào phù hợp.",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 13, FontStyle.Italic),
                    ForeColor = Color.Gray
                };
                flpResults.Controls.Add(lblNoResult);
            }
            else
            {
                int startIndex = (pageNumber - 1) * _pageSize;
                var pageItems = _allArticles.Skip(startIndex).Take(_pageSize).ToList();

                foreach (var art in pageItems)
                {
                    UCCardArticle card = new UCCardArticle();
                    card.SetData(art);
                    card.Margin = new Padding(15);
                    
                    // Sử dụng kích thước gốc từ Designer (trừ 10px chiều rộng) theo yêu cầu
                    // Điều này sẽ giữ nguyên vẻ đẹp nguyên bản của Card bạn đã vẽ
                    card.Width = card.Width - 25;
                    
                    flpResults.Controls.Add(card);
                }
            }

            int totalPages = (int)Math.Ceiling((double)_allArticles.Count / _pageSize);
            lblPageStatus.Text = $"Trang {_currentPage} / {Math.Max(1, totalPages)}";
            
            flpResults.ResumeLayout();
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBar.Text.Length > 2)
            {
                // Suggestion logic could go here
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void lblPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayPage(_currentPage);
            }
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_allArticles.Count / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }

        private void cboContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearch();
        }
    }
}
