using DTO_Tier;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucAdmin_TimeSlotDetailsDialog : UserControl
    {
        public event EventHandler OnCloseModal;
        private TimeSlotsDTO _timeSlot;

        public ucAdmin_TimeSlotDetailsDialog()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(flpPatients);
        }

        public void SetupData(TimeSlotsDTO timeSlot)
        {
            _timeSlot = timeSlot;
            
            lblTitle.Text = $"Chi tiết bệnh nhân - Phòng {timeSlot.Room?.RoomCode ?? "N/A"}";
            lblDate.Text = $"{timeSlot.WorkDate:dd/MM/yyyy} | {timeSlot.StartTime:hh\\:mm} - {timeSlot.EndTime:hh\\:mm}";
            
            string docPos = timeSlot.Doctor?.Position ?? "BS.";
            string docName = timeSlot.Doctor?.User?.FullName ?? "N/A";
            lblDoctor.Text = docName.StartsWith(docPos, StringComparison.OrdinalIgnoreCase) ? docName : $"{docPos} {docName}";

            LoadPatients();
        }

        private void LoadPatients()
        {
            flpPatients.SuspendLayout();
            flpPatients.Controls.Clear();

            if (_timeSlot.Appointments == null || !_timeSlot.Appointments.Any())
            {
                Label lblNoData = new Label
                {
                    Text = "Chưa có bệnh nhân nào đặt lịch.",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(20, 30, 0, 0)
                };
                flpPatients.Controls.Add(lblNoData);
                flpPatients.ResumeLayout();
                return;
            }

            var sortedApps = _timeSlot.Appointments
                .OrderBy(a => a.Status == "Pending" ? 0 : a.Status == "Confirmed" ? 1 : a.Status == "Completed" ? 2 : 3)
                .ToList();

            foreach (var app in sortedApps)
            {
                ucAppointmentRow row = new ucAppointmentRow();
                row.SetData(app);
                // Vì danh sách của Admin không cần thời gian (vì chung slot) nên ẩn hoặc giữ tuỳ ý, row mặc định hiển thị
                
                // Mở rộng width cho vừa với flow layout
                row.Width = flpPatients.ClientSize.Width - 25;
                flpPatients.Controls.Add(row);
            }

            flpPatients.ResumeLayout();
        }

        private void ucAdmin_TimeSlotDetailsDialog_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(this, 12);
            UIHelper.ApplyRoundedRegion(btnClose, 8);

            UIHelper.EnableNativeDrag(pnlHeader, this);
            UIHelper.EnableNativeDrag(lblTitle, this);

            this.Paint += (s, ev) =>
            {
                UIHelper.uc_Paint(this, ev, 12, Color.FromArgb(203, 213, 225), 2);
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnCloseModal?.Invoke(this, EventArgs.Empty);
        }
    }
}
