using BUS_Tier;
using DTO_Tier;

namespace UI_Tier
{
    public class ucSearchWorkspace : UserControl
    {
        private readonly SearchBUS _searchBus = new SearchBUS();
        private readonly DepartmentBUS _departmentBus = new DepartmentBUS();

        private readonly TabControl _tabs = new TabControl();
        private readonly TabPage _doctorTab = new TabPage("Bác sĩ");
        private readonly TabPage _contentTab = new TabPage("Bài viết");

        private readonly TextBox _txtDoctorKeyword = new TextBox();
        private readonly CheckedListBox _clbDoctorDepartments = new CheckedListBox();
        private readonly ComboBox _cboDoctorGender = new ComboBox();
        private readonly ComboBox _cboDoctorSort = new ComboBox();
        private readonly Button _btnDoctorSearch = new Button();
        private readonly Button _btnDoctorReset = new Button();
        private readonly Label _lblDoctorStatus = new Label();
        private readonly FlowLayoutPanel _flpDoctors = new FlowLayoutPanel();

        private readonly TextBox _txtContentKeyword = new TextBox();
        private readonly CheckedListBox _clbContentDepartments = new CheckedListBox();
        private readonly ComboBox _cboContentType = new ComboBox();
        private readonly ComboBox _cboContentSort = new ComboBox();
        private readonly Button _btnContentSearch = new Button();
        private readonly Button _btnContentReset = new Button();
        private readonly Label _lblContentStatus = new Label();
        private readonly FlowLayoutPanel _flpContents = new FlowLayoutPanel();

        public ucSearchWorkspace()
        {
            BackColor = Color.White;
            Dock = DockStyle.Fill;

            BuildLayout();
            WireEvents();
            Load += ucSearchWorkspace_Load;
        }

        private void ucSearchWorkspace_Load(object? sender, EventArgs e)
        {
            LoadDepartments();
            ResetDoctorFilters();
            ResetContentFilters();
            RunDoctorSearch();
            RunContentSearch();
        }

        private void BuildLayout()
        {
            _tabs.Dock = DockStyle.Fill;
            _tabs.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            BuildDoctorTab();
            BuildContentTab();

            _tabs.TabPages.Add(_doctorTab);
            _tabs.TabPages.Add(_contentTab);
            Controls.Add(_tabs);
        }

        private void BuildDoctorTab()
        {
            var layout = CreateTabLayout();
            var filterPanel = CreateDoctorFilterPanel();

            _flpDoctors.Dock = DockStyle.Fill;
            _flpDoctors.AutoScroll = true;
            _flpDoctors.WrapContents = true;
            _flpDoctors.Padding = new Padding(12);

            layout.Controls.Add(filterPanel, 0, 0);
            layout.Controls.Add(_lblDoctorStatus, 0, 1);
            layout.Controls.Add(_flpDoctors, 0, 2);

            _lblDoctorStatus.Dock = DockStyle.Fill;
            _lblDoctorStatus.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            _lblDoctorStatus.Padding = new Padding(16, 4, 16, 4);

            _doctorTab.Controls.Add(layout);
        }

        private void BuildContentTab()
        {
            var layout = CreateTabLayout();
            var filterPanel = CreateContentFilterPanel();

            _flpContents.Dock = DockStyle.Fill;
            _flpContents.AutoScroll = true;
            _flpContents.WrapContents = true;
            _flpContents.Padding = new Padding(12);

            layout.Controls.Add(filterPanel, 0, 0);
            layout.Controls.Add(_lblContentStatus, 0, 1);
            layout.Controls.Add(_flpContents, 0, 2);

            _lblContentStatus.Dock = DockStyle.Fill;
            _lblContentStatus.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            _lblContentStatus.Padding = new Padding(16, 4, 16, 4);

            _contentTab.Controls.Add(layout);
        }

