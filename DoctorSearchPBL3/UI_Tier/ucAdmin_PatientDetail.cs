using System;
using System.Drawing;
using System.Windows.Forms;
using DTO_Tier;

namespace UI_Tier
{
    public partial class ucAdmin_PatientDetail : UserControl
    {
        private Color _borderColor = Color.FromArgb(229, 231, 235);
        private UserDTO _currentUser;
        private PatientDTO _currentPatient;
        private bool _isEditMode = false;
        private readonly BUS_Tier.PatientBUS patientBUS = new BUS_Tier.PatientBUS();

        public ucAdmin_PatientDetail()
        {
            InitializeComponent();
            
            // Wire up events
            btnExit.Click += btnClose_Click;
            btnClose.Click += btnClose_Click;
            btnSave.Click += BtnSave_Click;

            // Apply rounding
            UIHelper.ApplyRoundedRegion(btnSave, 12);

            InitializeEditControls();

            this.Resize += (s, e) => UIHelper.ApplyRoundedRegion(this, 25);
            this.Paint += ucAdmin_PatientDetail_Paint;
            this.Padding = new Padding(2); // Thêm padding để không bị các panel con che mất viền

            // Cho phép di chuyển form bằng cách kéo Header
            UIHelper.EnableNativeDrag(pnlHeader, this);
            UIHelper.EnableNativeDrag(lblTitle, this);
            UIHelper.EnableNativeDrag(lblSubtitle, this);

            // Đăng ký click ra ngoài để thoát focus
            UIHelper.RegisterClickToUnfocus(this);
        }

        private void ucAdmin_PatientDetail_Paint(object sender, PaintEventArgs e)
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
            SetupEditControl(txtEditName, lblVName);
            SetupEditControl(txtEditPhone, lblVPhone);
            SetupEditControl(dtpEditDob, lblVDob);
            SetupEditControl(cboEditGender, lblVGender);
            SetupEditControl(txtEditCCCD, lblVCCCD);
            SetupEditControl(txtEditAddress, lblVAddress);
            SetupEditControl(txtEditInsCode, lblVInsCode);
            SetupEditControl(txtEditEmerName, lblVEmerName);
            SetupEditControl(txtEditEmerPhone, lblVEmerPhone);
            
            txtEditNotes.Multiline = true;
            SetupEditControl(txtEditNotes, lblVNotes);
            txtEditNotes.Height = 80;

            cboEditGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
        }

