//using BUS_Tier;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//namespace UI_Tier
//{
//    public partial class ucDoctorCertificate : UserControl
//    {
//        // 1. Khai báo cái loa (Event)
//        public event EventHandler OnRemoveRequested;

//        // 2. Khai báo đối tượng BUS để lấy dữ liệu chuyên khoa
//        private readonly DepartmentBUS _deptBUS = new DepartmentBUS();

//        public ucDoctorCertificate()
//        {
//            InitializeComponent();
//            UIHelper.SetDoubleBuffered(this); // Kích hoạt Double Buffering để giảm nhấp nháy
//            LoadYearData(); // Load dữ liệu năm vào comboBox4 ngay khi khởi tạo
//        }

//        #region Các hàm Public để Form chính (frmRegister) lấy dữ liệu

//        public int GetSelectedSpecialtyId()
//        {
//            // Lấy ID từ ValueMember của ComboBox
//            if (comboBox3.SelectedValue != null)
//            {
//                if (int.TryParse(comboBox3.SelectedValue.ToString(), out int id))
//                {
//                    return id;
//                }
//            }
//            return 0;
//        }

//        public string GetCertificateId()
//        {
//            return textBox6.Text.Trim();
//        }

//        public string GetCertificateImageName()
//        {
//            return label24.Text; // Trả về tên file đã chọn hoặc "default.jpg"
//        }
//        public int GetExperienceYears()
//        {
//            string val = comboBox4.Text;
//            if (int.TryParse(val, out int year))
//            {
//                return year;
//            }
//            return 0; // Hoặc trả về năm hiện tại tùy logic của bạn
//        }

//        #endregion

//        // Hàm đổ dữ liệu từ database vào ComboBox
//        //private void LoadSpecialties()
//        //{
//        //    try
//        //    {
//        //        DataTable dt = _specialtyBUS.GetDepartmentNameById(); // Gọi qua tầng BUS
//        //        if (dt != null)
//        //        {
//        //            comboBox3.DataSource = dt;
//        //            comboBox3.DisplayMember = "SpecialtyName"; // Tên hiển thị
//        //            comboBox3.ValueMember = "Id";             // Giá trị thực là ID
//        //            comboBox3.SelectedIndex = -1;             // Mặc định không chọn cái nào
//        //        }
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        MessageBox.Show("Lỗi khi tải chuyên khoa: " + ex.Message);
//        //    }
//        //}

//        private void LoadDepartments()
//        {
//            try
//            {
//                // Gọi BUS lấy List<DepartmentDTO> thay vì DataTable
//                var list = _deptBUS.GetDepartmentsForUI();

//                if (list != null && list.Count > 0)
//                {
//                    comboBox3.DataSource = list;
//                    comboBox3.DisplayMember = "DepartmentName"; // Tên cột hiển thị
//                    comboBox3.ValueMember = "Id";               // Giá trị ID
//                    comboBox3.SelectedIndex = -1;               // Mặc định chưa chọn
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi tải danh sách chuyên khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void LoadYearData()
//        {
//            comboBox4.Items.Clear();
//            for (int year = 2026; year >= 1990; year--)
//            {
//                comboBox4.Items.Add(year.ToString());
//            }
//            // Chọn mặc định năm hiện tại để tránh bị null
//            comboBox4.SelectedIndex = 0;
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            // 2. Khi bấm nút Cancel, "hét" lên cho cha nghe
//            OnRemoveRequested?.Invoke(this, EventArgs.Empty);
//        }

//        private void ucDoctorCertificate_Load(object sender, EventArgs e)
//        {
//            this.Paint += (sender, e) => UIHelper.uc_Paint(sender, e, 10, Color.FromArgb(200, 200, 200), 2);
//            // 3. Gọi hàm load dữ liệu chuyên khoa khi UC hiện lên
//            LoadDepartments();
//        }

//        private void label24_Click(object sender, EventArgs e)
//        {
//            // 1. Khởi tạo hộp thoại chọn file
//            using (OpenFileDialog ofd = new OpenFileDialog())
//            {
//                // 2. Lọc định dạng (chỉ cho phép chọn ảnh)
//                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
//                ofd.Title = "Chọn ảnh chứng chỉ hành nghề";

