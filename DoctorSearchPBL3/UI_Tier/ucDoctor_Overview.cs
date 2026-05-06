using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucDoctor_Overview : UserControl
    {
        private DoctorDTO _currentDoctor;
        private int _doctorId;

        public ucDoctor_Overview()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            
            // Đăng ký sự kiện Load để áp dụng bo tròn
            this.Load += ucDoctor_Overview_Load;
        }

        public void SetDoctorData(DoctorDTO doctor)
        {
            _currentDoctor = doctor;
            _doctorId = doctor.Id;

            lblWelcome.Text = $"Chào mừng, {doctor.Position} {doctor.User?.FullName}";
            lblDept.Text = $"Chuyên khoa: {doctor.Department?.DepartmentName ?? "Chưa cập nhật"}";

            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            DoctorBUS bus = new DoctorBUS();
            
            // 1. Stats
            lblTodayAppCount.Text = bus.GetTodayAppointments(_doctorId).Count.ToString();
            lblTotalPatientsCount.Text = bus.GetTotalPatientsCount(_doctorId).ToString();
            lblPendingCount.Text = bus.GetPendingAppointmentsCount(_doctorId).ToString();
            
            if (_currentDoctor.Reviews != null && _currentDoctor.Reviews.Any())
            {
                double avg = _currentDoctor.Reviews.Average(r => r.Rating);
                lblAvgRating.Text = avg.ToString("0.0");
            }
            else
            {
                lblAvgRating.Text = "0.0";
            }

            // 2. Today's Appointments
            LoadTodayAppointments();

            // 3. Recent Reviews
            LoadRecentReviews();

            // 4. Update Date
            lblTodayDate.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy", new System.Globalization.CultureInfo("vi-VN"));
        }

        private void LoadTodayAppointments()
        {
            flpTodayApp.SuspendLayout();
            flpTodayApp.Controls.Clear();

            DoctorBUS bus = new DoctorBUS();
            var apps = bus.GetTodayAppointments(_doctorId);

            foreach (var app in apps)
            {
                AddAppointmentRow(app);
            }
            flpTodayApp.ResumeLayout();
        }

        private void AddAppointmentRow(AppointmentsDTO app)
        {
            ucAppointmentRow row = new ucAppointmentRow();
            row.SetData(app);
            flpTodayApp.Controls.Add(row);
        }

        private void LoadRecentReviews()
        {
            flpRecentReviews.SuspendLayout();
            flpRecentReviews.Controls.Clear();

            DoctorBUS bus = new DoctorBUS();
            var reviews = bus.GetDoctorReviews(_doctorId).Take(5).ToList();
            foreach (var rev in reviews)
            {
                ucReviewItem item = new ucReviewItem();
                // TRUYỀN -1 để ẩn nút Sửa/Xóa trong màn hình Overview của bác sĩ
                item.SetReviewData(rev, _currentDoctor, -1);
                flpRecentReviews.Controls.Add(item);
            }
            flpRecentReviews.ResumeLayout();
        }

        private void ucDoctor_Overview_Load(object sender, EventArgs e)
        {
            // Cập nhật bo tròn ban đầu
            UpdateRoundedRegions();

            // Đăng ký sự kiện Resize để khi form co giãn, bo góc vẫn bám sát kích thước mới
            pnlReviews.Resize += (s, ev) => UIHelper.ApplyRoundedRegion(pnlReviews, 25);
            pnlAppointments.Resize += (s, ev) => UIHelper.ApplyRoundedRegion(pnlAppointments, 25);
            
            // Các ô stats nhỏ thường cố định size nên có thể gọi trực tiếp
            pnlTodayApp.Resize += (s, ev) => UIHelper.ApplyRoundedRegion(pnlTodayApp, 20);
            pnlTotalPatients.Resize += (s, ev) => UIHelper.ApplyRoundedRegion(pnlTotalPatients, 20);
            pnlPending.Resize += (s, ev) => UIHelper.ApplyRoundedRegion(pnlPending, 20);
            pnlRating.Resize += (s, ev) => UIHelper.ApplyRoundedRegion(pnlRating, 20);
        }

        private void UpdateRoundedRegions()
        {
            UIHelper.ApplyRoundedRegion(pnlTodayApp, 20);
            UIHelper.ApplyRoundedRegion(pnlTotalPatients, 20);
            UIHelper.ApplyRoundedRegion(pnlPending, 20);
            UIHelper.ApplyRoundedRegion(pnlRating, 20);
            
            UIHelper.ApplyRoundedRegion(pnlReviews, 25);
            UIHelper.ApplyRoundedRegion(pnlAppointments, 25);

            UIHelper.ApplyRoundedRegion(lblIconTodayApp, 15);
            UIHelper.ApplyRoundedRegion(lblIconTotalPatients, 15);
            UIHelper.ApplyRoundedRegion(lblIconPending, 15);
            UIHelper.ApplyRoundedRegion(lblIconRating, 15);
        }
    }
}
