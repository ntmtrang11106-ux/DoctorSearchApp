using BUS_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI_Tier
{
    public partial class ucDoctorCertificate : UserControl
    {
        // 1. Khai báo cái loa (Event)
        public event EventHandler OnRemoveRequested;

        // 2. Khai báo đối tượng BUS để lấy dữ liệu chuyên khoa
        private SpecialtyBUS _specialtyBUS = new SpecialtyBUS();

        public ucDoctorCertificate()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this); // Kích hoạt Double Buffering để giảm nhấp nháy
        }

        #region Các hàm Public để Form chính (frmRegister) lấy dữ liệu

        public int GetSelectedSpecialtyId()
        {
            // Lấy ID từ ValueMember của ComboBox
            if (comboBox3.SelectedValue != null)
            {
                if (int.TryParse(comboBox3.SelectedValue.ToString(), out int id))
                {
                    return id;
                }
            }
            return 0;
        }

        public string GetCertificateId()
        {
            return textBox6.Text.Trim();
        }

        public string GetCertificateImageName()
        {
            return label24.Text; // Trả về tên file đã chọn hoặc "default.jpg"
        }

        public int GetExperienceYears()
        {
            // Kiểm tra nếu người dùng đã chọn năm ở comboBox4
            if (comboBox4.SelectedItem != null)
            {
                if (int.TryParse(comboBox4.SelectedItem.ToString(), out int issuedYear))
                {
                    int currentYear = DateTime.Now.Year;
                    int exp = currentYear - issuedYear;

                    // Nếu năm cấp là năm hiện tại thì trả về 0, nếu lớn hơn 0 thì trả về hiệu số
                    return exp > 0 ? exp : 0;
                }
            }
            return 0; // Mặc định nếu chưa chọn hoặc lỗi là 0 năm kinh nghiệm
        }

        #endregion

        // Hàm đổ dữ liệu từ database vào ComboBox
        private void LoadSpecialties()
        {
            try
            {
                DataTable dt = _specialtyBUS.GetListSpecialties(); // Gọi qua tầng BUS
                if (dt != null)
                {
                    comboBox3.DataSource = dt;
                    comboBox3.DisplayMember = "SpecialtyName"; // Tên hiển thị
                    comboBox3.ValueMember = "Id";             // Giá trị thực là ID
                    comboBox3.SelectedIndex = -1;             // Mặc định không chọn cái nào
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chuyên khoa: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 2. Khi bấm nút Cancel, "hét" lên cho cha nghe
            OnRemoveRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ucDoctorCertificate_Load(object sender, EventArgs e)
        {
            this.Paint += (sender, e) => UIHelper.uc_Paint(sender, e, 10, Color.FromArgb(200, 200, 200), 2);
            // 3. Gọi hàm load dữ liệu chuyên khoa khi UC hiện lên
            LoadSpecialties();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo hộp thoại chọn file
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // 2. Lọc định dạng (chỉ cho phép chọn ảnh)
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                ofd.Title = "Chọn ảnh chứng chỉ hành nghề";

                // 3. Hiển thị hộp thoại
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn đầy đủ của file đã chọn
                    string filePath = ofd.FileName;

                    // Lấy chỉ tên file để hiển thị lên UI (cho gọn)
                    string fileName = System.IO.Path.GetFileName(filePath);

                    // Hiển thị tên file lên TextBox (ví dụ textBox6 của bạn)
                    label24.Text = fileName;

                    // MẸO: Bạn nên lưu filePath vào một biến tag hoặc một biến private 
                    // để lúc nhấn "Đăng ký" mình biết file đó nằm ở đâu mà Copy vào folder dự án.
                    this.Tag = filePath;
                }
            }
        }
    }
}
