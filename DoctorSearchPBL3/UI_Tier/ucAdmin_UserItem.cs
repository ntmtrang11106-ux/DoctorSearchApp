using System;
using System.Drawing;
using System.Windows.Forms;
using DTO_Tier;
using BUS_Tier;
using System.IO;

namespace UI_Tier
{
    public partial class ucAdmin_UserItem : UserControl
    {
        private UserDTO _user;
        private DoctorDTO _doctor;
        private AdminBUS _adminBUS = new AdminBUS();
        private PatientDTO _patientDTO = new PatientDTO();
        public event EventHandler DataChanged;

        public ucAdmin_UserItem()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlCard);
            
            pnlCard.Paint += pnlCard_Paint;
            pnlCard.Resize += (s, e) => {
                UIHelper.ApplyRoundedRegion(pnlCard, 15);
                UIHelper.ApplyRoundedRegion(btnApprove, 10);
                UIHelper.ApplyRoundedRegion(btnReject, 10);
                UIHelper.ApplyRoundedRegion(btnToggleStatus, 10);
                UIHelper.ApplyRoundedRegion(btnEdit, 10);
                UIHelper.ApplyRoundedRegion(btnRemove, 10);
                UIHelper.ApplyRoundedRegion(btnDetail, 10);
                UIHelper.ApplyRoundedRegion(pnlRoleBadge, 12);
                UIHelper.ApplyRoundedRegion(pnlApprovalBadge, 12);
                UIHelper.ApplyRoundedRegion(pnlStatusBadge, 12);
            };
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 15, Color.FromArgb(200, 200, 200), 3);
        }

        public void SetUserData(UserDTO user)
        {
            _user = user;
            if (_user.Role == "Doctor")
            {
                _doctor = _adminBUS.GetDoctorByUserId(_user.Id);
                _patientDTO = null;
            }
            else if (_user.Role == "Patient")
            {
                _doctor = null;
                _patientDTO = _adminBUS.GetPatientByUserId(_user.Id);
            }
            else
            {
                _doctor = null;
                _patientDTO = null;
            }
            UpdateUI();
        }

        public void SetDoctorData(DoctorDTO doctor)
        {
            _doctor = doctor;
            _user = doctor.User;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (_user == null) return;

            lblFullName.Text = _user.FullName;
            
            // Role Styling
            SetRoleBadge(_user.Role);

            // Status Badge
            lblStatus.Text = _user.Status == "Active" ? "✅ Hoạt động" : "🔒 Bị khóa";
            if (_user.Status == "Active")
            {
                lblStatus.ForeColor = Color.FromArgb(22, 163, 74);
                pnlStatusBadge.BackColor = Color.FromArgb(220, 252, 231);
            }
            else
            {
                lblStatus.ForeColor = Color.FromArgb(220, 38, 38);
                pnlStatusBadge.BackColor = Color.FromArgb(254, 226, 226);
            }

            // Role specific data
            if (_user.Role == "Doctor" && _doctor != null)
            {
                lblDeptOrCode.Text = "Chuyên khoa: " + (_doctor.Department?.DepartmentName ?? "Chưa cập nhật");
                lblPhone.Text = "Số điện thoại: " + (_user.PhoneNumber ?? "Chưa cập nhật");
                lblLicenseOrBHYT.Text = "Số CCHN: " + (_doctor.LicenseNumber ?? "Chưa cập nhật");
                lblExp.Text = "Kinh nghiệm: " + (_doctor.ExperienceYears?.ToString() ?? "0") + " năm";
                
                lblDeptOrCode.Visible = true;
                lblPhone.Visible = true;
                lblLicenseOrBHYT.Visible = true;
                lblExp.Visible = true;
                lblDob.Visible = false;

                // Approval Badge
                pnlApprovalBadge.Visible = true;
                btnRemove.Visible = true;
                if (_doctor.IsApproved)
                {
                    lblApproval.Text = "✔ Đã duyệt";
                    lblApproval.ForeColor = Color.FromArgb(22, 163, 74);
                    pnlApprovalBadge.BackColor = Color.FromArgb(220, 252, 231);
                }
                else
                {
                    lblApproval.Text = "⏳ Chờ duyệt";
                    lblApproval.ForeColor = Color.FromArgb(161, 98, 7);
                    pnlApprovalBadge.BackColor = Color.FromArgb(254, 252, 232);
                }
            }
            else
            {
                // Patient specific
                pnlApprovalBadge.Visible = false;
                lblDeptOrCode.Text = "Mã bệnh nhân: " + (_patientDTO?.MedicalCode ?? ("BN" + _user.Id.ToString("D4")));
                lblPhone.Text = "Số điện thoại: " + (_user.PhoneNumber ?? "Chưa cập nhật");
                lblLicenseOrBHYT.Text = "Mã BHYT: " + (_patientDTO?.InsuranceCode ?? "Chưa cập nhật");
                lblDob.Text = "Ngày sinh: " + (_user.Dob?.ToString("dd/MM/yyyy") ?? "Chưa cập nhật");
                
                lblDeptOrCode.Visible = true;
                lblPhone.Visible = true;
                lblLicenseOrBHYT.Visible = true;
                lblExp.Visible = false;
                lblDob.Visible = true;
                btnRemove.Visible = true;
            }

            // Action Buttons styling with Icons (MDL2 Assets)
            btnApprove.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnReject.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnToggleStatus.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btnApprove.Text = "✔ Phê duyệt";
            btnReject.Text = "✖ Từ chối";
            
            btnApprove.Visible = (_user.Role == "Doctor" && _doctor != null && !_doctor.IsApproved);
            btnReject.Visible = (_user.Role == "Doctor" && _doctor != null && !_doctor.IsApproved);

            if (_user.Status == "Active")
            {
                btnToggleStatus.Text = "🔒 Chặn";
                btnToggleStatus.BackColor = Color.FromArgb(255, 87, 34);
            }
            else
            {
                btnToggleStatus.Text = "🔓 Mở khóa";
                btnToggleStatus.BackColor = Color.FromArgb(37, 99, 235);
            }
            btnToggleStatus.Visible = !btnApprove.Visible;

            // Ensure buttons that use icons have the right font for the icon part if needed, 
            // but usually Segoe UI covers these or we use the icon button style.
            // Since we are mixing text and icons, Segoe UI is usually fine if they are unicode.

            // Apply rounding to badges
            UIHelper.ApplyRoundedRegion(pnlRoleBadge, 10);
            UIHelper.ApplyRoundedRegion(pnlStatusBadge, 10);
        }

        private void SetRoleBadge(string role)
        {
            switch (role)
            {
                case "Admin":
                    lblRole.ForeColor = Color.FromArgb(114, 46, 209);
                    pnlRoleBadge.BackColor = Color.FromArgb(249, 240, 255);
                    lblRole.Text = "QUẢN TRỊ";
                    break;
                case "Doctor":
                    lblRole.ForeColor = Color.FromArgb(0, 98, 255);
                    pnlRoleBadge.BackColor = Color.FromArgb(219, 234, 254);
                    lblRole.Text = "BÁC SĨ";
                    break;
                case "Patient":
                    lblRole.ForeColor = Color.FromArgb(16, 185, 129);
                    pnlRoleBadge.BackColor = Color.FromArgb(209, 250, 229);
                    lblRole.Text = "BỆNH NHÂN";
                    break;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (_doctor == null) return;
            string msg = _adminBUS.GetApproveConfirmMessage(_user.FullName);
            if (MessageBox.Show(msg, "Phê duyệt bác sĩ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_adminBUS.ApproveDoctor(_doctor.Id))
                {
                    DataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (_doctor == null) return;
            string msg = _adminBUS.GetRejectConfirmMessage(_user.FullName);
            if (MessageBox.Show(msg, "Từ chối bác sĩ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_adminBUS.RejectDoctor(_doctor.Id))
                {
                    DataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (_user == null) return;
            
            if (_user.Status == "Active")
            {
                // Logic Chặn (Block)
                var stats = _adminBUS.GetAppointmentStatistics(_user.Id, _user.Role);
                
                if (stats.Confirmed > 0)
                {
                    MessageBox.Show($"Không thể chặn tài khoản này vì đang có {stats.Confirmed} cuộc hẹn đã được duyệt.\nVui lòng xử lý các cuộc hẹn này trước khi chặn.", 
                        "Không thể chặn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string msg = $"Bạn có chắc chắn muốn khóa tài khoản của {_user.FullName}?";
                if (stats.Pending > 0)
                {
                    msg += $"\n\nLưu ý: Tài khoản này đang có {stats.Pending} cuộc hẹn ĐANG CHỜ DUYỆT. Nếu bạn chặn, tất cả các cuộc hẹn này sẽ bị HỦY tự động.";
                }

                if (MessageBox.Show(msg, "Khóa tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_adminBUS.BlockUserWithAppointmentHandling(_user.Id, _user.Role))
                    {
                        DataChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            else
            {
                // Logic Mở khóa (Unblock)
                string msg = $"Bạn có muốn mở khóa tài khoản cho {_user.FullName}? Người dùng có thể đăng nhập lại vào hệ thống.";
                if (MessageBox.Show(msg, "Mở khóa tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_adminBUS.UpdateUserStatus(_user.Id, "Active"))
                    {
                        // Nếu là bác sĩ, cũng cần mở lại IsActive trong bảng Doctors
                        if (_user.Role == "Doctor")
                        {
                            var doc = _adminBUS.GetDoctorByUserId(_user.Id);
                            if (doc != null)
                            {
                                // Cần một phương thức để mở lại IsActive bác sĩ nếu cần, 
                                // nhưng hiện tại UpdateUserStatus có thể đã đủ hoặc cần bổ sung vào DAL.
                                // Tuy nhiên, yêu cầu tập trung vào phần CHẶN.
                            }
                        }
                        DataChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_user == null) return;

            // Kiểm tra lịch hẹn trước khi xóa
            var stats = _adminBUS.GetAppointmentStatistics(_user.Id, _user.Role);

            if (stats.Confirmed > 0)
            {
                MessageBox.Show($"Không thể xóa tài khoản này vì đang có {stats.Confirmed} cuộc hẹn đã được duyệt.\nVui lòng xử lý các cuộc hẹn này trước khi xóa.", 
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string msg = $"Bạn có chắc chắn muốn xóa vĩnh viễn tài khoản của {_user.FullName}? Hành động này không thể hoàn tác.";
            if (stats.Pending > 0)
            {
                msg += $"\n\nLưu ý: Tài khoản này đang có {stats.Pending} cuộc hẹn ĐANG CHỜ DUYỆT. Nếu bạn xóa, tất cả các cuộc hẹn này sẽ bị HỦY tự động và giải phóng chỗ đặt.";
            }

            if (MessageBox.Show(msg, "Xóa tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_adminBUS.DeleteUserWithAppointmentHandling(_user.Id, _user.Role))
                {
                    DataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenDetailView(true);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            OpenDetailView(false);
        }

        private void OpenDetailView(bool editMode)
        {
            int userId = _user?.Id ?? _doctor?.UserId ?? 0;
            string role = _user?.Role ?? "Doctor";

            var result = _adminBUS.GetFullUserDetails(userId, role);

            if (result.User != null)
            {
                UserControl detail;
                if (role == "Doctor")
                {
                    var docDetail = new ucAdmin_DoctorDetail();
                    docDetail.SetData(result.User, result.Doctor);
                    if (editMode) docDetail.SetEditMode(true);
                    detail = docDetail;
                }
                else
                {
                    var patDetail = new ucAdmin_PatientDetail();
                    patDetail.SetData(result.User, result.Patient);
                    if (editMode) patDetail.SetEditMode(true);
                    detail = patDetail;
                }

                // Tìm Parent là ucAdmin_UserManagement để hiển thị Overlay
                Control p = this.Parent;
                while (p != null && !(p is ucAdmin_UserManagement))
                {
                    p = p.Parent;
                }

                if (p is ucAdmin_UserManagement userMgmt)
                {
                    userMgmt.ShowOverlay(detail);
                }
                else
                {
                    // Fallback nếu không tìm thấy (hiển thị form đơn giản)
                    Form f = new Form { 
                        Size = new Size(1300, 1100), 
                        FormBorderStyle = FormBorderStyle.None, 
                        StartPosition = FormStartPosition.CenterScreen 
                    };
                    detail.Dock = DockStyle.Fill;
                    f.Controls.Add(detail);
                    f.ShowDialog();
                }

                DataChanged?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
