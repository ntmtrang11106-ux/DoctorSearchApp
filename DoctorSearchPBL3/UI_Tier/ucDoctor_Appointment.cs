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
            btnAddTimeSlot.Visible = false;
            btnAddTimeSlot.Enabled = false;
            UIHelper.SetupHoverEffect(lblReviewPrevBtn, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212), 3);
            UIHelper.SetupHoverEffect(lblReviewNext, Color.FromArgb(0, 90, 158), Color.FromArgb(0, 120, 212), 3);

            lblReviewPrevBtn.Click += lblReviewPrevBtn_Click;
            lblReviewNext.Click += lblReviewNext_Click;

            // Tự động co giãn các card khi resize form
            flpAppItem.Resize += (s, e) =>
            {
                flpAppItem.SuspendLayout();
                foreach (Control ctrl in flpAppItem.Controls)
                {
                    if (ctrl is ucUserAppointmentCard card)
                    {
                        card.Width = flpAppItem.ClientSize.Width - 80;
                    }
                    else if (ctrl is Label lbl)
                    {
                        lbl.Width = flpAppItem.ClientSize.Width - 80;
                    }
                }
                flpAppItem.ResumeLayout();
            };

            // Đăng ký sự kiện lọc
            dtpBegin.ValueChanged += (s, ev) => InitData();
            dtpEnd.ValueChanged += (s, ev) => InitData();

            foreach (Control ctrl in flpFilter.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Click += StatusButton_Click;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    UIHelper.ApplyRoundedRegion(btn, 25);
                }
            }
            UpdateButtonStyles();
        }

        #region Xử lý phân trang (Pagination)
        private AppointmentBUS _bus = new AppointmentBUS();
        private List<AppointmentsDTO> _allApps = new List<AppointmentsDTO>();
        private int _pageSize = 6;     // Số lượng 1 trang
        private int _currentPage = 1;  // Trang hiện tại
        private int _doctorId = 0;
        private string _selectedStatus = "Tất cả";

        public void SetDoctorId(int id)
        {
            _doctorId = id;
            InitData();
        }

        public void InitData()
        {
            try
            {
                string status = _selectedStatus.Trim();

                DateTime startDate = dtpBegin.Value.Date;
                DateTime endDate = dtpEnd.Value.Date;

                // Sử dụng BUS để lọc và sắp xếp dữ liệu
                _allApps = _bus.GetFilteredAppointments(_doctorId, startDate, endDate, status);

                _currentPage = 1;
                DisplayPage(_currentPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi InitData: " + ex.Message);
            }
        }

        private AppointmentsDTO CreateEmptyAppointment(TimeSlotsDTO slot)
        {
            return new AppointmentsDTO
            {
                TimeSlotId = slot.Id,
                TimeSlot = slot,
                Status = "Open",
                Doctor = slot.Doctor,
                CreatedAt = slot.CreatedAt
            };
        }

        public void DisplayPage(int pageNumber)
        {
            flpAppItem.SuspendLayout();
            try
            {
                while (flpAppItem.Controls.Count > 0)
                {
                    var control = flpAppItem.Controls[0];
                    flpAppItem.Controls.RemoveAt(0);
                    control.Dispose();
                }

                int totalPages = (int)Math.Ceiling((double)_allApps.Count / _pageSize);
                if (totalPages == 0) totalPages = 1;
                lblReviewPageStatus.Text = $"Trang {_currentPage} / {totalPages}";

                if (_allApps == null || _allApps.Count == 0)
                {
                    Label lblEmpty = new Label();
                    lblEmpty.Text = "Không có lịch trình nào trong khoảng thời gian này.";
                    lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
                    lblEmpty.AutoSize = false;
                    lblEmpty.Size = new Size(flpAppItem.ClientSize.Width - 40, 100);
                    lblEmpty.ForeColor = Color.Gray;
                    lblEmpty.Font = new Font("Segoe UI", 11, FontStyle.Italic);
                    flpAppItem.Controls.Add(lblEmpty);
                    return;
                }

                int startIndex = (pageNumber - 1) * _pageSize;
                var pageItems = _allApps.Skip(startIndex).Take(_pageSize).ToList();

                var groupedItems = pageItems
                    .Where(a => a.TimeSlot != null)
                    .GroupBy(a => new { a.TimeSlot.WorkDate, a.TimeSlot.StartTime, a.TimeSlot.EndTime })
                    .ToList();

                foreach (var group in groupedItems)
                {
                    var slot = group.FirstOrDefault()?.TimeSlot;
                    int actualCount = group.Count();
                    int maxApp = slot != null ? slot.MaxAppointments : 0;

                    foreach (var ap in group)
                    {
                        ucUserAppointmentCard card = new ucUserAppointmentCard();
                        card.SetData(ap, ucUserAppointmentCard.UserAppCardMode.DoctorView);
                        card.Margin = new Padding(20, 10, 20, 10);
                        card.Width = flpAppItem.ClientSize.Width - 80;
                        card.Height = 252;

                        card.AcceptClicked += (s, appData) => {
                            if (MessageBox.Show("Chấp nhận lịch này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (new AppointmentBUS().AcceptAppointment(appData.Id))
                                {
                                    MessageBox.Show("Chấp nhận lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    InitData();
                                }
                            }
                        };
                        card.CancelClicked += (s, appData) => {
                            if (MessageBox.Show("Từ chối lịch hẹn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                if (new AppointmentBUS().RejectAppointment(appData.Id))
                                {
                                    MessageBox.Show("Đã từ chối lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    InitData();
                                }
                            }
                        };
                        card.RemoveClicked += (s, appData) => {
                            if (MessageBox.Show("Bạn có chắc chắn muốn hủy lịch hẹn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (new AppointmentBUS().UndoAppointment(appData.Id))
                                {
                                    MessageBox.Show("Đã hủy lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    InitData();
                                }
                            }
                        };
                        card.CompleteClicked += (s, appData) => {
                            if (MessageBox.Show("Xác nhận bệnh nhân đã khám xong và cập nhật trạng thái thành 'Thành công'?", "Hoàn thành ca khám", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (new AppointmentBUS().UpdateStatus(appData.Id, "Completed", "Khám hoàn tất"))
                                {
                                    MessageBox.Show("Đã cập nhật trạng thái lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    InitData();
                                }
                            }
                        };
                        card.EditClicked += (s, appData) =>
                        {
                            if (appData.Doctor == null) return;
                            ucBookingDialog editUc = new ucBookingDialog(appData.Doctor);
                            editUc.SetEditData(appData);
                            editUc.Location = new Point((this.Width - editUc.Width) / 2, (this.Height - editUc.Height) / 2);
                            editUc.AppointmentBooked += (s2, ev2) => InitData();
                            editUc.CloseRequested += (s2, ev2) =>
                            {
                                this.Controls.Remove(editUc);
                                editUc.Dispose();
                            };
                            this.Controls.Add(editUc);
                            editUc.BringToFront();
                        };

                        flpAppItem.Controls.Add(card);
                    }

                    // Add summary label for the group
                    if (slot != null)
                    {
                        Label lblSummary = new Label();
                        lblSummary.Text = $"Tổng kết: Có {actualCount}/{maxApp} lịch vào khung giờ {group.Key.StartTime:hh\\:mm} - {group.Key.EndTime:hh\\:mm} ngày {group.Key.WorkDate:dd/MM/yyyy}";
                        lblSummary.Font = new Font("Segoe UI", 12, FontStyle.Italic | FontStyle.Bold);
                        lblSummary.ForeColor = Color.FromArgb(0, 120, 212);
                        lblSummary.AutoSize = false;
                        lblSummary.Width = flpAppItem.ClientSize.Width - 80;
                        lblSummary.Height = 40;
                        lblSummary.TextAlign = ContentAlignment.MiddleCenter;
                        lblSummary.Margin = new Padding(20, 0, 20, 20); // space below the group

                        flpAppItem.Controls.Add(lblSummary);
                    }
                }

                pnlReviewPagination.Visible = _allApps.Count > 0;
                //UpdateListLayout();
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DisplayPage: " + ex.Message); }
            finally
            {
                flpAppItem.ResumeLayout();
            }
        }

        private void ucDoctor_Appointment_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void lblReviewPrevBtn_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayPage(_currentPage);
            }
        }

        private void lblReviewNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_allApps.Count / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }
        private void StatusButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                _selectedStatus = btn.Text.Trim();
                UpdateButtonStyles();
                InitData();
            }
        }

        private void UpdateButtonStyles()
        {
            foreach (Control ctrl in flpFilter.Controls)
            {
                if (ctrl is Button btn)
                {
                    if (btn.Text == _selectedStatus)
                    {
                        btn.BackColor = Color.FromArgb(24, 112, 255);
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                    }
                    else
                    {
                        btn.BackColor = Color.FromArgb(243, 244, 246);
                        btn.ForeColor = Color.FromArgb(107, 114, 128);
                        btn.Font = new Font("Segoe UI", 12f, FontStyle.Regular);
                    }
                }
            }
        }

        #region Xử lý phân trang (Pagination)
        private void UpdateListLayout()
        {
            flpAppItem.Padding = new Padding(flpAppItem.Padding.Left, flpAppItem.Padding.Top, flpAppItem.Padding.Right, 0);
            int totalItemsHeight = flpAppItem.Padding.Top + flpAppItem.Padding.Bottom;
            foreach (Control ctrl in flpAppItem.Controls)
            {
                if (ctrl.Visible && ctrl != pnlReviewPagination && ctrl.Name != "pnlBuffer")
                    totalItemsHeight += ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom;
            }

            int availableHeight = pnlResultContainer.Height - pnlResultContainer.Padding.Top - pnlResultContainer.Padding.Bottom;

            // Xóa buffer cũ
            Control oldBuffer = flpAppItem.Controls.Find("pnlBuffer", false).FirstOrDefault();
            if (oldBuffer != null) flpAppItem.Controls.Remove(oldBuffer);

            if (totalItemsHeight + pnlReviewPagination.Height < availableHeight)
            {
                // Danh sách ngắn: Bám sát nội dung
                pnlReviewPagination.Dock = DockStyle.Top;
                pnlReviewPagination.Margin = new Padding(0, 10, 0, 0);
                flpAppItem.Dock = DockStyle.Top;
                flpAppItem.Height = totalItemsHeight;
                flpAppItem.AutoScroll = false;
            }
            else
            {
                // Danh sách dài: Đứng yên ở đáy - Sát khít đáy hoàn toàn
                pnlReviewPagination.Dock = DockStyle.Bottom;
                pnlReviewPagination.Margin = new Padding(0);
                flpAppItem.Dock = DockStyle.Fill;
                flpAppItem.AutoScroll = true;

                // Thêm đệm vật lý 20px để card cuối không bị che viền
                Panel pnlBuffer = new Panel { Height = 20, Width = flpAppItem.Width - 25, Name = "pnlBuffer" };
                flpAppItem.Controls.Add(pnlBuffer);
            }

            // Đảm bảo Z-Order đúng trong Container - Kiểm tra an toàn
            if (!pnlResultContainer.Controls.Contains(pnlReviewPagination))
            {
                pnlResultContainer.Controls.Add(pnlReviewPagination);
            }
            pnlResultContainer.Controls.SetChildIndex(pnlReviewPagination, 0);
        }
        #endregion

        private void btnAddTimeSlot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bác sĩ không có quyền tự tạo lịch khám. Vui lòng liên hệ admin để được sắp lịch.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
        #endregion
}
