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
        private readonly ucDoctor_Appointment _appointmentControl = new ucDoctor_Appointment();
        private readonly ucSearchWorkspace _searchControl = new ucSearchWorkspace();

        public frmDoctor()
        {
            InitializeComponent();

            UIHelper.ApplyRoundedRegion(btnLogout, 15);
            UIHelper.ApplyRoundedRegion(btnAppointments, 15);
            UIHelper.ApplyRoundedRegion(btnSearch, 15);
            ShowUserControl(_appointmentControl);

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

        private void frmDoctor_Load(object sender, EventArgs e)
        {

        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            ShowUserControl(_appointmentControl);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowUserControl(_searchControl);
        }

        // Hàm này dùng để hiển thị hộp thoại (UserControl) dưới dạng Overlay (nền mờ phía sau)
        public void ShowOverlay(UserControl ucDialog)
        {
            // Vô hiệu hóa các control phía sau (nếu cần)
            foreach (Control ctrl in pnMain.Controls) { ctrl.Enabled=false; }

            if (ucDialog is ucTimeSlotDialog dialog)
            {
                dialog.OnCloseModal += CloseModalLogic;
            }

            ucDialog.Name = "ucDialog";
            // Căn giữa hộp thoại
            ucDialog.Location = new Point(
                (this.ClientSize.Width - ucDialog.Width) / 2,
                (this.ClientSize.Height - ucDialog.Height) / 2
            );
            // Nếu muốn khi resize form hộp thoại vẫn ở giữa
            ucDialog.Anchor = AnchorStyles.None;

            // 3. Add vào Form
            this.Controls.Add(ucDialog);
            ucDialog.BringToFront(); // Đưa lên lớp trên cùng
        }
        private void CloseModalLogic(object sender, EventArgs e)
        {
            UserControl uc = sender as UserControl;
            if (uc != null)
            {
                // Gỡ sự kiện để tránh rò rỉ bộ nhớ (Memory Leak)
                if (uc is ucTimeSlotDialog ucApp) ucApp.OnCloseModal -= CloseModalLogic;

                // Xóa UC khỏi Form
                this.Controls.Remove(uc);
                uc.Dispose(); // Hủy hẳn để giải phóng RAM

                // Kích hoạt lại các control phía sau
                foreach (Control ctrl in pnMain.Controls) { ctrl.Enabled = true; }
            }
        }
    }
}
