using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL_Tier;

namespace UI_Tier
{
    public partial class ucDoctor_Appointment : UserControl
    {
        public ucDoctor_Appointment()
        {
            InitializeComponent();

            UIHelper.ApplyRoundedRegion(btnAddTimeSlot, 10);
        }

        #region Xử lý phân trang (Pagination)
        // Khai báo một lần ở cấp độ class để tái sử dụng
        private AppointmentBUS _bus = new AppointmentBUS();

        private List<AppointmentsDTO> _allApps = new List<AppointmentsDTO>();
        private int _pageSize = 10;     // Số lượng 1 trang
        private int _currentPage = 1;  // Trang hiện tại

        public void InitData()
        {
            try
            {
                _allApps = _bus.GetAll();
                _currentPage = 1; // Reset về trang 1
                DisplayPage(_currentPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Hàm này dùng để vẽ 10 appointmet lên FlowLayoutPanel dựa vào số trang
        public void DisplayPage(int pageNumber)
        {
            flpAppItem.SuspendLayout(); // Tạm dừng vẽ giao diện

            while (flpAppItem.Controls.Count > 0)
            {
                var control = flpAppItem.Controls[0];
                flpAppItem.Controls.RemoveAt(0);
                control.Dispose(); // Xóa hẳn khỏi bộ nhớ
            }

            if (_allApps == null || _allApps.Count == 0) return;

            // Tính toán vị trí bắt đầu và kết thúc
            int startIndex = (pageNumber - 1) * _pageSize;

            // Lấy ra pagesize ông (hoặc ít hơn nếu là trang cuối)
            var pageItems = _allApps.Skip(startIndex).Take(_pageSize).ToList();

            foreach (var ap in pageItems)
            { 
                ucAppItem card = new ucAppItem();
                card.SetAppItemData(ap);
                card.Margin = new Padding(20, 10, 20, 10);
                // Ép chiều ngang UC = Chiều ngang Panel - (trừ đi 25~30 để chừa chỗ cho thanh cuộn)
                card.Width = flpAppItem.Width - 80;
                // Thêm dòng này để nếu resize Form thì UC nó cũng co giãn theo (tùy chọn)
                //card.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                
                flpAppItem.Controls.Add(card);
            }

            // Cập nhật cái nhãn hiển thị số trang (ví dụ: Trang 1 / 10)
            int totalPages = (int)Math.Ceiling((double)_allApps.Count / _pageSize);
            lblPageStatus.Text = $"Trang {_currentPage} / {totalPages}";

            flpAppItem.ResumeLayout(); // Cho phép vẽ lại giao diện
        }

        private void ucDoctor_Appointment_Load(object sender, EventArgs e)
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
            int totalPages = (int)Math.Ceiling((double)_allApps.Count / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }
        #endregion

        #region Xử lý thêm khung giờ mới cho bác sĩ

        private void btnAddTimeSlot_Click(object sender, EventArgs e)
        {
            // Khởi tạo UC hộp thoại của ông
            var myDialog = new ucTimeSlotDialog();

            // Tìm Form chính và gọi hàm hiện Overlay
            var mainForm = this.FindForm() as frmDoctor; // Thay 'MainForm' bằng tên class Form của ông
            if (mainForm != null)
            {
                mainForm.ShowOverlay(myDialog);
            }
        }

        #endregion
    }
}
