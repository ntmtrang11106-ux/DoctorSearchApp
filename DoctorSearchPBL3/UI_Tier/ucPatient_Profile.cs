using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UI_Tier.Properties;

namespace UI_Tier
{
    public partial class ucPatient_Profile : UserControl
    {
        private readonly BUS_Tier.PatientBUS _patientBUS = new BUS_Tier.PatientBUS();
        private readonly BUS_Tier.UserBUS _userBUS = new BUS_Tier.UserBUS();
        private DTO_Tier.PatientDTO _currentPatient;

        public ucPatient_Profile()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlMain);
            
            // Apply rounded corners to avatar
            UIHelper.ApplyRoundedRegion(picAvatar, picAvatar.Width / 2);
            
            // Set initial state
            SetEditMode(false, "basic");
            SetEditMode(false, "medical");

            // Wire up Load event
            this.HandleCreated += (s, e) => LoadPatientData();
        }

        private void LoadPatientData()
        {
            int profileId = DTO_Tier.GlobalAccount.GetProfileId();
            
            // For testing/development: if no one is logged in, try to load the first patient from DB
            if (profileId <= 0)
            {
                using (var db = new DAL_Tier.AppDbContext())
                {
                    var firstPatient = db.Patients.FirstOrDefault(p => !p.IsDeleted);
                    if (firstPatient != null) profileId = firstPatient.Id;
                }
            }

            _currentPatient = _patientBUS.GetPatientProfile(profileId);

            if (_currentPatient != null && _currentPatient.User != null)
            {
                txtFullName.Text = _currentPatient.User.FullName;
                lblPatientName.Text = _currentPatient.User.FullName;
                txtPhone.Text = _currentPatient.User.PhoneNumber;
                txtEmail.Text = ""; // SQL doesn't have Email yet
                txtBirthday.Text = _currentPatient.User.Dob?.ToString("dd/MM/yyyy") ?? "";
                txtGender.Text = _currentPatient.User.Gender ?? "";
                txtCCCD.Text = _currentPatient.User.CCCD ?? "";
                txtBHYT.Text = _currentPatient.InsuranceCode ?? "";
                txtPatientID.Text = _currentPatient.MedicalCode ?? $"BN-{_currentPatient.Id:D4}";
                txtEmergencyContact.Text = _currentPatient.EmergencyContactName ?? "";
                txtEmergencyPhone.Text = _currentPatient.EmergencyContactPhone ?? "";
                txtAddress.Text = _currentPatient.User.Residential_Address ?? "";

                // Parse Note for medical info
                ParseMedicalNote(_currentPatient.Note);

                if (!string.IsNullOrEmpty(_currentPatient.User.Picture))
                {
                    try { picAvatar.ImageLocation = _currentPatient.User.Picture; } catch { }
                }
            }
            else
            {
                LoadPlaceholderData();
            }
        }

        private void ParseMedicalNote(string note)
        {
            if (string.IsNullOrEmpty(note)) return;

            // Simple parsing: "BT: O | AL: None | MH: History"
            var parts = note.Split('|');
            foreach (var part in parts)
            {
                var kv = part.Split(':');
                if (kv.Length == 2)
                {
                    string key = kv[0].Trim();
                    string val = kv[1].Trim();
                    if (key == "BT") txtBloodType.Text = val;
                    else if (key == "AL") txtAllergy.Text = val;
                    else if (key == "MH") txtMedicalHistory.Text = val;
                }
            }
        }

        private string GenerateMedicalNote()
        {
            return $"BT: {txtBloodType.Text} | AL: {txtAllergy.Text} | MH: {txtMedicalHistory.Text}";
        }

        private void LoadPlaceholderData()
        {
            txtFullName.Text = "Nguyễn Văn Minh";
            lblPatientName.Text = "Nguyễn Văn Minh";
            txtPhone.Text = "0987654321";
            txtEmail.Text = "nguyenvanminh@email.com";
            txtBirthday.Text = "15/05/1990";
            txtGender.Text = "Nam";
            txtCCCD.Text = "001234567890";
            txtBHYT.Text = "DN1234567890123";
            txtPatientID.Text = "BN-2026-99";
            txtEmergencyContact.Text = "Nguyễn Thị Hoa";
            txtEmergencyPhone.Text = "0912345678";
            txtAddress.Text = "123 Đường Láng, Đống Đa, Hà Nội";

            txtBloodType.Text = "O";
            txtAllergy.Text = "Không có dị ứng thuốc";
            txtMedicalHistory.Text = "Viêm dạ dày mãn tính năm 2020";

            // Load default image if possible
            try {
                // If you have a default image, load it here
                // picAvatar.Image = Resources.bs_nguyen_van_an; 
            } catch { }
        }

        private void SetEditMode(bool isEditing, string section)
        {
            if (section == "basic")
            {
                txtFullName.ReadOnly = !isEditing;
                txtPhone.ReadOnly = !isEditing;
                txtEmail.ReadOnly = !isEditing;
                txtBirthday.ReadOnly = !isEditing;
                txtGender.ReadOnly = !isEditing;
                txtCCCD.ReadOnly = !isEditing;
                txtBHYT.ReadOnly = !isEditing;
                txtPatientID.ReadOnly = !isEditing;
                txtEmergencyContact.ReadOnly = !isEditing;
                txtEmergencyPhone.ReadOnly = !isEditing;
                txtAddress.ReadOnly = !isEditing;

                // Toggle colors to indicate editability
                Color bg = isEditing ? Color.White : Color.FromArgb(248, 249, 250);
                txtFullName.BackColor = bg;
                txtPhone.BackColor = bg;
                txtEmail.BackColor = bg;
                txtBirthday.BackColor = bg;
                txtGender.BackColor = bg;
                txtCCCD.BackColor = bg;
                txtBHYT.BackColor = bg;
                txtPatientID.BackColor = bg;
                txtEmergencyContact.BackColor = bg;
                txtEmergencyPhone.BackColor = bg;
                txtAddress.BackColor = bg;

                pnlBasicInfoActions.Visible = isEditing;
                btnEditBasicInfo.Visible = !isEditing;
            }
            else if (section == "medical")
            {
                txtBloodType.ReadOnly = !isEditing;
                txtAllergy.ReadOnly = !isEditing;
                txtMedicalHistory.ReadOnly = !isEditing;

                Color bg = isEditing ? Color.White : Color.FromArgb(248, 249, 250);
                txtBloodType.BackColor = bg;
                txtAllergy.BackColor = bg;
                txtMedicalHistory.BackColor = bg;

                pnlMedicalActions.Visible = isEditing;
                btnEditMedical.Visible = !isEditing;
            }
        }

        private void ShowChangePassword(bool show)
        {
            pnlChangePassword.Visible = show;
            lblSecurityHint.Visible = !show;
            btnChangePassword.Visible = !show;
            
            // Adjust height of security panel to fit the form
            pnlSecurity.Height = show ? 850 : 150;
            
            if (show) {
                txtCurrentPass.Clear();
                txtNewPass.Clear();
                txtConfirmPass.Clear();
                // Ensure the view scrolls to the security section
                pnlMain.ScrollControlIntoView(pnlSecurity);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnEditBasicInfo) SetEditMode(true, "basic");
            else if (btn == btnEditMedical) SetEditMode(true, "medical");
            else if (btn == btnChangePassword) ShowChangePassword(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentPatient == null) return;

            Button btn = sender as Button;
            if (btn == btnSaveBasicInfo) {
                // Gather Basic Info
                _currentPatient.User.FullName = txtFullName.Text;
                _currentPatient.User.PhoneNumber = txtPhone.Text;
                _currentPatient.User.Gender = txtGender.Text;
                _currentPatient.User.CCCD = txtCCCD.Text;
                _currentPatient.User.Residential_Address = txtAddress.Text;
                _currentPatient.InsuranceCode = txtBHYT.Text;
                _currentPatient.MedicalCode = txtPatientID.Text;
                _currentPatient.EmergencyContactName = txtEmergencyContact.Text;
                _currentPatient.EmergencyContactPhone = txtEmergencyPhone.Text;

                if (DateTime.TryParse(txtBirthday.Text, out DateTime dob))
                    _currentPatient.User.Dob = dob;

                string result = _patientBUS.UpdatePatientProfile(_currentPatient);
                if (result == "Success")
                {
                    SetEditMode(false, "basic");
                    lblPatientName.Text = txtFullName.Text;
                    MessageBox.Show("Đã lưu thông tin cá nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btn == btnSaveMedical) {
                // Gather Medical Info into Note
                _currentPatient.Note = GenerateMedicalNote();

                string result = _patientBUS.UpdatePatientProfile(_currentPatient);
                if (result == "Success")
                {
                    SetEditMode(false, "medical");
                    MessageBox.Show("Đã cập nhật hồ sơ y tế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btn == btnSavePass) {
                if (string.IsNullOrEmpty(txtCurrentPass.Text)) {
                    MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtNewPass.Text) || txtNewPass.Text.Length < 6) {
                    MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtNewPass.Text != txtConfirmPass.Text) {
                    MessageBox.Show("Xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Password change logic (using UserBUS/SecurityHelper)
                // Note: You might need to add a ChangePassword method to UserBUS if not exists
                // For now, I'll use a direct context update or assume UserBUS can handle it.
                // Assuming UserBUS has a way to verify and update pass.
                
                using (var db = new DAL_Tier.AppDbContext())
                {
                    var user = db.Users.Find(_currentPatient.UserId);
                    if (user != null)
                    {
                        if (BUS_Tier.UserBUS.SecurityHelper.VerifyPassword(txtCurrentPass.Text, user.Password))
                        {
                            user.Password = BUS_Tier.UserBUS.SecurityHelper.HashPassword(txtNewPass.Text);
                            user.UpdatedAt = DateTime.Now;
                            db.SaveChanges();
                            ShowChangePassword(false);
                            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu hiện tại không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnCancelBasicInfo) SetEditMode(false, "basic");
            else if (btn == btnCancelMedical) SetEditMode(false, "medical");
            else if (btn == btnCancelPass) ShowChangePassword(false);
        }

        private void TogglePassVisibility_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            TextBox target = null;

            if (target != null)
            {
                target.UseSystemPasswordChar = !target.UseSystemPasswordChar;
                // E115 is Eye (Open), E101 is Eye with Slash (Closed/Hidden)
                lbl.Text = target.UseSystemPasswordChar ? "\uE101" : "\uE115";
                lbl.ForeColor = target.UseSystemPasswordChar ? Color.Gray : Color.FromArgb(0, 120, 215);
            }
        }

        private void SectionPanel_Paint(object sender, PaintEventArgs e)
        {
            Control pnl = sender as Control;
            if (pnl == null) return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Extra soft shadow
            for (int i = 1; i <= 6; i++)
            {
                Rectangle shadowRect = new Rectangle(i, i, pnl.Width - i * 2, pnl.Height - i * 2);
                using (var path = UIHelper.GetRoundedPath(shadowRect, 20))
                {
                    using (Pen shadowPen = new Pen(Color.FromArgb(12 / i, Color.Black), i))
                    {
                        e.Graphics.DrawPath(shadowPen, path);
                    }
                }
            }

            Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            using (var path = UIHelper.GetRoundedPath(rect, 20))
            {
                using (Pen pen = new Pen(Color.FromArgb(232, 235, 239), 1))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.btn_Paint(sender, e);
        }
    }
}



