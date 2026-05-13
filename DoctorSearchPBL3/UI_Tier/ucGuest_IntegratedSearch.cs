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
    public partial class ucGuest_IntegratedSearch : UserControl
    {
        private SearchBUS _searchBus = new SearchBUS();
        private DepartmentBUS _deptBus = new DepartmentBUS();
        
        private List<DoctorDTO> _foundDoctors = new List<DoctorDTO>();
        private List<ContentDTO> _foundArticles = new List<ContentDTO>();
        
        private int _pageSize = 6;
        private int _currentDocPage = 1;
        private int _currentArtPage = 1;
        private bool _isUpdatingChips = false;

        private Color _activeBack = Color.FromArgb(206, 225, 255);
        private Color _normalBack = Color.Transparent;
        private Color _activeText = Color.FromArgb(0, 98, 255);
        private Color _normalText = SystemColors.ControlDarkDark;
        private Panel _activeTab;

        public ucGuest_IntegratedSearch()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            SetupUI();
            InitTabs();
        }

        private void InitTabs()
        {
            UIHelper.ApplyRoundedRegion(tabDoc, 15);
            UIHelper.ApplyRoundedRegion(tabArt, 15);

            Panel[] tabs = { tabDoc, tabArt };
            foreach (var pnl in tabs)
            {
                pnl.Click += PanelTab_Click;
                pnl.MouseEnter += PanelTab_MouseEnter;
                pnl.MouseLeave += PanelTab_MouseLeave;
                pnl.Cursor = Cursors.Hand;
                foreach (Control child in pnl.Controls)
                {
                    child.Click += PanelTab_Click;
                    child.MouseEnter += PanelTab_MouseEnter;
                    child.MouseLeave += PanelTab_MouseLeave;
                    child.Cursor = Cursors.Hand;
                }
            }

            PanelTab_Click(tabDoc, EventArgs.Empty);
        }

        private void PanelTab_MouseEnter(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Panel pnl = (ctrl is Panel) ? (Panel)ctrl : (Panel)ctrl.Parent;
            if (pnl == _activeTab) return;

            pnl.BackColor = Color.FromArgb(240, 245, 255); // Highlight nhẹ khi hover
        }

        private void PanelTab_MouseLeave(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Panel pnl = (ctrl is Panel) ? (Panel)ctrl : (Panel)ctrl.Parent;
            if (pnl == _activeTab) return;

            pnl.BackColor = _normalBack; // Trả về mặc định
        }

        public void HideTabs()
        {
            pnlTabHeader.Visible = false;
        }

        public void SetActiveTab(bool isDoctor)
        {
            Panel target = isDoctor ? tabDoc : tabArt;
            PanelTab_Click(target, EventArgs.Empty);
        }

        private void PanelTab_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Panel clicked = (ctrl is Panel p) ? p : (Panel)ctrl.Parent;

            if (clicked == _activeTab) return;
            _activeTab = clicked;

            UpdateTabStyles();
            DisplayResults();
        }

        private void UpdateTabStyles()
        {
            foreach (var tab in new[] { tabDoc, tabArt })
            {
                bool isActive = tab == _activeTab;
                tab.BackColor = isActive ? _activeBack : _normalBack;
                foreach (Control child in tab.Controls)
                {
                    if (child is Label lbl) lbl.ForeColor = isActive ? _activeText : _normalText;
                }
            }
        }

        private void SetupUI()
        {
            UIHelper.ApplyRoundedRegion(pnlSearchBox, 15);
            UIHelper.ApplyRoundedRegion(btnSearch, 15);

            // Gender
            cboGender.Items.Clear();
            cboGender.Items.Add("Tất cả Giới tính");
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
            cboGender.SelectedIndex = 0;

            // Content Type
            cboContentType.Items.Clear();
            cboContentType.Items.Add("Tất cả Loại bài");
            cboContentType.Items.Add("Thông báo");
            cboContentType.Items.Add("Quy trình khám");
            cboContentType.Items.Add("Bài viết chuyên khoa");
            cboContentType.Items.Add("Thông tin y tế");
            cboContentType.SelectedIndex = 0;
            
            // Set Hand Cursor for interactive elements
            btnSearch.Cursor = Cursors.Hand;
            lblPrev.Cursor = Cursors.Hand;
            lblNext.Cursor = Cursors.Hand;

            LoadDepartments();
        }

        private void LoadDepartments()
        {
            var depts = _deptBus.GetDepartmentsForUI();
            flpDepts.Controls.Clear();
            flpDepts.BackColor = Color.White; // Bỏ nền xanh, dùng nền trắng
            flpDepts.Padding = new Padding(10);
            
            // "Tất cả" Chip
            CheckBox chkAll = CreateChip("Tất cả Chuyên khoa", "Tất cả");
            chkAll.Checked = true;
            ApplyChipStyle(chkAll);
            flpDepts.Controls.Add(chkAll);

            foreach (var dept in depts)
            {
                CheckBox chk = CreateChip(dept.DepartmentName, dept.DepartmentName);
                ApplyChipStyle(chk);
                flpDepts.Controls.Add(chk);
                UIHelper.ApplyRoundedRegion(chk, 15);
            }
            UIHelper.ApplyRoundedRegion(chkAll, 15);
        }

        private CheckBox CreateChip(string text, string tag)
        {
            CheckBox chk = new CheckBox
            {
                Text = text,
                Tag = tag,
                AutoSize = true,
                Appearance = Appearance.Button,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14F),
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(64, 64, 64),
                Cursor = Cursors.Hand
            };
            chk.FlatAppearance.BorderSize = 1;
            chk.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            chk.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 120, 212);
            chk.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 100, 180);
            chk.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);

            chk.CheckedChanged += (s, e) =>
            {
                if (_isUpdatingChips) return;

                CheckBox c = (CheckBox)s;
                
                if (c.Checked)
                {
                    _isUpdatingChips = true;
                    // Bỏ chọn tất cả các Chip khác
                    foreach (Control ctrl in flpDepts.Controls)
                    {
                        if (ctrl is CheckBox other && other != c)
                        {
                            other.Checked = false;
                            other.ForeColor = Color.FromArgb(64, 64, 64);
                        }
                    }
                    _isUpdatingChips = false;
                }
                else
                {
                    // Nếu người dùng bỏ chọn một chip, kiểm tra xem còn cái nào đang chọn không
                    bool anyChecked = false;
                    foreach (Control ctrl in flpDepts.Controls)
                    {
                        if (ctrl is CheckBox other && other.Checked) { anyChecked = true; break; }
                    }

                    // Nếu không còn cái nào được chọn, tự động quay lại "Tất cả"
                    if (!anyChecked)
                    {
                        _isUpdatingChips = true;
                        foreach (Control ctrl in flpDepts.Controls)
                        {
                            if (ctrl is CheckBox other && other.Tag?.ToString() == "Tất cả")
                            {
                                other.Checked = true;
                                other.ForeColor = Color.White;
                                break;
                            }
                        }
                        _isUpdatingChips = false;
                    }
                }

                // Cập nhật màu sắc cho chip hiện tại
                c.ForeColor = c.Checked ? Color.White : Color.FromArgb(64, 64, 64);
                
                ExecuteSearch();
            };
            return chk;
        }

        private void ApplyChipStyle(CheckBox chk)
        {
            // Placeholder for any specific initialization if needed
        }

        public void ExecuteSearch()
        {
            string keyword = txtSearchBar.Text.Trim();
            string gender = cboGender.SelectedIndex <= 0 ? null : cboGender.SelectedItem?.ToString();
            string contentTypeDisplay = cboContentType.SelectedIndex <= 0 ? null : cboContentType.SelectedItem?.ToString();
            string contentType = contentTypeDisplay switch
            {
                "Thông báo" => "HospitalNotice",
                "Quy trình khám" => "ProcedureGuide",
                "Bài viết chuyên khoa" => "DepartmentGuide",
                "Thông tin y tế" => "HealthArticle",
                _ => null
            };
            string sort = cboSort.SelectedItem?.ToString();

            List<string> selectedDepts = new List<string>();
            foreach (Control ctrl in flpDepts.Controls)
            {
                if (ctrl is CheckBox chk && chk.Checked)
                {
                    selectedDepts.Add(chk.Tag.ToString());
                }
            }

            // Hide suggestions when searching
            if (lstSuggestions != null) lstSuggestions.Visible = false;

            var results = _searchBus.ExecuteIntegratedSearch(keyword, selectedDepts, gender, contentType, sort, sort);
            _foundDoctors = results.doctors;
            _foundArticles = results.contents;

            _currentDocPage = 1;
            _currentArtPage = 1;

            UpdateTabTitles();
            DisplayResults();
        }

        private void UpdateTabTitles()
        {
            lblDocText.Text = $"Bác sĩ ({_foundDoctors.Count})";
            lblArtText.Text = $"Bài viết ({_foundArticles.Count})";
        }

        private void DisplayResults()
        {
            // Update filter visibility based on selected tab
            bool isDoctorTab = _activeTab == tabDoc;
            
            cboGender.Visible = isDoctorTab;
            labelGender.Visible = isDoctorTab;
            
            cboContentType.Visible = !isDoctorTab;
            labelContentType.Visible = !isDoctorTab;

            UpdateSortOptions(isDoctorTab);

            flpDoctors.Visible = isDoctorTab;
            flpArticles.Visible = !isDoctorTab;

            if (isDoctorTab)
                DisplayDoctors(_currentDocPage);
            else
                DisplayArticles(_currentArtPage);
        }

        private void UpdateSortOptions(bool isDoctor)
        {
            cboSort.SelectedIndexChanged -= Filter_SelectedIndexChanged;
            string currentSort = cboSort.SelectedItem?.ToString();
            
            cboSort.Items.Clear();
            if (isDoctor)
            {
                cboSort.Items.Add("Mới nhất");
                cboSort.Items.Add("Giá khám thấp đến cao");
                cboSort.Items.Add("Giá khám cao đến thấp");
                cboSort.Items.Add("Năm kinh nghiệm cao đến thấp");
                cboSort.Items.Add("Đánh giá cao đến thấp");
            }
            else
            {
                cboSort.Items.Add("Mới nhất");
                cboSort.Items.Add("Xem nhiều nhất");
                cboSort.Items.Add("Xem ít nhất");
            }

            // Restore selection if still valid
            if (cboSort.Items.Contains(currentSort))
                cboSort.SelectedItem = currentSort;
            else
                cboSort.SelectedIndex = 0;

            cboSort.SelectedIndexChanged += Filter_SelectedIndexChanged;
        }

        private void DisplayDoctors(int page)
        {
            flpDoctors.SuspendLayout();
            flpDoctors.Controls.Clear();
            
            int startIndex = (page - 1) * _pageSize;
            var items = _foundDoctors.Skip(startIndex).Take(_pageSize).ToList();

            foreach (var doc in items)
            {
                UCCardDoctor card = new UCCardDoctor();
                card.IsClickable = false; // Guest không có hiệu ứng nổi và click
                card.SetDoctorData(doc);
                card.Margin = new Padding(15);
                flpDoctors.Controls.Add(card);
            }

            lblPageStatus.Text = $"Trang {page} / {Math.Max(1, (int)Math.Ceiling((double)_foundDoctors.Count / _pageSize))}";
            flpDoctors.ResumeLayout();
        }

        private void DisplayArticles(int page)
        {
            flpArticles.SuspendLayout();
            flpArticles.Controls.Clear();

            int startIndex = (page - 1) * _pageSize;
            var items = _foundArticles.Skip(startIndex).Take(_pageSize).ToList();

            foreach (var art in items)
            {
                UCCardArticle card = new UCCardArticle();
                card.SetData(art);
                card.Margin = new Padding(15);
                flpArticles.Controls.Add(card);
            }

            lblPageStatus.Text = $"Trang {page} / {Math.Max(1, (int)Math.Ceiling((double)_foundArticles.Count / _pageSize))}";
            flpArticles.ResumeLayout();
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string text = txtSearchBar.Text.Trim();
            if (text.Length >= 2)
            {
                var suggestions = _foundDoctors.Where(d => d.User?.FullName != null && d.User.FullName.Contains(text, StringComparison.OrdinalIgnoreCase))
                                              .Select(d => d.User.FullName)
                                              .Concat(_foundArticles.Where(a => a.Title != null && a.Title.Contains(text, StringComparison.OrdinalIgnoreCase))
                                                                    .Select(a => a.Title))
                                              .Distinct()
                                              .Take(5)
                                              .ToList();

                if (suggestions.Any())
                {
                    lstSuggestions.Items.Clear();
                    foreach (var s in suggestions) lstSuggestions.Items.Add(s);
                    lstSuggestions.Height = Math.Min(200, lstSuggestions.Items.Count * 25 + 5);
                    lstSuggestions.Visible = true;
                    lstSuggestions.BringToFront();
                }
                else
                {
                    lstSuggestions.Visible = false;
                }
            }
            else
            {
                lstSuggestions.Visible = false;
            }
        }

        private void lstSuggestions_Click(object sender, EventArgs e)
        {
            if (lstSuggestions.SelectedItem != null)
            {
                txtSearchBar.Text = lstSuggestions.SelectedItem.ToString();
                lstSuggestions.Visible = false;
                ExecuteSearch();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void lblPrev_Click(object sender, EventArgs e)
        {
            if (_activeTab == tabDoc)
            {
                if (_currentDocPage > 1) { _currentDocPage--; DisplayDoctors(_currentDocPage); }
            }
            else
            {
                if (_currentArtPage > 1) { _currentArtPage--; DisplayArticles(_currentArtPage); }
            }
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            if (_activeTab == tabDoc)
            {
                int totalPages = (int)Math.Ceiling((double)_foundDoctors.Count / _pageSize);
                if (_currentDocPage < totalPages) { _currentDocPage++; DisplayDoctors(_currentDocPage); }
            }
            else
            {
                int totalPages = (int)Math.Ceiling((double)_foundArticles.Count / _pageSize);
                if (_currentArtPage < totalPages) { _currentArtPage++; DisplayArticles(_currentArtPage); }
            }
        }

        private void Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearch();
        }
    }
}