//                // 3. Hiển thị hộp thoại
//                if (ofd.ShowDialog() == DialogResult.OK)
//                {
//                    // Lấy đường dẫn đầy đủ của file đã chọn
//                    string filePath = ofd.FileName;

//                    // Lấy chỉ tên file để hiển thị lên UI (cho gọn)
//                    string fileName = System.IO.Path.GetFileName(filePath);

//                    // Hiển thị tên file lên TextBox (ví dụ textBox6 của bạn)
//                    label24.Text = fileName;

//                    // MẸO: Bạn nên lưu filePath vào một biến tag hoặc một biến private 
//                    // để lúc nhấn "Đăng ký" mình biết file đó nằm ở đâu mà Copy vào folder dự án.
//                    this.Tag = filePath;
//                }
//            }
//        }
//    }
//}


using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using BUS_Tier; // Cần dùng để load dữ liệu chuyên khoa

namespace UI_Tier
{
    public partial class ucDoctorCertificate : UserControl
    {
        // 1. Khai báo sự kiện để báo cho Form cha xóa UC này
        public event EventHandler OnRemoveRequested;

        // 2. Khai báo BUS để nạp dữ liệu chuyên khoa vào ComboBox bên trong UC
        private readonly DepartmentBUS _deptBUS = new DepartmentBUS();

        public ucDoctorCertificate()
        {
            InitializeComponent();
            LoadYearData();
        }

        private void ucDoctorCertificate_Load(object sender, EventArgs e)
        {
            // Vẽ bo góc hoặc border cho UC (dùng helper của bạn)
            this.Paint += (s, ev) => UIHelper.uc_Paint(s, ev, 10, Color.FromArgb(200, 200, 200), 2);

            // Nạp dữ liệu chuyên khoa vào ComboBox (đặt tên là comboBox3 theo code cũ của bạn)
            LoadDepartments();
        }

        #region HÀM LẤY DỮ LIỆU (PUBLIC ĐỂ FORM CHÍNH GỌI)

        // Lấy mã chứng chỉ
        public string GetCertificateCode() => textBox6.Text.Trim();

        // Lấy tên ảnh chứng chỉ
        public string GetCertificateImageName() => label24.Text;

        // QUAN TRỌNG: Lấy ID chuyên khoa từ ComboBox nằm TRONG UserControl
        public int GetSelectedDepartmentId()
        {
            if (comboBox3.SelectedValue != null && int.TryParse(comboBox3.SelectedValue.ToString(), out int id))
            {
                return id;
            }
            return 0;
        }

        // Lấy số năm kinh nghiệm dựa trên năm cấp bằng
        public int GetExperienceYears()
        {
            if (int.TryParse(comboBox4.Text, out int gradYear))
            {
                int exp = DateTime.Now.Year - gradYear;
                return exp < 0 ? 0 : exp;
            }
            return 0;
        }
        #endregion

        #region NẠP DỮ LIỆU (UI LOGIC)

        private void LoadDepartments()
        {
            try
            {
                var list = _deptBUS.GetDepartmentsForUI();
                if (list != null)
                {
                    comboBox3.DataSource = list;
                    comboBox3.DisplayMember = "DepartmentName";
                    comboBox3.ValueMember = "Id";
                    comboBox3.SelectedIndex = -1; // Để trống mặc định
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chuyên khoa: " + ex.Message);
            }
        }

        private void LoadYearData()
        {
            comboBox4.Items.Clear();
            // Cho phép chọn từ năm hiện tại lùi về 1980
            for (int year = DateTime.Now.Year; year >= 1980; year--)
            {
                comboBox4.Items.Add(year.ToString());
            }
            comboBox4.SelectedIndex = 0;
        }

        #endregion

        // Nút hủy/xóa chứng chỉ này
        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    OnRemoveRequested?.Invoke(this, EventArgs.Empty);
        //}

        // Chọn ảnh chứng chỉ
        private void label24_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Lưu đường dẫn gốc vào Tag để lúc lưu database thì Copy file đi
                    this.Tag = ofd.FileName;
                    label24.Text = Path.GetFileName(ofd.FileName);
                    label24.ForeColor = Color.Blue;
                }
            }
        }
    }
}