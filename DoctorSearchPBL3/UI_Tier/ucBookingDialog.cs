using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;

namespace UI_Tier
{
    public partial class ucBookingDialog : UserControl
    {
        private DoctorDTO _doctor;
        private int _selectedTimeSlotId = -1;
        private TimeSlotBUS _timeSlotBUS = new TimeSlotBUS();
        private AppointmentBUS _appointmentBUS = new AppointmentBUS();
        private int _editAppointmentId = -1;
        private int _preselectedSlotId = -1;
        private string _prefilledReason = "";

        public event EventHandler CloseRequested;
        public event EventHandler AppointmentBooked;

        public ucBookingDialog(DoctorDTO doctor)
        {
            InitializeComponent();
            _doctor = doctor;

            // Tận dụng hàm bật DoubleBuffered đệ quy từ UIHelper chống xé hình
            UIHelper.SetDoubleBuffered(this);
        }

        private void ucBookingDialog_Load(object sender, EventArgs e)
        {
            // Kích hoạt tính năng nắm kéo di chuyển Control bằng hàm MakeDraggable của UIHelper

            // Styling Form chính
            this.Padding = new Padding(4);
            UIHelper.ApplyRoundedRegion(this, 20);
            this.BackColor = Color.White;

            // Sử dụng hàm uc_Paint có sẵn của UIHelper vẽ viền DimGray dày 3px cho Form chính
            this.Paint += (s, ev) => UIHelper.uc_Paint(s, ev, 20, Color.DimGray, 3);

            UIHelper.ApplyRoundedRegion(pnlDoctorInfo, 20);
            UIHelper.ApplyRoundedRegion(picDocAvatar, picDocAvatar.Width / 2);

            // Bo viền cho Lý do khám (Dùng panel bọc ngoài)
            Panel pnlReasonBorder = new Panel();
            pnlReasonBorder.Size = txtReason.Size;
            pnlReasonBorder.Location = txtReason.Location;
            pnlReasonBorder.BackColor = Color.White;
            this.Controls.Add(pnlReasonBorder);

            txtReason.Parent = pnlReasonBorder;
            txtReason.Dock = DockStyle.Fill;
            txtReason.BorderStyle = BorderStyle.None;
            txtReason.BackColor = Color.White;
            pnlReasonBorder.Padding = new Padding(12, 10, 12, 10);

            UIHelper.ApplyRoundedRegion(pnlReasonBorder, 15);
            pnlReasonBorder.Paint += (s, ev) => UIHelper.DrawControlBorder(s, ev, 15, Color.DimGray, 2);

            // Xử lý bao viền và Focus Effect chuẩn cho DateTimePicker bằng UIHelper
            Control dateOriginalParent = dtpDate.Parent;
            Panel pnlDateBorder = new Panel();
            pnlDateBorder.Size = new Size(dtpDate.Width + 16, dtpDate.Height + 12);
            pnlDateBorder.Location = new Point(dtpDate.Left - 8, dtpDate.Top - 6);
            pnlDateBorder.BackColor = Color.White;

            dateOriginalParent.Controls.Add(pnlDateBorder);
            dtpDate.Parent = pnlDateBorder;
            dtpDate.Dock = DockStyle.Fill;
            pnlDateBorder.Padding = new Padding(10, 6, 10, 6);

            UIHelper.ApplyRoundedRegion(pnlDateBorder, 12);
            UIHelper.SetupInputFocusEffect(dtpDate, pnlDateBorder, Color.FromArgb(243, 248, 255), Color.White, Color.FromArgb(37, 99, 235));

            // Viền ngoài cho FlowLayout Panel khung giờ
            UIHelper.ApplyRoundedRegion(flpTimeSlots, 8);
            flpTimeSlots.Paint += (s, ev) => UIHelper.DrawControlBorder(flpTimeSlots, ev, 8, Color.DimGray, 2);

            UIHelper.ApplyRoundedRegion(pnlNotice, 15);
            UIHelper.ApplyRoundedRegion(btnConfirm, 15);
            UIHelper.ApplyRoundedRegion(btnCancel, 15);

            // Cấu hình placeholder lý do khám
            txtReason.Text = "Vui lòng mô tả lý do bạn cần khám bệnh...";
            txtReason.ForeColor = Color.Gray;
            txtReason.Enter += txtReason_Enter;
            txtReason.Leave += txtReason_Leave;

            // Đổ thông tin tên bác sĩ (Chỉ hiển thị FullName)
            if (_doctor != null)
            {
                lblDocName.Text = _doctor.User?.FullName?.Trim() ?? "Bác sĩ";
                lblDocDept.Text = _doctor.Department?.DepartmentName ?? "Chuyên khoa";

                string fileName = string.IsNullOrWhiteSpace(_doctor.User?.Picture) ? "default.jpg" : _doctor.User.Picture.Trim();
                string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images", fileName);
                if (System.IO.File.Exists(imagePath))
                {
                    try
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                            picDocAvatar.Image = new Bitmap(fs);
                    }
                    catch { }
                }
            }