        private static TableLayoutPanel CreateTabLayout()
        {
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.White
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 185));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            return layout;
        }

        private Panel CreateDoctorFilterPanel()
        {
            var panel = CreateFilterPanel();

            ConfigureSearchTextBox(_txtDoctorKeyword, "Tìm bác sĩ theo tên...");
            ConfigureCheckedListBox(_clbDoctorDepartments);
            ConfigureComboBox(_cboDoctorGender, new[] { "Tất cả", "Nam", "Nữ" });
            ConfigureComboBox(_cboDoctorSort, new[]
            {
                "Rating cao đến thấp",
                "Giá khám thấp đến cao",
                "Giá khám cao đến thấp",
                "Năm kinh nghiệm cao đến thấp"
            });
            ConfigureActionButton(_btnDoctorSearch, "Tìm");
            ConfigureSecondaryButton(_btnDoctorReset, "Đặt lại");

            AddControl(panel, CreateLabel("Từ khóa"), 16, 16, 110, 30);
            AddControl(panel, _txtDoctorKeyword, 16, 48, 360, 40);
            AddControl(panel, CreateLabel("Chuyên khoa"), 400, 16, 150, 30);
            AddControl(panel, _clbDoctorDepartments, 400, 48, 290, 110);
            AddControl(panel, CreateLabel("Giới tính"), 720, 16, 120, 30);
            AddControl(panel, _cboDoctorGender, 720, 48, 180, 40);
            AddControl(panel, CreateLabel("Sắp xếp"), 930, 16, 120, 30);
            AddControl(panel, _cboDoctorSort, 930, 48, 280, 40);
            AddControl(panel, _btnDoctorSearch, 1240, 48, 120, 40);
            AddControl(panel, _btnDoctorReset, 1375, 48, 120, 40);

            return panel;
        }

        private Panel CreateContentFilterPanel()
        {
            var panel = CreateFilterPanel();

            ConfigureSearchTextBox(_txtContentKeyword, "Tìm bài viết theo tiêu đề...");
            ConfigureCheckedListBox(_clbContentDepartments);
            ConfigureComboBox(_cboContentType, new[]
            {
                "Tất cả",
                "HospitalNotice",
                "ProcedureGuide",
                "DepartmentGuide",
                "HealthArticle"
            });
            ConfigureComboBox(_cboContentSort, new[]
            {
                "Mới nhất",
                "Xem nhiều nhất",
                "Xem ít nhất"
            });
            ConfigureActionButton(_btnContentSearch, "Tìm");
            ConfigureSecondaryButton(_btnContentReset, "Đặt lại");

            AddControl(panel, CreateLabel("Từ khóa"), 16, 16, 110, 30);
            AddControl(panel, _txtContentKeyword, 16, 48, 360, 40);
            AddControl(panel, CreateLabel("Chuyên khoa"), 400, 16, 150, 30);
            AddControl(panel, _clbContentDepartments, 400, 48, 290, 110);
            AddControl(panel, CreateLabel("Kiểu bài viết"), 720, 16, 160, 30);
            AddControl(panel, _cboContentType, 720, 48, 220, 40);
            AddControl(panel, CreateLabel("Sắp xếp"), 970, 16, 120, 30);
            AddControl(panel, _cboContentSort, 970, 48, 240, 40);
            AddControl(panel, _btnContentSearch, 1240, 48, 120, 40);
            AddControl(panel, _btnContentReset, 1375, 48, 120, 40);

            return panel;
        }

        private static Panel CreateFilterPanel()
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.AliceBlue,
                Padding = new Padding(10)
            };
        }

        private void WireEvents()
        {
            _btnDoctorSearch.Click += (_, _) => RunDoctorSearch();
            _btnDoctorReset.Click += (_, _) =>
            {
                ResetDoctorFilters();
                RunDoctorSearch();
            };
            _btnContentSearch.Click += (_, _) => RunContentSearch();
            _btnContentReset.Click += (_, _) =>
            {
                ResetContentFilters();
                RunContentSearch();
            };
            _txtDoctorKeyword.KeyDown += SearchTextBox_KeyDown;
            _txtContentKeyword.KeyDown += SearchTextBox_KeyDown;
        }

        private void SearchTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.SuppressKeyPress = true;

            if (ReferenceEquals(sender, _txtDoctorKeyword))
            {
                RunDoctorSearch();
                return;
            }

            if (ReferenceEquals(sender, _txtContentKeyword))
            {
                RunContentSearch();
            }
        }

        private void LoadDepartments()
        {
            var departments = _departmentBus.GetDepartmentsForUI();

            _clbDoctorDepartments.Items.Clear();
            _clbContentDepartments.Items.Clear();

            foreach (var department in departments)
            {
                _clbDoctorDepartments.Items.Add(department.DepartmentName);
                _clbContentDepartments.Items.Add(department.DepartmentName);
            }
        }

        private void ResetDoctorFilters()
        {
            _txtDoctorKeyword.Clear();
            ResetCheckedList(_clbDoctorDepartments);
            _cboDoctorGender.SelectedIndex = 0;
            _cboDoctorSort.SelectedIndex = 0;
        }

        private void ResetContentFilters()
        {
            _txtContentKeyword.Clear();
            ResetCheckedList(_clbContentDepartments);
            _cboContentType.SelectedIndex = 0;
            _cboContentSort.SelectedIndex = 0;
        }

        private void RunDoctorSearch()
        {
            _lblDoctorStatus.Text = "Đang tải dữ liệu bác sĩ...";
            Application.DoEvents();

            var doctors = _searchBus.ExecuteDoctorOnlySearch(
                _txtDoctorKeyword.Text.Trim(),
                GetSelectedDepartments(_clbDoctorDepartments),
                _cboDoctorGender.SelectedItem?.ToString(),
                _cboDoctorSort.SelectedItem?.ToString());

            _flpDoctors.SuspendLayout();
            _flpDoctors.Controls.Clear();

            foreach (var doctor in doctors)
            {
                var card = new UCCardDoctor();
                card.SetDoctorData(doctor);
                card.Margin = new Padding(12);
                _flpDoctors.Controls.Add(card);
            }

            _flpDoctors.ResumeLayout();
            _lblDoctorStatus.Text = doctors.Count == 0
                ? "Không có kết quả bác sĩ."
                : $"Có {doctors.Count} kết quả bác sĩ.";
        }

        private void RunContentSearch()
        {
            _lblContentStatus.Text = "Đang tải dữ liệu bài viết...";
            Application.DoEvents();

            var contents = _searchBus.ExecuteContentOnlySearch(
                _txtContentKeyword.Text.Trim(),
                GetSelectedDepartments(_clbContentDepartments),
                _cboContentSort.SelectedItem?.ToString(),
                _cboContentType.SelectedItem?.ToString());

            _flpContents.SuspendLayout();
            _flpContents.Controls.Clear();

            foreach (var content in contents)
            {
                var card = new UCCardArticle();
                card.SetData(content);
                card.Margin = new Padding(12);
                _flpContents.Controls.Add(card);
            }

            _flpContents.ResumeLayout();
            _lblContentStatus.Text = contents.Count == 0
                ? "Không có kết quả bài viết."
                : $"Có {contents.Count} kết quả bài viết.";
        }

        private static List<string> GetSelectedDepartments(CheckedListBox listBox)
        {
            return listBox.CheckedItems
                .Cast<object>()
                .Select(item => item.ToString())
                .Where(text => !string.IsNullOrWhiteSpace(text))
                .Select(text => text!)
                .ToList();
        }

        private static void ResetCheckedList(CheckedListBox listBox)
        {
            for (var i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemChecked(i, false);
            }
        }

        private static Label CreateLabel(string text)
        {
            return new Label
            {
                AutoSize = false,
                Text = text,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private static void ConfigureSearchTextBox(TextBox textBox, string placeholder)
        {
            textBox.Font = new Font("Segoe UI", 11F);
            textBox.PlaceholderText = placeholder;
        }

        private static void ConfigureCheckedListBox(CheckedListBox listBox)
        {
            listBox.CheckOnClick = true;
            listBox.Font = new Font("Segoe UI", 9.5F);
            listBox.IntegralHeight = false;
        }

        private static void ConfigureComboBox(ComboBox comboBox, IEnumerable<string> items)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Font = new Font("Segoe UI", 10F);
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items.Cast<object>().ToArray());
            comboBox.SelectedIndex = comboBox.Items.Count > 0 ? 0 : -1;
        }

        private static void ConfigureActionButton(Button button, string text)
        {
            button.Text = text;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.BackColor = Color.FromArgb(24, 112, 255);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }

        private static void ConfigureSecondaryButton(Button button, string text)
        {
            button.Text = text;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.BackColor = Color.White;
            button.ForeColor = Color.FromArgb(24, 112, 255);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.FromArgb(24, 112, 255);
            button.FlatAppearance.BorderSize = 1;
        }

        private static void AddControl(Control parent, Control control, int left, int top, int width, int height)
        {
            control.Left = left;
            control.Top = top;
            control.Width = width;
            control.Height = height;
            parent.Controls.Add(control);
        }
    }
}
