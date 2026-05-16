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
        public event EventHandler? OnSuccess;

        public ucAdmin_AddDepartment()
        {
            InitializeComponent();
            this.Paint += ucAdmin_AddDepartment_Paint;
            this.Padding = new Padding(3); // Chừa chỗ để hiện viền

            SetupUI();
            InitializeInputStyling();
            
            // Bật DoubleBuffered đệ quy sau khi đã khởi tạo hết các Panel/Wrapper
            UIHelper.SetDoubleBuffered(this);
        }

        private void ucAdmin_AddDepartment_Paint(object sender, PaintEventArgs e)
        {
            // Vẽ viền đen dày 3px như yêu cầu
            UIHelper.DrawControlBorder(sender, e, 15, Color.Black, 3);
        }

        private void InitializeInputStyling()
        {
            // Wrap Name
            Panel pnlName = SetupInputWrapper(txtName);
            // Wrap Description
            Panel pnlDesc = SetupInputWrapper(txtDesc);

            // Apply focus effects with the new global standard (1px black border, 4px blue underline)
            // Note: UIHelper.SetupInputFocusEffect now handles the 1px/4px drawing automatically
            UIHelper.SetupInputFocusEffect(txtName, pnlName, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));
            UIHelper.SetupInputFocusEffect(txtDesc, pnlDesc, Color.FromArgb(242, 248, 255), Color.White, Color.FromArgb(37, 99, 235));

            // CỰC KỲ QUAN TRỌNG: Gọi sau khi đã tạo xong các Panel Wrapper 
            // để các Panel này cũng nhận được sự kiện Click để Unfocus
            UIHelper.RegisterClickToUnfocus(this);
        }

        private Panel SetupInputWrapper(Control ctrl)
        {
            Panel pnl = new Panel();
            // Tinh chỉnh padding mỏng lại (3px mỗi bên) để viền đen ôm sát hơn
            int padding = 3;
            pnl.Bounds = new Rectangle(ctrl.Left - padding, ctrl.Top - padding, ctrl.Width + (padding * 2), ctrl.Height + (padding * 2));
            pnl.BackColor = Color.White;
            pnl.Name = "pnlWrapper_" + ctrl.Name;
            
            this.Controls.Add(pnl);
            ctrl.Parent = pnl;
            ctrl.Location = new Point(padding, padding);
            ctrl.Width = pnl.Width - (padding * 2);
            
            return pnl;
        }

        private void SetupUI()
        {
            lblHeaderTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            label1.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            txtName.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtDesc.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            // Loại bỏ viền mặc định để viền đen custom hiện lên đẹp hơn
            txtName.BorderStyle = BorderStyle.None;
            txtDesc.BorderStyle = BorderStyle.None;

            UIHelper.ApplyRoundedRegion(btnSave, 12);
            UIHelper.ApplyRoundedRegion(btnCancel, 12);
            
            // Enable dragging
            UIHelper.EnableNativeDrag(this, this);
            UIHelper.EnableNativeDrag(lblHeaderTitle, this);
            UIHelper.EnableNativeDrag(label1, this);
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
