using BUS_Tier;
using DAL_Tier;
using DTO_Tier;
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
    public partial class frmRegister : Form
    {
        // 1. Khai báo tầng BUS để xử lý nghiệp vụ
        private UserBUS _userBUS = new UserBUS();

        //private LocationBUS _locationBUS = new LocationBUS(); // Bổ sung LocationBUS mới tách
        // Biến này cực kỳ quan trọng để phân biệt 2 luồng
        private string currentRole = "";

        public frmRegister()
        {
            InitializeComponent();
            SetActivePanel(true); // Mặc định chọn Bệnh nhân khi mở form
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Xử lý chọn Vai trò (Role)
        private void SetActivePanel(bool isPatientSelected)
        {
            this.SuspendLayout();
            if (isPatientSelected)
            {
                currentRole = "Patient";
                // Panel Bệnh nhân được chọn: Chữ đen, Nền trắng
                panel7.BackColor = Color.White;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;

                // Panel Bác sĩ: Chữ trắng, Nền xanh (Highlight)
                panel8.BackColor = Color.FromArgb(24, 112, 255); // Hoặc màu xanh bạn thích
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;

                // Ẩn các thông tin chỉ dành cho bác sĩ nếu có (ví dụ: Chuyên khoa, Số năm kinh nghiệm...)
                panel15.Hide();
                panel14.Hide();
                flpCertificate.Hide();

                // Hiển thị các thông tin chỉ dành cho bệnh nhân nếu có (ví dụ: BHYT...)
                panel27.Show();
            }
            else
            {
                currentRole = "Doctor";
                // Ngược lại: Bác sĩ được chọn
                panel8.BackColor = Color.White;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;

                panel7.BackColor = Color.FromArgb(24, 112, 255);
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;

                // Ẩn các thông tin chỉ dành cho bệnh nhân nếu có (ví dụ: BHYT...)
                panel27.Hide();

                // Hiển thị các thông tin chỉ dành cho bác sĩ nếu có (ví dụ: Chuyên khoa, Số năm kinh nghiệm...)
                panel15.Show();
                panel14.Show();
                flpCertificate.Show();
            }
            this.ResumeLayout();
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            SetActivePanel(true);
            // Có thể thêm lệnh để update role
        }

        private void panel8_MouseClick(object sender, MouseEventArgs e)
        {
            SetActivePanel(false);
            // Có thể thêm lệnh để update role
        }

        // MẸO: Bạn hãy gán sự kiện Click của label2, label3, label4, label5 
        // vào các hàm panel_MouseClick tương ứng để bấm vào chữ cũng đổi được luồng.
        #endregion

        //#region Xử lý Location (Tỉnh/Thành - Quận/Huyện)
        //// Sự kiện Load Form

        //// Khi chọn Tỉnh/Thành -> Lọc Quận/Huyện tương ứng
        //private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboProvince.SelectedItem != null)
        //    {
        //        string provinceName = cboProvince.SelectedItem.ToString();

        //        // Lấy danh sách Quận/Huyện theo Tỉnh lấy ở tầng BUS (đã tách riêng)
        //        //var districts = _locationBUS.GetDistricts(provinceName);

        //        //cboRegion.DataSource = districts;
        //        cboRegion.DisplayMember = "LocationName"; // Tên hiển thị (Cẩm Lệ, Hải Châu...)
        //        cboRegion.ValueMember = "Id";             // Giá trị lấy ra (ID)
        //    }
        //}
        //#endregion

        #region Đăng ký

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhanh vai trò
            if (string.IsNullOrEmpty(currentRole))
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Thu thập dữ liệu cơ bản vào DTO
            UserDTO newUser = new UserDTO
            {
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                FullName = txtUsername.Text.Trim(),
                Password = textBox4.Text.Trim(),
                Dob = dtpDOB.Value,
                //Gender = radioButton1.Checked ? "Nam" : "Nữ",
                // Sửa logic giới tính ở đây:
                Gender = radioButton1.Checked ? "Nam" : (radioButton2.Checked ? "Nữ" : null),

                CCCD = (txtCCCD.Text == "Chưa đủ tuổi") ? null : txtCCCD.Text.Trim(),
                Residential_Address = $"{cboRegion.Text}, {cboProvince.Text}",
                Picture = "default.jpg"
            };

            string confirmPass = textBox5.Text.Trim();
            string result = "";

            // 3. Phân luồng xử lý theo vai trò
            if (currentRole == "Patient")
            {
                // Lấy mã BHYT từ giao diện
                string bhyt = textBox7.Text.Trim();
                result = _userBUS.RegisterPatient(newUser, confirmPass, bhyt);
            }
            else if (currentRole == "Doctor")
            {
                // 1. Lấy UserControl chứng chỉ (Dùng để lấy chuyên khoa, số giấy phép, kinh nghiệm)
                var firstCertUC = flpCertificate.Controls.OfType<ucDoctorCertificate>().FirstOrDefault();

                if (firstCertUC == null)
                {
                    // Nếu không có UC nào, gán lỗi vào result để hiện ở bước 4 thay vì return im lặng
                    result = "Vui lòng thêm thông tin chứng chỉ và chuyên khoa.";
                }
                else
                {
                    // 2. Thu thập dữ liệu từ các Control
                    string position = textBox3.Text.Trim();
                    int deptId = firstCertUC.GetSelectedDepartmentId();
                    string licenseNumber = firstCertUC.GetCertificateCode(); // Lấy từ UC
                    int maxExp = firstCertUC.GetExperienceYears();  

                    // 3. Gọi tầng BUS xử lý (Tầng BUS sẽ lo việc check trống, check CCCD, check tuổi...)
                    try
                    {
                        // Truyền đủ 6 tham số như bạn đã định nghĩa ở tầng BUS
                        result = _userBUS.RegisterDoctor(newUser, confirmPass, deptId, maxExp, position, licenseNumber);
                    }
                    catch (Exception ex)
                    {
                        // Trường hợp lỗi kết nối DB hoặc lỗi code nghiêm trọng
                        result = "Lỗi hệ thống: " + ex.Message;
                    }
                }
            }

            // 4. Thông báo kết quả (Đoạn này cực kỳ quan trọng để không bị "đứng im")
            if (result == "Success")
            {
                MessageBox.Show($"Đăng ký {currentRole} thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (!string.IsNullOrEmpty(result))
            {
                // Chỉ hiện thông báo lỗi nếu result có nội dung (tránh hiện thông báo trống)
                MessageBox.Show(result, "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


            #region Quản lý User Control chứng chỉ
            int certCount = 0; // Biến đếm số chứng chỉ đã thêm

        // Hàm cập nhật lại số thứ tự hiển thị (1, 2, 3...)
        private void UpdateCertIndexes()
        {
            // Lấy danh sách các UC hiện có và ép kiểu
            var certList = flpCertificate.Controls.OfType<ucDoctorCertificate>().ToList();

            // Dùng vòng lặp for để gán lại số thứ tự dựa trên vị trí trong danh sách
            for (int i = 0; i < certList.Count; i++)
            {
                certList[i].lblCertIndex.Text = $"Chứng chỉ #{i + 1}";
            }

            // Cập nhật lại biến đếm để lần sau thêm mới sẽ là (tổng số + 1)
            certCount = certList.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ucDoctorCertificate newUC = new ucDoctorCertificate();
            newUC.OnRemoveRequested += Uc_OnRemoveRequested;

            flpCertificate.Controls.Add(newUC);

            // Cập nhật số thứ tự ngay sau khi thêm
            UpdateCertIndexes();
        }

        // 3. Hàm xử lý khi thằng con "đòi cook"
        private void Uc_OnRemoveRequested(object sender, EventArgs e)
        {
            // Xác định thằng con nào vừa hét (sender chính là cái UC đó)
            ucDoctorCertificate ucToCook = sender as ucDoctorCertificate;

            if (ucToCook != null)
            {
                // Xóa nó khỏi giao diện
                flpCertificate.Controls.Remove(ucToCook);

                // CỰC KỲ QUAN TRỌNG: Giải phóng bộ nhớ (Dispose)
                ucToCook.Dispose();

                // Cập nhật lại số thứ tự sau khi xóa để các chứng chỉ sau đôn lên đúng số
                UpdateCertIndexes();
            }
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

            // 2. Thêm 1 chứng chỉ mặc định cho bác sĩ
            btnNew_Click(null, null);
        }
        #endregion

        //private void cboProvince_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    // Kiểm tra nếu người dùng thực sự chọn một mục (tránh lỗi khi form mới load)
        //    if (cboProvince.SelectedIndex != -1 && cboProvince.SelectedItem != null)
        //    {
        //        // Lấy tên tỉnh đang chọn
        //        string selectedProvince = cboProvince.SelectedItem.ToString();

        //        // 1. Gọi BUS để lấy danh sách Quận/Huyện từ Database
        //        var districts = _locationBUS.GetDistricts(selectedProvince);

        //        // 2. Xóa các ràng buộc cũ của cboRegion (Xã/Phường) để làm sạch dữ liệu
        //        cboRegion.DataSource = null;
        //        cboRegion.Items.Clear();

        //        // 3. Nạp dữ liệu mới
        //        if (districts != null && districts.Count > 0)
        //        {
        //            cboRegion.DataSource = districts;
        //            cboRegion.DisplayMember = "LocationName"; // Tên hiển thị trên ComboBox
        //            cboRegion.ValueMember = "Id";             // ID thực tế để lưu xuống bảng Doctor

        //            cboRegion.SelectedIndex = -1; // Để trống, bắt người dùng phải tự chọn
        //        }
        //    }
        //}

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            //int age = CalculateAge(dtpDOB.Value);
            int age = _userBUS.CalculateAge(dtpDOB.Value);

            if (age < 16)
            {
                // Khóa ô nhập CCCD và xóa nội dung cũ
                txtCCCD.Text = "Chưa đủ tuổi";
                txtCCCD.Enabled = false; // Làm mờ ô nhập
                txtCCCD.BackColor = Color.LightGray; // Đổi màu để người dùng biết là bị khóa
            }
            else
            {
                // Mở khóa nếu từ 16 tuổi trở lên
                if (txtCCCD.Text == "Chưa đủ tuổi") txtCCCD.Text = "";
                txtCCCD.Enabled = true;
                txtCCCD.BackColor = Color.White;
            }
        }
    }
}
