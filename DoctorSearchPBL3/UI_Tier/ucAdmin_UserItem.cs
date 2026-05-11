using System;
using System.Drawing;
using System.Windows.Forms;
using DTO_Tier;
using BUS_Tier;
using System.IO;

namespace UI_Tier
{
    public partial class ucAdmin_UserItem : UserControl
    {
        private UserDTO _user;
        private DoctorDTO _doctor;
        private AdminBUS _adminBUS = new AdminBUS();
        public event EventHandler DataChanged;

        public ucAdmin_UserItem()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
        }

        public void SetUserData(UserDTO user)
        {
            _user = user;
            _doctor = null;
            UpdateUI();
        }

        public void SetDoctorData(DoctorDTO doctor)
        {
            _doctor = doctor;
            _user = doctor.User;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (_user == null) return;

            lblFullName.Text = _user.FullName;
            lblPhone.Text = _user.PhoneNumber;
            lblRole.Text = _user.Role;
            lblJoinedDate.Text = _user.CreatedAt.ToString("dd/MM/yyyy");
            
            // Status Badge
            lblStatus.Text = _user.Status;
            lblStatus.ForeColor = _user.Status == "Active" ? Color.FromArgb(0, 182, 122) : Color.FromArgb(255, 77, 79);
            pnlStatusBadge.BackColor = _user.Status == "Active" ? Color.FromArgb(230, 249, 243) : Color.FromArgb(255, 241, 240);

            // Role Badge
            SetRoleBadge(_user.Role);

            // Action Buttons
            btnApprove.Visible = (_user.Role == "Doctor" && _doctor != null && !_doctor.IsApproved);
            btnReject.Visible = (_user.Role == "Doctor" && _doctor != null && !_doctor.IsApproved);
            btnToggleStatus.Text = _user.Status == "Active" ? "Chặn" : "Mở chặn";
            btnToggleStatus.Visible = !btnApprove.Visible;

            // Load Avatar
            LoadAvatar();
        }

        private void SetRoleBadge(string role)
        {
            switch (role)
            {
                case "Admin":
                    lblRole.ForeColor = Color.FromArgb(114, 46, 209);
                    pnlRoleBadge.BackColor = Color.FromArgb(249, 240, 255);
                    break;
                case "Doctor":
                    lblRole.ForeColor = Color.FromArgb(24, 144, 255);
                    pnlRoleBadge.BackColor = Color.FromArgb(230, 247, 255);
                    break;
                case "Patient":
                    lblRole.ForeColor = Color.FromArgb(250, 173, 20);
                    pnlRoleBadge.BackColor = Color.FromArgb(255, 251, 230);
                    break;
            }
        }

        private void LoadAvatar()
        {
            string fileName = string.IsNullOrWhiteSpace(_user.Picture) ? "default.jpg" : _user.Picture.Trim();
            string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images");
            string imagePath = Path.Combine(imageFolder, fileName);

            if (File.Exists(imagePath))
            {
                try
                {
                    if (picAvatar.Image != null) picAvatar.Image.Dispose();
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        picAvatar.Image = new Bitmap(fs);
                    }
                }
                catch { picAvatar.Image = null; }
            }
            else
            {
                picAvatar.Image = null; // Or a default image
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (_doctor == null) return;
            if (MessageBox.Show($"Duyệt bác sĩ {_user.FullName}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_adminBUS.ApproveDoctor(_doctor.Id))
                {
                    DataChanged?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Duyệt thất bại!");
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (_doctor == null) return;
            if (MessageBox.Show($"Từ chối bác sĩ {_user.FullName}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_adminBUS.RejectDoctor(_doctor.Id))
                {
                    DataChanged?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Thao tác thất bại!");
                }
            }
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            string newStatus = _user.Status == "Active" ? "Inactive" : "Active";
            if (_adminBUS.UpdateUserStatus(_user.Id, newStatus))
            {
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void ucAdmin_UserItem_Load(object sender, EventArgs e)
        {
            UIHelper.ApplyRoundedRegion(picAvatar, picAvatar.Width / 2);
            UIHelper.ApplyRoundedRegion(pnlRoleBadge, 10);
            UIHelper.ApplyRoundedRegion(pnlStatusBadge, 10);
            UIHelper.ApplyRoundedRegion(btnApprove, 8);
            UIHelper.ApplyRoundedRegion(btnReject, 8);
            UIHelper.ApplyRoundedRegion(btnToggleStatus, 8);
        }

        private void ucAdmin_UserItem_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 15, Color.FromArgb(240, 240, 240), 1);
        }
    }
}
