using BUS_Tier;
using DTO_Tier;

namespace UI_Tier
{
    public partial class frmGuest : Form
    {
        private readonly SearchBUS _searchBUS = new SearchBUS();
        private readonly DoctorBUS _doctorBus = new DoctorBUS();
        private readonly ContentBUS _contentBus = new ContentBUS();
        private readonly DepartmentBUS _departmentBus = new DepartmentBUS();

        private readonly CheckedListBox _clbGuestDepartments = new CheckedListBox();
        private readonly ComboBox _cboGuestGender = new ComboBox();
        private readonly ComboBox _cboGuestDoctorSort = new ComboBox();
        private readonly ComboBox _cboGuestContentSort = new ComboBox();

        private List<DoctorDTO> _allDoctors = new();
        private readonly int _pageSize = 8;
        private int _currentPage = 1;

        public frmGuest()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.ApplyRoundedRegion(btnLogin, 15);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void frmGuest_Load(object sender, EventArgs e)
        {
            BuildGuestFilters();
            InitData();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        public void InitData()
        {
            try
            {
                _allDoctors = _doctorBus.GetListDoctors();
                _currentPage = 1;
                DisplayPage(_currentPage);

                var initialContents = _contentBus.GetInitialContents();
                flpArticles.Controls.Clear();

                foreach (var content in initialContents)
                {
                    var card = new UCCardArticle();
                    card.SetData(content);
                    card.Margin = new Padding(15);
                    flpArticles.Controls.Add(card);
                }

                tabPage1.Text = $"Bác sĩ ({_allDoctors.Count})";
                tabPage2.Text = $"Bài viết ({initialContents.Count})";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        public void DisplayPage(int pageNumber)
        {
            flpDoctors.SuspendLayout();

            while (flpDoctors.Controls.Count > 0)
            {
                var control = flpDoctors.Controls[0];
                flpDoctors.Controls.RemoveAt(0);
                control.Dispose();
            }

            if (_allDoctors.Count == 0)
            {
                lblPageStatus.Text = "Trang 0 / 0";
                flpDoctors.ResumeLayout();
                return;
            }

            int startIndex = (pageNumber - 1) * _pageSize;
            var pageItems = _allDoctors.Skip(startIndex).Take(_pageSize).ToList();

            foreach (var doctor in pageItems)
            {
                var card = new UCCardDoctor();
                card.SetDoctorData(doctor);
                card.Margin = new Padding(25);
                flpDoctors.Controls.Add(card);
            }

            int totalPages = (int)Math.Ceiling((double)_allDoctors.Count / _pageSize);
            lblPageStatus.Text = $"Trang {_currentPage} / {totalPages}";
            flpDoctors.ResumeLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginForm = new frmLogin();
            Hide();
            loginForm.ShowDialog();
            Show();
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

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchBar.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                errorProvider1.SetError(txtSearchBar, "");
                RunGuestSearch();
                return;
            }

            if (keyword.Length >= 2)
            {
                errorProvider1.SetError(txtSearchBar, "");
                RunGuestSearch();
            }
            else
            {
                errorProvider1.SetError(txtSearchBar, "Vui lòng nhập ít nhất 2 ký tự!");
            }
        }

        private void txtSearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.SuppressKeyPress = true;
            string keyword = txtSearchBar.Text.Trim();

            if (keyword.Length is > 0 and < 2)
            {
                errorProvider1.SetError(txtSearchBar, "Vui lòng nhập ít nhất 2 ký tự!");
                return;
            }

            RunGuestSearch();
        }

        private void ExecuteUI_Search(
            string keyword,
            List<string> departments,
            string gender,
            string doctorSort,
            string contentSort)
        {
            var result = _searchBUS.ExecuteIntegratedSearch(
                keyword,
                departments,
                gender,
                doctorSort,
                contentSort);

            _allDoctors = result.doctors;
            _currentPage = 1;
            DisplayPage(_currentPage);

            flpArticles.Controls.Clear();
            foreach (var content in result.contents)
            {
                var card = new UCCardArticle();
                card.SetData(content);
                card.Margin = new Padding(15);
                flpArticles.Controls.Add(card);
            }

            tabPage1.Text = $"Bác sĩ ({result.doctors.Count})";
            tabPage2.Text = $"Bài viết ({result.contents.Count})";
        }

        private void BuildGuestFilters()
        {
            flpFilter.SuspendLayout();
            flpFilter.Controls.Clear();
            flpFilter.WrapContents = false;
            flpFilter.AutoScroll = true;

            ConfigureDepartmentFilter();
            ConfigureCombo(_cboGuestGender, new[] { "Tất cả", "Nam", "Nữ" });
            ConfigureCombo(_cboGuestDoctorSort, new[]
            {
                "Rating cao đến thấp",
                "Giá khám thấp đến cao",
                "Giá khám cao đến thấp",
                "Năm kinh nghiệm cao đến thấp"
            });
            ConfigureCombo(_cboGuestContentSort, new[]
            {
                "Mới nhất",
                "Xem nhiều nhất",
                "Xem ít nhất"
            });

            flpFilter.Controls.Add(CreateFilterPanel("Chuyên khoa", _clbGuestDepartments, 320));
            flpFilter.Controls.Add(CreateFilterPanel("Giới tính", _cboGuestGender, 180));
            flpFilter.Controls.Add(CreateFilterPanel("Sort bác sĩ", _cboGuestDoctorSort, 260));
            flpFilter.Controls.Add(CreateFilterPanel("Sort bài viết", _cboGuestContentSort, 220));

            _clbGuestDepartments.ItemCheck += (_, _) => BeginInvoke(new Action(RunGuestSearch));
            _cboGuestGender.SelectedIndexChanged += (_, _) => RunGuestSearch();
            _cboGuestDoctorSort.SelectedIndexChanged += (_, _) => RunGuestSearch();
            _cboGuestContentSort.SelectedIndexChanged += (_, _) => RunGuestSearch();

            flpFilter.ResumeLayout();
        }

        private void ConfigureDepartmentFilter()
        {
            _clbGuestDepartments.Items.Clear();
            _clbGuestDepartments.CheckOnClick = true;
            _clbGuestDepartments.Font = new Font("Segoe UI", 9.5F);
            _clbGuestDepartments.IntegralHeight = false;
            _clbGuestDepartments.Height = 88;

            foreach (var department in _departmentBus.GetDepartmentsForUI())
            {
                _clbGuestDepartments.Items.Add(department.DepartmentName);
            }
        }

        private static void ConfigureCombo(ComboBox comboBox, IEnumerable<string> items)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Font = new Font("Segoe UI", 10F);
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items.Cast<object>().ToArray());
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        private static Panel CreateFilterPanel(string title, Control control, int width)
        {
            var panel = new Panel
            {
                Width = width,
                Height = 100,
                Margin = new Padding(10, 6, 10, 6)
            };

            var label = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                AutoSize = false,
                Width = width,
                Height = 24,
                Location = new Point(0, 0)
            };