        private void SetupEditControl(Control edit, Control label)
        {
            Panel pnlWrapper = new Panel();
            pnlWrapper.Name = edit.Name + "_wrapper";
            
            // Đặc biệt cho phần Ghi chú (Notes)
            if (edit == txtEditNotes)
            {
                pnlWrapper.Location = pnlNotesContainer.Location;
                pnlWrapper.Size = pnlNotesContainer.Size;
                pnlWrapper.BackColor = Color.White;
                pnlWrapper.Visible = false;
                pnlWrapper.Padding = new Padding(10);
                
                edit.Parent = pnlWrapper;
                edit.Dock = DockStyle.Fill;
                edit.BackColor = Color.White;
                edit.Visible = true;
                if (edit is TextBox tb) tb.BorderStyle = BorderStyle.None;
                
                pnlNotes.Controls.Add(pnlWrapper);
                pnlWrapper.BringToFront();
            }
            else
            {
                pnlWrapper.Location = new Point(label.Left, label.Top - 8); 
                pnlWrapper.Width = label.Parent.Width - label.Left - 15;
                pnlWrapper.Height = label.Height + 20; // Giảm chiều cao xuống một chút
                pnlWrapper.BackColor = Color.White;
                pnlWrapper.Visible = false;
                pnlWrapper.Padding = new Padding(5, 4, 5, 2);

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
            lblVInsCode.Visible = !editMode; SetEditVisible(txtEditInsCode, editMode);
            lblVEmerName.Visible = !editMode; SetEditVisible(txtEditEmerName, editMode);
            lblVEmerPhone.Visible = !editMode; SetEditVisible(txtEditEmerPhone, editMode);
            lblVNotes.Visible = !editMode; SetEditVisible(txtEditNotes, editMode);

            pnlNotesContainer.Visible = !editMode; // Ẩn container cũ khi edit

            btnSave.Visible = editMode;

            if (editMode)
            {
                txtEditName.Text = _currentUser.FullName;
                txtEditPhone.Text = _currentUser.PhoneNumber;
                dtpEditDob.Value = _currentUser.Dob ?? DateTime.Now;
                cboEditGender.SelectedItem = _currentUser.Gender;
                txtEditCCCD.Text = _currentUser.CCCD;
                txtEditAddress.Text = _currentUser.Residential_Address;

                if (_currentPatient != null)
                {
                    txtEditInsCode.Text = _currentPatient.InsuranceCode;
                    txtEditEmerName.Text = _currentPatient.EmergencyContactName;
                    txtEditEmerPhone.Text = _currentPatient.EmergencyContactPhone;
                    txtEditNotes.Text = _currentPatient.Note;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Sync data to DTOs
                _currentUser.FullName = txtEditName.Text.Trim();
                _currentUser.PhoneNumber = txtEditPhone.Text.Trim();
                _currentUser.Dob = dtpEditDob.Value;
                _currentUser.Gender = cboEditGender.SelectedItem?.ToString();
                
                // Handle "Chưa đủ tuổi" placeholder for CCCD
                string cccdValue = txtEditCCCD.Text.Trim();
                _currentUser.CCCD = (cccdValue == "Chưa đủ tuổi") ? null : cccdValue;

                _currentUser.Residential_Address = txtEditAddress.Text.Trim();

                if (_currentPatient != null)
                {
                    _currentPatient.InsuranceCode = txtEditInsCode.Text.Trim();
                    _currentPatient.EmergencyContactName = txtEditEmerName.Text.Trim();
                    _currentPatient.EmergencyContactPhone = txtEditEmerPhone.Text.Trim();
                    _currentPatient.Note = txtEditNotes.Text.Trim();
                    
                    // Link user to patient for BUS validation
                    _currentPatient.User = _currentUser;

                    // Call BUS to Save with validation
                    string result = patientBUS.UpdatePatientProfile(_currentPatient);
                    
                    if (result == "Success")
                    {
                        MessageBox.Show("Đã lưu thay đổi thông tin bệnh nhân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SwitchMode(false);
                        
                        // Refresh data from DB
                        var updatedPatient = patientBUS.GetPatientProfile(_currentPatient.Id);
                        if (updatedPatient != null)
                        {
                            SetData(updatedPatient.User, updatedPatient);
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

        public void SetData(UserDTO user, PatientDTO patient)
        {
            _currentUser = user;
            _currentPatient = patient;

            lblSubtitle.Text = user.FullName;
            lblTitle.Text = "Chi tiết Bệnh nhân";

            // Basic Info
            lblVName.Text = user.FullName;
            lblVPhone.Text = user.PhoneNumber;
            lblVDob.Text = user.Dob?.ToString("dd/MM/yyyy") ?? "Chưa cập nhật";
            lblVGender.Text = user.Gender ?? "Chưa cập nhật";
            lblVCCCD.Text = user.CCCD ?? "Chưa cập nhật";
            lblVAddress.Text = user.Residential_Address ?? "Chưa cập nhật";
            lblVCreatedAt.Text = user.CreatedAt.ToString("HH:mm:ss dd/MM/yyyy");

            // Role Badge (Always Patient)
            lblVRole.Text = "Bệnh nhân";
            lblVRole.ForeColor = Color.FromArgb(22, 163, 74);
            pnlBadgeRole.BackColor = Color.FromArgb(220, 252, 231);

            // Status Badge
            lblVStatus.Text = user.Status == "Active" ? "Hoạt động" : "Bị khóa";
            if (user.Status == "Active") { lblVStatus.ForeColor = Color.FromArgb(22, 163, 74); pnlBadgeStatus.BackColor = Color.FromArgb(220, 252, 231); }
            else { lblVStatus.ForeColor = Color.FromArgb(220, 38, 38); pnlBadgeStatus.BackColor = Color.FromArgb(254, 226, 226); }

            // Medical Info
            if (patient != null)
            {
                lblVMedCode.Text = patient.MedicalCode ?? ("BN" + user.Id.ToString("D4"));
                lblVInsCode.Text = patient.InsuranceCode ?? "Chưa cập nhật";
                lblVEmerName.Text = patient.EmergencyContactName ?? "Chưa cập nhật";
                lblVEmerPhone.Text = patient.EmergencyContactPhone ?? "Chưa cập nhật";
                //lblVRegDate.Text = patient.CreatedAt.ToString("dd/MM/yyyy");
                lblVNotes.Text = patient.Note ?? "Chưa có ghi chú";
            }

            // Apply rounded corners
            if (pnlBadgeRole != null) UIHelper.ApplyRoundedRegion(pnlBadgeRole, 18);
            if (pnlBadgeStatus != null) UIHelper.ApplyRoundedRegion(pnlBadgeStatus, 18);
            if (pnlNotesContainer != null) UIHelper.ApplyRoundedRegion(pnlNotesContainer, 8);
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

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(_borderColor))
            {
                e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            }
        }

        private void SectionHeader_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = (Label)sender;
            using (Pen pen = new Pen(_borderColor))
            {
                e.Graphics.DrawLine(pen, 0, lbl.Height - 1, lbl.Width, lbl.Height - 1);
            }
        }
    }
}
