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

        public ucDoctor_Profile()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlMain);
            UIHelper.SetupSmoothScrolling(pnlMain);
            
            //// Apply rounded corners
            //UIHelper.ApplyRoundedRegion(picAvatar, picAvatar.Width / 2);
            //UIHelper.ApplyRoundedRegion(pnlBasicInfo, 20);
            //UIHelper.ApplyRoundedRegion(pnlSecurity, 20);
            //UIHelper.ApplyRoundedRegion(btnSaveBasicInfo, 12);
            //UIHelper.ApplyRoundedRegion(btnCancelBasicInfo, 12);
            //UIHelper.ApplyRoundedRegion(btnSavePass, 12);
            //UIHelper.ApplyRoundedRegion(btnCancelPass, 12);

            SetEditMode(false, "basic");

            // Fix blinking
            UIHelper.SetDoubleBuffered(pnlBasicInfo);
            UIHelper.SetDoubleBuffered(pnlSecurity);
            UIHelper.SetDoubleBuffered(pnlChangePassword);
            UIHelper.SetDoubleBuffered(pnlBasicInfoActions);
            UIHelper.SetDoubleBuffered(pnlPassActions);

            SetupFocusEffects();

            // Gán sự kiện Paint để vẽ viền và bóng đổ
            pnlBasicInfo.Paint += SectionPanel_Paint;
            pnlSecurity.Paint += SectionPanel_Paint;
            pnlChangePassword.Paint += SectionPanel_Paint;

            this.HandleCreated += (s, e) => {
                InitData();
                AddAvatarOverlay();
                UIHelper.ApplyRoundedRegion(picAvatar, picAvatar.Width / 2);
            };
            dtpBirthday.ValueChanged += dtpBirthday_ValueChanged;
            picAvatar.Cursor = Cursors.Hand;
            picAvatar.Click += (s, e) => ChangeAvatar();

            // Đăng ký click ra ngoài để thoát focus cho toàn bộ form và các panel chính
            UIHelper.RegisterClickToUnfocus(this);
            UIHelper.RegisterClickToUnfocus(pnlMain);
            UIHelper.RegisterClickToUnfocus(pnlBasicInfo);
            UIHelper.RegisterClickToUnfocus(pnlSecurity);
            UIHelper.RegisterClickToUnfocus(pnlChangePassword);
        }

        private void SetupFocusEffects()
        {
            TextBox[] inputs = { txtFullName, txtPhone, txtGender, txtCCCD, txtAddress, txtPosition, txtSpecialty, txtLicense, txtExperienceYears, txtConsultationFee, txtBiography, txtCurrentPass, txtNewPass, txtConfirmPass };
            foreach (var input in inputs)
            {
                input.Font = new Font("Segoe UI", 12F);
                UIHelper.SetupInputFocusEffect(input, null, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            }
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

            if (_currentDoctor == null || _currentDoctor.User == null)
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

                        string fileName = $"doc_{GlobalAccount.GetUserId()}_{DateTime.Now.Ticks}{Path.GetExtension(ofd.FileName)}";
                        string destPath = Path.Combine(uploadDir, fileName);
                        string relativePath = Path.Combine("uploads", "avatars", fileName);

                        File.Copy(ofd.FileName, destPath, true);
                        
                        // Save to database immediately
                        string result = _userBUS.UpdateAvatar(GlobalAccount.GetUserId(), relativePath);
                        if (result == "Success")
                        {
                            picAvatar.ImageLocation = destPath;
                            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                            _currentDoctor.User.Picture = relativePath;
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
                if (!string.IsNullOrEmpty(picPath))
                {
                    string fullPath = Path.IsPathRooted(picPath) ? picPath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, picPath);
                    if (File.Exists(fullPath))
                    {
                        try { 
                            picAvatar.ImageLocation = fullPath;
                            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                        } catch { LoadDefaultAvatar(); }
                    }
                    else LoadDefaultAvatar();
                }
                else LoadDefaultAvatar();
            }
        }

        private void LoadDefaultAvatar()
        {
            try
            {
                string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images", "default.jpg");
                if (File.Exists(defaultPath))
                {
                    picAvatar.ImageLocation = defaultPath;
                    picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    picAvatar.Image = null;
                    picAvatar.BackColor = Color.FromArgb(241, 245, 249);
                }
            }
            catch { }
        }

        private void SetEditMode(bool isEdit, string section)
        {
            if (section == "basic")
            {
                _isEditingBasic = isEdit;
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
                Color readOnlyColor = Color.FromArgb(241, 243, 245);

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

                if (lblUpload != null) lblUpload.Visible = isEdit;

                if (isEdit)
                {
                    txtFullName.Focus();
                    // Nếu đang sửa mà tuổi < 16 thì vẫn phải xám CCCD
                    int age = _userBUS.CalculateAge(dtpBirthday.Value);
                    if (age < 16)
                    {
                        txtCCCD.ReadOnly = true;
                        txtCCCD.Enabled = false;
                        txtCCCD.BackColor = Color.FromArgb(241, 243, 245);
                    }
                }
                else
                {
                    // Khi thoát chế độ sửa, cập nhật lại trạng thái CCCD dựa trên tuổi
                    dtpBirthday_ValueChanged(dtpBirthday, EventArgs.Empty);
                }
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
            if (_currentDoctor == null || _currentDoctor.User == null) return;

            // 1. Thu thập dữ liệu từ UI
            _currentDoctor.User.FullName = txtFullName.Text.Trim();
            _currentDoctor.User.PhoneNumber = txtPhone.Text.Trim();
            _currentDoctor.User.Gender = txtGender.Text.Trim();
            _currentDoctor.User.CCCD = txtCCCD.Text.Trim();
            _currentDoctor.User.Residential_Address = txtAddress.Text.Trim();
            _currentDoctor.User.Dob = dtpBirthday.Value;

            // Doctor specific fields
            _currentDoctor.Biography = txtBiography.Text.Trim();
            if (decimal.TryParse(txtConsultationFee.Text.Replace(".", "").Replace(",", ""), out decimal fee))
                _currentDoctor.ConsultationFee = fee;

            // 2. Gọi BUS để xử lý (có Validation bên trong)
            string result = _doctorBUS.UpdateDoctorInfo(_currentDoctor);

            if (result.Contains("thành công"))
            {
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetEditMode(false, "basic");
                InitData(); // Nạp lại dữ liệu mới nhất
            }
            else
            {
                MessageBox.Show(result, "Lưu thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            Control pnl = sender as Control;
            
            // Chỉ vẽ shadow và accent line cho các panel chính
            if (pnl == pnlBasicInfo || pnl == pnlSecurity)
            {
                Color accentColor = (pnl == pnlSecurity) ? Color.FromArgb(244, 63, 94) : Color.FromArgb(37, 99, 235);
                UIHelper.DrawSectionShadow(sender, e, 20, accentColor);
            }

            // Draw Bottom Borders for all inputs in this panel
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
                    Color borderColor = isFocused ? Color.FromArgb(37, 99, 235) : Color.Black;
                    int borderThickness = isFocused ? 2 : 1;

                    using (Pen pen = new Pen(borderColor, borderThickness))
                    {
                        g.DrawLine(pen, c.Left, c.Bottom, c.Right, c.Bottom);
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
                            Color borderColor = isFocused ? Color.FromArgb(37, 99, 235) : Color.Black;
                            int borderThickness = isFocused ? 2 : 1;

                            Point relPos = container.PointToClient(c.PointToScreen(subC.Location));
                            using (Pen pen = new Pen(borderColor, borderThickness))
                            {
                                g.DrawLine(pen, relPos.X, relPos.Y + subC.Height, relPos.X + subC.Width, relPos.Y + subC.Height);
                            }
                        }
                    }
                }
            }
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            int age = _userBUS.CalculateAge(dtpBirthday.Value);

            if (age < 16)
            {
                // Khóa ô nhập CCCD và hiển thị trạng thái như hồ sơ bệnh nhân
                txtCCCD.Text = "Chưa đủ tuổi";
                txtCCCD.Enabled = false;
                txtCCCD.BackColor = Color.FromArgb(241, 243, 245);
            }
            else
            {
                // Mở khóa nếu từ 16 tuổi trở lên
                if (txtCCCD.Text == "Chưa đủ tuổi") txtCCCD.Text = "";
                txtCCCD.Enabled = true;

                // Chỉ thực sự cho sửa nếu đang trong mode Edit
                bool isEditing = pnlBasicInfoActions.Visible;
                txtCCCD.ReadOnly = !isEditing;
                txtCCCD.BackColor = isEditing ? Color.White : Color.FromArgb(250, 251, 252);
            }
        }
    }
}