            control.Width = width;
            control.Location = new Point(0, 30);
            if (control is ComboBox combo)
            {
                combo.Height = 40;
            }

            panel.Controls.Add(label);
            panel.Controls.Add(control);
            return panel;
        }

        private void RunGuestSearch()
        {
            var keyword = txtSearchBar.Text.Trim();
            var selectedDepartments = _clbGuestDepartments.CheckedItems
                .Cast<object>()
                .Select(item => item.ToString())
                .Where(text => !string.IsNullOrWhiteSpace(text))
                .Select(text => text!)
                .ToList();

            var gender = _cboGuestGender.SelectedItem?.ToString() ?? "Tất cả";
            var doctorSort = _cboGuestDoctorSort.SelectedItem?.ToString() ?? "Rating cao đến thấp";
            var contentSort = _cboGuestContentSort.SelectedItem?.ToString() ?? "Mới nhất";

            if (string.IsNullOrWhiteSpace(keyword) &&
                selectedDepartments.Count == 0 &&
                gender == "Tất cả" &&
                doctorSort == "Rating cao đến thấp" &&
                contentSort == "Mới nhất")
            {
                InitData();
                return;
            }

            ExecuteUI_Search(keyword, selectedDepartments, gender, doctorSort, contentSort);
        }
    }
}
