using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucGuest_IntegratedSearch : UserControl
    {
        // Khai báo các đối tượng BUS xử lý nghiệp vụ tìm kiếm và chuyên khoa
        private readonly SearchBUS _searchBus = new SearchBUS();
        private readonly DepartmentBUS _deptBus = new DepartmentBUS();

        // Danh sách lưu trữ kết quả tìm kiếm Bác sĩ và Bài viết
        private List<DoctorDTO> _foundDoctors = new();
        private List<ContentDTO> _foundArticles = new();

        // Cấu hình phân trang (Pagination)
        private readonly int _pageSize = 6; // Số lượng phần tử tối đa hiển thị trên mỗi trang
        private int _currentDocPage = 1;     // Trang bác sĩ hiện tại
        private int _currentArtPage = 1;     // Trang bài viết hiện tại
        private bool _isAdmin = false;       // Cờ xác định có đang ở quyền quản trị Admin không
        private bool _isUpdatingChips = false; // Cờ khóa tránh đệ quy khi cập nhật trạng thái chọn của các nút chuyên khoa (Chips)

        // Định nghĩa bảng màu trực quan cho các Tab tiêu đề (Bác sĩ / Bài viết)
        private readonly Color _activeBack = Color.FromArgb(206, 225, 255); // Nền xanh nhạt khi được chọn
        private readonly Color _normalBack = Color.Transparent;             // Nền trong suốt mặc định
        private readonly Color _activeText = Color.FromArgb(0, 98, 255);     // Chữ xanh đậm khi được chọn
        private readonly Color _normalText = SystemColors.ControlDarkDark;   // Chữ xám tối mặc định
        private Panel? _activeTab;                                           // Lưu trữ tab hiện đang kích hoạt

        public ucGuest_IntegratedSearch()
        {
            InitializeComponent();

            // Bật Double Buffered giúp mượt mà giao diện khi cuộn và đổi màn hình hiển thị
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(flpDoctors);
            UIHelper.SetDoubleBuffered(flpArticles);
            UIHelper.SetDoubleBuffered(flpDepts);

            SetupUI();
            InitTabs();

            // Đăng ký hiệu ứng hover đổi màu/nhích nhẹ cho các nút điều hướng phân trang
            lblPrev.MouseEnter += PaginationLabel_MouseEnter;
            lblPrev.MouseLeave += PaginationLabel_MouseLeave;
            lblNext.MouseEnter += PaginationLabel_MouseEnter;
            lblNext.MouseLeave += PaginationLabel_MouseLeave;

            // Đặt con trỏ chuột dạng bàn tay (Cursors.Hand) cho nút trang trước và trang sau để biểu thị phần tử click được
            lblPrev.Cursor = Cursors.Hand;
            lblNext.Cursor = Cursors.Hand;
        }

        private void UpdatePaginationUI(int currentPage, int totalItems)
        {
            int totalPages = Math.Max(1, (int)Math.Ceiling((double)totalItems / _pageSize));
            lblPageStatus.Text = $"Trang {currentPage} / {totalPages}";

            lblPrev.Enabled = true;
            lblNext.Enabled = true;
            lblPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblNext.ForeColor = Color.FromArgb(0, 120, 212);
            pnlPagination.Visible = totalItems > 0;
        }

        private void PaginationLabel_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(0, 90, 158);
                lbl.Top -= 2;
            }
        }

        private void PaginationLabel_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(0, 120, 212);
                lbl.Top += 2;
            }
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

            // Kích hoạt mặc định chọn tab Bác sĩ lúc đầu
            PanelTab_Click(tabDoc, EventArgs.Empty);
        }

        private void PanelTab_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is not Control ctrl) return;
            Panel pnl = ctrl as Panel ?? (Panel)ctrl.Parent!;
            if (pnl == _activeTab) return;
            pnl.BackColor = Color.FromArgb(240, 245, 255);
        }

        private void PanelTab_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is not Control ctrl) return;
            Panel pnl = ctrl as Panel ?? (Panel)ctrl.Parent!;
            if (pnl == _activeTab) return;
            pnl.BackColor = _normalBack;
        }

        public void HideTabs() => pnlTabHeader.Visible = false;

        public void HideSearchInput(bool hide)
        {
            pnlSearchBox.Visible = !hide;
            pnlHeader.Height = hide ? 60 : 130;
        }

        public void SetPlaceholder(string text) => txtSearchBar.PlaceholderText = text;

        public void SetAdminMode(bool isAdmin)
        {
            _isAdmin = isAdmin;
            lblAdminStatus.Visible = isAdmin;
            cboAdminStatus.Visible = isAdmin;

            if (isAdmin)
            {
                cboAdminStatus.SelectedIndexChanged -= Filter_SelectedIndexChanged;
                cboAdminStatus.Items.Clear();
                cboAdminStatus.Items.Add("Tất cả trạng thái");
                cboAdminStatus.Items.Add("Đã xuất bản");
                cboAdminStatus.Items.Add("Bản nháp");
                cboAdminStatus.Items.Add("Đã ẩn");
                cboAdminStatus.SelectedIndex = 0;
                cboAdminStatus.SelectedIndexChanged += Filter_SelectedIndexChanged;
                ExecuteSearch();
            }
        }

        public void SetActiveTab(bool isDoctor) => PanelTab_Click(isDoctor ? tabDoc : tabArt, EventArgs.Empty);

        private void PanelTab_Click(object? sender, EventArgs e)
        {
            if (sender is not Control ctrl) return;
            Panel clicked = ctrl as Panel ?? (Panel)ctrl.Parent!;
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
                    if (child is Label lbl)
                        lbl.ForeColor = isActive ? _activeText : _normalText;
                }
            }
        }

        private void SetupUI()
        {
            UIHelper.ApplyRoundedRegion(pnlSearchBox, 15);
            UIHelper.ApplyRoundedRegion(btnSearch, 15);

            label1.Text = "Tìm kiếm bác sĩ và bài viết";
            txtSearchBar.PlaceholderText = "Nhập tên bác sĩ hoặc tiêu đề bài viết...";
            btnSearch.Text = "Tìm kiếm";
            labelGender.Text = "Giới tính:";
            labelContentType.Text = "Loại bài viết:";
            labelSort.Text = "Sắp xếp:";
            lblDocText.Text = "Bác sĩ";
            lblArtText.Text = "Bài viết";
            lblPrev.Text = "<< Trang trước";
            lblNext.Text = "Trang sau >>";
            lblAdminStatus.Text = "Trạng thái:";

            cboGender.Items.Clear();
            cboGender.Items.Add("Tất cả giới tính");
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
            cboGender.SelectedIndex = 0;

            cboContentType.Items.Clear();
            cboContentType.Items.Add("Tất cả loại bài viết");
            cboContentType.Items.Add("Thông báo");
            cboContentType.Items.Add("Quy trình khám");
            cboContentType.Items.Add("Bài viết chuyên khoa");
            cboContentType.Items.Add("Thông tin y tế");
            cboContentType.SelectedIndex = 0;

            btnSearch.Cursor = Cursors.Hand;

            txtSearchBar.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    ExecuteSearch();
                }
            };

            // Đăng ký sự kiện Resize cho các khung chứa danh sách ngay từ đầu
            flpArticles.Resize += (_, _) => { if (_activeTab == tabArt) DisplayResults(); };
            flpDoctors.Resize += (_, _) => { if (_activeTab == tabDoc) DisplayResults(); };

            Load += (_, _) => ExecuteSearch();
            LoadDepartments();
        }

        // =======================================================
        // HỌC HỎI TỪ CƠ CHẾ SẮP XẾP UI CỦA DOCTOR APPOINTMENT
        // =======================================================

        /// <summary>
        /// Tải danh sách chuyên khoa và dựng bộ khung Chips lọc ban đầu nâng cao.
        /// </summary>
        private void LoadDepartments()
        {
            var depts = _deptBus.GetDepartmentsForUI();

            // Khóa vẽ để nạp các nút chip mượt mà
            flpDepts.SuspendLayout();
            flpDepts.Controls.Clear();
            flpDepts.BackColor = Color.White;
            flpDepts.Padding = new Padding(10);

            lblAdminStatus.Visible = false;
            cboAdminStatus.Visible = false;

            // Tạo nút "Tất cả chuyên khoa" mặc định
            CheckBox chkAll = CreateChip("Tất cả chuyên khoa", "Tất cả");
            chkAll.Checked = true;
            flpDepts.Controls.Add(chkAll);
            UIHelper.ApplyRoundedRegion(chkAll, 15);

            // Nạp từng nút Chuyên khoa tương ứng từ DB
            foreach (var dept in depts)
            {
                CheckBox chk = CreateChip(dept.DepartmentName, dept.DepartmentName);
                flpDepts.Controls.Add(chk);
                UIHelper.ApplyRoundedRegion(chk, 15);
            }

            // Gọi hàm quét style đồng bộ lần đầu tiên
            UpdateDepartmentChipStyles();

            flpDepts.ResumeLayout(true);
        }

        /// <summary>
        /// Đồng bộ giao diện các nút Chip lọc Chuyên khoa giống hệt bộ lọc Status appointment
        /// </summary>
        private void UpdateDepartmentChipStyles()
        {
            // Tạm dừng Layout để ép render đồng loạt các Chip, chống flicker giật chữ
            flpDepts.SuspendLayout();

            foreach (Control ctrl in flpDepts.Controls)
            {
                if (ctrl is CheckBox chk)
                {
                    if (chk.Checked)
                    {
                        // STYLE KHI ĐƯỢC CHỌN (ACTIVE): Xanh đậm + Chữ trắng Bold giống nút Lịch hẹn
                        chk.BackColor = Color.FromArgb(24, 112, 255);
                        chk.ForeColor = Color.White;
                        chk.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                        chk.FlatAppearance.BorderSize = 0; // Tắt viền thô
                    }
                    else
                    {
                        // STYLE MẶC ĐỊNH (INACTIVE): Xám nhạt + Chữ xám mờ Regular thoáng mắt
                        chk.BackColor = Color.FromArgb(243, 244, 246);
                        chk.ForeColor = Color.FromArgb(107, 114, 128);
                        chk.Font = new Font("Segoe UI", 12f, FontStyle.Regular);
                        chk.FlatAppearance.BorderSize = 1;
                        chk.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235); // Viền nhẹ tinh tế
                    }
                }
            }

            flpDepts.ResumeLayout(true);
        }

        /// <summary>
        /// Tạo nút lọc Chuyên khoa (Chip) với cấu hình sự kiện CheckChanged cải tiến.
        /// </summary>
        private CheckBox CreateChip(string text, string tag)
        {
            CheckBox chk = new CheckBox
            {
                Text = text,
                Tag = tag,
                AutoSize = true,
                Appearance = Appearance.Button,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                Margin = new Padding(5, 0, 5, 0),
            };

            // Sự kiện thay đổi trạng thái chọn của Chip
            chk.CheckedChanged += (_, _) =>
            {
                if (_isUpdatingChips) return;

                // Cơ chế lựa chọn đơn (Single-Choice Chip) công nghệ khóa đệ quy
                if (chk.Checked)
                {
                    _isUpdatingChips = true;
                    foreach (Control ctrl in flpDepts.Controls)
                    {
                        if (ctrl is CheckBox other && other != chk)
                        {
                            other.Checked = false;
                        }
                    }
                    _isUpdatingChips = false;
                }
                else
                {
                    // Nếu bấm bỏ chọn mà không còn ai được chọn, tự động quay về nút "Tất cả"
                    bool anyChecked = flpDepts.Controls.OfType<CheckBox>().Any(other => other.Checked);
                    if (!anyChecked)
                    {
                        _isUpdatingChips = true;
                        foreach (Control ctrl in flpDepts.Controls)
                        {
                            if (ctrl is CheckBox other && string.Equals(other.Tag?.ToString(), "Tất cả", StringComparison.Ordinal))
                            {
                                other.Checked = true;
                                break;
                            }
                        }
                        _isUpdatingChips = false;
                    }
                }

                // Cập nhật lại màu sắc chữ, font Bold/Regular mượt mà không bị nhấp nháy màn hình
                UpdateDepartmentChipStyles();

                // Thực thi tìm kiếm lại theo bộ lọc chuyên khoa mới
                ExecuteSearch();
            };

            return chk;
        }

        // =======================================================

        public void ExecuteSearch()
        {
            string keyword = txtSearchBar.Text.Trim();
            string? gender = cboGender.SelectedIndex <= 0 ? null : cboGender.SelectedItem?.ToString();
            string? contentTypeDisplay = cboContentType.SelectedIndex <= 0 ? null : cboContentType.SelectedItem?.ToString();
            string? contentType = contentTypeDisplay switch
            {
                "Thông báo" => "HospitalNotice",
                "Quy trình khám" => "ProcedureGuide",
                "Bài viết chuyên khoa" => "DepartmentGuide",
                "Thông tin y tế" => "HealthArticle",
                _ => null
            };
            string? sort = cboSort.SelectedItem?.ToString();

            List<string> selectedDepts = flpDepts.Controls
                .OfType<CheckBox>()
                .Where(chk => chk.Checked)
                .Select(chk => chk.Tag?.ToString())
                .Where(tag => !string.IsNullOrWhiteSpace(tag))
                .Select(tag => tag!)
                .ToList();

            lstSuggestions.Visible = false;

            string status = "Published";
            if (_isAdmin)
            {
                string? selectedStatus = cboAdminStatus.SelectedItem?.ToString();
                status = selectedStatus switch
                {
                    "Đã xuất bản" => "Published",
                    "Bản nháp" => "Draft",
                    "Đã ẩn" => "Hidden",
                    _ => "Tất cả"
                };
            }

            var results = _searchBus.ExecuteIntegratedSearch(keyword, selectedDepts, gender, contentType, sort, status);
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

        public void DisplayResults()
        {
            bool isDoctorTab = _activeTab == tabDoc;

            cboGender.Visible = isDoctorTab;
            labelGender.Visible = isDoctorTab;

            cboContentType.Visible = !isDoctorTab;
            labelContentType.Visible = !isDoctorTab;

            lblAdminStatus.Visible = _isAdmin && !isDoctorTab;
            cboAdminStatus.Visible = _isAdmin && !isDoctorTab;

            UpdateSortOptions(isDoctorTab);

            flpDoctors.Visible = isDoctorTab;
            flpArticles.Visible = !isDoctorTab;

            if (isDoctorTab) DisplayDoctors(_currentDocPage);
            else DisplayArticles(_currentArtPage);
        }

        private void UpdateSortOptions(bool isDoctor)
        {
            cboSort.SelectedIndexChanged -= Filter_SelectedIndexChanged;
            string? currentSort = cboSort.SelectedItem?.ToString();

            cboSort.Items.Clear();
            if (isDoctor)
            {
                cboSort.Items.Add("Mới nhất");
                cboSort.Items.Add("Giá khám thấp đến cao");
                cboSort.Items.Add("Giá khám cao đến thấp");
                cboSort.Items.Add("Năm kinh nghiệm cao đến thấp");
                cboSort.Items.Add("Rating cao đến thấp");
            }
            else
            {
                cboSort.Items.Add("Mới nhất");
                cboSort.Items.Add("Xem nhiều nhất");
                cboSort.Items.Add("Xem ít nhất");
            }

            if (!string.IsNullOrWhiteSpace(currentSort) && cboSort.Items.Contains(currentSort))
                cboSort.SelectedItem = currentSort;
            else
                cboSort.SelectedIndex = 0;

            cboSort.SelectedIndexChanged += Filter_SelectedIndexChanged;
        }

        private void DisplayDoctors(int page)
        {
            flpDoctors.SuspendLayout();
            
            // Dọn dẹp RAM trước khi tạo thẻ mới
            foreach (Control c in flpDoctors.Controls)
            {
                c.Dispose();
            }
            flpDoctors.Controls.Clear();

            int startIndex = (page - 1) * _pageSize;
            var items = _foundDoctors.Skip(startIndex).Take(_pageSize).ToList();

            string keyword = txtSearchBar.Text.Trim();
            if (keyword == "Nhập tên bác sĩ hoặc tiêu đề bài viết...") keyword = "";

            foreach (var doc in items)
            {
                UCCardDoctor card = new UCCardDoctor
                {
                    IsClickable = true,
                    Margin = new Padding(15)
                };
                card.SetDoctorData(doc, keyword);

                int containerWidth = flpDoctors.ClientSize.Width;
                if (containerWidth > 100)
                    card.Width = (containerWidth / 4) - 55;

                flpDoctors.Controls.Add(card);
            }

            UpdatePaginationUI(page, _foundDoctors.Count);
            flpDoctors.ResumeLayout();
        }

        private void DisplayArticles(int page)
        {
            flpArticles.SuspendLayout();

            // Dọn dẹp RAM trước khi tạo thẻ mới
            foreach (Control c in flpArticles.Controls)
            {
                c.Dispose();
            }
            flpArticles.Controls.Clear();

            int startIndex = (page - 1) * _pageSize;
            var items = _foundArticles.Skip(startIndex).Take(_pageSize).ToList();

            string keyword = txtSearchBar.Text.Trim();
            if (keyword == "Nhập tên bác sĩ hoặc tiêu đề bài viết...") keyword = "";

            foreach (var art in items)
            {
                UCCardArticle card = new UCCardArticle { Margin = new Padding(15) };
                card.SetData(art, keyword);

                int containerWidth = flpArticles.ClientSize.Width;
                if (containerWidth > 50)
                    card.Width = (containerWidth / 2) - 65;

                flpArticles.Controls.Add(card);
            }

            UpdatePaginationUI(page, _foundArticles.Count);
            flpArticles.ResumeLayout();
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string text = txtSearchBar.Text.Trim();
            if (text.Length < 2)
            {
                lstSuggestions.Visible = false;
                return;
            }

            var suggestions = _foundDoctors
                .Where(d => d.User?.FullName != null && d.User.FullName.Contains(text, StringComparison.OrdinalIgnoreCase))
                .Select(d => d.User!.FullName)
                .Concat(_foundArticles
                    .Where(a => a.Title != null && a.Title.Contains(text, StringComparison.OrdinalIgnoreCase))
                    .Select(a => a.Title))
                .Distinct()
                .Take(5)
                .ToList();

            if (suggestions.Any())
            {
                lstSuggestions.Items.Clear();
                foreach (var suggestion in suggestions) lstSuggestions.Items.Add(suggestion);

                lstSuggestions.Height = Math.Min(200, lstSuggestions.Items.Count * 25 + 5);
                lstSuggestions.Visible = true;
                lstSuggestions.BringToFront();
            }
            else
            {
                lstSuggestions.Visible = false;
            }
        }

        private void lstSuggestions_Click(object sender, EventArgs e)
        {
            if (lstSuggestions.SelectedItem == null) return;
            txtSearchBar.Text = lstSuggestions.SelectedItem.ToString();
            lstSuggestions.Visible = false;
            ExecuteSearch();
        }

        private void btnSearch_Click(object sender, EventArgs e) => ExecuteSearch();

        private void lblPrev_Click(object sender, EventArgs e)
        {
            if (_activeTab == tabDoc)
            {
                if (_currentDocPage > 1)
                {
                    _currentDocPage--;
                    DisplayDoctors(_currentDocPage);
                }
            }
            else if (_currentArtPage > 1)
            {
                _currentArtPage--;
                DisplayArticles(_currentArtPage);
            }
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            if (_activeTab == tabDoc)
            {
                int totalPages = (int)Math.Ceiling((double)_foundDoctors.Count / _pageSize);
                if (_currentDocPage < totalPages)
                {
                    _currentDocPage++;
                    DisplayDoctors(_currentDocPage);
                }
            }
            else
            {
                int totalPages = (int)Math.Ceiling((double)_foundArticles.Count / _pageSize);
                if (_currentArtPage < totalPages)
                {
                    _currentArtPage++;
                    DisplayArticles(_currentArtPage);
                }
            }
        }

        private void Filter_SelectedIndexChanged(object? sender, EventArgs e) => ExecuteSearch();
    }
}