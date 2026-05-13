using System;
using System.Drawing;
using System.Windows.Forms;
using DTO_Tier;
using BUS_Tier;

namespace UI_Tier
{
    public partial class ucAdmin_AddDepartment : UserControl
    {
        private DepartmentDTO _dept;
        private DepartmentBUS _deptBUS = new DepartmentBUS();
        public event EventHandler OnCancel;
        public event EventHandler OnSuccess;

        public ucAdmin_AddDepartment()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            SetupUI();
        }

        private void SetupUI()
        {
            UIHelper.ApplyRoundedRegion(btnSave, 10);
            UIHelper.ApplyRoundedRegion(btnCancel, 10);
            UIHelper.ApplyRoundedRegion(txtName, 8);
            UIHelper.ApplyRoundedRegion(txtDesc, 8);
        }

        public void SetData(DepartmentDTO dept)
        {
            _dept = dept;
            if (_dept != null)
            {
                lblHeaderTitle.Text = "Cập nhật chuyên khoa";
                btnSave.Text = "Cập nhật";
                txtName.Text = _dept.DepartmentName;
                txtDesc.Text = _dept.Description;
                rbShow.Checked = _dept.IsActive;
                rbHide.Checked = !_dept.IsActive;
            }
            else
            {
                lblHeaderTitle.Text = "Thêm chuyên khoa mới";
                btnSave.Text = "Thêm mới";
                rbShow.Checked = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên chuyên khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DepartmentDTO dept = _dept ?? new DepartmentDTO();
            dept.DepartmentName = name;
            dept.Description = txtDesc.Text.Trim();
            dept.IsActive = rbShow.Checked;
            dept.DisplayOrder = 0; // Default or manage it

            bool success = (_dept == null) ? _deptBUS.AddDepartment(dept) : _deptBUS.UpdateDepartment(dept);

            if (success)
            {
                MessageBox.Show("Thành công!", "Thông báo");
                OnSuccess?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại.", "Lỗi");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(this, EventArgs.Empty);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(this, EventArgs.Empty);
        }
    }
}
