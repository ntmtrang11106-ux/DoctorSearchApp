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
            SetupUI();
            SetActivePanel(true); // Mặc định chọn Bệnh nhân khi mở form
        }

        private void SetupUI()
        {
            // 1. Thay đổi màu viền chính và làm mỏng lại (độ dày 3)
            panel2.BackColor = Color.Black;
            panel3.Location = new Point(3, 3);
            panel3.Size = new Size(panel2.Width - 6, panel2.Height - 6);
            UIHelper.ApplyRoundedRegion(panel2, 30);
            UIHelper.ApplyRoundedRegion(panel3, 30);
                   // 2. Xử lý cho ô Nơi ở thường trú
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Font = new Font("Segoe UI", 12F);

            // Designer lại toàn bộ ô nhập liệu theo "Mẫu Chuyên khoa" (Cao 70, Viền đen 2px, Bo góc 8)
            var inputPairs = new[] { 
                (txtUsername, panel5), (txtPhoneNumber, panel6), 
                (txtCCCD, panel11), (txtAddress, panel22),
                (textBox4, panel9), (textBox5, panel10),
                (textBox7, panel28), (textBox3, panel24)
            };

            foreach (var pair in inputPairs)
            {
                Panel pnl = pair.Item2;
                TextBox txt = pair.Item1;

                pnl.Height = 70;
                pnl.BackColor = Color.White;
                UIHelper.ApplyRoundedRegion(pnl, 8);
                pnl.BorderStyle = BorderStyle.None;
                pnl.Paint += (s, ev) => UIHelper.uc_Paint(s, ev, 8, Color.Black, 2);

                txt.BorderStyle = BorderStyle.None;
                txt.Dock = DockStyle.None; // Không dùng Dock để kiểm soát vị trí chính xác
                txt.Location = new Point(15, 15);
                txt.Width = pnl.Width - 30;
                txt.Font = new Font("Segoe UI", 12F);
                
                // Vẫn giữ hiệu ứng đổi màu nền khi focus cho xịn
                txt.Enter += (s, e) => { pnl.BackColor = Color.FromArgb(243, 248, 255); txt.BackColor = Color.FromArgb(243, 248, 255); };
                txt.Leave += (s, e) => { pnl.BackColor = Color.White; txt.BackColor = Color.White; };
            }

            // Ô Ngày sinh (Theo chuẩn Cao 70)
            Panel pnlDOBContainer = panel19.Controls.Find("pnlDOBContainer", true).Length > 0 ? 
                (Panel)panel19.Controls.Find("pnlDOBContainer", true)[0] : new Panel();
            
            if (pnlDOBContainer.Parent == null) {
                pnlDOBContainer.Name = "pnlDOBContainer";
                pnlDOBContainer.Size = new Size(panel19.Width - 70, 70);
                pnlDOBContainer.Location = new Point(37, 65);
                pnlDOBContainer.BackColor = Color.White;
                panel19.Controls.Add(pnlDOBContainer);
                pnlDOBContainer.Controls.Add(dtpDOB);
            }
            pnlDOBContainer.Height = 70;
            UIHelper.ApplyRoundedRegion(pnlDOBContainer, 8);
            pnlDOBContainer.Paint += (s, ev) => UIHelper.uc_Paint(s, ev, 8, Color.Black, 2);

            dtpDOB.Dock = DockStyle.None;
            dtpDOB.Location = new Point(15, 15);
            dtpDOB.Width = pnlDOBContainer.Width - 30;
            dtpDOB.Font = new Font("Segoe UI", 12F);

            // Hiệu ứng Hover chuẩn
            UIHelper.SetupHoverEffect(label7, Color.FromArgb(0, 80, 200), Color.Blue, 2);

            UIHelper.RegisterClickToUnfocus(this, label1);
            UIHelper.ApplyRoundedRegion(btnLogin, 15);
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
        #endregion

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
                Residential_Address = txtAddress.Text.Trim(),
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
                var firstCertUC = flpCertificate.Controls.OfType<ucDoctorCertificate>().FirstOrDefault();

                if (firstCertUC == null)
                {
                    result = "Vui lòng thêm thông tin chứng chỉ và chuyên khoa.";
                }
                else
                {
                    string position = textBox3.Text.Trim();
                    int deptId = firstCertUC.GetSelectedDepartmentId();
                    string licenseNumber = firstCertUC.GetCertificateCode(); 
                    int maxExp = firstCertUC.GetExperienceYears();  

                    try
                    {
                        int newDoctorId = 0;
                        result = _userBUS.RegisterDoctor(newUser, confirmPass, deptId, maxExp, position, licenseNumber, out newDoctorId);
                        
                        if (result == "Success" && newDoctorId > 0)
                        {
                            // Sau khi đăng ký thành công, duyệt qua các UC để upload file
                            var doctorBUS = new BUS_Tier.DoctorBUS();
                            var allCerts = flpCertificate.Controls.OfType<ucDoctorCertificate>().ToList();
                            System.Collections.Generic.List<string> uploadErrors = new System.Collections.Generic.List<string>();
                            
                            foreach (var certUC in allCerts)
                            {
                                if (certUC.Tag != null) // Tag chứa đường dẫn file gốc
                                {
                                    string localFile = certUC.Tag.ToString();
                                    if (System.IO.File.Exists(localFile))
                                    {
                                        string uploadRes = doctorBUS.UploadCertificate(newDoctorId, localFile);
                                        if (uploadRes != "Tải lên thành công!")
                                        {
                                            uploadErrors.Add(uploadRes);
                                        }
                                    }
                                }
                            }

                            if (uploadErrors.Count > 0)
                            {
                                MessageBox.Show("Đăng ký hoàn tất nhưng có lỗi khi tải lên chứng chỉ:\n" + string.Join("\n", uploadErrors), 
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        result = "Lỗi hệ thống: " + ex.Message;
                    }
                }
            }

            // 4. Thông báo kết quả
            if (result == "Success")
            {
                MessageBox.Show($"Đăng ký {currentRole} thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (!string.IsNullOrEmpty(result))
            {
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
