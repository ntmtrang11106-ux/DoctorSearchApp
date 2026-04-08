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
        // Khai báo một lần ở cấp độ class để tái sử dụng
        private DoctorBUS _bus = new DoctorBUS();

        private List<DoctorDTO> _allDoctors = new List<DoctorDTO>();
        private int _pageSize = 8;     // Số lượng 1 trang
        private int _currentPage = 1;  // Trang hiện tại

        public ucPatient_SearchDoc()
        {
            InitializeComponent();
        }

        public void InitData()
        {
            try
            {
                _allDoctors = _bus.GetListDoctors();
                _currentPage = 1; // Reset về trang 1
                DisplayPage(_currentPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Hàm này dùng để vẽ 8 ông bác sĩ lên FlowLayoutPanel dựa vào số trang
        public void DisplayPage(int pageNumber)
        {
            flpDoctors.Controls.Clear();

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
                card.SetDoctorData(doc, true);
                card.Margin = new Padding(15);
                flpDoctors.Controls.Add(card);
            }

            // Cập nhật cái nhãn hiển thị số trang (ví dụ: Trang 1 / 10)
            int totalPages = (int)Math.Ceiling((double)_allDoctors.Count / _pageSize);
            lblPageStatus.Text = $"Trang {_currentPage} / {totalPages}";
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
    }
}