            // Thiết lập giá trị ngày khám ban đầu hoặc dữ liệu chỉnh sửa (Edit)
            if (_editAppointmentId != -1)
            {
                dtpDate.Value = _currentDate;
                txtReason.Text = _prefilledReason;
                txtReason.ForeColor = string.IsNullOrEmpty(_prefilledReason) || _prefilledReason == "Vui lòng mô tả lý do bạn cần khám bệnh..." ? Color.Gray : Color.Black;
                _selectedTimeSlotId = _preselectedSlotId;
            }
            else
            {
                dtpDate.Value = DateTime.Now;
            }
            dtpDate.MinDate = DateTime.Now;

            LoadTimeSlots();
        }

        private DateTime _currentDate = DateTime.Now;
        public void SetEditData(AppointmentsDTO app)
        {
            _editAppointmentId = app.Id;
            _preselectedSlotId = app.TimeSlotId;
            _prefilledReason = app.Reason;
            if (app.TimeSlot != null)
            {
                _currentDate = app.TimeSlot.WorkDate;
            }
        }

        private void LoadTimeSlots()
        {
            flpTimeSlots.SuspendLayout();
            flpTimeSlots.Controls.Clear();
            _selectedTimeSlotId = (_editAppointmentId != -1) ? _preselectedSlotId : -1;

            var slots = _timeSlotBUS.GetSlotsByDoctorAndDate(_doctor.Id, dtpDate.Value);

            if (slots == null || slots.Count == 0)
            {
                Label lblEmpty = new Label();
                // Dùng hàm định vị thông báo trống đồng bộ từ UIHelper
                UIHelper.SetupEmptyStateLabel(lblEmpty, flpTimeSlots, "Không có lịch khám nào trong ngày này.");
                flpTimeSlots.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var slot in slots)
                {
                    Button btnSlot = new Button();
                    btnSlot.Text = $"{slot.StartTime:hh\\:mm} - {slot.EndTime:hh\\:mm}";
                    btnSlot.Tag = slot.Id;
                    btnSlot.Size = new Size(235, 75);
                    btnSlot.FlatStyle = FlatStyle.Flat;
                    btnSlot.FlatAppearance.BorderSize = 0; // Tắt viền gốc WinForms để tự vẽ
                    btnSlot.Margin = new Padding(10);
                    btnSlot.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

                    // Xử lý đóng băng trạng thái nếu ô lịch đã Full hoặc hết chỗ
                    if (slot.Id != _preselectedSlotId && (slot.Status == "Full" || slot.BookedCount >= slot.MaxAppointments))
                    {
                        btnSlot.Enabled = false;
                        btnSlot.Cursor = Cursors.No;
                    }
                    else
                    {
                        btnSlot.Enabled = true;
                        btnSlot.Cursor = Cursors.Hand;
                        btnSlot.Click += Slot_Click;
                    }

                    // Tận dụng GraphicsPath từ hàm UIHelper.GetRoundedPath để vẽ bo góc mượt mà (AntiAlias)
                    btnSlot.Paint += (s, ev) =>
                    {
                        Button currentBtn = (Button)s;
                        ev.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                        Color backColor;
                        Color borderColor;
                        Color textColor;
                        int borderThickness = 2;

                        if (!currentBtn.Enabled)
                        {
                            backColor = Color.FromArgb(243, 244, 246);
                            borderColor = Color.FromArgb(219, 222, 227);
                            textColor = Color.FromArgb(160, 168, 180);
                            borderThickness = 1;
                        }
                        else if ((int)currentBtn.Tag == _selectedTimeSlotId)
                        {
                            backColor = Color.FromArgb(37, 99, 235);
                            borderColor = Color.FromArgb(37, 99, 235);
                            textColor = Color.White;
                        }
                        else
                        {
                            backColor = Color.White;
                            borderColor = Color.DimGray;
                            textColor = Color.FromArgb(31, 41, 55);
                        }

                        Rectangle rect = new Rectangle(0, 0, currentBtn.Width - 1, currentBtn.Height - 1);
                        using (var path = UIHelper.GetRoundedPath(rect, 10))
                        {
                            using (var brush = new SolidBrush(backColor))
                                ev.Graphics.FillPath(brush, path);

                            using (var pen = new Pen(borderColor, borderThickness))
                            {
                                pen.Alignment = PenAlignment.Inset;
                                ev.Graphics.DrawPath(pen, path);
                            }
                        }

                        TextRenderer.DrawText(ev.Graphics, currentBtn.Text, currentBtn.Font,
                            currentBtn.ClientRectangle, textColor,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    };

                    flpTimeSlots.Controls.Add(btnSlot);
                }
            }

            flpTimeSlots.ResumeLayout();
        }

