using BUS_Tier;
using DAL_Tier;
using DTO_Tier;
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
        private LoginBUS _loginBUS = new LoginBUS();
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

        #region Đăng ký
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra vai trò
            if (string.IsNullOrEmpty(currentRole))
            {
                MessageBox.Show("Vui lòng chọn vai trò!");
                return;
            }

            // 2. Xử lý gộp địa chỉ "Xã, Tỉnh"
            string province = cboProvince.Text.Trim();
            string ward = cboRegion.Text.Trim();
            string fullAddress = $"{ward}, {province}";

            // Lấy LocationId(ID Tỉnh / Thành) - Trả về null nếu chưa chọn
            int? locationId = cboProvince.SelectedValue as int?;

            // Lấy Password và Confirm Password
            string password = textBox4.Text.Trim();
            string confirmPass = textBox5.Text.Trim();

            // 3. Đóng gói dữ liệu vào DTO (Chỉ mang tính chất vận chuyển dữ liệu)
            UserDTO newUser = new UserDTO
            {
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                FullName = txtUsername.Text.Trim(),
                Password = password,
                Dob = dtpDOB.Value,
                Gender = radioButton1.Checked ? "Nam" : "Nữ",
                Role = currentRole,
                CCCD = txtCCCD.Text.Trim(),
                Residential_Address = fullAddress,
                Picture = "default.jpg",
                Status = currentRole == "Doctor" ? "Pending" : "Active"
            };

            string result = "";

            // 4. Gọi hàm BUS tương ứng theo vai trò
            if (currentRole == "Patient")
            {
                string bhyt = textBox7.Text.Trim(); // Mã số BHYT
                result = _loginBUS.RegisterPatient(newUser, confirmPass, bhyt);
            }
            else if (currentRole == "Doctor")
            {
                // Thu thập thông tin từ các UserControl (UC) chứng chỉ
                List<int> specialtyIds = new List<int>();
                List<string> certCodes = new List<string>();

                foreach (Control ctrl in flpCertificate.Controls)
                {
                    if (ctrl is ucDoctorCertificate uc)
                    {
                        // Lấy ID chuyên khoa (để đổ vào bảng trung gian ở DAL)
                        int specId = uc.GetSelectedSpecialtyId();
                        if (specId > 0 && !specialtyIds.Contains(specId))
                            specialtyIds.Add(specId);

                        // Lấy mã chứng chỉ
                        string cCode = uc.GetCertificateId();
                        if (!string.IsNullOrWhiteSpace(cCode))
                            certCodes.Add(cCode);
                    }
                }


                string clinicName = textBox3.Text.Trim();

                // Gộp các mã chứng chỉ thành chuỗi (ví dụ: "CCHN01, CCHN02")
                string allCertificates = string.Join(", ", certCodes);

                // Gọi BUS: BUS sẽ kiểm tra ClinicName trống, specialtyIds trống, v.v.
                result = _loginBUS.RegisterDoctor(newUser, confirmPass, allCertificates, fullAddress, clinicName, locationId, specialtyIds);
            }

            // 5. Kết quả
            if (result == "Success")
            {
                MessageBox.Show($"Đăng ký {currentRole} thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

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
            btnNew_Click(null, null); // Tự động thêm 1 UC chứng chỉ khi mở form (tùy chọn)
        }
        
    }
}
