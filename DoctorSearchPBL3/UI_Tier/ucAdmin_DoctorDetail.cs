using System;
using System.Drawing;
using System.Windows.Forms;
using DTO_Tier;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace UI_Tier
{
    public partial class ucAdmin_DoctorDetail : UserControl
    {
        private string _certPath = null;
        private UserDTO _currentUser;
        private DoctorDTO _currentDoctor;
        private readonly BUS_Tier.DoctorBUS doctorBUS = new BUS_Tier.DoctorBUS();
        private readonly BUS_Tier.DepartmentBUS departmentBUS = new BUS_Tier.DepartmentBUS();
        private bool _isEditMode = false;

        public ucAdmin_DoctorDetail()
        {
            InitializeComponent();
            
            // Wire up events
            btnClose.Click += btnClose_Click;
            btnExit.Click += btnClose_Click;
            
            btnSave.Click += BtnSave_Click;
            lnkUploadLicense.LinkClicked += lnkUploadLicense_LinkClicked;
            lnkViewLicense.LinkClicked += lnkViewLicense_LinkClicked;

            // Apply rounded corners
            UIHelper.ApplyRoundedRegion(btnSave, 12);
            UIHelper.ApplyRoundedRegion(btnClose, 12);

            InitializeEditControls();
            LoadDepartments();

            this.Resize += (s, e) => UIHelper.ApplyRoundedRegion(this, 25);
            this.Paint += ucAdmin_DoctorDetail_Paint;
            this.Padding = new Padding(2); // Thêm padding để không bị các panel con che mất viền

            // Cho phép di chuyển form bằng cách kéo Header
            UIHelper.EnableNativeDrag(pnlHeader, this);
            UIHelper.EnableNativeDrag(lblTitle, this);
            UIHelper.EnableNativeDrag(lblSubtitle, this);

            // Đăng ký click ra ngoài để thoát focus
            UIHelper.RegisterClickToUnfocus(this);
        }

        private void ucAdmin_DoctorDetail_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // Độ dày viền form chính là 3
            using (Pen pen = new Pen(Color.Black, 3))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                float offset = 1.5f; // Căn giữa cho pen 3px
                using (var path = UIHelper.GetRoundedPath(new RectangleF(offset, offset, this.Width - offset * 2, this.Height - offset * 2), 25))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void InitializeEditControls()
        {
            // Position edit controls over labels
            SetupEditControl(txtEditName, lblVName);
            SetupEditControl(txtEditPhone, lblVPhone);
            SetupEditControl(dtpEditDob, lblVDob);
            SetupEditControl(cboEditGender, lblVGender);
            SetupEditControl(txtEditCCCD, lblVCCCD);
            SetupEditControl(txtEditAddress, lblVAddress);
            SetupEditControl(cboEditDept, lblVDept);
            SetupEditControl(txtEditPosition, lblVPosition);
            SetupEditControl(txtEditLicense, lblVLicense);
            SetupEditControl(nudEditExp, lblVExp);
            SetupEditControl(nudEditFee, lblVFee);
            
            // Bio is special (larger)
            txtEditBio.Multiline = true;
            SetupEditControl(txtEditBio, lblVBio);
            txtEditBio.Height = 100;

            cboEditGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
        }

        private void LoadDepartments()
        {
            try
            {
                var list = departmentBUS.GetDepartmentsForUI();
                if (list != null)
                {
                    cboEditDept.DataSource = list;
                    cboEditDept.DisplayMember = "DepartmentName";
                    cboEditDept.ValueMember = "Id";
                    cboEditDept.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkUploadLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _certPath = ofd.FileName;
                    MessageBox.Show("Đã chọn file chứng chỉ. Vui lòng nhấn Lưu để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lnkViewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_certPath))
            {
                try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(_certPath) { UseShellExecute = true }); }
                catch { MessageBox.Show("Không thể mở file."); }
            }
        }

        private void SetupEditControl(Control edit, Control label)
        {
            Panel pnlWrapper = new Panel();
            pnlWrapper.Name = edit.Name + "_wrapper";

            if (edit == txtEditBio)
            {
                // pnlBio contains label and edit
                pnlWrapper.Location = new Point(0, 54); 
                pnlWrapper.Size = new Size(label.Parent.Width - 20, 150);
                pnlWrapper.BackColor = Color.White;
                pnlWrapper.Visible = false;
                pnlWrapper.Padding = new Padding(10);
                
                edit.Parent = pnlWrapper;
                edit.Dock = DockStyle.Fill;
                edit.BackColor = Color.White;
                edit.Visible = true;
                if (edit is TextBox tb) tb.BorderStyle = BorderStyle.None;
                
                label.Parent.Controls.Add(pnlWrapper);
                pnlWrapper.BringToFront();
            }
            else
            {
                // Nhích lên trên một chút để thấy được viền dưới
                pnlWrapper.Location = new Point(label.Left, label.Top - 8); 
                
                // Đặc biệt cho License để không che mất link tải lên
                if (edit == txtEditLicense) pnlWrapper.Width = 480;
                else pnlWrapper.Width = label.Parent.Width - label.Left - 15;

                pnlWrapper.Height = label.Height + 30; // Đảm bảo đủ 50px hoặc hơn cho thoáng
                pnlWrapper.BackColor = Color.White;
                pnlWrapper.Visible = false;
                pnlWrapper.Padding = new Padding(12, 12, 12, 10); // Chuẩn padding mới

                edit.Parent = pnlWrapper;
                edit.Dock = DockStyle.Fill;
                edit.BackColor = Color.White;
                edit.Visible = true; 

                if (edit is TextBox tb) tb.BorderStyle = BorderStyle.None;
                if (edit is RichTextBox rtb) rtb.BorderStyle = BorderStyle.None;

                label.Parent.Controls.Add(pnlWrapper);
                pnlWrapper.BringToFront();
            }

            UIHelper.SetDoubleBuffered(pnlWrapper);
            UIHelper.SetupInputFocusEffect(edit, pnlWrapper, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
        }

        private void SetEditVisible(Control edit, bool visible)
        {
            if (edit.Parent is Panel pnl && pnl.Name == edit.Name + "_wrapper")
            {
                pnl.Visible = visible;
                if (visible) pnl.BringToFront();
            }
            else
            {
                edit.Visible = visible;
            }
        }

        private void SwitchMode(bool editMode)
        {
            _isEditMode = editMode;
            
            // Toggle visibility
            lblVName.Visible = !editMode; SetEditVisible(txtEditName, editMode);
            lblVPhone.Visible = !editMode; SetEditVisible(txtEditPhone, editMode);
            lblVDob.Visible = !editMode; SetEditVisible(dtpEditDob, editMode);
            lblVGender.Visible = !editMode; SetEditVisible(cboEditGender, editMode);
            lblVCCCD.Visible = !editMode; SetEditVisible(txtEditCCCD, editMode);
            lblVAddress.Visible = !editMode; SetEditVisible(txtEditAddress, editMode);
            lblVDept.Visible = !editMode; SetEditVisible(cboEditDept, editMode);
            lblVPosition.Visible = !editMode; SetEditVisible(txtEditPosition, editMode);
            lblVLicense.Visible = !editMode; SetEditVisible(txtEditLicense, editMode);
            lblVExp.Visible = !editMode; SetEditVisible(nudEditExp, editMode);
            lblVFee.Visible = !editMode; SetEditVisible(nudEditFee, editMode);
            lblVBio.Visible = !editMode; SetEditVisible(txtEditBio, editMode);
            //pnlNotesContainer.Visible = !editMode; // Ẩn view mode panel của bio

            btnSave.Visible = editMode;
            
            // License links visibility
            lnkUploadLicense.Visible = editMode;
            lnkViewLicense.Visible = !editMode && !string.IsNullOrEmpty(_certPath);
            
            if (editMode)
            {
                // Sync data from labels/DTO to edit controls
                txtEditName.Text = _currentUser.FullName;
                txtEditPhone.Text = _currentUser.PhoneNumber;
                dtpEditDob.Value = _currentUser.Dob ?? DateTime.Now;
                cboEditGender.SelectedItem = _currentUser.Gender;
                txtEditCCCD.Text = _currentUser.CCCD;
                txtEditAddress.Text = _currentUser.Residential_Address;
                
                if (_currentDoctor != null)
                {
                    txtEditPosition.Text = _currentDoctor.Position;
                    txtEditLicense.Text = _currentDoctor.LicenseNumber;
                    nudEditExp.Value = _currentDoctor.ExperienceYears ?? 0;
                    nudEditFee.Value = (decimal)(_currentDoctor.ConsultationFee ?? 0);
                    txtEditBio.Text = _currentDoctor.Biography;
                    
                    if (_currentDoctor.DepartmentId != null)
                    {
                        cboEditDept.SelectedValue = _currentDoctor.DepartmentId;
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Sync data from edit controls to DTOs
                _currentUser.FullName = txtEditName.Text.Trim();
                _currentUser.PhoneNumber = txtEditPhone.Text.Trim();
                _currentUser.Dob = dtpEditDob.Value;
                _currentUser.Gender = cboEditGender.SelectedItem?.ToString();
                _currentUser.CCCD = txtEditCCCD.Text.Trim();
                _currentUser.Residential_Address = txtEditAddress.Text.Trim();

                if (_currentDoctor != null)
                {
                    _currentDoctor.Position = txtEditPosition.Text.Trim();
                    _currentDoctor.LicenseNumber = txtEditLicense.Text.Trim();
                    _currentDoctor.ExperienceYears = (int)nudEditExp.Value;
                    _currentDoctor.ConsultationFee = nudEditFee.Value;
                    _currentDoctor.Biography = txtEditBio.Text.Trim();
                    _currentDoctor.DepartmentId = (int)cboEditDept.SelectedValue;
                    
                    // Link user to doctor for validation
                    _currentDoctor.User = _currentUser;

                    // Call BUS to Save with validation
                    string result = doctorBUS.UpdateDoctorInfo(_currentDoctor);
                    
                    if (result == "Cập nhật thành công!")
                    {
                        MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SwitchMode(false);
                        
                        // Refresh data from DB to ensure UI reflects actual state
                        var updatedDoc = doctorBUS.GetDoctorById(_currentDoctor.Id);
                        if (updatedDoc != null)
                        {
                            SetData(updatedDoc.User, updatedDoc);
                        }
                    }
                    else
                    {
                        MessageBox.Show(result, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetEditMode(bool edit)
        {
            SwitchMode(edit);
        }

        public void SetData(UserDTO user, DoctorDTO doctor)
        {
            _currentUser = user;
            _currentDoctor = doctor;

            lblSubtitle.Text = user.FullName;
            lblTitle.Text = "Chi tiết Bác sĩ";

            // Basic Info
            lblVName.Text = user.FullName;
            lblVPhone.Text = user.PhoneNumber;
            lblVDob.Text = user.Dob?.ToString("dd/MM/yyyy") ?? "Chưa cập nhật";
            lblVGender.Text = user.Gender ?? "Chưa cập nhật";
            lblVCCCD.Text = user.CCCD ?? "Chưa cập nhật";
            lblVAddress.Text = user.Residential_Address ?? "Chưa cập nhật";
            lblVCreatedAt.Text = user.CreatedAt.ToString("HH:mm:ss dd/MM/yyyy");

            // Role Badge (Always Doctor)
            lblVRole.Text = "Bác sĩ";
            lblVRole.ForeColor = Color.FromArgb(37, 99, 235);
            pnlBadgeRole.BackColor = Color.FromArgb(239, 246, 255);

            // Status Badge
            lblVStatus.Text = user.Status == "Active" ? "Hoạt động" : "Bị khóa";
            if (user.Status == "Active") { lblVStatus.ForeColor = Color.FromArgb(22, 163, 74); pnlBadgeStatus.BackColor = Color.FromArgb(220, 252, 231); }
            else { lblVStatus.ForeColor = Color.FromArgb(220, 38, 38); pnlBadgeStatus.BackColor = Color.FromArgb(254, 226, 226); }

            // Professional Info
            if (doctor != null)
            {
                lblVDept.Text = doctor.Department?.DepartmentName ?? "Chưa cập nhật";
                lblVPosition.Text = doctor.Position ?? "Bác sĩ";
                lblVLicense.Text = doctor.LicenseNumber ?? "Chưa cập nhật";
                lblVExp.Text = (doctor.ExperienceYears?.ToString() ?? "0") + " năm";
                lblVFee.Text = (doctor.ConsultationFee != null && doctor.ConsultationFee > 0) 
                    ? doctor.ConsultationFee.Value.ToString("N0") + "đ" 
                    : "Chưa cập nhật";
                //lblVJoinDate.Text = (doctor.JoinDate ?? user.CreatedAt).ToString("dd/MM/yyyy");

                // Approval Badge
                lblVApproval.Text = doctor.IsApproved ? "Đã duyệt" : "Chờ duyệt";
                if (doctor.IsApproved) { lblVApproval.ForeColor = Color.FromArgb(22, 163, 74); pnlBadgeApproval.BackColor = Color.FromArgb(220, 252, 231); }
                else { lblVApproval.ForeColor = Color.FromArgb(161, 98, 7); pnlBadgeApproval.BackColor = Color.FromArgb(254, 252, 232); }

                lblVRating.Text = doctor.TotalReviews > 0 ? $"{doctor.AverageRating:F1}/5.0 ({doctor.TotalReviews} đánh giá)" : "Chưa có đánh giá";
                lblVBio.Text = doctor.Biography ?? "Chưa cập nhật";

                // Certificate Link
                var primaryCert = doctor.Certificates?
                    .Where(c => !c.IsDeleted)
                    .OrderByDescending(c => c.UploadedAt)
                    .FirstOrDefault();
                _certPath = primaryCert?.FilePath;
                
                // Refresh link visibility based on current mode
                lnkUploadLicense.Visible = _isEditMode;
                lnkViewLicense.Visible = !_isEditMode && !string.IsNullOrEmpty(_certPath);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                if (this.Parent is Form f && f.FormBorderStyle != FormBorderStyle.None)
                {
                    f.Close();
                }
                else
                {
                    Control p = this.Parent;
                    p.Controls.Remove(this);
                    this.Dispose();
                }
            }
        }

        //private void lnkViewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(_certPath)) return;

        //    try
        //    {
        //        string fullPath = Path.Combine(Application.StartupPath, _certPath);
        //        if (File.Exists(fullPath))
        //        {
        //            Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không tìm thấy file chứng chỉ tại: " + fullPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Không thể mở file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void lnkUploadLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    if (_currentDoctor == null) return;

        //    using (OpenFileDialog ofd = new OpenFileDialog())
        //    {
        //        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.pdf|All Files|*.*";
        //        ofd.Title = "Chọn file chứng chỉ";

        //        if (ofd.ShowDialog() == DialogResult.OK)
        //        {
        //            string result = doctorBUS.UploadCertificate(_currentDoctor.Id, ofd.FileName);
        //            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
        //            if (result == "Tải lên thành công!")
        //            {
        //                // Refresh only the certificate path to avoid losing other unsaved edits
        //                var updatedDoctor = doctorBUS.GetDoctorById(_currentDoctor.Id);
        //                if (updatedDoctor != null)
        //                {
        //                    var primaryCert = updatedDoctor.Certificates?
        //                        .Where(c => !c.IsDeleted)
        //                        .OrderByDescending(c => c.UploadedAt)
        //                        .FirstOrDefault();
                            
        //                    _certPath = primaryCert?.FilePath;
        //                    lnkViewLicense.Visible = !string.IsNullOrEmpty(_certPath);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
