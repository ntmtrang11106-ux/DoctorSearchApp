using BUS_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
                panel14.Hide();
                panel22.Hide();
                panel25.Hide();
                panel26.Hide();
                panel15.Hide();

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
                panel14.Show();
                panel22.Show();
                panel25.Show();
                panel26.Show();
                panel15.Show();
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

        #region
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra vai trò
            if (string.IsNullOrEmpty(currentRole))
            {
                MessageBox.Show("Vui lòng chọn vai trò là Bệnh nhân hoặc Bác sĩ!");
                return;
            }

            // 2. Xử lý địa chỉ (Gộp Tỉnh/Thành phố và Xã/Phường)
            string province = cboProvince.Text.Trim(); 
            string ward = cboRegion.Text.Trim();         
            if (string.IsNullOrEmpty(province) || string.IsNullOrEmpty(ward))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ địa chỉ nơi ở!");
                return;
            }
            string fullAddress = $"{ward}, {province}";

            // 3. Đóng gói thông tin chung vào UserDTO
            UserDTO newUser = new UserDTO
            {
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                FullName = txtUsername.Text.Trim(),
                Password = textBox4.Text.Trim(),
                Dob = dtpDOB.Value,
                Gender = radioButton1.Checked ? "Nam" : "Nữ",
                Role = currentRole,
                CCCD = txtCCCD.Text.Trim(),
                Residential_Address = fullAddress, // Sử dụng địa chỉ đã gộp
                Picture = "default.jpg",
                Status = currentRole == "Doctor" ? "Pending" : "Active"
            };

            // Kiểm tra mật khẩu xác nhận nhanh
            string confirm = textBox5.Text.Trim();
            if (newUser.Password != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi");
                return;
            }

            string result = "";

            // 4. Xử lý logic theo Role
            if (currentRole == "Patient")
            {
                // Lấy mã BHYT
                string bhyt = textBox7.Text.Trim();
                result = _loginBUS.RegisterPatient(newUser, bhyt);
            }
            else if (currentRole == "Doctor")
            {
                //// 4.1. Lấy danh sách ID chuyên khoa (Nhiều chuyên khoa)
                //List<int> specialtyIds = new List<int>();
                //// Nếu dùng ComboBox thường chỉ chọn 1, nếu dùng CheckedListBox thì lặp như sau:
                //foreach (var item in clbSpecialties.CheckedItems)
                //{
                //    if (item is SpecialtyDTO spec) specialtyIds.Add(spec.Id);
                //}

                //// 4.2. Lấy thông tin chứng chỉ và nơi công tác
                //string clinicName = txtClinicName.Text.Trim(); // Nơi công tác hiện tại
                //string certImages = txtCertCode.Text.Trim();   // Mã số/Ảnh chứng chỉ
                //string clinicAddr = fullAddress; // Có thể dùng địa chỉ riêng của phòng khám nếu có ô nhập

                //result = _loginBUS.RegisterDoctor(newUser, certImages, clinicAddr, clinicName, specialtyIds);
            }

            // 5. Thông báo kết quả
            if (result == "Success")
            {
                MessageBox.Show($"Đăng ký tài khoản {currentRole} thành công!", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void panel29_MouseClick(object sender, MouseEventArgs e)
        {
            ofdCCHN.ShowDialog();
        }
    }
}
