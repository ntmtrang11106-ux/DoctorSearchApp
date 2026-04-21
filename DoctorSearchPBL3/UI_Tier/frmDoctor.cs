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
            ucDoctor_Appointment AppointmentControl = new ucDoctor_Appointment();
            AppointmentControl.Dock = DockStyle.Fill; // Đảm bảo UserControl chiếm toàn bộ pnMain
            pnMain.Controls.Add(AppointmentControl);

        }

        // Override CreateParams để bật WS_EX_COMPOSITED, giúp giảm nhấp nháy khi vẽ lại Form
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        /// <summary>
        /// Hàm dùng chung để thay đổi nội dung hiển thị trong panel chính (pnMain).
        /// Việc dùng hàm này giúp giải phóng bộ nhớ (Dispose) các Control cũ, tránh giật lag.
        /// </summary>
        private void ShowUserControl(UserControl uc)
        {
            // Giải phóng các control cũ để tối ưu RAM
            foreach (Control ctrl in pnMain.Controls)
            {
                ctrl.Dispose();
            }

            pnMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
