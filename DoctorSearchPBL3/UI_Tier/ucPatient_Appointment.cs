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
    public partial class ucPatient_Appointment : UserControl
    {
        public ucPatient_Appointment()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(flpAppItem);

            // Hiệu ứng hover cho các nút phân trang
            lblPrev.MouseEnter += Pagination_MouseEnter;
            lblPrev.MouseLeave += Pagination_MouseLeave;
            lblNext.MouseEnter += Pagination_MouseEnter;
            lblNext.MouseLeave += Pagination_MouseLeave;
            
            lblPrev.Click += lblPrev_Click;
            lblNext.Click += lblNext_Click;

            lblPrev.Cursor = Cursors.Hand;
            lblNext.Cursor = Cursors.Hand;
        }
        // Khai báo một lần ở cấp độ class để tái sử dụng
        private AppointmentBUS _bus = new AppointmentBUS();

        private List<AppointmentsDTO> _allApps = new List<AppointmentsDTO>();
        private int _pageSize = 10;     // Số lượng 1 trang
        private int _currentPage = 1;  // Trang hiện tại

        private int _patientId = 0;

        public void SetPatientId(int id)
        {
            _patientId = id;
            InitData();
        }

        public void InitData()
        {
            try
            {
                int currentId = _patientId > 0 ? _patientId : GlobalAccount.GetProfileId();
                _allApps = _bus.GetAppointmentsByPatientId(currentId);
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
                card.SetupCard(ap, ucAppItem.AppCardMode.PatientView);
                card.Margin = new Padding(20, 10, 20, 10);

                // Ép chiều ngang Full Width (trừ đi 40px cho thanh cuộn và lề)
                card.Width = flpAppItem.ClientSize.Width - 40;
                card.Height = 252;

                // Thêm card vào danh sách mà không cần tìm kiếm control đệ quy
                // (Mọi layout sẽ được card tự xử lý hoặc thông qua SetupCard)
                
                // Thêm handler Xóa/Sửa
                card.AppointmentDeleted += (s, ev) => InitData();
                card.AppointmentEdited += (s, appData) => {
                    // Cần bác sĩ từ data của app
                    if (appData.Doctor == null) return;
                    ucBookingDialog editUc = new ucBookingDialog(appData.Doctor);
                    editUc.SetEditData(appData);

                    editUc.Location = new Point((this.Width - editUc.Width) / 2, (this.Height - editUc.Height) / 2);
                    editUc.AppointmentBooked += (s2, ev2) => InitData();
                    editUc.CloseRequested += (s2, ev2) => {
                        this.Controls.Remove(editUc);
                        editUc.Dispose();
                    };
                    this.Controls.Add(editUc);
                    editUc.BringToFront();
                };

                flpAppItem.Controls.Add(card);
            }

            // Cập nhật cái nhãn hiển thị số trang (ví dụ: Trang 1 / 10)
            int totalPages = (int)Math.Ceiling((double)_allApps.Count / _pageSize);
            lblPageStatus.Text = $"Trang {_currentPage} / {totalPages}";

            flpAppItem.ResumeLayout(); // Cho phép vẽ lại giao diện
        }

        private void ucPatient_Appointment_Load(object sender, EventArgs e)
        {
            InitData();

            this.Resize += (s, ev) =>
            {
                foreach (Control ctrl in flpAppItem.Controls)
                {
                    if (ctrl is ucAppItem card)
                    {
                        card.Width = flpAppItem.ClientSize.Width - 40;
                    }
                }
            };
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

        private void Pagination_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(0, 90, 158); // Xanh đậm hơn khi hover
                lbl.Top -= 2; // Hiệu ứng "nhấc lên"
            }
        }

        private void Pagination_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(0, 120, 212); // Trở lại màu chuẩn
                lbl.Top += 2;
            }
        }
    }
}
