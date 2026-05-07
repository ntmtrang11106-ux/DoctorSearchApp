using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace UI_Tier
{
    public partial class ucDoctor_Appointment : UserControl
    {
        public ucDoctor_Appointment()
        {
            InitializeComponent();

            UIHelper.ApplyRoundedRegion(btnAddTimeSlot, 10);

            // Tự động co giãn các card khi resize form
            flpAppItem.Resize += (s, e) => {
                foreach (Control ctrl in flpAppItem.Controls)
                {
                    if (ctrl is ucAppItem card)
                    {
                        card.Width = flpAppItem.ClientSize.Width - 40;
                    }
                }
            };
        }

        #region Xử lý phân trang (Pagination)
        private AppointmentBUS _bus = new AppointmentBUS();
        private List<AppointmentsDTO> _allApps = new List<AppointmentsDTO>();
        private int _pageSize = 10;     // Số lượng 1 trang
        private int _currentPage = 1;  // Trang hiện tại
        private int _doctorId = 0;

        public void SetDoctorId(int id)
        {
            _doctorId = id;
            InitData();
        }

        public void InitData()
        {
            try
            {
                if (_doctorId > 0)
                {
                    _allApps = _bus.GetAppointmentsByDoctorId(_doctorId);
                }
                else
                {
                    _allApps = _bus.GetAll();
                }
                _currentPage = 1; // Reset về trang 1
                DisplayPage(_currentPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void DisplayPage(int pageNumber)
        {
            flpAppItem.SuspendLayout(); // Tạm dừng vẽ giao diện

            while (flpAppItem.Controls.Count > 0)
            {
                var control = flpAppItem.Controls[0];
                flpAppItem.Controls.RemoveAt(0);
                control.Dispose();
            }

            if (_allApps == null || _allApps.Count == 0) return;

            int startIndex = (pageNumber - 1) * _pageSize;
            var pageItems = _allApps.Skip(startIndex).Take(_pageSize).ToList();

            foreach (var ap in pageItems)
            { 
                ucAppItem card = new ucAppItem();
                card.SetupCard(ap, ucAppItem.AppCardMode.DoctorView);
                card.Margin = new Padding(20, 10, 20, 10);
                
                // Ép chiều ngang Full Width (trừ đi 40px cho thanh cuộn và lề)
                card.Width = flpAppItem.ClientSize.Width - 40;
                card.Height = 252; 

                // CAN THIỆP BỐ CỤC ĐỂ KHỚP VỚI TIÊU ĐỀ
                var btnStatus = card.Controls.Find("btnStatus", true).FirstOrDefault();
                if (btnStatus != null) btnStatus.Location = new Point(1900, 95);


                var lblName = card.Controls.Find("lblName", true).FirstOrDefault();
                if (lblName != null) {
                    lblName.Location = new Point(380, 60);
                    lblName.MaximumSize = new Size(600, 0);
                }

                var lblSymptoms = card.Controls.Find("lblSymptoms", true).FirstOrDefault();
                if (lblSymptoms != null) lblSymptoms.Location = new Point(1117, 80);

                var label2 = card.Controls.Find("label2", true).FirstOrDefault();
                if (label2 != null) label2.Location = new Point(1013, 75);

                // THIẾT LẬP HANDLER
                card.RefreshData = () => InitData();
                card.AppointmentDeleted += (s, ev) => InitData();
                card.AppointmentEdited += (s, appData) => {
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

        private void btnAddTimeSlot_Click(object sender, EventArgs e)
        {
            var myDialog = new ucTimeSlotDialog();
            var mainForm = this.FindForm() as frmDoctor;
            if (mainForm != null)
            {
                mainForm.ShowOverlay(myDialog);
            }
        }
    }
}
