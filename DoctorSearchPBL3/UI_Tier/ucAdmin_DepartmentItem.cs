using System;
using System.Drawing;
using System.Windows.Forms;
using DTO_Tier;
using BUS_Tier;

namespace UI_Tier
{
    public partial class ucAdmin_DepartmentItem : UserControl
    {
        private DepartmentDTO _dept;
        private DepartmentBUS _deptBUS = new DepartmentBUS();
        private AdminBUS _adminBUS = new AdminBUS(); // To get doctor count
        public event EventHandler DataChanged;

        public ucAdmin_DepartmentItem()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlCard);

            pnlCard.Paint += pnlCard_Paint;
            pnlCard.Resize += (s, e) => UIHelper.ApplyRoundedRegion(pnlCard, 15);
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 15, Color.FromArgb(200, 200, 200), 3);
        }

        public void SetData(DepartmentDTO dept)
        {
            _dept = dept;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (_dept == null) return;

            lblName.Text = _dept.DepartmentName;
            lblDesc.Text = _dept.Description ?? "Không có mô tả";
            
            // Get doctor count directly from DoctorBUS
            int count = new DoctorBUS().GetDoctorCountByDepartmentId(_dept.Id);
            lblCount.Text = $"{count} bác sĩ";
            
            // Status Badge
            lblStatus.Text = _dept.IsActive ? "Hiển thị" : "Ẩn";
            if (_dept.IsActive)
            {
                lblStatus.ForeColor = Color.FromArgb(22, 163, 74);
                pnlStatusBadge.BackColor = Color.FromArgb(220, 252, 231);
                btnToggleHide.Text = "\uE890"; // Eye-slash icon
            }
            else
            {
                lblStatus.ForeColor = Color.FromArgb(220, 38, 38);
                pnlStatusBadge.BackColor = Color.FromArgb(254, 226, 226);
                btnToggleHide.Text = "\uE7B3"; // Eye icon
            }

            UIHelper.ApplyRoundedRegion(pnlStatusBadge, 10);
            UIHelper.ApplyRoundedRegion(pnlCountBadge, 10);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(_dept);
        }

        private void btnToggleHide_Click(object sender, EventArgs e)
        {
            _dept.IsActive = !_dept.IsActive;
            if (_deptBUS.UpdateDepartment(_dept))
            {
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa chuyên khoa '{_dept.DepartmentName}'?", 
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_deptBUS.DeleteDepartment(_dept.Id))
                {
                    DataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void ShowAddEditDialog(DepartmentDTO dept)
        {
            ucAdmin_AddDepartment uc = new ucAdmin_AddDepartment();
            uc.SetData(dept);

            // Tìm Parent là ucAdmin_DepartmentManagement để hiển thị Overlay
            Control p = this.Parent;
            while (p != null && !(p is ucAdmin_DepartmentManagement))
            {
                p = p.Parent;
            }

            if (p is ucAdmin_DepartmentManagement deptMgmt)
            {
                uc.OnCancel += (s, ev) => deptMgmt.Controls.Remove(uc);
                uc.OnSuccess += (s, ev) => {
                    deptMgmt.Controls.Remove(uc);
                    DataChanged?.Invoke(this, EventArgs.Empty);
                };
                deptMgmt.ShowOverlay(uc);
            }
            else
            {
                // Fallback
                Form f = new Form { Size = new Size(1000, 850), FormBorderStyle = FormBorderStyle.None, StartPosition = FormStartPosition.CenterScreen };
                uc.Dock = DockStyle.Fill;
                f.Controls.Add(uc);
                uc.OnCancel += (s, ev) => f.Close();
                uc.OnSuccess += (s, ev) => { f.Close(); DataChanged?.Invoke(this, EventArgs.Empty); };
                f.ShowDialog();
            }
        }
    }
}
