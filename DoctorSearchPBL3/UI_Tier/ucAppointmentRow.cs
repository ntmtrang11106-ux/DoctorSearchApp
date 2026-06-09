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
    public partial class ucAppointmentRow : UserControl
    {
        public ucAppointmentRow()
        {
            InitializeComponent();
        }

        public void SetData(AppointmentsDTO app)
        {
            string start = app.TimeSlot?.StartTime.ToString(@"hh\:mm") ?? "00:00";
            string end = app.TimeSlot?.EndTime.ToString(@"hh\:mm") ?? "00:00";
            lblTime.Text = $"{start} - {end}";
            lblPatientName.Text = app.Patient?.User?.FullName ?? "N/A";
            lblPatientPhone.Text = app.Patient?.User?.PhoneNumber ?? "Chưa có SDT";
            lblReason.Text = app.Reason ?? "Khám tổng quát";

            if (app.Status == "Confirmed")
            {
                lblStatus.Text = "Đã xác nhận";
                lblStatus.ForeColor = Color.FromArgb(40, 199, 111);
                lblStatus.BackColor = Color.FromArgb(235, 252, 245);
            }
            else if (app.Status == "Pending")
            {
                lblStatus.Text = "Chờ xác nhận";
                lblStatus.ForeColor = Color.FromArgb(255, 159, 67);
                lblStatus.BackColor = Color.FromArgb(255, 248, 235);
            }
            else
            {
                lblStatus.Text = app.Status;
                lblStatus.ForeColor = Color.Gray;
                lblStatus.BackColor = Color.FromArgb(245, 245, 245);
            }

            UIHelper.ApplyRoundedRegion(lblStatus, 10);
        }

        private void ucAppointmentRow_Load(object sender, EventArgs e)
        {
            this.Margin = new Padding(5, 5, 5, 10); // Tạo khoảng cách giữa các card
            UIHelper.ApplyRoundedRegion(this, 15);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Vẽ viền cho từng ô lịch hẹn rõ hơn
            UIHelper.uc_Paint(this, e, 15, Color.FromArgb(203, 213, 225), 2);
        }
    }
}
