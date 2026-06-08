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

            // Bo tròn avatar
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

            // Đăng ký sự kiện Paint để vẽ viền sắc nét (Không dùng blur đổ bóng cũ nữa)
            SetupSecurityRuleHints();
            SetupProfileRuleHints();
            
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

            // Toàn bộ panel nhập liệu chuyển thành nền trắng chuẩn chỉnh
            UIHelper.SetupInputFocusEffect(txtFullName, pnlFullNameBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtPhone, pnlPhoneBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtRole, pnlRoleBorder, Color.White, Color.White, highlight);
            UIHelper.SetupInputFocusEffect(txtGender, pnlGenderBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(dtpBirthday, pnlBirthdayBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtCCCD, pnlCCCDBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtAddress, pnlAddressBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtCurrentPass, pnlCurrentPassBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtNewPass, pnlNewPassBorder, focus, unfocus, highlight);
            UIHelper.SetupInputFocusEffect(txtConfirmPass, pnlConfirmPassBorder, focus, unfocus, highlight);
        }

        private void SetupSecurityRuleHints()
        {
            lblSecurityHint.Text = "Mật khẩu mới cần 8-64 ký tự, có chữ hoa/thường, số và ký tự đặc biệt.";
            txtNewPass.PlaceholderText = "Mật khẩu mới theo đúng quy định bảo mật";
            txtConfirmPass.PlaceholderText = "Nhập lại đúng mật khẩu mới";
            UIHelper.AddPasswordRuleHint(pnlChangePassword, 52, 385, 1320);
            pnlPassActions.Location = new Point(52, 430);
            pnlChangePassword.Height = Math.Max(pnlChangePassword.Height, 530);
        }

        private void SetupProfileRuleHints()
        {
            UIHelper.AddInputHint(pnlBasicInfo, "Họ tên: 2-100 ký tự, chỉ dùng chữ cái và khoảng trắng.", 440, 222, 770);
            UIHelper.AddInputHint(pnlBasicInfo, "SĐT: đúng 10 chữ số, bắt đầu bằng 0 và không trùng tài khoản khác.", 1240, 222, 770);
            UIHelper.AddInputHint(pnlBasicInfo, "Ngày sinh: quản trị viên phải từ 18 tuổi trở lên.", 1240, 362, 770);
            UIHelper.AddInputHint(pnlBasicInfo, "Giới tính: chỉ nhập Nam hoặc Nữ.", 440, 502, 770);
            UIHelper.AddInputHint(pnlBasicInfo, "CCCD: bắt buộc đúng 12 chữ số.", 1240, 502, 770);
            UIHelper.AddInputHint(pnlBasicInfo, "Địa chỉ: 5-255 ký tự, không chứa ký tự điều khiển.", 440, 642, 1570);

            pnlBasicInfoActions.Location = new Point(50, 690);
            pnlBasicInfo.Height = Math.Max(pnlBasicInfo.Height, 800);
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            int age = _userBUS.CalculateAge(dtpBirthday.Value);
            if (age < 18)
            {
                txtCCCD.Text = "Chưa đủ tuổi";
                txtCCCD.Enabled = false;
                txtCCCD.BackColor = Color.White; // Giữ nền trắng
                pnlCCCDBorder.BackColor = Color.White;
            }
            else
            {
                if (txtCCCD.Text == "Chưa đủ tuổi") txtCCCD.Text = "";
                txtCCCD.Enabled = true;
                txtCCCD.BackColor = Color.White;
                pnlCCCDBorder.BackColor = Color.White;
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

        // --- CẬP NHẬT: ÉP TOÀN BỘ NỀN PANEL/TEXTBOX LUÔN TRẮNG TINH ---
        private void SetEditMode(bool isEditing)
        {
            _isEditing = isEditing;
            txtFullName.ReadOnly = !isEditing;
            txtPhone.ReadOnly = !isEditing;
            txtAddress.ReadOnly = !isEditing;
            dtpBirthday.Enabled = isEditing;
            txtGender.ReadOnly = !isEditing;
            txtRole.ReadOnly = true;

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

            // Đã xóa sạch mớ mã màu xám FormArgb(241, 243, 245). Tất cả gán cứng Color.White.
            Color whiteBg = Color.White;

            txtFullName.BackColor = whiteBg;
            pnlFullNameBorder.BackColor = whiteBg;

            txtPhone.BackColor = whiteBg;
            pnlPhoneBorder.BackColor = whiteBg;

            txtGender.BackColor = whiteBg;
            pnlGenderBorder.BackColor = whiteBg;

            txtCCCD.BackColor = whiteBg;
            pnlCCCDBorder.BackColor = whiteBg;

            txtAddress.BackColor = whiteBg;
            pnlAddressBorder.BackColor = whiteBg;

            txtRole.BackColor = whiteBg;
            pnlRoleBorder.BackColor = whiteBg;

            pnlBirthdayBorder.BackColor = whiteBg;

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

            _currentUser.FullName = txtFullName.Text;
            _currentUser.PhoneNumber = txtPhone.Text;
            _currentUser.Dob = dtpBirthday.Value;
            _currentUser.Gender = txtGender.Text;
            _currentUser.CCCD = txtCCCD.Text;
            _currentUser.Residential_Address = txtAddress.Text;

            string result = _userBUS.UpdateAdminProfile(_currentUser);

            if (result == "Success")
            {
                SetEditMode(false);
                lblAdminName.Text = txtFullName.Text;
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSavePass_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //string result = _userBUS.ChangePassword(GlobalAccount.GetUserId(), txtCurrentPass.Text, txtNewPass.Text);

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

        // --- CẬP NHẬT: THAY THẾ HOÀN TOÀN VIỀN BLUR THÀNH VIỀN ĐƠN SẮC NÉT ---
        private void SectionPanel_Paint(object sender, PaintEventArgs e)
        {
            Control pnl = sender as Control;
            if (pnl == null) return;

            // Bo tròn vùng hiển thị của Panel chính với bán kính 16px cho hiện đại
            UIHelper.ApplyRoundedRegion(pnl, 16);

            // Bỏ hoàn toàn hàm DrawSectionShadow cũ. Gọi hàm DrawControlBorder để kẻ 1 đường viền xám nhẹ (LightGray) dày 2px cực kỳ sạch sẽ, rõ ràng.
            UIHelper.DrawControlBorder(pnl, e, 16, Color.Gainsboro, 2);
        }

        private void Button_Paint(object sender, PaintEventArgs e) => UIHelper.btn_Paint(sender, e);
    }
}