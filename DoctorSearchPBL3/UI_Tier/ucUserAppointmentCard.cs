using DTO_Tier;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucUserAppointmentCard : UserControl
    {
        public enum UserAppCardMode
        {
            PatientView,    // Bệnh nhân xem lịch của mình
            HistoryView,    // Xem lại lịch cũ (Hoàn thành)
            DoctorView      // Bác sĩ duyệt lịch
        }

        private AppointmentsDTO? _currentAppData;
        private UserAppCardMode _currentMode;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowDoctorInfo { get; set; } = true;

        // --- CÁC SỰ KIỆN ĐỂ BẮN NGƯỢC LÊN CHA XỬ LÝ (EVENT-DRIVEN) ---
        public event EventHandler<AppointmentsDTO>? AcceptClicked;
        public event EventHandler<AppointmentsDTO>? CancelClicked;
        public event EventHandler<AppointmentsDTO>? RemoveClicked;
        public event EventHandler<AppointmentsDTO>? EditClicked;
        public event EventHandler<AppointmentsDTO>? RateClicked;
        public event EventHandler<AppointmentsDTO>? ViewRecordClicked;
        public event EventHandler<AppointmentsDTO>? CompleteClicked;

        public ucUserAppointmentCard()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
        }

        private void ucUserAppointmentCard_Load(object sender, EventArgs e)
        {
            // Thiết lập bo góc mặc định cho các nút bấm thông qua UIHelper
            UIHelper.ApplyRoundedRegion(btnStatus, 10);
            UIHelper.ApplyRoundedRegion(btnAccept, 40);
            UIHelper.ApplyRoundedRegion(btnCancel, 40);
            UIHelper.ApplyRoundedRegion(btnRemove, 40);
            UIHelper.ApplyRoundedRegion(btnEdit, 40);
            UIHelper.ApplyRoundedRegion(btnRate, 40);
            UIHelper.ApplyRoundedRegion(btnViewRecord, 40);
            UIHelper.ApplyRoundedRegion(btnComplete, 40);

            // Vẽ viền cho card
            this.Paint += (s, ev) =>
            {
                UIHelper.uc_Paint(this, ev, 40, Color.LightGray, 3);
            };
        }

        // --- CẬP NHẬT TRẠNG THÁI HIỂN THỊ BADGE ---
        private void UpdateStatusStyle(string status)
        {
            btnStatus.Visible = true;
            switch (status)
            {
                case "Open":
                    btnStatus.Text = "Trống";
                    btnStatus.BackColor = Color.LightGray;
                    btnStatus.ForeColor = Color.DarkGray;
                    break;
                case "Pending":
                    btnStatus.Text = "Chờ duyệt";
                    btnStatus.BackColor = Color.Ivory;
                    btnStatus.ForeColor = Color.Goldenrod;
                    break;
                case "Confirmed":
                    btnStatus.Text = "Đã duyệt";
                    btnStatus.BackColor = Color.Honeydew;
                    btnStatus.ForeColor = Color.Green;
                    break;
                case "Cancelled":
                    btnStatus.Text = "Đã hủy";
                    btnStatus.BackColor = Color.MistyRose;
                    btnStatus.ForeColor = Color.IndianRed;
                    break;
                case "Completed":
                    btnStatus.Text = "Thành công";
                    btnStatus.BackColor = Color.Azure;
                    btnStatus.ForeColor = Color.DodgerBlue;
                    break;
                default:
                    btnStatus.Visible = false;
                    break;
            }
        }

        // --- ĐỒNG BỘ HIỂN THỊ NÚT THAO TÁC THEO CHẾ ĐỘ ---
        private void SetupButtons(UserAppCardMode mode, string status)
        {
            // Ẩn tất cả nút trước khi cấu hình
            btnAccept.Visible = false;
            btnCancel.Visible = false;
            btnRemove.Visible = false;
            btnRate.Visible = false;
            btnViewRecord.Visible = false;
            btnEdit.Visible = false;
            btnComplete.Visible = false;

            switch (mode)
            {
                case UserAppCardMode.PatientView:
                    if (status == "Pending")
                    {
                        btnEdit.Visible = true;
                        btnRemove.Visible = true; // Hủy lịch hẹn
                    }
                    else if (status == "Cancelled")
                    {
                        // Ẩn nút Undo khi đã hủy
                    }
                    break;

                case UserAppCardMode.HistoryView:
                    if (status == "Completed")
                    {
                        btnViewRecord.Visible = true;
                        btnRate.Visible = true;
                    }
                    break;

                case UserAppCardMode.DoctorView:
                    if (status == "Pending")
                    {
                        btnAccept.Visible = true;
                        btnCancel.Visible = true;
                    }
                    else if (status == "Confirmed")
                    {
                        btnComplete.Visible = true;
                    }
                    break;
            }
        }

        // --- THIẾT LẬP DỮ LIỆU HIỂN THỊ ---
        public void SetData(AppointmentsDTO data, UserAppCardMode mode)
        {
            _currentMode = mode;
            _currentAppData = data;

            // 1. Điền dữ liệu thời gian
            if (data.TimeSlot != null)
            {
                lblDate.Text = data.TimeSlot.WorkDate.ToString("dd/MM/yyyy");
                lblTime.Text = $"{data.TimeSlot.StartTime:hh\\:mm} - {data.TimeSlot.EndTime:hh\\:mm}";
            }

            // 2. Điền thông tin chi tiết dựa vào đối tượng tương tác
            if (mode == UserAppCardMode.PatientView || mode == UserAppCardMode.HistoryView)
            {
                lblSymptoms.Text = data.Reason ?? "N/A";
                // Bệnh nhân nhìn: Hiện thông tin Bác sĩ
                string position = UIHelper.NormalizeDoctorTitle(data.Doctor?.Position);
                string fullName = UIHelper.NormalizeDoctorName(data.Doctor?.User?.FullName ?? "N/A");
                lblName.Text = string.IsNullOrWhiteSpace(position)
                    ? $"BS. {fullName}"
                    : $"{position} {fullName}".Trim();
                lblPhoneNumber.Text = data.Doctor?.User?.PhoneNumber ?? "N/A";
                
                lblSymptoms.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                lblSymptoms.ForeColor = Color.Black;
                lblPhoneNumber.Visible = true;
            }
            else // DoctorView
            {
                if (data.Patient == null || data.Patient.User == null)
                {
                    lblName.Text = "Chưa có bệnh nhân";
                    lblPhoneNumber.Visible = false;
                    
                    lblSymptoms.Text = "Chưa ghi chú";
                    lblSymptoms.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
                    lblSymptoms.ForeColor = Color.DarkGray;
                }
                else
                {
                    lblName.Text = data.Patient.User.FullName;
                    lblPhoneNumber.Text = data.Patient.User.PhoneNumber;
                    lblPhoneNumber.Visible = true;
                    
                    lblSymptoms.Text = data.Reason ?? "N/A";
                    lblSymptoms.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    lblSymptoms.ForeColor = Color.Black;
                }
            }

            // Cập nhật trạng thái và hiển thị nút
            UpdateStatusStyle(data.Status);
            SetupButtons(mode, data.Status);

            // Xử lý rút gọn giao diện tối giản nếu tắt ShowDoctorInfo
            if (!ShowDoctorInfo)
            {
                lblName.Visible = false;
                lblPhoneNumber.Visible = false;
                label2.Visible = false;
                lblSymptoms.Visible = false;
                flpAction.Visible = false;

                int buttonX = this.Width - btnStatus.Width - 40; // Với Width = 850, X sẽ là 850 - 229 - 40 = 581
                int buttonY = (this.Height - btnStatus.Height) / 2; // Căn giữa theo chiều dọc

                btnStatus.Location = new Point(buttonX, buttonY);

                // Nếu ShowDoctorInfo = false, ta ẩn flpAction và chỉ hiện Badge trạng thái
                // Nhờ thuộc tính Anchor = Right của Designer, btnStatus sẽ căn chỉnh gọn gàng bên phải
            }
            else
            {
                lblName.Visible = true;
                bool isEmptySlot = mode == UserAppCardMode.DoctorView && (data.Patient == null || data.Patient.User == null);
                lblPhoneNumber.Visible = !isEmptySlot;
                label2.Visible = true;
                lblSymptoms.Visible = true;
                flpAction.Visible = true;
            }
        }

        // --- BẮN SỰ KIỆN LÊN CHA KHI CLICK NÚT ---
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (_currentAppData != null) AcceptClicked?.Invoke(this, _currentAppData);
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (_currentAppData != null) CompleteClicked?.Invoke(this, _currentAppData);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_currentAppData != null) CancelClicked?.Invoke(this, _currentAppData);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_currentAppData != null) RemoveClicked?.Invoke(this, _currentAppData);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_currentAppData != null) EditClicked?.Invoke(this, _currentAppData);
        }

        private void btnRate_Click(object sender, EventArgs e)
        {
            if (_currentAppData != null) RateClicked?.Invoke(this, _currentAppData);
        }

        private void btnViewRecord_Click(object sender, EventArgs e)
        {
            if (_currentAppData != null) ViewRecordClicked?.Invoke(this, _currentAppData);
        }
    }
}
