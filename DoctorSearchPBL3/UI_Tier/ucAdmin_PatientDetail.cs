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
            btnSave.Click += BtnSave_Click;

            // Apply rounding
            UIHelper.ApplyRoundedRegion(btnSave, 12);

            InitializeEditControls();
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
            edit.Location = label.Location;
            edit.Width = label.Parent.Width - label.Left - 15;
            edit.Height = label.Height + 18;
            edit.Visible = false;
            edit.BackColor = Color.FromArgb(249, 250, 251);

            // Create a blue underline panel for focus effect
            Panel focusLine = new Panel();
            focusLine.Height = 2;
            focusLine.BackColor = Color.FromArgb(59, 130, 246); // Blue-500
            focusLine.Width = edit.Width;
            focusLine.Location = new Point(edit.Left, edit.Bottom);
            focusLine.Visible = false;
            focusLine.Name = "focus_" + edit.Name;
            label.Parent.Controls.Add(focusLine);
            
            // Add focus effects
            if (edit is TextBox || edit is ComboBox || edit is NumericUpDown || edit is DateTimePicker)
            {
                edit.Enter += (s, e) => {
                    edit.BackColor = Color.White;
                    focusLine.Visible = _isEditMode;
                    focusLine.BringToFront();
                };
                edit.Leave += (s, e) => {
                    edit.BackColor = Color.FromArgb(249, 250, 251);
                    focusLine.Visible = false;
                };
            }

            label.Parent.Controls.Add(edit);
        }

        private void ApplyFocusEffect(Control ctrl)
        {
            ctrl.Enter += (s, e) => {
                ctrl.BackColor = Color.White;
                // You can add more visual cues here
            };
            ctrl.Leave += (s, e) => {
                ctrl.BackColor = Color.FromArgb(249, 250, 251);
            };
        }

        private void SwitchMode(bool editMode)
        {
            _isEditMode = editMode;

            lblVName.Visible = !editMode; txtEditName.Visible = editMode;
            lblVPhone.Visible = !editMode; txtEditPhone.Visible = editMode;
            lblVDob.Visible = !editMode; dtpEditDob.Visible = editMode;
            lblVGender.Visible = !editMode; cboEditGender.Visible = editMode;
            lblVCCCD.Visible = !editMode; txtEditCCCD.Visible = editMode;
            lblVAddress.Visible = !editMode; txtEditAddress.Visible = editMode;
            lblVInsCode.Visible = !editMode; txtEditInsCode.Visible = editMode;
            lblVEmerName.Visible = !editMode; txtEditEmerName.Visible = editMode;
            lblVEmerPhone.Visible = !editMode; txtEditEmerPhone.Visible = editMode;
            lblVNotes.Visible = !editMode; txtEditNotes.Visible = editMode;

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
                lblVRegDate.Text = patient.CreatedAt.ToString("dd/MM/yyyy");
                lblVNotes.Text = patient.Note ?? "Chưa có ghi chú";
            }

            // Apply rounded corners
            if (pnlBadgeRole != null) UIHelper.ApplyRoundedRegion(pnlBadgeRole, 18);
            if (pnlBadgeStatus != null) UIHelper.ApplyRoundedRegion(pnlBadgeStatus, 18);
            if (pnlNotesContainer != null) UIHelper.ApplyRoundedRegion(pnlNotesContainer, 8);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null) this.ParentForm.Close();
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
