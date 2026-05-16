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

        private Label lblUpload;
        private void AddAvatarOverlay()
        {
            lblUpload = new Label
            {
                Size = new Size(50, 50),
                BackColor = Color.FromArgb(200, 37, 99, 235), // Blue semi-transparent
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe MDL2 Assets", 18F),
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
            if (!_isEditing) return;

            if (_currentUser == null)
            {
                MessageBox.Show("Không thể đổi ảnh khi dữ liệu hồ sơ chưa được tải.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picAvatar.ImageLocation = ofd.FileName;
                    picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                    
                    // Nếu muốn lưu ngay lập tức vào DTO:
                    if (_currentUser != null)
                    {
                        // _currentUser.AvatarPath = ofd.FileName; // Cần kiểm tra logic lưu file thật
                    }
                }
            }
        }

        private void SetupFocusEffects()
        {
            Control[] inputs = { txtFullName, txtPhone, txtRole, txtGender, dtpBirthday, txtCCCD, txtAddress, txtCurrentPass, txtNewPass, txtConfirmPass };
            foreach (var input in inputs)
            {
                input.Font = new Font("Segoe UI", 12F);
                UIHelper.SetupInputFocusEffect(input, null, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            }
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            int age = _userBUS.CalculateAge(dtpBirthday.Value);
            if (age < 18)
            {
                txtCCCD.Text = "Chưa đủ tuổi";
                txtCCCD.Enabled = false;
                txtCCCD.BackColor = Color.FromArgb(241, 243, 245);
            }
            else
            {
                if (txtCCCD.Text == "Chưa đủ tuổi") txtCCCD.Text = "";
                txtCCCD.Enabled = true;
                txtCCCD.BackColor = Color.White;
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

        private void SetEditMode(bool isEditing)
        {
            _isEditing = isEditing;
            txtFullName.ReadOnly = !isEditing;
            txtPhone.ReadOnly = !isEditing;
            txtAddress.ReadOnly = !isEditing;
            dtpBirthday.Enabled = isEditing;
            txtGender.ReadOnly = !isEditing;
            
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
            txtPhone.BackColor = bg;
            txtGender.BackColor = bg;
            txtCCCD.BackColor = (isEditing && age < 18) ? Color.FromArgb(241, 243, 245) : bg;
            txtAddress.BackColor = bg;
            txtRole.BackColor = Color.FromArgb(241, 243, 245); // Luôn xám

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
            
            if (show) {
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

            // Gather info
            _currentUser.FullName = txtFullName.Text;
            _currentUser.PhoneNumber = txtPhone.Text;
            _currentUser.Dob = dtpBirthday.Value;
            _currentUser.Gender = txtGender.Text;
            _currentUser.CCCD = txtCCCD.Text;
            _currentUser.Residential_Address = txtAddress.Text;

            // Validate and Update via BUS
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
            if (txtNewPass.Text != txtConfirmPass.Text) {
                MessageBox.Show("Xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string result = _userBUS.ChangePassword(GlobalAccount.GetUserId(), txtCurrentPass.Text, txtNewPass.Text);
            
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
            try {
                string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images", "default.jpg");
                if (File.Exists(defaultPath)) picAvatar.ImageLocation = defaultPath;
                picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            } catch { }
        }

        private void SectionPanel_Paint(object sender, PaintEventArgs e)
        {
            Control pnl = sender as Control;
            if (pnl == pnlBasicInfo || pnl == pnlSecurity || pnl == pnlChangePassword)
            {
                Color accentColor = (pnl == pnlBasicInfo) ? Color.FromArgb(37, 99, 235) : Color.Transparent;
                UIHelper.DrawSectionShadow(sender, e, 20, accentColor);
            }

            // Vẽ viền (vạch dưới) cho các ô nhập liệu
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
                    
                    // 1. Vẽ khung viền quanh toàn bộ ô (Đen - 2px, Bo góc 8)
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
                else if (c is Panel && c.HasChildren && c.Visible && c != pnlBasicInfoActions && c != pnlPassActions)
                {
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

        private void Button_Paint(object sender, PaintEventArgs e) => UIHelper.btn_Paint(sender, e);
    }
}
