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

        public ucPatient_SearchArticle()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            SetupUI();
        }

        private void SetupUI()
        {
            // Populate Content Type
            cboContentType.Items.Clear();
            cboContentType.Items.Add("Tất cả");
            cboContentType.Items.Add("HospitalNotice");
            cboContentType.Items.Add("ProcedureGuide");
            cboContentType.Items.Add("DepartmentGuide");
            cboContentType.Items.Add("HealthArticle");
            cboContentType.SelectedIndex = 0;

            // Populate Sort
            cboSort.Items.Clear();
            cboSort.Items.Add("Mới nhất");
            cboSort.Items.Add("Xem nhiều nhất");
            cboSort.Items.Add("Xem ít nhất");
            cboSort.SelectedIndex = 0;

            LoadDepartments();
        }

        private void LoadDepartments()
        {
            var depts = _deptBus.GetDepartmentsForUI();
            flpDepartments.Controls.Clear();
            
            CheckBox chkAll = new CheckBox { Text = "Tất cả", AutoSize = true, Tag = "Tất cả", Checked = true };
            chkAll.CheckedChanged += FilterChanged;
            flpDepartments.Controls.Add(chkAll);

            foreach (var dept in depts)
            {
                CheckBox chk = new CheckBox { Text = dept.DepartmentName, AutoSize = true, Tag = dept.DepartmentName };
                chk.CheckedChanged += FilterChanged;
                flpDepartments.Controls.Add(chk);
            }
        }

        public void InitData()
        {
            ExecuteSearch();
        }

        private void ExecuteSearch()
        {
            string keyword = txtSearchBar.Text.Trim();
            string contentType = cboContentType.SelectedItem?.ToString();
            string sortType = cboSort.SelectedItem?.ToString();

            List<string> selectedDepts = new List<string>();
            foreach (Control ctrl in flpDepartments.Controls)
            {
                if (ctrl is CheckBox chk && chk.Checked)
                {
                    selectedDepts.Add(chk.Tag.ToString());
                }
            }

            _allArticles = _contentBus.SearchContents(keyword, selectedDepts, contentType, sortType);
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
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
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
                    flpResults.Controls.Add(card);
                }
            }

            int totalPages = (int)Math.Ceiling((double)_allArticles.Count / _pageSize);
            lblPageStatus.Text = $"Trang {_currentPage} / {Math.Max(1, totalPages)} (Tổng: {_allArticles.Count})";
            
            flpResults.ResumeLayout();
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            // Suggestion logic could go here
            if (txtSearchBar.Text.Length > 2)
            {
                // Show suggestions
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
    }
}
