using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class frmPatient : Form
    {
        public frmPatient()
        {
            InitializeComponent();

            // Add main card in panel
            pnMain.Controls.Clear();
            ucPatient_SearchDoc searchDocControl = new ucPatient_SearchDoc();
            searchDocControl.Dock = DockStyle.Fill; // Đảm bảo UserControl chiếm toàn bộ pnMain
            pnMain.Controls.Add(searchDocControl);
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
    }
}
