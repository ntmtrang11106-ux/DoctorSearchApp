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
            string msg = _adminBUS.GetToggleStatusMessage(_user);
            string title = _user.Status == "Active" ? "Khóa tài khoản" : "Mở khóa tài khoản";
            
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string newStatus = _user.Status == "Active" ? "Inactive" : "Active";
                if (_adminBUS.UpdateUserStatus(_user.Id, newStatus))
                {
                    DataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_user == null) return;
            string msg = _adminBUS.GetDeleteConfirmMessage(_user.FullName);
            if (MessageBox.Show(msg, "Xóa tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_adminBUS.DeleteUser(_user.Id))
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
                Form f = new Form
                {
                    FormBorderStyle = FormBorderStyle.None,
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = Color.White,
                    Padding = new Padding(2),
                    Text = "",
                    ControlBox = false
                };

                Panel pnlBorder = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
                f.Controls.Add(pnlBorder);

                if (role == "Doctor")
                {
                    ucAdmin_DoctorDetail detail = new ucAdmin_DoctorDetail();
                    detail.Dock = DockStyle.Fill;
                    detail.SetData(result.User, result.Doctor);
                    if (editMode) detail.SetEditMode(true);
                    pnlBorder.Controls.Add(detail);
                    f.Size = new Size(1300, 1100);
                }
                else
                {
                    ucAdmin_PatientDetail detail = new ucAdmin_PatientDetail();
                    detail.Dock = DockStyle.Fill;
                    detail.SetData(result.User, result.Patient);
                    if (editMode) detail.SetEditMode(true);
                    pnlBorder.Controls.Add(detail);
                    f.Size = new Size(1300, 1100);
                }

                f.Resize += (s, ev) => {
                    UIHelper.ApplyRoundedRegion(f, 15);
                    f.Refresh();
                };

                f.Paint += (s, ev) => {
                    using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 2)) {
                        ev.Graphics.DrawRectangle(pen, 0, 0, f.Width - 1, f.Height - 1);
                    }
                };

                UIHelper.ApplyRoundedRegion(f, 15);
                f.ShowDialog();
                
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //public static extern bool ReleaseCapture();

        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //public const int WM_NCLBUTTONDOWN = 0xA1;
        //public const int HT_CAPTION = 0x2;

        //private void ucAdmin_UserItem_Load(object sender, EventArgs e)
        //{
        //    UIHelper.ApplyRoundedRegion(pnlCard, 15);
        //    UIHelper.ApplyRoundedRegion(pnlRoleBadge, 5);
        //    UIHelper.ApplyRoundedRegion(pnlStatusBadge, 15);
        //    UIHelper.ApplyRoundedRegion(pnlApprovalBadge, 15);
        //    UIHelper.ApplyRoundedRegion(btnApprove, 8);
        //    UIHelper.ApplyRoundedRegion(btnReject, 8);
        //    UIHelper.ApplyRoundedRegion(btnToggleStatus, 8);
        //    UIHelper.ApplyRoundedRegion(btnDetail, 20); // Circle button
        //}

        //private void ucAdmin_UserItem_Paint(object sender, PaintEventArgs e)
        //{
        //    // Optional shadow or border for card effect
        //    UIHelper.DrawControlBorder(pnlCard, e, 15, Color.FromArgb(230, 230, 230), 1);
        //}
    }
}

        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //public static extern bool ReleaseCapture();

        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //public const int WM_NCLBUTTONDOWN = 0xA1;
        //public const int HT_CAPTION = 0x2;

        //private void ucAdmin_UserItem_Load(object sender, EventArgs e)
        //{
        //    UIHelper.ApplyRoundedRegion(pnlCard, 15);
        //    UIHelper.ApplyRoundedRegion(pnlRoleBadge, 5);
        //    UIHelper.ApplyRoundedRegion(pnlStatusBadge, 15);
        //    UIHelper.ApplyRoundedRegion(pnlApprovalBadge, 15);
        //    UIHelper.ApplyRoundedRegion(btnApprove, 8);
        //    UIHelper.ApplyRoundedRegion(btnReject, 8);
        //    UIHelper.ApplyRoundedRegion(btnToggleStatus, 8);
        //    UIHelper.ApplyRoundedRegion(btnDetail, 20); // Circle button
        //}

        //private void ucAdmin_UserItem_Paint(object sender, PaintEventArgs e)
        //{
        //    // Optional shadow or border for card effect
        //    UIHelper.DrawControlBorder(pnlCard, e, 15, Color.FromArgb(230, 230, 230), 1);
        //}
//    }
//}
