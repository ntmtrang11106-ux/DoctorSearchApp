using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucAppointment : UserControl
    {
        public ucAppointment()
        {
            InitializeComponent();

            UIHelper.ApplyRoundedRegion(btnAddTimeSlot, 10);
        }
    }
}
