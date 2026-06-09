using System;
using System.Drawing;
using System.Windows.Forms;
using BUS_Tier;
using DTO_Tier;

namespace UI_Tier
{
    public partial class ucAdmin_DepartmentItem : UserControl
    {
        private DepartmentDTO _dept;
        private readonly DepartmentBUS _deptBUS = new DepartmentBUS();
        public event EventHandler DataChanged;

        private readonly ToolTip _toolTip = new ToolTip();
        private string _searchKeyword = "";

        public ucAdmin_DepartmentItem()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlCard);

            _toolTip.SetToolTip(btnEdit, "Chỉnh sửa thông tin chuyên khoa");
            _toolTip.SetToolTip(btnRemove, "Xóa chuyên khoa khỏi hệ thống");

            pnlCard.Paint += pnlCard_Paint;
            pnlCard.Resize += (s, e) => UIHelper.ApplyRoundedRegion(pnlCard, 15);

            UIHelper.ApplyRoundedRegion(btnEdit, 40);
            UIHelper.ApplyRoundedRegion(btnRemove, 40);
            UIHelper.ApplyRoundedRegion(btnToggleHide, 40);

            // Vẽ lại tên và mô tả chuyên khoa với chữ nổi bật (Highlight) khi có từ khóa tìm kiếm trùng khớp
            lblName.Paint += lblName_Paint;
            lblDesc.Paint += lblDesc_Paint;
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 15, Color.DimGray, 3);
        }

        public void SetData(DepartmentDTO dept, string searchKeyword = "")
        {
            _dept = dept;
            _searchKeyword = searchKeyword;
            UpdateUI();
            lblName.Invalidate();
            lblDesc.Invalidate();
        }

        private void UpdateUI()
        {
            if (_dept == null)
            {
                return;
            }

            lblName.Text = _dept.DepartmentName;
            lblDesc.Text = string.IsNullOrWhiteSpace(_dept.Description) ? "Không có mô tả" : _dept.Description;

            // 1. Khởi tạo cục bộ các đối tượng BUS để đảm bảo không bị lỗi NullReference giữa các tầng
            DoctorBUS docBus = new DoctorBUS();
            RoomBUS roomBus = new RoomBUS();

            int doctorCount = docBus.GetDoctorCountByDepartmentId(_dept.Id, _dept.IsDeleted);
            int roomCount = roomBus.GetRoomCountByDepartmentId(_dept.Id, _dept.IsDeleted);

            // 2. Gán chuỗi nội suy chuẩn chỉnh
            lblCount.Text = $"{doctorCount} Bác sĩ | {roomCount} Phòng";

            if (_dept.IsDeleted)
            {
                lblStatus.Text = "Đã xóa";
                lblStatus.ForeColor = Color.Gray;
                btnEdit.Visible = false;
                btnToggleHide.Visible = false;
                btnRemove.Visible = false;
            }
            else
            {
                btnEdit.Visible = true;
                btnToggleHide.Visible = true;
                btnRemove.Visible = true;

                btnRemove.Text = "\uE74D"; // Trash icon
                btnRemove.BackColor = Color.FromArgb(255, 252, 235);
                btnRemove.ForeColor = Color.FromArgb(217, 119, 6);
                _toolTip.SetToolTip(btnRemove, "Xóa chuyên khoa khỏi hệ thống");

                lblStatus.Text = _dept.IsActive ? "Hiển thị" : "Ẩn";
                if (_dept.IsActive)
                {
                    lblStatus.ForeColor = Color.FromArgb(22, 163, 74);
                    btnToggleHide.Text = "\uE890";
                    _toolTip.SetToolTip(btnToggleHide, "Ẩn chuyên khoa này khỏi danh sách tìm kiếm");
                }
                else
                {
                    lblStatus.ForeColor = Color.FromArgb(220, 38, 38);
                    btnToggleHide.Text = "\uE7B3";
                    _toolTip.SetToolTip(btnToggleHide, "Hiển thị lại chuyên khoa này trong danh sách tìm kiếm");
                }
            }
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
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa chuyên khoa '{_dept.DepartmentName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes && _deptBUS.DeleteDepartment(_dept.Id))
            {
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void ShowAddEditDialog(DepartmentDTO dept)
        {
            ucAdmin_AddDepartment uc = new ucAdmin_AddDepartment();
            uc.SetData(dept);

            Control p = Parent;
            while (p != null && p is not ucAdmin_DepartmentManagement)
            {
                p = p.Parent;
            }

            if (p is ucAdmin_DepartmentManagement deptMgmt)
            {
                uc.OnCancel += (s, ev) => deptMgmt.Controls.Remove(uc);
                uc.OnSuccess += (s, ev) =>
                {
                    deptMgmt.Controls.Remove(uc);
                    DataChanged?.Invoke(this, EventArgs.Empty);
                };
                deptMgmt.ShowOverlay(uc);
            }
            else
            {
                Form f = new Form
                {
                    Size = new Size(1000, 980),
                    FormBorderStyle = FormBorderStyle.None,
                    StartPosition = FormStartPosition.CenterScreen
                };
                uc.Dock = DockStyle.Fill;
                f.Controls.Add(uc);
                uc.OnCancel += (s, ev) => f.Close();
                uc.OnSuccess += (s, ev) =>
                {
                    f.Close();
                    DataChanged?.Invoke(this, EventArgs.Empty);
                };
                f.ShowDialog();
            }
        }

        private void lblName_Paint(object sender, PaintEventArgs e)
        {
            if (_dept == null) return;
            UIHelper.DrawHighlightText(e.Graphics, lblName, _dept.DepartmentName, _searchKeyword, 
                Color.FromArgb(17, 24, 39), Color.FromArgb(206, 225, 255), Color.FromArgb(0, 98, 255));
        }

        private void lblDesc_Paint(object sender, PaintEventArgs e)
        {
            if (_dept == null) return;
            string text = string.IsNullOrWhiteSpace(_dept.Description) ? "Không có mô tả" : _dept.Description;
            UIHelper.DrawHighlightText(e.Graphics, lblDesc, text, _searchKeyword, 
                Color.FromArgb(107, 114, 128), Color.FromArgb(206, 225, 255), Color.FromArgb(0, 98, 255));
        }
    }
}
