//using BUS_Tier;
//using DTO_Tier;
//using DAL_Tier;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;

//namespace UI_Tier
//{
//    public partial class ucPatient_Article : UserControl
//    {
//        public ucPatient_Article()
//        {
//            InitializeComponent();
//            UIHelper.SetDoubleBuffered(flpArticle); // Kích hoạt double buffering cho FlowLayoutPanel
//        }

//        // Khai báo một lần ở cấp độ class để tái sử dụng
//        private ArticleBUS _bus = new ArticleBUS();

//        private List<ArticlesDTO> _allArt = new List<ArticlesDTO>();
//        private int _pageSize = 10;     // Số lượng 1 trang
//        private int _currentPage = 1;  // Trang hiện tại

//        public void InitData()
//        {
//            try
//            {
//                _allArt = _bus.GetInitialArticles();
//                _currentPage = 1; // Reset về trang 1
//                DisplayPage(_currentPage);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi: " + ex.Message);
//            }
//        }

//        // Hàm này dùng để vẽ 10 appointmet lên FlowLayoutPanel dựa vào số trang
//        public void DisplayPage(int pageNumber)
//        {
//            flpArticle.SuspendLayout(); // Tạm dừng vẽ giao diện

//            while (flpArticle.Controls.Count > 0)
//            {
//                var control = flpArticle.Controls[0];
//                flpArticle.Controls.RemoveAt(0);
//                control.Dispose(); // Xóa hẳn khỏi bộ nhớ
//            }

//            if (_allArt == null || _allArt.Count == 0) return;
//            // Tính toán vị trí bắt đầu và kết thúc
//            int startIndex = (pageNumber - 1) * _pageSize;

//            // Lấy ra pagesize ông (hoặc ít hơn nếu là trang cuối)
//            var pageItems = _allArt.Skip(startIndex).Take(_pageSize).ToList();

//            foreach (var ap in pageItems)
//            {
//                UCCardArticle card = new UCCardArticle();
//                card.SetData(ap);
//                card.Margin = new Padding(20, 10, 20, 10);

//                // Ép chiều ngang UC = Chiều ngang Panel - (trừ đi 25~30 để chừa chỗ cho thanh cuộn)
//                // Thêm dòng này để nếu resize Form thì UC nó cũng co giãn theo (tùy chọn)
//                //card.Anchor = AnchorStyles.Left | AnchorStyles.Right;

//                flpArticle.Controls.Add(card);
//            }

//            // Cập nhật cái nhãn hiển thị số trang (ví dụ: Trang 1 / 10)
//            int totalPages = (int)Math.Ceiling((double)_allArt.Count / _pageSize);
//            lblPageStatus.Text = $"Trang {_currentPage} / {totalPages}";

//            flpArticle.ResumeLayout(); // Cho phép vẽ lại giao diện
//        }

//        private void lblPrev_Click(object sender, EventArgs e)
//        {
//            if (_currentPage > 1)
//            {
//                _currentPage--;
//                DisplayPage(_currentPage);
//            }
//        }

//        private void lblNext_Click(object sender, EventArgs e)
//        {
//            int totalPages = (int)Math.Ceiling((double)_allArt.Count / _pageSize);
//            if (_currentPage < totalPages)
//            {
//                _currentPage++;
//                DisplayPage(_currentPage);
//            }
//        }

//        private void ucPatient_Article_Load(object sender, EventArgs e)
//        {
//            InitData();
//        }
//    }
//}
