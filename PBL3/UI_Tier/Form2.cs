using BUS_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class Form2 : Form
    {
        DoctorBUS bus = new DoctorBUS();

        public Form2()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvDoctors.DataSource = bus.GetListDoctors();
        }
    }
}
