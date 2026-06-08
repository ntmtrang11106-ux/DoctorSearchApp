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
            
            // Thiết lập chế độ cuộn mượt cho các panel danh sách bác sĩ, bài viết, chuyên khoa
            UIHelper.SetupScrollableContainer(flpDoctors);
            UIHelper.SetupScrollableContainer(flpArticles);
            UIHelper.SetupScrollableContainer(flpDepts);
            
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

        /// <summary>
        /// Cập nhật hiển thị trạng thái phân trang (Trang X / Y) và ẩn/hiện bảng điều khiển phân trang.
        /// </summary>
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

        /// <summary>
        /// Hiệu ứng di chuột vào nhãn phân trang (Đổi màu tối hơn và dịch chuyển lên trên 2px).
        /// </summary>
        private void PaginationLabel_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(0, 90, 158);
                lbl.Top -= 2;
            }
        }

        /// <summary>
        /// Hiệu ứng di chuột ra khỏi nhãn phân trang (Trả lại màu gốc và đưa về vị trí cũ).
        /// </summary>
        private void PaginationLabel_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(0, 120, 212);
                lbl.Top += 2;
            }
        }

        /// <summary>
        /// Khởi tạo các Tab tiêu đề chọn loại tìm kiếm: "Bác sĩ" hoặc "Bài viết".
        /// Tự động đăng ký sự kiện di chuột và Click cho Panel Tab và tất cả Control con bên trong Tab.
        /// </summary>
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

        /// <summary>
        /// Sự kiện Hover chuột lên Tab chưa hoạt động (đổi nền xám xanh nhạt để biểu thị có thể bấm).
        /// </summary>
        private void PanelTab_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is not Control ctrl)
            {
                return;
            }

            Panel pnl = ctrl as Panel ?? (Panel)ctrl.Parent!;
            if (pnl == _activeTab)
            {
                return;
            }

            pnl.BackColor = Color.FromArgb(240, 245, 255);
        }

        /// <summary>
        /// Trả lại nền mặc định khi chuột rời khỏi Tab.
        /// </summary>
        private void PanelTab_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is not Control ctrl)
            {
                return;
            }

            Panel pnl = ctrl as Panel ?? (Panel)ctrl.Parent!;
            if (pnl == _activeTab)
            {
                return;
            }

            pnl.BackColor = _normalBack;
        }

        /// <summary>
        /// Ẩn vùng tiêu đề chuyển đổi Tab (Dùng khi tích hợp vào các phân hệ chỉ cần tìm kiếm 1 loại).
        /// </summary>
        public void HideTabs()
        {
            pnlTabHeader.Visible = false;
        }

        /// <summary>
        /// Ẩn ô nhập thanh tìm kiếm và thu nhỏ chiều cao Header.
        /// </summary>
        public void HideSearchInput(bool hide)
        {
            pnlSearchBox.Visible = !hide;
            pnlHeader.Height = hide ? 60 : 130;
        }

        /// <summary>
        /// Cấu hình văn bản gợi ý (Placeholder) cho thanh tìm kiếm.
        /// </summary>
        public void SetPlaceholder(string text)
        {
            txtSearchBar.PlaceholderText = text;
        }

        /// <summary>
        /// Thiết lập cấu hình tìm kiếm dưới vai trò Quản trị viên (cho phép lọc trạng thái bài viết Nháp/Đã ẩn).
        /// </summary>
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

        /// <summary>
        /// Kích hoạt Tab tương ứng qua lập trình bên ngoài.
        /// </summary>
        public void SetActiveTab(bool isDoctor)
        {
            PanelTab_Click(isDoctor ? tabDoc : tabArt, EventArgs.Empty);
        }

        /// <summary>
        /// Xử lý sự kiện click chuyển Tab tìm kiếm.
        /// </summary>
        private void PanelTab_Click(object? sender, EventArgs e)
        {
            if (sender is not Control ctrl)
            {
                return;
            }

            Panel clicked = ctrl as Panel ?? (Panel)ctrl.Parent!;
            if (clicked == _activeTab)
            {
                return;
            }

            _activeTab = clicked;
            UpdateTabStyles(); // Cập nhật màu sắc chữ và nền
            DisplayResults();   // Render danh sách tương ứng
        }

        /// <summary>
        /// Cập nhật trực quan màu chữ và màu nền cho Tab đang được chọn (Active) và Tab tĩnh bình thường.
        /// </summary>
        private void UpdateTabStyles()
        {
            foreach (var tab in new[] { tabDoc, tabArt })
            {
                bool isActive = tab == _activeTab;
                tab.BackColor = isActive ? _activeBack : _normalBack;
                foreach (Control child in tab.Controls)
                {
                    if (child is Label lbl)
                    {
                        lbl.ForeColor = isActive ? _activeText : _normalText;
                    }
                }
            }
        }

        /// <summary>
        /// Khởi tạo ban đầu cho giao diện Tìm kiếm tích hợp (Bo góc, Nạp văn bản, Khai báo sự kiện phím nóng Enter).
        /// </summary>
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

            // Thiết lập con trỏ chuột dạng bàn tay (Cursors.Hand) cho nút Tìm kiếm chính
            btnSearch.Cursor = Cursors.Hand;

            // Kích hoạt nút Enter khi nhập ô Tìm kiếm để tìm kiếm nhanh
            txtSearchBar.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // Chặn tiếng bíp mặc định của Windows
                    ExecuteSearch();
                }
            };

            Load += (_, _) => ExecuteSearch();
            LoadDepartments();
        }

        /// <summary>
        /// Tải động danh sách các Chuyên khoa từ cơ sở dữ liệu lên FlowLayoutPanel dưới dạng các nút Chip (Check chọn).
        /// </summary>
        private void LoadDepartments()
        {
            var depts = _deptBus.GetDepartmentsForUI();
            flpDepts.Controls.Clear();
            flpDepts.BackColor = Color.White;
            flpDepts.Padding = new Padding(10);

            lblAdminStatus.Visible = false;
            cboAdminStatus.Visible = false;

            // Lắng nghe sự kiện co giãn khung chứa kết quả để tính toán lại số cột hiển thị cho thẻ
            flpArticles.Resize += (_, _) =>
            {
                if (_activeTab == tabArt)
                {
                    DisplayResults();
                }
            };
            flpDoctors.Resize += (_, _) =>
            {
                if (_activeTab == tabDoc)
                {
                    DisplayResults();
                }
            };

            // Nút "Tất cả chuyên khoa" mặc định ban đầu
            CheckBox chkAll = CreateChip("Tất cả chuyên khoa", "Tất cả");
            chkAll.Checked = true;
            flpDepts.Controls.Add(chkAll);
            UIHelper.ApplyRoundedRegion(chkAll, 15);

            // Nạp từng nút Chuyên khoa tương ứng
            foreach (var dept in depts)
            {
                CheckBox chk = CreateChip(dept.DepartmentName, dept.DepartmentName);
                flpDepts.Controls.Add(chk);
                UIHelper.ApplyRoundedRegion(chk, 15);
            }
        }

        /// <summary>
        /// Khởi tạo và thiết lập thuộc tính trực quan cho Nút Chuyên khoa (Chip) dạng CheckBox nút bấm phẳng.
        /// Thiết lập con trỏ chuột Cursors.Hand và logic kiểm tra lẫn nhau (Single Choice Chip).
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
                Font = new Font("Segoe UI", 14F),
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(64, 64, 64),
                Cursor = Cursors.Hand // Đặt con trỏ chuột bàn tay chỉ định bấm được
            };

            chk.FlatAppearance.BorderSize = 1;
            chk.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            chk.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 120, 212);
            chk.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 100, 180);
            chk.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);

            chk.CheckedChanged += (_, _) =>
            {
                if (_isUpdatingChips)
                {
                    return;
                }

                // Nếu check nút này thì uncheck toàn bộ các nút khác (Lựa chọn đơn độc lập)
                if (chk.Checked)
                {
                    _isUpdatingChips = true;
                    foreach (Control ctrl in flpDepts.Controls)
                    {
                        if (ctrl is CheckBox other && other != chk)
                        {
                            other.Checked = false;
                            other.ForeColor = Color.FromArgb(64, 64, 64);
                        }
                    }
                    _isUpdatingChips = false;
                }
                else
                {
                    // Nếu uncheck nút này mà không còn nút nào được check, tự động check lại nút "Tất cả"
                    bool anyChecked = flpDepts.Controls.OfType<CheckBox>().Any(other => other.Checked);
                    if (!anyChecked)
                    {
                        _isUpdatingChips = true;
                        foreach (Control ctrl in flpDepts.Controls)
                        {
                            if (ctrl is CheckBox other && string.Equals(other.Tag?.ToString(), "Tất cả", StringComparison.Ordinal))
                            {
                                other.Checked = true;
                                other.ForeColor = Color.White;
                                break;
                            }
                        }
                        _isUpdatingChips = false;
                    }
                }

                // Đổi màu chữ khi được check (Chữ trắng) và khi không được check (Chữ xám)
                chk.ForeColor = chk.Checked ? Color.White : Color.FromArgb(64, 64, 64);
                
                // Thực hiện tìm kiếm lại theo bộ lọc chuyên khoa mới chọn
                ExecuteSearch();
            };

            return chk;
        }

        /// <summary>
        /// Thực thi lấy dữ liệu tìm kiếm tích hợp từ BUS dựa trên các bộ lọc (Keyword, Chuyên khoa, Giới tính, Loại bài viết, Sắp xếp, Trạng thái Admin).
        /// </summary>
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

            // Thu thập các chuyên khoa được chọn (nếu chọn "Tất cả" thì mảng trống để hiển thị mọi chuyên khoa)
            List<string> selectedDepts = flpDepts.Controls
                .OfType<CheckBox>()
                .Where(chk => chk.Checked)
                .Select(chk => chk.Tag?.ToString())
                .Where(tag => !string.IsNullOrWhiteSpace(tag))
                .Select(tag => tag!)
                .ToList();

            // Ẩn bảng gợi ý từ khóa thông minh sau khi thực thi tìm kiếm
            lstSuggestions.Visible = false;

            // Xác định trạng thái lọc của bài viết
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

            // Gọi BUS thực hiện lọc tích hợp dưới Database
            var results = _searchBus.ExecuteIntegratedSearch(keyword, selectedDepts, gender, contentType, sort, status);
            _foundDoctors = results.doctors;
            _foundArticles = results.contents;
            
            // Đưa phân trang về trang 1
            _currentDocPage = 1;
            _currentArtPage = 1;

            // Làm mới tiêu đề số lượng kết quả trên Tab và render lại UI
            UpdateTabTitles();
            DisplayResults();
        }

        /// <summary>
        /// Cập nhật hiển thị số lượng phần tử tìm thấy vào tiêu đề Tab Bác sĩ và Bài viết.
        /// </summary>
        private void UpdateTabTitles()
        {
            lblDocText.Text = $"Bác sĩ ({_foundDoctors.Count})";
            lblArtText.Text = $"Bài viết ({_foundArticles.Count})";
        }

        /// <summary>
        /// Điều phối render kết quả dựa trên Tab hiện tại đang được kích hoạt.
        /// Đồng thời ẩn/hiện bộ lọc phù hợp (Bộ lọc Giới tính cho Bác sĩ, bộ lọc loại/trạng thái cho Bài viết).
        /// </summary>
        public void DisplayResults()
        {
            bool isDoctorTab = _activeTab == tabDoc;

            // Bộ lọc giới tính chỉ hiện ở Tab bác sĩ
            cboGender.Visible = isDoctorTab;
            labelGender.Visible = isDoctorTab;

            // Bộ lọc loại bài viết chỉ hiện ở Tab bài viết
            cboContentType.Visible = !isDoctorTab;
            labelContentType.Visible = !isDoctorTab;

            // Bộ lọc trạng thái nháp chỉ hiện ở bài viết dưới tài khoản Admin
            lblAdminStatus.Visible = _isAdmin && !isDoctorTab;
            cboAdminStatus.Visible = _isAdmin && !isDoctorTab;

            // Thay đổi bộ tiêu chí sắp xếp phù hợp
            UpdateSortOptions(isDoctorTab);

            // Ẩn hiện luân phiên FlowLayoutPanel kết quả tương ứng
            flpDoctors.Visible = isDoctorTab;
            flpArticles.Visible = !isDoctorTab;

            if (isDoctorTab)
            {
                DisplayDoctors(_currentDocPage);
            }
            else
            {
                DisplayArticles(_currentArtPage);
            }
        }

        /// <summary>
        /// Thay đổi các tùy chọn sắp xếp trong ComboBox `cboSort` theo từng phân hệ Tab.
        /// </summary>
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

            // Đồng bộ lại lựa chọn trước đó của người dùng nếu còn khả dụng trong bộ lọc mới
            if (!string.IsNullOrWhiteSpace(currentSort) && cboSort.Items.Contains(currentSort))
            {
                cboSort.SelectedItem = currentSort;
            }
            else
            {
                cboSort.SelectedIndex = 0;
            }

            cboSort.SelectedIndexChanged += Filter_SelectedIndexChanged;
        }

        /// <summary>
        /// Tạo lập các Card bác sĩ (`UCCardDoctor`) động đưa vào FlowLayoutPanel dựa trên trang hiện tại.
        /// Tự động tính toán độ rộng Card tỉ lệ theo kích thước FlowLayoutPanel.
        /// </summary>
        private void DisplayDoctors(int page)
        {
            flpDoctors.SuspendLayout(); // Tạm khóa vẽ lại để tránh giật hình khi render hàng loạt
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

                // Tính toán chiều rộng động cho Card chia làm 4 cột (Responsive nhẹ dựa trên kích thước panel chứa)
                int containerWidth = flpDoctors.ClientSize.Width;
                if (containerWidth > 100)
                {
                    card.Width = (containerWidth / 4) - 55;
                }

                flpDoctors.Controls.Add(card);
            }

            // Làm mới giao diện điều hướng phân trang
            UpdatePaginationUI(page, _foundDoctors.Count);
            flpDoctors.ResumeLayout();
        }

        /// <summary>
        /// Tạo lập các Card bài viết (`UCCardArticle`) động đưa vào FlowLayoutPanel dựa trên trang hiện tại.
        /// </summary>
        private void DisplayArticles(int page)
        {
            flpArticles.SuspendLayout(); // Tạm khóa vẽ lại
            flpArticles.Controls.Clear();

            int startIndex = (page - 1) * _pageSize;
            var items = _foundArticles.Skip(startIndex).Take(_pageSize).ToList();

            string keyword = txtSearchBar.Text.Trim();
            if (keyword == "Nhập tên bác sĩ hoặc tiêu đề bài viết...") keyword = "";

            foreach (var art in items)
            {
                UCCardArticle card = new UCCardArticle
                {
                    Margin = new Padding(15)
                };
                card.SetData(art, keyword);

                // Tính toán chiều rộng động cho Card bài viết chia làm 2 cột
                int containerWidth = flpArticles.ClientSize.Width;
                if (containerWidth > 50)
                {
                    card.Width = (containerWidth / 2) - 65;
                }

                flpArticles.Controls.Add(card);
            }

            // Làm mới giao diện điều hướng phân trang
            UpdatePaginationUI(page, _foundArticles.Count);
            flpArticles.ResumeLayout();
        }

        /// <summary>
        /// Xử lý sự kiện TextChanged của thanh tìm kiếm.
        /// Lọc nhanh các gợi ý khớp từ khóa hiện tại hiển thị lên bảng gợi ý thông minh (`lstSuggestions`).
        /// </summary>
        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string text = txtSearchBar.Text.Trim();
            if (text.Length < 2)
            {
                lstSuggestions.Visible = false;
                return;
            }

            // Lấy tối đa 5 từ khóa gợi ý trùng khớp từ danh sách tên bác sĩ và bài viết có sẵn
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
                foreach (var suggestion in suggestions)
                {
                    lstSuggestions.Items.Add(suggestion);
                }

                // Căn chỉnh động chiều cao bảng gợi ý dựa trên số lượng phần tử
                lstSuggestions.Height = Math.Min(200, lstSuggestions.Items.Count * 25 + 5);
                lstSuggestions.Visible = true;
                lstSuggestions.BringToFront();
            }
            else
            {
                lstSuggestions.Visible = false;
            }
        }

        /// <summary>
        /// Chọn từ gợi ý thông minh: Điền từ khóa được chọn vào ô tìm kiếm và thực thi tìm kiếm tức thì.
        /// </summary>
        private void lstSuggestions_Click(object sender, EventArgs e)
        {
            if (lstSuggestions.SelectedItem == null)
            {
                return;
            }

            txtSearchBar.Text = lstSuggestions.SelectedItem.ToString();
            lstSuggestions.Visible = false;
            ExecuteSearch();
        }

        /// <summary>
        /// Xử lý click nút tìm kiếm chính.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        /// <summary>
        /// Quay về trang kết quả trước đó.
        /// </summary>
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

        /// <summary>
        /// Chuyển tiếp sang trang kết quả tiếp theo.
        /// </summary>
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

        /// <summary>
        /// Khi thay đổi bất kỳ bộ lọc ComboBox nào, tự động kích hoạt tìm kiếm lại.
        /// </summary>
        private void Filter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ExecuteSearch();
        }
    }
}
