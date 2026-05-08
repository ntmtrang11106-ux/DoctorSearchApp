using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class frmGuest : Form
    {
        private ucGuest_IntegratedSearch _searchControl;

        public frmGuest()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.ApplyRoundedRegion(btnLogin, 15);
            
            _searchControl = new ucGuest_IntegratedSearch();
            _searchControl.Dock = DockStyle.Fill;
            pnlMainContainer.Controls.Add(_searchControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            this.Hide();
            loginForm.ShowDialog();
            this.Show();
        }

        private void frmGuest_Load(object sender, EventArgs e)
        {
            _searchControl.ExecuteSearch();
        }
    }
}
