using BUS_Tier;
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
        private UserBUS _userBUS = new UserBUS();

        // === QUAN TRỌNG: THÊM DÒNG NÀY ĐỂ LƯU ID TOÀN CỤC ===
        public static int LoggedInUserId;

        public frmLogin()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // Bo góc cho các Panel và Nút
            UIHelper.ApplyRoundedRegion(panel2, 30);
            UIHelper.ApplyRoundedRegion(panel3, 30);
            UIHelper.ApplyRoundedRegion(panel4, 10);
            UIHelper.ApplyRoundedRegion(panel5, 10);
            panel4.BorderStyle = BorderStyle.None;
            panel5.BorderStyle = BorderStyle.None;
            UIHelper.ApplyRoundedRegion(btnLogin, 15);
            
            // Con trỏ bàn tay cho nút Đăng nhập
            btnLogin.Cursor = Cursors.Hand;

            // Vẽ viền đen đậm cho ô nhập liệu
            panel4.Paint += (s, e) => UIHelper.uc_Paint(s, e, 10, Color.Black, 2);
            panel5.Paint += (s, e) => UIHelper.uc_Paint(s, e, 10, Color.Black, 2);
            
            // Hiệu ứng cho nút Con mắt (Ẩn/Hiện mật khẩu)
            picShowPass.Cursor = Cursors.Hand;
            picShowPass.MouseEnter += (s, e) => {
                picShowPass.Location = new Point(picShowPass.Location.X, picShowPass.Location.Y - 2);
            };
            picShowPass.MouseLeave += (s, e) => {
                picShowPass.Location = new Point(picShowPass.Location.X, picShowPass.Location.Y + 2);
            };

            // Thiết lập cho link Đăng ký
            label5.Cursor = Cursors.Hand;
            label5.MouseEnter += (s, e) => {
                label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold | FontStyle.Underline);
                label5.ForeColor = Color.FromArgb(0, 80, 200);
                label5.Location = new Point(label5.Location.X, label5.Location.Y - 2); // Nổi lên 2px
            };
            label5.MouseLeave += (s, e) => {
                label5.Font = new Font("Segoe UI", 10.125F, FontStyle.Underline);
                label5.ForeColor = Color.Blue;
                label5.Location = new Point(label5.Location.X, label5.Location.Y + 2); // Trở về vị trí cũ
            };
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

        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    // 1. Lấy thông tin từ TextBox (Nhân kiểm tra tên txtPhoneNumber cho đúng nhé)
        //    string phone = txtUsername.Text.Trim();
        //    string pass = txtPassword.Text.Trim();

        //    // 2. Khai báo các biến để hứng dữ liệu từ BUS trả về (out)
        //    int loggedInId;
        //    string message;

        //    // 3. Gọi hàm Login từ tầng BUS
        //    // Hàm này trả về Role (Doctor/Patient), và đẩy ID vào loggedInId, thông báo vào message
        //    string role = _userBUS.Login(phone, pass, out loggedInId, out message);

        //    // 4. Xử lý điều hướng dựa trên Role nhận được
        //    if (!string.IsNullOrEmpty(role))
        //    {

        //        // 2. CỰC KỲ QUAN TRỌNG: Lưu ID và Role vào kho lưu trữ chung (GlobalAccount)
        //        // Dòng này giúp xóa bỏ lỗi "ID bác sĩ không hợp lệ" khi tạo lịch
        //        UI_Tier.GlobalAccount.SetLoggedInAccount(loggedInId, role);


        //        // Đăng nhập thành công
        //        this.Hide();

        //        if (role == "Patient")
        //        {
        //            frmPatient f = new frmPatient();
        //            f.Tag = loggedInId; // QUAN TRỌNG: Lưu ID vào Tag để Form Patient biết ai đang dùng
        //            f.ShowDialog();
        //        }
        //        else if (role == "Doctor")
        //        {
        //            frmDoctor f = new frmDoctor();
        //            f.Tag = loggedInId; // Lưu ID bác sĩ vào Tag
        //            f.ShowDialog();
        //        }
        //        else if (role == "Admin")
        //        {
        //            MessageBox.Show("Chào Admin! Form quản trị đang được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            // Nếu có Form Admin thì mở ở đây
        //        }

        //        // Sau khi đóng Form chức năng thì đóng luôn Form Login
        //        this.Close();
        //    }
        //    else
        //    {
        //        // 5. Đăng nhập thất bại (Sai pass, số điện thoại, hoặc tài khoản bị khóa)
        //        // Hiển thị nội dung lỗi cụ thể mà tầng BUS đã trả về trong biến 'message'
        //        MessageBox.Show(message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        txtPassword.Clear();
        //        txtPassword.Focus();
        //    }
        //}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string phone = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            int userId, profileId;
            string fullName, message;

            // 1. Gọi BUS để kiểm tra tài khoản (User) và lấy toàn bộ thông tin định danh
            string role = _userBUS.Login(phone, pass, out userId, out profileId, out fullName, out message);

            if (!string.IsNullOrEmpty(role))
            {
                // 2. LƯU VÀO DTO: Cất vào GlobalAccount để dùng toàn app
                DTO_Tier.GlobalAccount.SetLoggedInAccount(userId, profileId, role, fullName);

                // 3. ĐÓNG LOGIN: Trả về OK để Guest biết và mở Form tiếp theo
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
