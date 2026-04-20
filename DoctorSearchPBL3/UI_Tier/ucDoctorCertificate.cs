using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucDoctorCertificate : UserControl
    {
        // 1. Khai báo cái loa (Event)
        public event EventHandler OnRemoveRequested;

        public ucDoctorCertificate()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this); // Kích hoạt Double Buffering để giảm nhấp nháy
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 2. Khi bấm nút Cancel, "hét" lên cho cha nghe
            OnRemoveRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ucDoctorCertificate_Load(object sender, EventArgs e)
        {
            this.Paint += (sender, e) => UIHelper.uc_Paint(sender, e, 10, Color.FromArgb(200, 200, 200), 2);
        }
    }
}
