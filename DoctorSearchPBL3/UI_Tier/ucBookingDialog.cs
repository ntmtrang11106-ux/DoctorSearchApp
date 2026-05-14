using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            UIHelper.SetDoubleBuffered(this);
        }

        private void ucBookingDialog_Load(object sender, EventArgs e)
        {
            // Styling
            this.Padding = new Padding(3); // Giúp viền dày 3 không bị các panel con che khuất
            UIHelper.ApplyRoundedRegion(this, 20);
            this.BackColor = Color.White;
            // Viền form màu đen dày 3 - Phải vẽ sau cùng hoặc chừa lề bằng Padding
            this.Paint += (s, ev) => UIHelper.uc_Paint(s, ev, 20, Color.Black, 3);

            UIHelper.ApplyRoundedRegion(pnlDoctorInfo, 20); // Bo góc cho card bác sĩ
            UIHelper.ApplyRoundedRegion(picDocAvatar, picDocAvatar.Width / 2); // Bo tròn ảnh đại diện

            // Bo viền cho Lý do khám (Dùng panel bọc ngoài)
            Panel pnlReasonBorder = new Panel();
            pnlReasonBorder.Size = txtReason.Size;
            pnlReasonBorder.Location = txtReason.Location;
            pnlReasonBorder.BackColor = Color.White; // Nền trắng mặc định
            this.Controls.Add(pnlReasonBorder);

            txtReason.Parent = pnlReasonBorder;
            txtReason.Dock = DockStyle.Fill;
            txtReason.BorderStyle = BorderStyle.None;
            txtReason.BackColor = Color.White; // Nền trắng mặc định đồng bộ
            // Chừa lề một chút để text không dính vào viền
            pnlReasonBorder.Padding = new Padding(12, 10, 12, 10);

            UIHelper.ApplyRoundedRegion(pnlReasonBorder, 15);
            pnlReasonBorder.Paint += (s, ev) =>
            {
                // Vẽ viền xám mờ bao quanh - Độ dày 2 theo yêu cầu
                using (Pen penGray = new Pen(Color.FromArgb(209, 213, 219), 2))
                {
                    ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    ev.Graphics.DrawPath(penGray, UIHelper.GetRoundedPath(new Rectangle(0, 0, pnlReasonBorder.Width - 1, pnlReasonBorder.Height - 1), 15));
                }
            };

            UIHelper.ApplyRoundedRegion(flpTimeSlots, 15);
            flpTimeSlots.Paint += (s, ev) => UIHelper.DrawControlBorder(flpTimeSlots, ev, 15, Color.Black, 2);

            UIHelper.ApplyRoundedRegion(pnlNotice, 15);
            UIHelper.ApplyRoundedRegion(btnConfirm, 15);
            UIHelper.ApplyRoundedRegion(btnCancel, 15);

            // Click ra vùng trắng để thoát ô nhập (Đăng ký cho tất cả các control không phải input)
            RegisterUnfocus(this);

            // Placeholder cho txtReason
            txtReason.Text = "Vui lòng mô tả lý do bạn cần khám bệnh...";
            txtReason.ForeColor = Color.Gray;
            txtReason.Enter += txtReason_Enter;
            txtReason.Leave += txtReason_Leave;

            // Đổ dữ liệu bác sĩ
            if (_doctor != null)
            {
                lblDocName.Text = (_doctor.Position + " " + _doctor.User?.FullName).Trim();
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

            // Bo tròn Legend thành hình vuông bo góc nhẹ như hình mẫu
            UIHelper.ApplyRoundedRegion(picLegendSelected, 6);
            UIHelper.ApplyRoundedRegion(picLegendAvailable, 6);
            UIHelper.ApplyRoundedRegion(picLegendBooked, 6);

            // Vẽ viền đen đậm hơn cho ô "Còn trống"
            picLegendAvailable.Paint += (s, ev) => UIHelper.DrawControlBorder(picLegendAvailable, ev, 6, Color.Black, 2);

            // Set default date hoặc dữ liệu Edit
            if (_editAppointmentId != -1)
            {
                dtpDate.Value = _currentDate; // Sẽ gán từ SetEditData
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
            _selectedTimeSlotId = -1;

            var slots = _timeSlotBUS.GetSlotsByDoctorAndDate(_doctor.Id, dtpDate.Value);

            if (slots == null || slots.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Không có lịch khám nào trong ngày này.";
                lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblEmpty.ForeColor = Color.Gray;
                lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
                // Căn giữa chính xác bằng cách chiếm toàn bộ chiều cao container
                lblEmpty.AutoSize = false;
                lblEmpty.Size = new Size(flpTimeSlots.Width - 40, flpTimeSlots.Height - 40);
                lblEmpty.Margin = new Padding(20, 20, 20, 20);
                flpTimeSlots.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var slot in slots)
                {
                    Button btnSlot = new Button();
                    btnSlot.Text = $"  {slot.StartTime:hh\\:mm} - {slot.EndTime:hh\\:mm}";
                    btnSlot.Tag = slot.Id;
                    btnSlot.Size = new Size(270, 80);
                    btnSlot.FlatStyle = FlatStyle.Flat;
                    btnSlot.Cursor = Cursors.Hand;
                    btnSlot.Font = new Font("Segoe UI", 10);
                    btnSlot.Margin = new Padding(5, 5, 5, 5);

                    // Status based styling
                    if (slot.Status == "Full" || slot.BookedCount >= slot.MaxAppointments)
                    {
                        btnSlot.BackColor = Color.FromArgb(249, 250, 251); // Màu xám rất nhạt
                        btnSlot.ForeColor = Color.FromArgb(156, 163, 175);
                        btnSlot.FlatAppearance.BorderColor = Color.FromArgb(249, 250, 251); // Không dùng Transparent vì lỗi WinForms
                        btnSlot.Enabled = false;
                    }
                    else
                    {
                        btnSlot.BackColor = Color.White;
                        btnSlot.ForeColor = Color.FromArgb(31, 41, 55);
                        btnSlot.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
                        btnSlot.Click += Slot_Click;
                    }

                    UIHelper.ApplyRoundedRegion(btnSlot, 10);
                    flpTimeSlots.Controls.Add(btnSlot);

                    // Nếu là slot đang edit thì auto chọn
                    if (slot.Id == _preselectedSlotId)
                    {
                        _selectedTimeSlotId = slot.Id;
                        btnSlot.BackColor = Color.FromArgb(37, 99, 235);
                        btnSlot.ForeColor = Color.White;
                        btnSlot.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
                    }
                }
            }

            flpTimeSlots.ResumeLayout();
        }

        private void Slot_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            int slotId = (int)clickedBtn.Tag;

            // Deselect previous
            foreach (Control ctrl in flpTimeSlots.Controls)
            {
                if (ctrl is Button btn && btn.Enabled)
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(31, 41, 55);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
                }
            }

            // Select new
            _selectedTimeSlotId = slotId;
            clickedBtn.BackColor = Color.FromArgb(37, 99, 235);
            clickedBtn.ForeColor = Color.White;
            clickedBtn.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
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

            // 1. Kiểm tra trùng lịch (Loại trừ lịch đang sửa nếu có)
            var conflict = _appointmentBUS.CheckPatientOverlap(patientId, _selectedTimeSlotId, _editAppointmentId);
            if (conflict != null)
            {
                string conflictMsg = $"Bạn đã có một lịch hẹn vào khung giờ này ({conflict.TimeSlot.StartTime:hh\\:mm} - {conflict.TimeSlot.EndTime:hh\\:mm} ngày {conflict.TimeSlot.WorkDate:dd/MM/yyyy}).\n\nBạn có muốn thay thế lịch hẹn cũ bằng lịch hẹn mới này không?";
                var diagResult = MessageBox.Show(conflictMsg, "Trùng lịch hẹn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (diagResult == DialogResult.Yes)
                {
                    // Xóa lịch cũ trước khi đặt/cập nhật lịch mới
                    _appointmentBUS.DeleteAppointment(conflict.Id);
                }
                else
                {
                    return; // Dừng lại để user chọn khung giờ khác
                }
            }

            // 2. Thực hiện Đặt hoặc Cập nhật
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
            // Highlight khi chọn: Nền xanh nhạt và viền xanh ở đáy
            txtReason.Parent.BackColor = Color.FromArgb(243, 248, 255);
            txtReason.BackColor = Color.FromArgb(243, 248, 255);
            txtReason.Parent.Paint += DrawFocusHighlight;
            txtReason.Parent.Invalidate();
        }

        private void txtReason_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                txtReason.Text = "Vui lòng mô tả lý do bạn cần khám bệnh...";
                txtReason.ForeColor = Color.Gray;
            }
            // Trở về bình thường khi thoát: Nền trắng
            txtReason.Parent.BackColor = Color.White;
            txtReason.BackColor = Color.White;
            txtReason.Parent.Paint -= DrawFocusHighlight;
            txtReason.Parent.Invalidate();
        }

        private void DrawFocusHighlight(object sender, PaintEventArgs e)
        {
            Control ctrl = (Control)sender;
            using (Pen penBlue = new Pen(Color.FromArgb(37, 99, 235), 4))
            {
                e.Graphics.DrawLine(penBlue, 15, ctrl.Height - 2, ctrl.Width - 15, ctrl.Height - 2);
            }
        }

        #region Draggable Header & Unfocus
        private void RegisterUnfocus(Control ctrl)
        {
            // Sử dụng ActiveControl để đẩy focus ra khỏi ô nhập liệu một cách triệt để
            ctrl.Click += (s, e) => this.ActiveControl = lblTitle;
            
            foreach (Control child in ctrl.Controls)
            {
                // Không đăng ký cho các ô nhập liệu hoặc nút bấm
                if (!(child is RichTextBox || child is TextBox || child is Button || child is DateTimePicker))
                {
                    RegisterUnfocus(child);
                }
            }
        }

        private Point _mouseLoc;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e) => _mouseLoc = e.Location;
        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _mouseLoc.X;
                this.Top += e.Y - _mouseLoc.Y;
            }
        }
        #endregion
    }
}
