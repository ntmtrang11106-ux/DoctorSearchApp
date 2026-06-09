using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BUS_Tier;
using DTO_Tier;
using UI_Tier.Properties;

namespace UI_Tier
{
    public partial class ucAdmin_Profile : UserControl
    {
        private readonly UserBUS _userBUS = new UserBUS();
        private UserDTO _currentUser;
        private bool _isEditing = false;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        public ucAdmin_Profile()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlMain);
            UIHelper.SetupSmoothScrolling(pnlMain);

            // Apply rounded corners to avatar
            UIHelper.ApplyRoundedRegion(picAvatar, picAvatar.Width / 2);

            // Set initial state
            SetEditMode(false);
            ShowChangePassword(false);

            // Fix blinking
            UIHelper.SetDoubleBuffered(pnlBasicInfo);
            UIHelper.SetDoubleBuffered(pnlSecurity);
            UIHelper.SetDoubleBuffered(pnlChangePassword);
            UIHelper.SetDoubleBuffered(pnlBasicInfoActions);
            UIHelper.SetDoubleBuffered(pnlPassActions);

            // Wire up events
            this.HandleCreated += (s, e) => InitData();
            picAvatar.Cursor = Cursors.Hand;
            picAvatar.Click += (s, e) => ChangeAvatar();
            dtpBirthday.ValueChanged += dtpBirthday_ValueChanged;

            SetupFocusEffects();

            // Gán sự kiện Paint để vẽ viền
            pnlBasicInfo.Paint += SectionPanel_Paint;
            pnlSecurity.Paint += SectionPanel_Paint;
            pnlChangePassword.Paint += SectionPanel_Paint;

            // Đăng ký click ra ngoài để thoát focus cho toàn bộ các vùng chính
            UIHelper.RegisterClickToUnfocus(this);
            UIHelper.RegisterClickToUnfocus(pnlMain);
            UIHelper.RegisterClickToUnfocus(pnlBasicInfo);
            UIHelper.RegisterClickToUnfocus(pnlSecurity);
            UIHelper.RegisterClickToUnfocus(pnlChangePassword);

