using DTO_Tier;
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
        private UserDTO _currentUser;
        private bool _isEditingBasic = false;
        private bool _isEditingMedical = false;
        private readonly Color _viewFieldBackColor = Color.FromArgb(248, 250, 252);
        private readonly Color _lockedFieldBackColor = Color.FromArgb(241, 245, 249);
        private readonly Color _fieldTextColor = Color.FromArgb(33, 37, 41);
        private readonly Color _lockedTextColor = Color.FromArgb(100, 116, 139);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        public ucPatient_Profile()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlMain);
            UIHelper.SetupSmoothScrolling(pnlMain);

            SetEditMode(false, "basic");
            SetEditMode(false, "medical");

            // Fix blinking
            UIHelper.SetDoubleBuffered(pnlBasicInfo);
            UIHelper.SetDoubleBuffered(pnlMedicalProfile);
            UIHelper.SetDoubleBuffered(pnlSecurity);
            UIHelper.SetDoubleBuffered(pnlChangePassword);
            UIHelper.SetDoubleBuffered(pnlBasicInfoActions);
            UIHelper.SetDoubleBuffered(pnlMedicalActions);

            // THÊM: Gán sự kiện Click cho tất cả các nút (Nếu designer chưa có)
            btnEditBasicInfo.Click += btnEdit_Click;
            btnEditMedical.Click += btnEdit_Click;
            btnChangePassword.Click += btnEdit_Click;

            btnCancelBasicInfo.Click += btnCancel_Click;
            btnCancelMedical.Click += btnCancel_Click;
            btnCancelPass.Click += btnCancel_Click;

            btnSaveBasicInfo.Click += btnSave_Click;
            btnSaveMedical.Click += btnSave_Click;
            btnSavePass.Click += btnSave_Click;

            // Gán sự kiện cho các nhãn Toggle Password (ví dụ đặt tên nhãn là lblToggleNewPass,...)
            // lblToggleNewPass.Click += TogglePassVisibility_Click;

            picAvatar.Cursor = Cursors.Hand;
            picAvatar.Click += picAvatar_Click; // Dùng hàm riêng của m bên dưới bọc sẵn check edit mode
            lblUpload.Click += picAvatar_Click;
            dtpBirthday.ValueChanged += dtpBirthday_ValueChanged;
            SetupFocusEffects();
            SetupViewModeInputBehavior();
            SetEditMode(false, "basic");
            SetEditMode(false, "medical");

            // THAY VÌ HandleCreated -> Dùng VisibleChanged để reset dữ liệu chuẩn khi chuyển Tab
            this.VisibleChanged += (s, e) => {
                if (this.Visible)
                {
                    InitData();
                    UIHelper.ApplyRoundedRegion(lblUpload, lblUpload.Width / 2);
                    UIHelper.ApplyRoundedRegion(picAvatar, picAvatar.Width / 2);
                }
            };

            UIHelper.RegisterClickToUnfocus(this);
            UIHelper.RegisterClickToUnfocus(pnlMain);
            UIHelper.RegisterClickToUnfocus(pnlBasicInfo);
            UIHelper.RegisterClickToUnfocus(pnlMedicalProfile);
            UIHelper.RegisterClickToUnfocus(pnlSecurity);
            UIHelper.RegisterClickToUnfocus(pnlChangePassword);
        }

        private void ChangeAvatar()
        {
            if (!_isEditingBasic) return;

            if (_currentPatient == null || _currentPatient.User == null)
            {
                MessageBox.Show("Không thể đổi ảnh khi dữ liệu hồ sơ chưa được tải.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string uploadDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads", "avatars");
                        if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

                        string fileName = $"pat_{DTO_Tier.GlobalAccount.GetUserId()}_{DateTime.Now.Ticks}{Path.GetExtension(ofd.FileName)}";
                        string destPath = Path.Combine(uploadDir, fileName);
                        string relativePath = Path.Combine("uploads", "avatars", fileName);

                        File.Copy(ofd.FileName, destPath, true);

                        // Save to database immediately
                        string result = _userBUS.UpdateAvatar(DTO_Tier.GlobalAccount.GetUserId(), relativePath);
                        if (result == "Success")
                        {
                            picAvatar.ImageLocation = destPath;
                            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                            _currentPatient.User.Picture = relativePath;
                            MessageBox.Show("Cập nhật ảnh đại diện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SetupFocusEffects()
        {
            UIHelper.SetupInputFocusEffect(txtFullName, pnlFullNameBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtPhone, pnlPhoneBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtGender, pnlGenderBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtCCCD, pnlCCCDBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtAddress, pnlAddressBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtBHYT, pnlBHYTBorder, Color.FromArgb(241, 243, 245), Color.FromArgb(241, 243, 245), Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtPatientID, pnlPatientIDBorder, Color.FromArgb(241, 243, 245), Color.FromArgb(241, 243, 245), Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtEmergencyContact, pnlEmergencyContactBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtEmergencyPhone, pnlEmergencyPhoneBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtBloodType, pnlBloodTypeBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtMedicalHistory, pnlMedicalHistoryBorder, Color.FromArgb(242, 248, 255), Color.FromArgb(248, 249, 250), Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtCurrentPass, pnlCurrentPassBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtNewPass, pnlNewPassBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtConfirmPass, pnlConfirmPassBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            
            // Birthday DateTimePicker focus styling
            UIHelper.SetupInputFocusEffect(dtpBirthday, pnlBirthdayBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
        }

        private void SetupViewModeInputBehavior()
        {
            TextBox[] textBoxes =
            {
                txtFullName, txtPhone, txtGender, txtCCCD, txtAddress,
                txtPatientID, txtEmergencyContact, txtEmergencyPhone,
                txtBHYT, txtBloodType, txtMedicalHistory
            };

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Enter += ReadOnlyTextBox_Enter;
            }

            Panel[] inputBorders =
            {
                pnlFullNameBorder, pnlPhoneBorder, pnlGenderBorder, pnlBirthdayBorder,
                pnlCCCDBorder, pnlAddressBorder, pnlEmergencyContactBorder,
                pnlEmergencyPhoneBorder, pnlPatientIDBorder, pnlBHYTBorder,
                pnlBloodTypeBorder, pnlMedicalHistoryBorder
            };

            foreach (Panel panel in inputBorders)
            {
                UIHelper.ApplyRoundedRegion(panel, 10);
                panel.Paint += ProfileInputBorder_Paint;
            }
        }

        private void ReadOnlyTextBox_Enter(object sender, EventArgs e)
        {
            if (sender is not TextBox textBox || !textBox.ReadOnly) return;

            BeginInvoke(new Action(() =>
            {
                if (IsDisposed || !textBox.ReadOnly) return;

                textBox.SelectionLength = 0;
                Form form = FindForm();
                if (form != null) form.ActiveControl = null;
                InvalidateProfileInputBorders();
            }));
        }

        private void SetTextBoxEditState(TextBox textBox, Panel borderPanel, bool canEdit, bool locked = false)
        {
            textBox.Enabled = true;
            textBox.ReadOnly = !canEdit;
            textBox.TabStop = canEdit;
            textBox.Cursor = canEdit ? Cursors.IBeam : Cursors.Default;
            textBox.ForeColor = locked ? _lockedTextColor : _fieldTextColor;

            Color backColor = canEdit ? Color.White : (locked ? _lockedFieldBackColor : _viewFieldBackColor);
            textBox.BackColor = backColor;
            borderPanel.BackColor = backColor;
            borderPanel.Invalidate();
        }

        private void ProfileInputBorder_Paint(object sender, PaintEventArgs e)
        {
            if (sender is not Panel panel) return;

            if (!IsPanelEditable(panel))
            {
                UIHelper.uc_Paint(panel, e, 10, Color.FromArgb(226, 232, 240), 2);
            }
        }

        private bool IsPanelEditable(Panel panel)
        {
            if (panel == pnlPatientIDBorder || panel == pnlBHYTBorder) return false;
            if (panel == pnlBloodTypeBorder || panel == pnlMedicalHistoryBorder) return _isEditingMedical;
            return _isEditingBasic;
        }

        private void InvalidateProfileInputBorders()
        {
            Panel[] inputBorders =
            {
                pnlFullNameBorder, pnlPhoneBorder, pnlGenderBorder, pnlBirthdayBorder,
                pnlCCCDBorder, pnlAddressBorder, pnlEmergencyContactBorder,
                pnlEmergencyPhoneBorder, pnlPatientIDBorder, pnlBHYTBorder,
                pnlBloodTypeBorder, pnlMedicalHistoryBorder
            };

            foreach (Panel panel in inputBorders)
            {
                panel.Invalidate();
            }
        }

        private void ClearActiveProfileFocus()
        {
            Form form = FindForm();
            if (form != null) form.ActiveControl = null;
        }

        private void UpdateBirthdayDisplay()
        {
            if (lblBirthdayValue != null)
            {
                lblBirthdayValue.Text = dtpBirthday.Value.ToString("dd / MM / yyyy");
            }
        }

        public void InitData()
        {
            int profileId = DTO_Tier.GlobalAccount.GetProfileId();
            
            // Fallback: If profileId is 0, try to get it from UserId
            if (profileId <= 0)
            {
                int userId = DTO_Tier.GlobalAccount.GetUserId();
                if (userId > 0)
                {
                    profileId = _userBUS.GetProfileIdByRole(userId, "Patient");
                }
            }

            if (profileId <= 0)
            {
                LoadPlaceholderData();
                return;
            }

            _currentPatient = _patientBUS.GetPatientProfile(profileId);

            if (_currentPatient != null && _currentPatient.User != null)
            {
                txtFullName.Text = _currentPatient.User.FullName;
                lblPatientName.Text = _currentPatient.User.FullName;
                txtPhone.Text = _currentPatient.User.PhoneNumber;
                dtpBirthday.Value = _currentPatient.User.Dob ?? DateTime.Now;
                txtGender.Text = _currentPatient.User.Gender ?? "";
                txtCCCD.Text = _currentPatient.User.CCCD ?? "";
                txtBHYT.Text = _currentPatient.InsuranceCode ?? "";
                txtPatientID.Text = string.IsNullOrWhiteSpace(_currentPatient.MedicalCode)
                    ? $"BN-{_currentPatient.Id:0000}"
                    : _currentPatient.MedicalCode;
                txtEmergencyContact.Text = _currentPatient.EmergencyContactName ?? "";
                txtEmergencyPhone.Text = _currentPatient.EmergencyContactPhone ?? "";
                txtAddress.Text = _currentPatient.User.Residential_Address ?? "";
                txtBloodType.Text = _currentPatient.BloodType ?? "";
                UpdateBirthdayDisplay();

                // Parse Note for medical info
                ParseMedicalNote(_currentPatient.Note);

                string picPath = _currentPatient.User.Picture;
                if (!string.IsNullOrEmpty(picPath))
                {
                    string fullPath = Path.IsPathRooted(picPath) ? picPath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images", picPath);

                    if (!File.Exists(fullPath))
                    {
                        // Thử nghiệm dự phòng nếu lỡ ảnh nằm ở BaseDirectory
                        fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, picPath);
                    }

                    if (File.Exists(fullPath))
                    {
                        picAvatar.ImageLocation = fullPath;
                        picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else LoadDefaultAvatar();
                }
                else LoadDefaultAvatar();
            }
            else
            {
                LoadPlaceholderData();
            }
        }

        private void ParseMedicalNote(string note)
        {
            if (string.IsNullOrEmpty(note)) 
            {
                txtMedicalHistory.Text = "";
                return;
            }

            // Bây giờ ô Note chỉ chứa trực tiếp Tiền sử bệnh
            txtMedicalHistory.Text = note;
        }

        private string GenerateMedicalNote()
        {
            // Chỉ trả về nội dung của Tiền sử bệnh để lưu vào ô Note
            return txtMedicalHistory.Text.Trim();
        }

        private void LoadPlaceholderData()
        {
            txtFullName.Text = "Nguyễn Văn Minh";
            lblPatientName.Text = "Nguyễn Văn Minh";
            txtPhone.Text = "0987654321";
            dtpBirthday.Value = new DateTime(1990, 5, 15);
            UpdateBirthdayDisplay();
            txtGender.Text = "Nam";
            txtCCCD.Text = "001234567890";
            txtBHYT.Text = "DN1234567890123";
            txtPatientID.Text = "BN-2026-99";
            txtEmergencyContact.Text = "Nguyễn Thị Hoa";
            txtEmergencyPhone.Text = "0912345678";
            txtAddress.Text = "123 Đường Láng, Đống Đa, Hà Nội";

            txtBloodType.Text = "O";
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
                _isEditingBasic = isEditing;

                dtpBirthday.Enabled = isEditing;
                dtpBirthday.Visible = isEditing;
                lblBirthdayValue.Visible = !isEditing;
                UpdateBirthdayDisplay();

                SetTextBoxEditState(txtFullName, pnlFullNameBorder, isEditing);
                SetTextBoxEditState(txtPhone, pnlPhoneBorder, isEditing);
                SetTextBoxEditState(txtGender, pnlGenderBorder, isEditing);
                SetTextBoxEditState(txtAddress, pnlAddressBorder, isEditing);
                SetTextBoxEditState(txtEmergencyContact, pnlEmergencyContactBorder, isEditing);
                SetTextBoxEditState(txtEmergencyPhone, pnlEmergencyPhoneBorder, isEditing);
                SetTextBoxEditState(txtPatientID, pnlPatientIDBorder, false, true);

                bool canEditCccd = isEditing && _userBUS.CalculateAge(dtpBirthday.Value) >= 16;
                SetTextBoxEditState(txtCCCD, pnlCCCDBorder, canEditCccd, !canEditCccd);
                pnlBirthdayBorder.BackColor = isEditing ? Color.White : _viewFieldBackColor;

                pnlBasicInfoActions.Visible = isEditing;
                btnEditBasicInfo.Visible = !isEditing;
                if (lblUpload != null) lblUpload.Visible = isEditing;

                InvalidateProfileInputBorders();
                if (isEditing) txtFullName.Focus();
                else ClearActiveProfileFocus();
            }
            else if (section == "medical")
            {
                _isEditingMedical = isEditing;
                SetTextBoxEditState(txtBloodType, pnlBloodTypeBorder, isEditing);
                SetTextBoxEditState(txtMedicalHistory, pnlMedicalHistoryBorder, isEditing);
                SetTextBoxEditState(txtBHYT, pnlBHYTBorder, false, true);

                pnlMedicalActions.Visible = isEditing;
                btnEditMedical.Visible = !isEditing;

                InvalidateProfileInputBorders();
                if (isEditing) txtBloodType.Focus();
                else ClearActiveProfileFocus();
            }
        }

        private void ShowChangePassword(bool show)
        {
            pnlChangePassword.Visible = show;
            lblSecurityHint.Visible = !show;
            btnChangePassword.Visible = !show;
            
            // Adjust height of security panel to fit the form
            pnlSecurity.Height = show ? 700 : 200;
            
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
                _currentPatient.User.Dob = dtpBirthday.Value;
                _currentPatient.User.Gender = txtGender.Text;
                _currentPatient.User.CCCD = txtCCCD.Text;
                _currentPatient.User.Residential_Address = txtAddress.Text;
                _currentPatient.EmergencyContactName = txtEmergencyContact.Text;
                _currentPatient.EmergencyContactPhone = txtEmergencyPhone.Text;

                if (DateTime.TryParse(dtpBirthday.Value.ToString("dd/MM/yyyy"), out DateTime dob))
                    _currentPatient.User.Dob = dob;

                string result = _patientBUS.UpdatePatientProfile(_currentPatient);
                if (result == "Success")
                {
                    SetEditMode(false, "basic");
                    lblPatientName.Text = txtFullName.Text;
                    MessageBox.Show("Cập nhật thông tin cá nhân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Hiển thị chi tiết lỗi từ BUS (Trùng SĐT, Thiếu số điện thoại khẩn cấp,...)
                    MessageBox.Show(result, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (btn == btnSaveMedical) {
                // Gather Medical Info into Note
                _currentPatient.BloodType = txtBloodType.Text.Trim();
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
                string result = _userBUS.ChangePassword(_currentPatient.UserId, txtCurrentPass.Text, txtNewPass.Text, txtConfirmPass.Text);
                
                if (result == "Success")
                {
                    ShowChangePassword(false);
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            if (_currentPatient == null) return;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "Chọn ảnh đại diện mới";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = ofd.FileName;
                    // In a real app, you might want to copy the image to a local folder
                    // For now, we'll just save the path
                    string result = _userBUS.UpdateAvatar(_currentPatient.UserId, imagePath);

                    if (result == "Success")
                    {
                        picAvatar.ImageLocation = imagePath;
                        _currentPatient.User.Picture = imagePath;
                        MessageBox.Show("Cập nhật ảnh đại diện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnCancelBasicInfo)
            {
                SetEditMode(false, "basic");
                InitData(); // <-- PHẢI CÓ: Xóa chữ đang gõ bậy, nạp lại dữ liệu gốc từ DB
            }
            else if (btn == btnCancelMedical)
            {
                SetEditMode(false, "medical");
                InitData(); // <-- PHẢI CÓ: Reset hồ sơ y tế về ban đầu
            }
            else if (btn == btnCancelPass)
            {
                ShowChangePassword(false);
            }
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
            
            // Chỉ vẽ shadow và accent line cho các panel chính (không vẽ cho panel con như pnlChangePassword)
            if (pnl == pnlBasicInfo || pnl == pnlMedicalProfile || pnl == pnlSecurity)
            {
                Color accentColor = (pnl == pnlSecurity) ? Color.FromArgb(244, 63, 94) : Color.FromArgb(37, 99, 235);
                UIHelper.DrawSectionShadow(sender, e, 20, accentColor);
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.btn_Paint(sender, e);
        }
        private void LoadDefaultAvatar()
        {
            try
            {
                string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images", "default.jpg");
                if (File.Exists(defaultPath))
                {
                    picAvatar.ImageLocation = defaultPath;
                }
                else
                {
                    picAvatar.Image = null; // Hoặc một ảnh mặc định từ Resources nếu cần
                }
                picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }
        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            UpdateBirthdayDisplay();
            int age = _userBUS.CalculateAge(dtpBirthday.Value);

            if (age < 16)
            {
                // Khóa ô nhập CCCD và hiển thị trạng thái như màn Register
                txtCCCD.Text = "Chưa đủ tuổi";
                SetTextBoxEditState(txtCCCD, pnlCCCDBorder, false, true);
            }
            else
            {
                if (txtCCCD.Text == "Chưa đủ tuổi") txtCCCD.Text = "";
                SetTextBoxEditState(txtCCCD, pnlCCCDBorder, _isEditingBasic);
            }
        }
    }
}



