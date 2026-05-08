using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BUS_Tier;
using DTO_Tier;

namespace UI_Tier
{
    public partial class ucDoctor_Profile : UserControl
    {
        private readonly DoctorBUS _doctorBUS = new DoctorBUS();
        private readonly UserBUS _userBUS = new UserBUS();
        private DoctorDTO _currentDoctor;

        public ucDoctor_Profile()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlMain);
            
            //// Apply rounded corners
            //UIHelper.ApplyRoundedRegion(picAvatar, picAvatar.Width / 2);
            //UIHelper.ApplyRoundedRegion(pnlBasicInfo, 20);
            //UIHelper.ApplyRoundedRegion(pnlSecurity, 20);
            //UIHelper.ApplyRoundedRegion(btnSaveBasicInfo, 12);
            //UIHelper.ApplyRoundedRegion(btnCancelBasicInfo, 12);
            //UIHelper.ApplyRoundedRegion(btnSavePass, 12);
            //UIHelper.ApplyRoundedRegion(btnCancelPass, 12);

            SetEditMode(false, "basic");
            this.HandleCreated += (s, e) => InitData();
            AttachReadOnlyHandlers();
        }

        private void AttachReadOnlyHandlers()
        {
            txtFullName.Enter += TextBox_Enter;
            txtPhone.Enter += TextBox_Enter;
            txtGender.Enter += TextBox_Enter;
            txtCCCD.Enter += TextBox_Enter;
            txtAddress.Enter += TextBox_Enter;
            txtPosition.Enter += TextBox_Enter;
            txtSpecialty.Enter += TextBox_Enter;
            txtLicense.Enter += TextBox_Enter;
            txtConsultationFee.Enter += TextBox_Enter;
            txtExperienceYears.Enter += TextBox_Enter;
            txtBiography.Enter += TextBox_Enter;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox tb && tb.ReadOnly)
            {
                pnlMain.Focus();
            }
        }

        public void InitData()
        {
            int profileId = GlobalAccount.GetProfileId();
            if (profileId <= 0) return;

            _currentDoctor = _doctorBUS.GetDoctorById(profileId);

            if (_currentDoctor != null && _currentDoctor.User != null)
            {
                txtFullName.Text = _currentDoctor.User.FullName;
                lblDoctorName.Text = (_currentDoctor.Position + " " + _currentDoctor.User.FullName).Trim();
                txtPhone.Text = _currentDoctor.User.PhoneNumber;
                dtpBirthday.Value = _currentDoctor.User.Dob ?? DateTime.Now;
                txtGender.Text = _currentDoctor.User.Gender ?? "";
                txtCCCD.Text = _currentDoctor.User.CCCD ?? "";
                txtAddress.Text = _currentDoctor.User.Residential_Address ?? "";
                txtPosition.Text = _currentDoctor.Position ?? "";
                txtSpecialty.Text = _currentDoctor.Department?.DepartmentName ?? "Chuyên khoa";
                txtLicense.Text = _currentDoctor.LicenseNumber ?? $"DR-{_currentDoctor.Id:D4}";
                txtExperienceYears.Text = _currentDoctor.ExperienceYears?.ToString() ?? "0";
                txtConsultationFee.Text = _currentDoctor.ConsultationFee?.ToString("N0") ?? "0";
                txtBiography.Text = _currentDoctor.Biography ?? "";

                string picPath = _currentDoctor.User.Picture;
                if (!string.IsNullOrEmpty(picPath) && File.Exists(picPath))
                {
                    try { picAvatar.ImageLocation = picPath; } catch { LoadDefaultAvatar(); }
                }
                else LoadDefaultAvatar();
            }
        }

        private void LoadDefaultAvatar()
        {
            picAvatar.Image = null; // or set a default image from resources
            picAvatar.BackColor = Color.FromArgb(241, 245, 249);
        }

        private void SetEditMode(bool isEdit, string section)
        {
            if (section == "basic")
            {
                // Editable fields
                txtFullName.ReadOnly = !isEdit;
                txtPhone.ReadOnly = !isEdit;
                txtGender.ReadOnly = !isEdit;
                txtCCCD.ReadOnly = !isEdit;
                txtAddress.ReadOnly = !isEdit;
                dtpBirthday.Enabled = isEdit;
                txtConsultationFee.ReadOnly = !isEdit;
                txtBiography.ReadOnly = !isEdit;

                // Always Read-Only fields
                txtPosition.ReadOnly = true;
                txtSpecialty.ReadOnly = true;
                txtLicense.ReadOnly = true;
                txtExperienceYears.ReadOnly = true;

                pnlBasicInfoActions.Visible = isEdit;
                btnEditBasicInfo.Visible = !isEdit;

                Color editColor = Color.White;
                Color readOnlyColor = Color.FromArgb(250, 251, 252);

                // Set backgrounds based on editability
                txtFullName.BackColor = isEdit ? editColor : readOnlyColor;
                txtPhone.BackColor = isEdit ? editColor : readOnlyColor;
                txtGender.BackColor = isEdit ? editColor : readOnlyColor;
                txtCCCD.BackColor = isEdit ? editColor : readOnlyColor;
                txtAddress.BackColor = isEdit ? editColor : readOnlyColor;
                txtConsultationFee.BackColor = isEdit ? editColor : readOnlyColor;
                txtBiography.BackColor = isEdit ? editColor : readOnlyColor;

                // These always stay gray
                txtPosition.BackColor = readOnlyColor;
                txtSpecialty.BackColor = readOnlyColor;
                txtLicense.BackColor = readOnlyColor;
                txtExperienceYears.BackColor = readOnlyColor;

                if (isEdit) txtFullName.Focus();
            }
            else if (section == "security")
            {
                pnlChangePassword.Visible = isEdit;
                btnChangePassword.Visible = !isEdit;
                if (isEdit) txtCurrentPass.Focus();
                else
                {
                    txtCurrentPass.Clear();
                    txtNewPass.Clear();
                    txtConfirmPass.Clear();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (sender == btnEditBasicInfo) SetEditMode(true, "basic");
            else if (sender == btnChangePassword) SetEditMode(true, "security");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (sender == btnCancelBasicInfo)
            {
                SetEditMode(false, "basic");
                InitData(); // Reset values
            }
            else if (sender == btnCancelPass) SetEditMode(false, "security");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sender == btnSaveBasicInfo) SaveBasicInfo();
            else if (sender == btnSavePass) SavePassword();
        }

        private void SaveBasicInfo()
        {
            if (_currentDoctor == null) return;

            var user = _currentDoctor.User;
            user.FullName = txtFullName.Text.Trim();
            user.PhoneNumber = txtPhone.Text.Trim();
            user.Gender = txtGender.Text.Trim();
            user.CCCD = txtCCCD.Text.Trim();
            user.Residential_Address = txtAddress.Text.Trim();
            user.Dob = dtpBirthday.Value;

            // Update doctor specific fields
            _currentDoctor.ExperienceYears = int.TryParse(txtExperienceYears.Text, out int exp) ? exp : 0;
            _currentDoctor.ConsultationFee = decimal.TryParse(txtConsultationFee.Text.Replace(".", "").Replace(",", ""), out decimal fee) ? fee : 0;
            _currentDoctor.Biography = txtBiography.Text.Trim();

            string result = _doctorBUS.UpdateDoctorInfo(_currentDoctor);
            if (result.Contains("thành công"))
            {
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetEditMode(false, "basic");
                InitData();
            }
            else MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SavePassword()
        {
            string curr = txtCurrentPass.Text;
            string newP = txtNewPass.Text;
            string conf = txtConfirmPass.Text;

            if (string.IsNullOrEmpty(curr) || string.IsNullOrEmpty(newP))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newP != conf)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = GlobalAccount.GetUserId();
            string result = _userBUS.ChangePassword(userId, curr, newP);
            if (result == "Success")
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetEditMode(false, "security");
            }
            else MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SectionPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            // Vẽ viền bo góc nhẹ
            UIHelper.DrawControlBorder(p, e, 20, Color.FromArgb(226, 232, 240), 1);

            // Vẽ một đường trang trí màu sắc ở trên cùng của panel để tạo điểm nhấn
            Color accentColor = Color.FromArgb(37, 99, 235); // Blue cho bác sĩ
            if (p == pnlSecurity) accentColor = Color.FromArgb(244, 63, 94); // Rose cho bảo mật

            using (Pen accentPen = new Pen(accentColor, 6))
            {
                e.Graphics.DrawLine(accentPen, 20, 0, p.Width - 20, 0);
            }
        }
    }
}
