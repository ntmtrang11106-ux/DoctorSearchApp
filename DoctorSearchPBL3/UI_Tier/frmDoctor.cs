using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class frmDoctor : Form
    {
        public frmDoctor()
        {
            InitializeComponent();

            UIHelper.ApplyRoundedRegion(btnLogout, 15);

            // Add main card in panel
            pnMain.Controls.Clear();
            ucAppointment AppointmentControl = new ucAppointment();
            AppointmentControl.Dock = DockStyle.Fill; // Đảm bảo UserControl chiếm toàn bộ pnMain
            pnMain.Controls.Add(AppointmentControl);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
