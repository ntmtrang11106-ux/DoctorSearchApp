using BUS_Tier;

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