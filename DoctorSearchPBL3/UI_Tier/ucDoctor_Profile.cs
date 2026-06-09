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
        private string _pendingAvatarSourcePath;
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

        public ucDoctor_Profile()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlMain);
            UIHelper.SetupSmoothScrolling(pnlMain);

            // XÓA các dòng gán Paint ở đây đi vì Designer có rồi:
            // pnlBasicInfo.Paint += SectionPanel_Paint; <-- XÓA
            // pnlSecurity.Paint += SectionPanel_Paint;   <-- XÓA
            pnlChangePassword.Paint += SectionPanel_Paint; // Giữ lại dòng này vì designer chưa có

            // THÊM: Gán sự kiện click cho các nút bấm hoạt động
            btnEditBasicInfo.Click += btnEdit_Click;
            btnChangePassword.Click += btnEdit_Click;

            btnCancelBasicInfo.Click += btnCancel_Click;
            btnCancelPass.Click += btnCancel_Click;

            btnSaveBasicInfo.Click += btnSave_Click;
            btnSavePass.Click += btnSave_Click;

            SetEditMode(false, "basic");

            // Fix blinking
            UIHelper.SetDoubleBuffered(pnlBasicInfo);
            UIHelper.SetDoubleBuffered(pnlSecurity);
            UIHelper.SetDoubleBuffered(pnlChangePassword);
            UIHelper.SetDoubleBuffered(pnlBasicInfoActions);
            UIHelper.SetDoubleBuffered(pnlPassActions);

            SetupFocusEffects();
            SetupViewModeInputBehavior();
            SetEditMode(false, "basic");

            // Gán sự kiện Paint để vẽ viền và bóng đổ
            pnlBasicInfo.Paint += SectionPanel_Paint;
            pnlSecurity.Paint += SectionPanel_Paint;
            pnlChangePassword.Paint += SectionPanel_Paint;

            this.HandleCreated += (s, e) => {
                InitData();
                UIHelper.ApplyRoundedRegion(lblUpload, lblUpload.Width / 2);
                UIHelper.ApplyRoundedRegion(picAvatar, picAvatar.Width / 2);
            };
            dtpBirthday.ValueChanged += dtpBirthday_ValueChanged;
            picAvatar.Cursor = Cursors.Hand;
            picAvatar.Click += (s, e) => ChangeAvatar();
            lblUpload.Click += (s, e) => ChangeAvatar();

            // Đăng ký click ra ngoài để thoát focus cho toàn bộ form và các panel chính
            UIHelper.RegisterClickToUnfocus(this);
            UIHelper.RegisterClickToUnfocus(pnlMain);
            UIHelper.RegisterClickToUnfocus(pnlBasicInfo);
            UIHelper.RegisterClickToUnfocus(pnlSecurity);
            UIHelper.RegisterClickToUnfocus(pnlChangePassword);

            //Bo góc các nút
            btnCancelBasicInfo.Paint += Button_Paint;
            btnCancelPass.Paint += Button_Paint;
            btnSaveBasicInfo.Paint += Button_Paint;
            btnSavePass.Paint += Button_Paint;
        }

        private void SetupFocusEffects()
        {
            UIHelper.SetupInputFocusEffect(txtFullName, pnlFullNameBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtPhone, pnlPhoneBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtGender, pnlGenderBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtCCCD, pnlCCCDBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtAddress, pnlAddressBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtPosition, pnlPositionBorder, Color.FromArgb(241, 243, 245), Color.FromArgb(241, 243, 245), Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtSpecialty, pnlSpecialtyBorder, Color.FromArgb(241, 243, 245), Color.FromArgb(241, 243, 245), Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtLicense, pnlLicenseBorder, Color.FromArgb(241, 243, 245), Color.FromArgb(241, 243, 245), Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtExperienceYears, pnlExperienceYearsBorder, Color.FromArgb(241, 243, 245), Color.FromArgb(241, 243, 245), Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtConsultationFee, pnlConsultationFeeBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtBiography, pnlBiographyBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtCurrentPass, pnlCurrentPassBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtNewPass, pnlNewPassBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtConfirmPass, pnlConfirmPassBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(dtpBirthday, pnlBirthdayBorder, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
        }

        private void SetupViewModeInputBehavior()
        {
            TextBox[] textBoxes =
            {
                txtFullName, txtPhone, txtGender, txtCCCD, txtAddress,
                txtPosition, txtSpecialty, txtLicense, txtExperienceYears,
                txtConsultationFee, txtBiography
            };

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Enter += ReadOnlyTextBox_Enter;
            }

            Panel[] inputBorders =
            {
                pnlFullNameBorder, pnlPhoneBorder, pnlGenderBorder, pnlBirthdayBorder,
                pnlCCCDBorder, pnlAddressBorder, pnlPositionBorder, pnlSpecialtyBorder,
                pnlLicenseBorder, pnlExperienceYearsBorder, pnlConsultationFeeBorder,
                pnlBiographyBorder
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
                ClearActiveProfileFocus();
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
            if (panel == pnlCCCDBorder || panel == pnlPositionBorder ||
                panel == pnlSpecialtyBorder || panel == pnlLicenseBorder ||
                panel == pnlExperienceYearsBorder)
            {
                return false;
            }

            return _isEditingBasic;
        }

        private void InvalidateProfileInputBorders()
        {
            Panel[] inputBorders =
            {
                pnlFullNameBorder, pnlPhoneBorder, pnlGenderBorder, pnlBirthdayBorder,
                pnlCCCDBorder, pnlAddressBorder, pnlPositionBorder, pnlSpecialtyBorder,
                pnlLicenseBorder, pnlExperienceYearsBorder, pnlConsultationFeeBorder,
                pnlBiographyBorder
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
                        _pendingAvatarSourcePath = ofd.FileName;
                        picAvatar.ImageLocation = _pendingAvatarSourcePath;
                        picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string PreparePendingAvatar(out string relativePath)
        {
            relativePath = "";

            if (string.IsNullOrWhiteSpace(_pendingAvatarSourcePath))
                return "Success";

            if (!File.Exists(_pendingAvatarSourcePath))
                return "Không tìm thấy file ảnh đã chọn.";

            string uploadDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads", "avatars");
            if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

            string extension = Path.GetExtension(_pendingAvatarSourcePath);
            string fileName = $"doc_{GlobalAccount.GetUserId()}_{DateTime.Now.Ticks}{extension}";
            string destPath = Path.Combine(uploadDir, fileName);

            File.Copy(_pendingAvatarSourcePath, destPath, true);
            relativePath = Path.Combine("uploads", "avatars", fileName);
            return "Success";
        }

        public void InitData()
        {
            _pendingAvatarSourcePath = null;

            int profileId = GlobalAccount.GetProfileId();
            if (profileId <= 0) return;

            _currentDoctor = _doctorBUS.GetDoctorById(profileId);

            if (_currentDoctor != null && _currentDoctor.User != null)
            {
                string displayName = StripDoctorTitlePrefix(_currentDoctor.User.FullName);
                string displayPosition = (_currentDoctor.Position ?? "").Trim();

                txtFullName.Text = displayName;
                lblDoctorName.Text = string.IsNullOrWhiteSpace(displayPosition)
                    ? displayName
                    : $"{displayPosition}{Environment.NewLine}{displayName}";
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
                    string fullPath = Path.IsPathRooted(picPath) ? picPath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images", picPath);
                      
                    if (!File.Exists(fullPath))
                    {
                        fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, picPath);
                    }

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

        private static string StripDoctorTitlePrefix(string fullName)
        {
            string name = (fullName ?? "").Trim();
            string[] prefixes = { "BS.", "BS", "Bác sĩ", "Bac si" };

            bool changed;
            do
            {
                changed = false;
                foreach (string prefix in prefixes)
                {
                    if (name.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase))
                    {
                        name = name.Substring(prefix.Length).TrimStart('.', ' ');
                        changed = true;
                        break;
                    }
                }
            } while (changed);

            return name;
        }

        private void SetEditMode(bool isEdit, string section)
        {
            this.ActiveControl = null;
            if (section == "basic")
            {
                _isEditingBasic = isEdit;

                SetTextBoxEditState(txtFullName, pnlFullNameBorder, isEdit);
                SetTextBoxEditState(txtPhone, pnlPhoneBorder, isEdit);
                SetTextBoxEditState(txtGender, pnlGenderBorder, isEdit);
                SetTextBoxEditState(txtAddress, pnlAddressBorder, isEdit);
                SetTextBoxEditState(txtConsultationFee, pnlConsultationFeeBorder, isEdit);
                SetTextBoxEditState(txtBiography, pnlBiographyBorder, isEdit);

                SetTextBoxEditState(txtCCCD, pnlCCCDBorder, false, true);
                SetTextBoxEditState(txtPosition, pnlPositionBorder, false, true);
                SetTextBoxEditState(txtSpecialty, pnlSpecialtyBorder, false, true);
                SetTextBoxEditState(txtLicense, pnlLicenseBorder, false, true);
                SetTextBoxEditState(txtExperienceYears, pnlExperienceYearsBorder, false, true);

                dtpBirthday.Enabled = isEdit;
                pnlBirthdayBorder.BackColor = isEdit ? Color.White : _viewFieldBackColor;

                pnlBasicInfoActions.Visible = isEdit;
                btnEditBasicInfo.Visible = !isEdit;
                if (lblUpload != null) lblUpload.Visible = isEdit;

                InvalidateProfileInputBorders();
                if (isEdit) txtFullName.Focus();
                else ClearActiveProfileFocus();
            }
            else if (section == "security")
            {
                pnlChangePassword.Visible = isEdit;
                btnChangePassword.Visible = !isEdit;

                // THÊM: Tự động co giãn chiều cao của panel cha để tránh khoảng trống bự
                pnlSecurity.Height = isEdit ? 700 : 200;

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
                _pendingAvatarSourcePath = null;
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
            _currentDoctor.User.FullName = StripDoctorTitlePrefix(txtFullName.Text);
            _currentDoctor.User.PhoneNumber = txtPhone.Text.Trim();
            _currentDoctor.User.Gender = txtGender.Text.Trim();
            _currentDoctor.User.Residential_Address = txtAddress.Text.Trim();
            _currentDoctor.User.Dob = dtpBirthday.Value;

            // Doctor specific fields
            _currentDoctor.Biography = txtBiography.Text.Trim();
            if (decimal.TryParse(txtConsultationFee.Text.Replace(".", "").Replace(",", ""), out decimal fee))
                _currentDoctor.ConsultationFee = fee;
            else
                _currentDoctor.ConsultationFee = -1;

            string previousPicture = _currentDoctor.User.Picture;
            if (!string.IsNullOrWhiteSpace(_pendingAvatarSourcePath))
            {
                try
                {
                    string avatarResult = PreparePendingAvatar(out string avatarPath);
                    if (avatarResult != "Success")
                    {
                        MessageBox.Show(avatarResult, "Lưu ảnh thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _currentDoctor.User.Picture = avatarPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu ảnh đại diện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 2. Gọi BUS để xử lý (có Validation bên trong)
            string result = _doctorBUS.UpdateDoctorInfo(_currentDoctor);

            if (result.Contains("thành công"))
            {
                _pendingAvatarSourcePath = null;
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetEditMode(false, "basic");
                InitData(); // Nạp lại dữ liệu mới nhất
            }
            else
            {
                _currentDoctor.User.Picture = previousPicture;
                MessageBox.Show(result, "Lưu thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SavePassword()
        {
            string curr = txtCurrentPass.Text;
            string newP = txtNewPass.Text;
            string conf = txtConfirmPass.Text;

            int userId = GlobalAccount.GetUserId();
            string result = _userBUS.ChangePassword(userId, curr, newP, conf);
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
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                UIHelper.ApplyRoundedRegion(btn, 12);
            }
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            SetTextBoxEditState(txtCCCD, pnlCCCDBorder, false, true);
        }
    }
}
