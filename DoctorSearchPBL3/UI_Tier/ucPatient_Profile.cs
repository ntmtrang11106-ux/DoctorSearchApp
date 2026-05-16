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
            
            // Apply rounded corners to avatar
            UIHelper.ApplyRoundedRegion(picAvatar, picAvatar.Width / 2);
            
            // Set initial state
            SetEditMode(false, "basic");
            SetEditMode(false, "medical");

            // Fix blinking
            UIHelper.SetDoubleBuffered(pnlBasicInfo);
            UIHelper.SetDoubleBuffered(pnlMedicalProfile);
            UIHelper.SetDoubleBuffered(pnlSecurity);
            UIHelper.SetDoubleBuffered(pnlChangePassword);
            UIHelper.SetDoubleBuffered(pnlBasicInfoActions);
            UIHelper.SetDoubleBuffered(pnlMedicalActions);

            // Wire up events
            picAvatar.Cursor = Cursors.Hand;
            picAvatar.Click += (s, e) => ChangeAvatar();
            dtpBirthday.ValueChanged += dtpBirthday_ValueChanged;
            SetupFocusEffects();

            // Gán sự kiện Paint để vẽ viền và bóng đổ
            pnlBasicInfo.Paint += SectionPanel_Paint;
            pnlMedicalProfile.Paint += SectionPanel_Paint;
            pnlSecurity.Paint += SectionPanel_Paint;
            pnlChangePassword.Paint += SectionPanel_Paint;

            this.HandleCreated += (s, e) => {
                InitData();
                AddAvatarOverlay();
                UIHelper.ApplyRoundedRegion(picAvatar, picAvatar.Width / 2);
            };

            // Đăng ký click ra ngoài để thoát focus cho toàn bộ form và các panel chính
            UIHelper.RegisterClickToUnfocus(this);
            UIHelper.RegisterClickToUnfocus(pnlMain);
            UIHelper.RegisterClickToUnfocus(pnlBasicInfo);
            UIHelper.RegisterClickToUnfocus(pnlMedicalProfile);
            UIHelper.RegisterClickToUnfocus(pnlSecurity);
            UIHelper.RegisterClickToUnfocus(pnlChangePassword);
        }

        private Label lblUpload;
        private void AddAvatarOverlay()
        {
            lblUpload = new Label
            {
                Size = new Size(40, 40),
                BackColor = Color.FromArgb(200, 37, 99, 235), // Blue semi-transparent
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe MDL2 Assets", 14F),
                Text = "\uE722", // Camera icon
                Cursor = Cursors.Hand,
                Visible = false
            };

            // Vị trí: Góc dưới bên phải của picAvatar
            lblUpload.Location = new Point(
                picAvatar.Right - lblUpload.Width - 5,
                picAvatar.Bottom - lblUpload.Height - 5
            );

            UIHelper.ApplyRoundedRegion(lblUpload, lblUpload.Width / 2);
            
            picAvatar.Parent.Controls.Add(lblUpload);
            lblUpload.BringToFront();
            
            lblUpload.Click += (s, e) => ChangeAvatar();
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
            TextBox[] inputs = { txtFullName, txtPhone, txtGender, txtCCCD, txtAddress, txtBHYT, txtPatientID, txtEmergencyContact, txtEmergencyPhone, txtBloodType, txtMedicalHistory, txtCurrentPass, txtNewPass, txtConfirmPass };
            foreach (var input in inputs)
            {
                input.Font = new Font("Segoe UI", 12F);
                UIHelper.SetupInputFocusEffect(input, null, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
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
                txtPatientID.Text = _currentPatient.MedicalCode ?? ""; // Không tự để BN-0001 nếu DB trống
                txtEmergencyContact.Text = _currentPatient.EmergencyContactName ?? "";
                txtEmergencyPhone.Text = _currentPatient.EmergencyContactPhone ?? "";
                txtAddress.Text = _currentPatient.User.Residential_Address ?? "";

                // Parse Note for medical info
                ParseMedicalNote(_currentPatient.Note);

                string picPath = _currentPatient.User.Picture;
                if (!string.IsNullOrEmpty(picPath))
                {
                    string fullPath = Path.IsPathRooted(picPath) ? picPath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, picPath);
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
                txtFullName.ReadOnly = !isEditing;
                txtPhone.ReadOnly = !isEditing;
                txtAddress.ReadOnly = !isEditing;
                dtpBirthday.Enabled = isEditing;
                txtGender.ReadOnly = !isEditing;
                txtCCCD.ReadOnly = !isEditing;
                txtBHYT.ReadOnly = !isEditing;
                txtPatientID.ReadOnly = true; 
                txtEmergencyContact.ReadOnly = !isEditing;
                txtEmergencyPhone.ReadOnly = !isEditing;

                Color bg = isEditing ? Color.White : Color.FromArgb(241, 243, 245);
                txtFullName.BackColor = bg;
                txtPhone.BackColor = bg;
                txtGender.BackColor = bg;
                txtCCCD.BackColor = bg;
                txtBHYT.BackColor = bg;
                txtPatientID.BackColor = Color.FromArgb(241, 243, 245); // Luôn xám vì là ID
                txtEmergencyContact.BackColor = bg;
                txtEmergencyPhone.BackColor = bg;
                txtAddress.BackColor = bg;

                pnlBasicInfoActions.Visible = isEditing;
                btnEditBasicInfo.Visible = !isEditing;
                if (lblUpload != null) lblUpload.Visible = isEditing;
                
                if (isEditing) txtFullName.Focus();
            }
            else if (section == "medical")
            {
                txtBloodType.ReadOnly = !isEditing;
                txtMedicalHistory.ReadOnly = !isEditing;

                Color bg = isEditing ? Color.White : Color.FromArgb(241, 243, 245);
                txtBloodType.BackColor = bg;
                txtMedicalHistory.BackColor = bg;

                pnlMedicalActions.Visible = isEditing;
                btnEditMedical.Visible = !isEditing;

                if (isEditing) txtBloodType.Focus();
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
                _currentPatient.User.Dob = dtpBirthday.Value;
                _currentPatient.User.Gender = txtGender.Text;
                _currentPatient.User.CCCD = txtCCCD.Text;
                _currentPatient.User.Residential_Address = txtAddress.Text;
                _currentPatient.InsuranceCode = txtBHYT.Text;
                _currentPatient.MedicalCode = txtPatientID.Text;
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
                if (txtNewPass.Text != txtConfirmPass.Text) {
                    MessageBox.Show("Xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string result = _userBUS.ChangePassword(_currentPatient.UserId, txtCurrentPass.Text, txtNewPass.Text);
                
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
            
            // Chỉ vẽ shadow và accent line cho các panel chính (không vẽ cho panel con như pnlChangePassword)
            if (pnl == pnlBasicInfo || pnl == pnlMedicalProfile || pnl == pnlSecurity)
            {
                Color accentColor = (pnl == pnlSecurity) ? Color.FromArgb(244, 63, 94) : Color.FromArgb(37, 99, 235);
                UIHelper.DrawSectionShadow(sender, e, 20, accentColor);
            }
            
            // Vẽ đường kẻ dưới cho các ô nhập liệu
            DrawInputBorders(pnl, e.Graphics);
        }

        private void DrawInputBorders(Control container, Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Control c in container.Controls)
            {
                if ((c is TextBox || c is DateTimePicker) && c.Visible)
                {
                    bool isFocused = c.Focused;
                    
                    // 1. Vẽ khung viền dày 2px quanh toàn bộ ô (Đen - Bo góc 8)
                    Rectangle borderRect = new Rectangle(c.Left - 1, c.Top - 1, c.Width + 1, c.Height + 1);
                    using (var path = UIHelper.GetRoundedPath(borderRect, 8))
                    {
                        using (Pen blackPen = new Pen(Color.Black, 2))
                        {
                            blackPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                            g.DrawPath(blackPen, path);
                        }
                        
                        // 2. Nếu đang focus, vẽ vạch dưới màu xanh dày 4px (Cực kỳ rõ nét)
                        if (isFocused)
                        {
                            using (Pen bluePen = new Pen(Color.FromArgb(37, 99, 235), 4))
                            {
                                g.DrawLine(bluePen, c.Left, c.Bottom, c.Right, c.Bottom);
                            }
                        }
                    }
                }
                else if (c is Panel && c.HasChildren && c.Visible)
                {
                    // For nested panels like pnlChangePassword
                    foreach (Control subC in c.Controls)
                    {
                        if ((subC is TextBox || subC is DateTimePicker) && subC.Visible)
                        {
                            bool isFocused = subC.Focused;
                            Point relPos = container.PointToClient(c.PointToScreen(subC.Location));
                            
                            // 1. Vẽ khung viền dày 2px (Đen, Bo góc 8)
                            Rectangle borderRect = new Rectangle(relPos.X - 1, relPos.Y - 1, subC.Width + 1, subC.Height + 1);
                            using (var path = UIHelper.GetRoundedPath(borderRect, 8))
                            {
                                using (Pen blackPen = new Pen(Color.Black, 2))
                                {
                                    blackPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                                    g.DrawPath(blackPen, path);
                                }

                                // 2. Vẽ vạch dưới xanh 4px khi focus
                                if (isFocused)
                                {
                                    using (Pen bluePen = new Pen(Color.FromArgb(37, 99, 235), 4))
                                    {
                                        g.DrawLine(bluePen, relPos.X, relPos.Y + subC.Height, relPos.X + subC.Width, relPos.Y + subC.Height);
                                    }
                                }
                            }
                        }
                    }
                }
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
            int age = _userBUS.CalculateAge(dtpBirthday.Value);

            if (age < 16)
            {
                // Khóa ô nhập CCCD và hiển thị trạng thái như màn Register
                txtCCCD.Text = "Chưa đủ tuổi";
                txtCCCD.Enabled = false;
                txtCCCD.BackColor = Color.FromArgb(241, 243, 245); 
            }
            else
            {
                // Mở khóa nếu từ 16 tuổi trở lên
                if (txtCCCD.Text == "Chưa đủ tuổi") txtCCCD.Text = "";
                txtCCCD.Enabled = true; // Lưu ý: khi ở chế độ ReadOnly thì Enabled vẫn có thể true nhưng k sửa đc
                // Chỉ thực sự cho sửa nếu đang trong mode Edit
                // Logic này sẽ được SetEditMode quản lý thêm
                txtCCCD.BackColor = Color.White;
            }
        }
    }
}