            AddAvatarOverlay();
        }

        private void AddAvatarOverlay()
        {
            UIHelper.ApplyRoundedRegion(lblUpload, lblUpload.Width / 2);
            lblUpload.BringToFront();
            lblUpload.Click += (s, e) => ChangeAvatar();
        }

        private void ChangeAvatar()
        {
            if (!_isEditing) return;

            if (_currentUser == null)
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

                        string fileName = $"adm_{GlobalAccount.GetUserId()}_{DateTime.Now.Ticks}{Path.GetExtension(ofd.FileName)}";
                        string destPath = Path.Combine(uploadDir, fileName);
                        string relativePath = Path.Combine("uploads", "avatars", fileName);

                        File.Copy(ofd.FileName, destPath, true);

                        // Save to database immediately
                        string result = _userBUS.UpdateAvatar(GlobalAccount.GetUserId(), relativePath);
                        if (result == "Success")
                        {
                            picAvatar.ImageLocation = destPath;
                            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                            _currentUser.Picture = relativePath;
                            MessageBox.Show("Cập nhật ảnh đại diện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật ảnh vào cơ sở dữ liệu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Color focus = Color.FromArgb(242, 248, 255);
            Color unfocus = Color.White;
            Color highlight = Color.FromArgb(37, 99, 235);

            UIHelper.SetupInputFocusEffect(txtFullName, pnlFullNameBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtPhone, pnlPhoneBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtRole, pnlRoleBorder, Color.FromArgb(241, 243, 245), Color.FromArgb(241, 243, 245), highlight);
            UIHelper.SetupInputFocusEffect(txtGender, pnlGenderBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(dtpBirthday, pnlBirthdayBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtCCCD, pnlCCCDBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtAddress, pnlAddressBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtCurrentPass, pnlCurrentPassBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtNewPass, pnlNewPassBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtConfirmPass, pnlConfirmPassBorder, focus, unfocus, highlight);
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            int age = _userBUS.CalculateAge(dtpBirthday.Value);
            if (age < 18)
            {
                txtCCCD.Text = "Chưa đủ tuổi";
                txtCCCD.Enabled = false;
                txtCCCD.BackColor = Color.FromArgb(241, 243, 245);
                pnlCCCDBorder.BackColor = Color.FromArgb(241, 243, 245);
            }
            else
            {
                if (txtCCCD.Text == "Chưa đủ tuổi") txtCCCD.Text = "";
                txtCCCD.Enabled = true;
                bool isEditing = _isEditing;
                Color bg = isEditing ? Color.White : Color.FromArgb(241, 243, 245);
                txtCCCD.BackColor = bg;
                pnlCCCDBorder.BackColor = bg;
            }
        }


        public void InitData()
        {
            int userId = GlobalAccount.GetUserId();
            if (userId <= 0) return;

            LoadUserData(userId);
        }

        private void LoadUserData(int userId)
        {
            _currentUser = _userBUS.GetUserById(userId);
            if (_currentUser == null) return;

            txtFullName.Text = _currentUser.FullName;
            lblAdminName.Text = _currentUser.FullName;
            txtPhone.Text = _currentUser.PhoneNumber;
            txtRole.Text = "Quản trị viên";

            dtpBirthday.Value = _currentUser.Dob ?? new DateTime(1990, 1, 1);
            txtGender.Text = _currentUser.Gender;
            txtCCCD.Text = _currentUser.CCCD;
            txtAddress.Text = _currentUser.Residential_Address;

            string picPath = _currentUser.Picture;
            if (!string.IsNullOrEmpty(picPath))
            {
                string fullPath = Path.IsPathRooted(picPath) ? picPath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images", picPath);

                if (!File.Exists(fullPath))
                {
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

        private void SetEditMode(bool isEditing)
        {
            _isEditing = isEditing;
            txtFullName.ReadOnly = !isEditing;
            txtPhone.ReadOnly = !isEditing;
            txtAddress.ReadOnly = !isEditing;
            dtpBirthday.Enabled = isEditing;
            txtGender.ReadOnly = !isEditing;
            txtRole.ReadOnly = true; // Luôn luôn Read-Only không cho sửa

            // Age-based CCCD logic
            int age = _userBUS.CalculateAge(dtpBirthday.Value);
            if (isEditing && age < 18)
            {
                txtCCCD.ReadOnly = true;
                txtCCCD.Enabled = false;
            }
            else
            {
                txtCCCD.ReadOnly = !isEditing;
                txtCCCD.Enabled = true;
            }

            Color bg = isEditing ? Color.White : Color.FromArgb(241, 243, 245);
            txtFullName.BackColor = bg;
            pnlFullNameBorder.BackColor = bg;

            txtPhone.BackColor = bg;
            pnlPhoneBorder.BackColor = bg;

            txtGender.BackColor = bg;
            pnlGenderBorder.BackColor = bg;

            Color cccdBg = (isEditing && age < 18) ? Color.FromArgb(241, 243, 245) : bg;
            txtCCCD.BackColor = cccdBg;
            pnlCCCDBorder.BackColor = cccdBg;

            txtAddress.BackColor = bg;
            pnlAddressBorder.BackColor = bg;

            txtRole.BackColor = Color.FromArgb(241, 243, 245); // Luôn xám
            pnlRoleBorder.BackColor = Color.FromArgb(241, 243, 245); // Luôn xám

            pnlBirthdayBorder.BackColor = bg;

            pnlBasicInfoActions.Visible = isEditing;
            btnEditBasicInfo.Visible = !isEditing;
            if (lblUpload != null) lblUpload.Visible = isEditing;

            if (isEditing) txtFullName.Focus();
        }

        private void ShowChangePassword(bool show)
        {
            pnlChangePassword.Visible = show;
            lblSecurityHint.Visible = !show;
            btnChangePassword.Visible = !show;

            pnlSecurity.Height = show ? 700 : 180;

            if (show)
            {
                txtCurrentPass.Clear();
                txtNewPass.Clear();
                txtConfirmPass.Clear();
                pnlMain.ScrollControlIntoView(pnlSecurity);
            }
        }

        private void btnEditBasicInfo_Click(object sender, EventArgs e) => SetEditMode(true);

        private void btnChangePassword_Click(object sender, EventArgs e) => ShowChangePassword(true);

        private void btnSaveBasicInfo_Click(object sender, EventArgs e)
        {
            if (_currentUser == null) return;

            // 1. Tạo một bản sao tạm thời để hứng dữ liệu mới, KHÔNG sửa trực tiếp vào _currentUser vội
            UserDTO tempUser = new UserDTO
            {
                Id = _currentUser.Id, // Đảm bảo giữ lại ID để update
                FullName = txtFullName.Text,
                PhoneNumber = txtPhone.Text,
                Dob = dtpBirthday.Value,
                Gender = txtGender.Text,
                CCCD = txtCCCD.Text,
                Residential_Address = txtAddress.Text,
                Picture = _currentUser.Picture, // Giữ nguyên ảnh
                Role = _currentUser.Role,
                Status = _currentUser.Status
            };

            // 2. Truyền bản sao tạm thời này xuống BUS để lưu vào DB
            string result = _userBUS.UpdateAdminProfile(tempUser);

            // 3. Check kết quả (Chấp nhận cả "Success" lẫn "success")
            if (string.Equals(result, "Success", StringComparison.OrdinalIgnoreCase))
            {
                // DB lưu thành công thì mới chính thức cập nhật vào biến toàn cục _currentUser
                _currentUser = tempUser;

                SetEditMode(false);
                lblAdminName.Text = txtFullName.Text;
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Nếu thực sự thất bại, hiện thông báo lỗi của BUS trả về
                MessageBox.Show(result, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // ĐỒNG THỜI: Ép giao diện tải lại dữ liệu cũ từ DB/hoặc giữ nguyên biến cũ để hủy bỏ các chữ m vừa gõ bậy
                LoadUserData(_currentUser.Id);
            }
        }

        private void btnSavePass_Click(object sender, EventArgs e)
        {
            string result = _userBUS.ChangePassword(GlobalAccount.GetUserId(), txtCurrentPass.Text, txtNewPass.Text, txtConfirmPass.Text);

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

        //private void ChangeAvatar()
        //{
        //    using (OpenFileDialog ofd = new OpenFileDialog())
        //    {
        //        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
        //        if (ofd.ShowDialog() == DialogResult.OK)
        //        {
        //            try
        //            {
        //                string uploadDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads", "avatars");
        //                if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

        //                string fileName = $"admin_{GlobalAccount.GetUserId()}_{DateTime.Now.Ticks}{Path.GetExtension(ofd.FileName)}";
        //                string destPath = Path.Combine(uploadDir, fileName);
        //                string relativePath = Path.Combine("uploads", "avatars", fileName);

        //                File.Copy(ofd.FileName, destPath, true);

        //                string result = _userBUS.UpdateAvatar(GlobalAccount.GetUserId(), relativePath);
        //                if (result == "Success")
        //                {
        //                    picAvatar.ImageLocation = destPath;
        //                    picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        //                    _currentUser.Picture = relativePath;
        //                    MessageBox.Show("Cập nhật ảnh đại diện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Lỗi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //}

        private void btnCancelBasicInfo_Click(object sender, EventArgs e) => SetEditMode(false);

        private void btnCancelPass_Click(object sender, EventArgs e) => ShowChangePassword(false);

        private void LoadDefaultAvatar()
        {
            try
            {
                string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images", "default.jpg");
                if (File.Exists(defaultPath)) picAvatar.ImageLocation = defaultPath;
                picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }

        private void SectionPanel_Paint(object sender, PaintEventArgs e)
        {
            Control pnl = sender as Control;

            // Chỉ vẽ shadow cho các panel chính (không vẽ cho pnlChangePassword để tránh khung đè)
            if (pnl == pnlBasicInfo || pnl == pnlSecurity)
            {
                Color accentColor = (pnl == pnlSecurity) ? Color.FromArgb(244, 63, 94) : Color.FromArgb(37, 99, 235);
                UIHelper.DrawSectionShadow(sender, e, 20, accentColor);
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e) => UIHelper.btn_Paint(sender, e);

    }
}
