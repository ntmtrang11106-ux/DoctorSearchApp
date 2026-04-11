using Bus_Tier;
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
    public partial class frmLogin : Form
    {

        // === BƯỚC 1: KHAI BÁO BIẾN Ở ĐÂY ĐỂ HẾT LỖI ===
        private LoginBUS _loginBUS = new LoginBUS();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Nếu đang che mật khẩu (dấu chấm)
            if (txtPassword.UseSystemPasswordChar)
            {
                // 1. Hiện mật khẩu
                txtPassword.UseSystemPasswordChar = false;

                // 2. Đổi sang hình con mắt đóng
                picShowPass.Image = Properties.Resources.hide;
                // (Lưu ý: Thay bằng cách gọi Resource của mày, ví dụ: myImages.eye_close)
            }
            else
            {
                // 1. Che mật khẩu lại
                txtPassword.UseSystemPasswordChar = true;

                // 2. Đổi về hình con mắt mở
                picShowPass.Image = Properties.Resources.visible;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo Form Login
            frmRegister registerForm = new frmRegister();

            // 2. Ẩn Form hiện tại (frmGuest)
            this.Hide();

            // 3. Hiển thị Form Login
            registerForm.ShowDialog();
            // Dùng ShowDialog để nó chặn không cho tương tác với Form cũ 
            // hoặc dùng loginForm.Show() nếu muốn mở tự do.

            // 4. (Tùy chọn) Sau khi đóng Login thì hiện lại Guest
            this.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string phone = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // 1. Gọi hàm Login. 
            // Giả sử hàm này bây giờ trả về Role (Patient/Doctor/Admin) nếu đúng, 
            // hoặc trả về thông báo lỗi nếu sai.
            string result = _loginBUS.Login(phone, pass);

            if (result == "Patient")
            {              
                this.Hide();
                frmPatient f = new frmPatient();
                f.ShowDialog();
                this.Close();
            }
            else if (result == "Doctor")
            {
                MessageBox.Show("Tài khoản Bác sĩ: Hiện tại chưa có Form giao diện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == "Admin")
            {
                MessageBox.Show("Tài khoản Admin: Hiện tại chưa có Form giao diện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
