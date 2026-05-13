using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DTO_Tier;
using BUS_Tier;
using System.Linq;

namespace UI_Tier
{
    public partial class ucAdmin_DepartmentManagement : UserControl
    {
        private DepartmentBUS _deptBUS = new DepartmentBUS();
        private List<DepartmentDTO> _allDepts = new List<DepartmentDTO>();

        public ucAdmin_DepartmentManagement()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(flpList);
            InitData();
        }

        public void InitData()
        {
            _allDepts = _deptBUS.GetAllDepartments();
            PopulateList(_allDepts);
        }

        private void PopulateList(List<DepartmentDTO> list)
        {
            flpList.Controls.Clear();
            foreach (var dept in list)
            {
                ucAdmin_DepartmentItem item = new ucAdmin_DepartmentItem();
                item.SetData(dept);
                item.DataChanged += (s, ev) => InitData();
                item.Width = flpList.Width - 40;
                flpList.Controls.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form f = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White,
                Size = new Size(800, 700),
                ControlBox = false
            };

            ucAdmin_AddDepartment uc = new ucAdmin_AddDepartment();
            uc.Dock = DockStyle.Fill;
            uc.SetData(null);
            uc.OnCancel += (s, ev) => f.Close();
            uc.OnSuccess += (s, ev) => {
                f.Close();
                InitData();
            };

            f.Controls.Add(uc);
            UIHelper.ApplyRoundedRegion(f, 15);
            f.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower().Trim();
            var filtered = _allDepts.Where(d => 
                d.DepartmentName.ToLower().Contains(keyword) || 
                (d.Description != null && d.Description.ToLower().Contains(keyword))
            ).ToList();
            PopulateList(filtered);
        }
    }
}
