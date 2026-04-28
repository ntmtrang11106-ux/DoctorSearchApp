using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class frmGuest : Form
    {
        // 1. Khai báo BUS để tìm kiếm tổng hợp (Cái này Trang mới viết này)
        private SearchBUS _searchBUS = new SearchBUS();

        // Khai báo một lần ở cấp độ class để tái sử dụng
        private DoctorBUS _bus = new DoctorBUS();

        private ArticleBUS _articleBus = new ArticleBUS();

        private List<DoctorDTO> _allDoctors = new List<DoctorDTO>();
        private int _pageSize = 8;     // Số lượng 1 trang
        private int _currentPage = 1;  // Trang hiện tại

        public frmGuest()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);

            // Bo góc cho Button Đăng nhập
            UIHelper.ApplyRoundedRegion(btnLogin, 15);

        }


        // Override CreateParams để bật WS_EX_COMPOSITED, giúp giảm nhấp nháy khi vẽ lại Form
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // Hàm này gọi 1 lần lúc Load Form để lấy hết data từ DB về máy
        public void InitData()
        {
            try
            {
                // 1. Nạp Bác sĩ (Trang làm rồi)
                _allDoctors = _bus.GetListDoctors();
                DisplayPage(_currentPage);

                // 2. Nạp Bài viết (Mới thêm nè)
                // Gọi ArticleBUS để lấy dữ liệu ban đầu
                var initialArticles = _articleBus.GetInitialArticles();

                flpArticles.Controls.Clear();
                foreach (var art in initialArticles)
                {
                    UCCardArticle ucArt = new UCCardArticle();
                    ucArt.SetData(art);
                    // Gán Margin cho đẹp, đồng bộ với Card Bác sĩ
                    ucArt.Margin = new Padding(15);
                    flpArticles.Controls.Add(ucArt);
                }

                // Cập nhật số lượng lên tab cho chuyên nghiệp
                tabPage2.Text = $"Bài viết ({initialArticles.Count})";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        // Hàm này dùng để vẽ 8 ông bác sĩ lên FlowLayoutPanel dựa vào số trang
        public void DisplayPage(int pageNumber)
        {
            flpDoctors.SuspendLayout(); // Tạm dừng vẽ giao diện

            while (flpDoctors.Controls.Count > 0)
            {
                var control = flpDoctors.Controls[0];
                flpDoctors.Controls.RemoveAt(0);
                control.Dispose(); // Xóa hẳn khỏi bộ nhớ
            }

            if (_allDoctors == null || _allDoctors.Count == 0) return;

            // Tính toán vị trí bắt đầu và kết thúc
            // Trang 1: lấy từ 0 đến 7
            // Trang 2: lấy từ 8 đến 15
            int startIndex = (pageNumber - 1) * _pageSize;

            // Lấy ra 8 ông (hoặc ít hơn nếu là trang cuối)
            var pageItems = _allDoctors.Skip(startIndex).Take(_pageSize).ToList();

            foreach (var doc in pageItems)
            {
                UCCardDoctor card = new UCCardDoctor();
                card.SetDoctorData(doc);
                card.Margin = new Padding(25);
                flpDoctors.Controls.Add(card);
            }

            // Cập nhật cái nhãn hiển thị số trang (ví dụ: Trang 1 / 10)
            int totalPages = (int)Math.Ceiling((double)_allDoctors.Count / _pageSize);
            lblPageStatus.Text = $"Trang {_currentPage} / {totalPages}";

            flpDoctors.ResumeLayout(); // Cho phép vẽ lại giao diện
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo Form Login
            frmLogin loginForm = new frmLogin();

            // 2. Ẩn Form hiện tại (frmGuest)
            this.Hide();

            // 3. Hiển thị Form Login
            loginForm.ShowDialog();
            // Dùng ShowDialog để nó chặn không cho tương tác với Form cũ 
            // hoặc dùng loginForm.Show() nếu muốn mở tự do.

            // 4. (Tùy chọn) Sau khi đóng Login thì hiện lại Guest
            this.Show();
        }

        private void frmGuest_Load(object sender, EventArgs e)
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

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            // 1. Kiểm tra độ dài từ khóa
            if (txtSearchBar.Text.Trim().Length > 0 && txtSearchBar.Text.Trim().Length < 2)
            {
                // Hiện dấu chấm than đỏ báo lỗi
                errorProvider1.SetError(txtSearchBar, "Vui lòng nhập ít nhất 2 ký tự để tìm kiếm!");
                return; // Dừng lại không tìm kiếm
            }
            else
            {
                // Xóa dấu báo lỗi nếu đã nhập đủ hoặc để trống
                errorProvider1.SetError(txtSearchBar, "");
            }
        }

        private void txtSearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string keyword = txtSearchBar.Text.Trim();

                if (keyword.Length < 2 && keyword.Length > 0)
                {
                    errorProvider1.SetError(txtSearchBar, "Vui lòng nhập ít nhất 2 ký tự!");
                    return;
                }

                List<string> selectedSpecs = new List<string>();
                string gender = null;
                string sortDoc = "Rating";
                string sortArt = "Newest";

                ExecuteUI_Search(keyword, selectedSpecs, gender, sortDoc, sortArt);
            }
        } // <--- DẤU NGOẶC NÀY CỰC KỲ QUAN TRỌNG, PHẢI ĐÓNG Ở ĐÂY!

        // Bây giờ mới viết hàm ExecuteUI_Search nằm RIÊNG BIỆT ra ngoài
        private void ExecuteUI_Search(string key, List<string> specs, string gen, string sDoc, string sArt)
        {
            var result = _searchBUS.ExecuteIntegratedSearch(key, specs, gen, sDoc, sArt);

            List<DoctorDTO> doctors = result.doctors;
            List<ContentDTO> articles = result.contents;

            // Đổ Bác sĩ
            flpDoctors.Controls.Clear();
            foreach (var doc in doctors)
            {
                UCCardDoctor uc = new UCCardDoctor();
                uc.SetDoctorData(doc); // Dùng đúng tên hàm SetDoctorData của Trang nhé
                flpDoctors.Controls.Add(uc);
            }

            // Đổ Bài viết
            flpArticles.Controls.Clear();
            foreach (var art in articles)
            {
                UCCardArticle ucArt = new UCCardArticle();
                ucArt.SetData(art);
                flpArticles.Controls.Add(ucArt);
            }

            // Cập nhật Tab (Nhớ kiểm tra tên tabPage1, tabPage2 của Trang nhé)
            tabPage1.Text = $"Bác sĩ ({doctors.Count})";
            tabPage2.Text = $"Bài viết ({articles.Count})";
        }


    }
}
