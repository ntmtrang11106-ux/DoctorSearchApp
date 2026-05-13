using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucAdmin_AppointmentManagement : UserControl
    {
        private readonly TimeSlotBUS _bus = new TimeSlotBUS();
        private readonly DepartmentBUS _deptBus = new DepartmentBUS();
        private List<TimeSlotsDTO> _allSlots = new List<TimeSlotsDTO>();
        private List<TimeSlotsDTO> _filteredSlots = new List<TimeSlotsDTO>();
        
        private int _pageSize = 10;
        private int _currentPage = 1;

        public ucAdmin_AppointmentManagement()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(flpAppItem);
            
            // Custom styling for search area
            UIHelper.ApplyRoundedRegion(pnlSearchArea, 10);
            UIHelper.ApplyRoundedRegion(btnCreateSchedule, 8);

            flpAppItem.Resize += (s, e) => {
                foreach (Control ctrl in flpAppItem.Controls)
                {
                    ctrl.Width = flpAppItem.ClientSize.Width - 20;
                }
            };
        }

        private void ucAdmin_AppointmentManagement_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            InitData();
        }

        private void LoadDepartments()
        {
            try
            {
                var depts = _deptBus.GetAllDepartments();
                depts.Insert(0, new DepartmentDTO { Id = 0, DepartmentName = "Lọc theo khoa" });
                cbDept.DataSource = depts;
                cbDept.DisplayMember = "DepartmentName";
                cbDept.ValueMember = "Id";
            }
            catch { }
        }

        public void InitData()
        {
            try
            {
                _allSlots = _bus.GetAllTimeSlots();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            int deptId = (cbDept.SelectedValue is int id) ? id : 0;

            _filteredSlots = _allSlots.Where(s => 
                (string.IsNullOrEmpty(keyword) || 
                 (s.Doctor?.User?.FullName?.ToLower().Contains(keyword) ?? false) ||
                 (s.Doctor?.Department?.DepartmentName?.ToLower().Contains(keyword) ?? false) ||
                 (s.Room?.RoomName?.ToLower().Contains(keyword) ?? false)) &&
                (deptId == 0 || s.Doctor?.DepartmentId == deptId)
            ).ToList();

            _currentPage = 1;
            DisplayPage(_currentPage);
        }

        public void DisplayPage(int pageNumber)
        {
            flpAppItem.SuspendLayout();
            flpAppItem.Controls.Clear();

            if (_filteredSlots == null || _filteredSlots.Count == 0)
            {
                lblPageStatus.Text = "Không tìm thấy kết quả.";
                flpAppItem.ResumeLayout();
                return;
            }

            int startIndex = (pageNumber - 1) * _pageSize;
            var pageItems = _filteredSlots.Skip(startIndex).Take(_pageSize).ToList();

            foreach (var slot in pageItems)
            {
                ucAppItem card = new ucAppItem();
                card.SetupCard(slot, ucAppItem.AppCardMode.AdminView);
                card.Width = flpAppItem.ClientSize.Width - 20;
                card.Height = 252;
                card.Margin = new Padding(-10, 10, 10, 10);
                
                card.RefreshData = () => InitData();
                
                flpAppItem.Controls.Add(card);
            }

            int totalPages = (int)Math.Ceiling((double)_filteredSlots.Count / _pageSize);
            lblPageStatus.Text = $"Trang {_currentPage} / {totalPages} (Tổng cộng: {_filteredSlots.Count})";
            flpAppItem.ResumeLayout();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void cbDept_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void lblPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayPage(_currentPage);
            }
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_filteredSlots.Count / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            var dialog = new ucTimeSlotDialog();
            ShowOverlay(dialog);
        }

        private void ShowOverlay(UserControl uc)
        {
            // Thêm trực tiếp form vào control thay vì dùng Panel nền xám
            uc.Location = new Point((this.Width - uc.Width) / 2, (this.Height - uc.Height) / 2);
            
            if (uc is ucTimeSlotDialog dialog)
            {
                dialog.OnCloseModal += (s, e) => {
                    this.Controls.Remove(dialog);
                    dialog.Dispose();
                    InitData();
                };
            }

            this.Controls.Add(uc);
            uc.BringToFront();
        }

        private void pnlSearchArea_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 10, Color.FromArgb(226, 232, 240), 1);
        }

        private void pnlTableHead_Paint(object sender, PaintEventArgs e)
        {
            // Bottom border for header
            using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 2))
            {
                e.Graphics.DrawLine(pen, 0, pnlTableHead.Height - 1, pnlTableHead.Width, pnlTableHead.Height - 1);
            }
        }
    }
}
