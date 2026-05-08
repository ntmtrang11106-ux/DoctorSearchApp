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
    public partial class ucPatient_SearchDoc : UserControl
    {
        private DoctorBUS _bus = new DoctorBUS();
        private DepartmentBUS _deptBus = new DepartmentBUS();
        private List<DoctorDTO> _allDoctors = new List<DoctorDTO>();
        private int _pageSize = 8;
        private int _currentPage = 1;

        public ucPatient_SearchDoc()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            SetupUI();
        }

        private void SetupUI()
        {
            // Populate Gender
            cboGender.Items.Clear();
            cboGender.Items.Add("Tất cả");
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
            cboGender.SelectedIndex = 0;

            // Populate Sort
            cboSort.Items.Clear();
            cboSort.Items.Add("Mới nhất");
            cboSort.Items.Add("Giá khám thấp đến cao");
            cboSort.Items.Add("Giá khám cao đến thấp");
            cboSort.Items.Add("Năm kinh nghiệm cao đến thấp");
            cboSort.Items.Add("Rating cao đến thấp");
            cboSort.SelectedIndex = 0;

            LoadDepartments();
        }

        private void LoadDepartments()
        {
            var depts = _deptBus.GetDepartmentsForUI();
            flpFilter.Controls.Clear();
            
            CheckBox chkAll = new CheckBox { Text = "Tất cả", AutoSize = true, Tag = "Tất cả", Checked = true };
            chkAll.CheckedChanged += (s, e) => ExecuteSearch();
            flpFilter.Controls.Add(chkAll);

            foreach (var dept in depts)
            {
                CheckBox chk = new CheckBox { Text = dept.DepartmentName, AutoSize = true, Tag = dept.DepartmentName };
                chk.CheckedChanged += (s, e) => ExecuteSearch();
                flpFilter.Controls.Add(chk);
            }
        }

        public void InitData()
        {
            ExecuteSearch();
        }

        private void ExecuteSearch()
        {
            string keyword = txtSearchBar.Text.Trim();
            string gender = cboGender.SelectedItem?.ToString();
            if (gender == "Tất cả") gender = null;
            string sortType = cboSort.SelectedItem?.ToString();

            List<string> selectedDepts = new List<string>();
            foreach (Control ctrl in flpFilter.Controls)
            {
                if (ctrl is CheckBox chk && chk.Checked)
                {
                    selectedDepts.Add(chk.Tag.ToString());
                }
            }

            _allDoctors = _bus.SearchDoctors(keyword, selectedDepts, gender, sortType);
            _currentPage = 1;
            DisplayPage(_currentPage);
        }

        public void DisplayPage(int pageNumber)
        {
            flpDoctors.SuspendLayout();
            flpDoctors.Controls.Clear();

            if (_allDoctors == null || _allDoctors.Count == 0)
            {
                // Show no results message
                return;
            }

            int startIndex = (pageNumber - 1) * _pageSize;
            var pageItems = _allDoctors.Skip(startIndex).Take(_pageSize).ToList();

            foreach (var doc in pageItems)
            {
                UCCardDoctor card = new UCCardDoctor();
                card.SetDoctorData(doc);
                card.Margin = new Padding(15);
                flpDoctors.Controls.Add(card);
            }

            int totalPages = (int)Math.Ceiling((double)_allDoctors.Count / _pageSize);
            lblPageStatus.Text = $"Trang {_currentPage} / {Math.Max(1, totalPages)}";

            flpDoctors.ResumeLayout();
        }

        private void ucPatient_SearchDoc_Load(object sender, EventArgs e)
        {
            InitData();
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
            int totalPages = (int)Math.Ceiling((double)_allDoctors.Count / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearch();
        }
    }
}
