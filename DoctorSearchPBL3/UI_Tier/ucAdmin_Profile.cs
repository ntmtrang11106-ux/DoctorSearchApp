using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BUS_Tier;
using DTO_Tier;

namespace UI_Tier
{
    public partial class ucAdmin_Profile : UserControl
    {
        private readonly UserBUS _userBUS = new UserBUS();
        private UserDTO _currentUser;

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
            picAvatar.Click += picAvatar_Click;
            dtpBirthday.ValueChanged += dtpBirthday_ValueChanged;

            AttachFocusEvents(pnlBasicInfo, pnlBasicInfo);
            AttachFocusEvents(pnlChangePassword, pnlSecurity);
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

        private Control _focusedControl;
        private void AttachFocusEvents(Control container, Control parentToInvalidate)
        {
            foreach (Control c in container.Controls)
            {
                if (c is TextBox || c is DateTimePicker)
                {
                    c.Enter += (s, e) => { _focusedControl = (Control)s; parentToInvalidate.Invalidate(); };
                    c.Leave += (s, e) => { _focusedControl = null; parentToInvalidate.Invalidate(); };
                }
                else if (c is Panel && c.HasChildren)
                {
                    AttachFocusEvents(c, parentToInvalidate);
                }
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

            LoadDefaultAvatar();
            if (!string.IsNullOrEmpty(_currentUser.Picture) && File.Exists(_currentUser.Picture))
            {
                picAvatar.ImageLocation = _currentUser.Picture;
            }
        }

        private void SetEditMode(bool isEditing)
        {
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

            Color bg = isEditing ? Color.White : Color.FromArgb(250, 251, 252);
            txtFullName.BackColor = bg;
            txtPhone.BackColor = bg;
            txtGender.BackColor = bg;
            txtCCCD.BackColor = (isEditing && age < 18) ? Color.FromArgb(241, 243, 245) : bg;
            txtAddress.BackColor = bg;

            pnlBasicInfoActions.Visible = isEditing;
            btnEditBasicInfo.Visible = !isEditing;
            
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

        private void picAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string result = _userBUS.UpdateAvatar(GlobalAccount.GetUserId(), ofd.FileName);
                    if (result == "Success")
                    {
                        picAvatar.ImageLocation = ofd.FileName;
                        MessageBox.Show("Cập nhật ảnh đại diện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

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
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Soft Shadow
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
                using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }

            // Accent Line (Top)
            Color accentColor = (pnl == pnlSecurity) ? Color.FromArgb(244, 63, 94) : Color.FromArgb(37, 99, 235);
            using (Pen accentPen = new Pen(accentColor, 6))
            {
                e.Graphics.DrawLine(accentPen, 20, 0, pnl.Width - 20, 0);
            }

            // Draw Bottom Borders for all inputs in this panel
            DrawInputBorders(pnl, e.Graphics);
        }

        private void DrawInputBorders(Control container, Graphics g)
        {
            foreach (Control c in container.Controls)
            {
                if (c is TextBox || c is DateTimePicker)
                {
                    bool isFocused = (_focusedControl == c);
                    Color borderColor = isFocused ? 
                        ((container == pnlSecurity || container == pnlChangePassword) ? Color.FromArgb(244, 63, 94) : Color.FromArgb(37, 99, 235)) 
                        : Color.FromArgb(226, 232, 240);
                    int borderHeight = isFocused ? 2 : 1;

                    using (Pen pen = new Pen(borderColor, borderHeight))
                    {
                        g.DrawLine(pen, c.Left, c.Bottom, c.Right, c.Bottom);
                    }
                }
                else if (c is Panel && c.HasChildren)
                {
                    // For nested panels like pnlChangePassword
                    foreach (Control subC in c.Controls)
                    {
                        if (subC is TextBox || subC is DateTimePicker)
                        {
                            bool isFocused = (_focusedControl == subC);
                            Color borderColor = isFocused ? Color.FromArgb(244, 63, 94) : Color.FromArgb(226, 232, 240);
                            int borderHeight = isFocused ? 2 : 1;

                            Point relPos = container.PointToClient(c.PointToScreen(subC.Location));
                            using (Pen pen = new Pen(borderColor, borderHeight))
                            {
                                g.DrawLine(pen, relPos.X, relPos.Y + subC.Height, relPos.X + subC.Width, relPos.Y + subC.Height);
                            }
                        }
                    }
                }
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e) => UIHelper.btn_Paint(sender, e);
    }
}
