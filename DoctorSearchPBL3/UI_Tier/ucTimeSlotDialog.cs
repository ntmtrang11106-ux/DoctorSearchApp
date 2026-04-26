using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucTimeSlotDialog : UserControl
    {
        public ucTimeSlotDialog()
        {
            InitializeComponent();
        }

        private Color _activeBack = Color.FromArgb(206, 225, 255); // Màu xanh nhạt
        private Color _normalBack = Color.Transparent;
        private Color _activeText = Color.FromArgb(0, 98, 255); // Màu xanh đậm
        private Color _normalText = SystemColors.ControlDarkDark;

        public event EventHandler OnCloseModal;
        private void InitDayPicker()
        {
            // Dùng list để dễ quản lý hoặc lấy từ DB
            string[] days = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            flpDay.Controls.Clear();
            foreach (var day in days)
            {
                CheckBox chk = new CheckBox();
                chk.Font= new Font("Segoe UI", 12);
                chk.Text = day;
                chk.Appearance = Appearance.Button; // Biến CheckBox thành nút bấm
                chk.Size = new Size(100, 100);         // Nút vuông
                chk.TextAlign = ContentAlignment.MiddleCenter;
                chk.FlatStyle = FlatStyle.Flat;
                chk.FlatAppearance.BorderSize = 0;   // Bỏ viền mặc định cho hiện đại
                UIHelper.ApplyRoundedRegion(chk, 20); // Bo tròn nút
                chk.Cursor = Cursors.Hand;

                // Màu sắc mặc định (Chưa chọn)
                chk.BackColor = _normalBack;
                chk.ForeColor = _normalText;

                // Xử lý logic đổi màu khi Click
                chk.CheckedChanged += (s, e) =>
                {
                    if (chk.Checked)
                    {
                        chk.BackColor = _activeBack;
                        chk.ForeColor = _activeText;
                    }
                    else
                    {
                        chk.BackColor = _normalBack;
                        chk.ForeColor = _normalText;
                    }
                };

                // Trick để bo tròn nút (Hệ System Dev)
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, chk.Width, chk.Height);
                chk.Region = new Region(path);

                flpDay.Controls.Add(chk);
            }
        }

        private void ucTimeSlotCheckbox_Load(object sender, EventArgs e)
        {
            UIHelper.SetDoubleBuffered(this);
            UIHelper.ApplyRoundedRegion(this, 10);
            UIHelper.ApplyRoundedRegion(btnConfirm, 10);
            this.Paint += (s, ev) => UIHelper.uc_Paint(s, ev, 10, Color.Gray, 2);
            pnlRepeat.Visible = false; // Ẩn phần chọn ngày ban đầu
            InitDayPicker();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 2. Khi bấm nút Cancel, bắn tín hiệu báo cho Form cha biết
            OnCloseModal?.Invoke(this, EventArgs.Empty);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Xử lý lưu database các kiểu ở đây...

            // Sau khi lưu xong, cũng bắn tín hiệu để đóng
            OnCloseModal?.Invoke(this, EventArgs.Empty);
        }

        private void cbRepeat_CheckedChanged(object sender, EventArgs e)
        {
            // Hiển thị hoặc ẩn phần chọn ngày tùy theo trạng thái của checkbox
            pnlRepeat.Visible = cbRepeat.Checked;
        }
    }
}