        private void Slot_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            _selectedTimeSlotId = (int)clickedBtn.Tag;

            // Làm mới toàn bộ FlowLayout để vẽ lại trạng thái các nút theo ID vừa chọn (Duy nhất 1 ô hoạt động)
            flpTimeSlots.Refresh();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e) => LoadTimeSlots();

        private void btnCancel_Click(object sender, EventArgs e) => CloseRequested?.Invoke(this, EventArgs.Empty);

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_selectedTimeSlotId == -1)
            {
                MessageBox.Show("Vui lòng chọn khung giờ khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int patientId = GlobalAccount.GetProfileId();
            if (patientId <= 0)
            {
                MessageBox.Show("Phiên đăng nhập hết hạn. Vui lòng đăng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string reason = txtReason.Text == "Vui lòng mô tả lý do bạn cần khám bệnh..." ? "" : txtReason.Text.Trim();
            if (reason.Length > 500)
            {
                MessageBox.Show("Lý do khám không được vượt quá 500 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var conflict = _appointmentBUS.CheckPatientOverlap(patientId, _selectedTimeSlotId, _editAppointmentId);
            if (conflict != null)
            {
                string conflictMsg = $"Bạn đã có một lịch hẹn vào khung giờ này ({conflict.TimeSlot.StartTime:hh\\:mm} - {conflict.TimeSlot.EndTime:hh\\:mm} ngày {conflict.TimeSlot.WorkDate:dd/MM/yyyy}).\n\nBạn có muốn thay thế lịch hẹn cũ bằng lịch hẹn mới này không?";
                var diagResult = MessageBox.Show(conflictMsg, "Trùng lịch hẹn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (diagResult == DialogResult.Yes)
                {
                    _appointmentBUS.DeleteAppointment(conflict.Id);
                }
                else
                {
                    return;
                }
            }

            if (_editAppointmentId != -1)
            {
                if (_appointmentBUS.UpdateAppointment(_editAppointmentId, _selectedTimeSlotId, reason))
                {
                    MessageBox.Show("Cập nhật lịch khám thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AppointmentBooked?.Invoke(this, EventArgs.Empty);
                    CloseRequested?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Có thể khung giờ này đã vừa hết chỗ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string result = _appointmentBUS.BookAppointment(patientId, _selectedTimeSlotId, reason);

                if (result == "SUCCESS")
                {
                    MessageBox.Show("Đặt lịch khám thành công! Vui lòng chờ bác sĩ xác nhận.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AppointmentBooked?.Invoke(this, EventArgs.Empty);
                    CloseRequested?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            string currentText = txtReason.Text;
            if (currentText == "Vui lòng mô tả lý do bạn cần khám bệnh...") return;

            int length = currentText.Length;
            lblCharCount.Text = $"{length}/500 ký tự";
            lblCharCount.ForeColor = length > 500 ? Color.Red : Color.Gray;
        }

        private void txtReason_Enter(object sender, EventArgs e)
        {
            if (txtReason.Text == "Vui lòng mô tả lý do bạn cần khám bệnh...")
            {
                txtReason.Text = "";
                txtReason.ForeColor = Color.Black;
            }
        }

        private void txtReason_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                txtReason.Text = "Vui lòng mô tả lý do bạn cần khám bệnh...";
                txtReason.ForeColor = Color.Gray;
            }
        }
    }
}