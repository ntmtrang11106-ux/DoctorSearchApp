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
        public frmLogin()
        {
            InitializeComponent();
        }

        // Hàm bo góc
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void btn_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            int borderRadius = 20; // Độ bo góc, chỉnh số này theo ý muốn

            // 1. Cắt khung Button (Region)
            btn.Region = new Region(GetRoundedPath(btn.ClientRectangle, borderRadius));

            // 2. Vẽ lại viền cho mịn (Khử răng cưa)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Nếu muốn có viền thì thêm đoạn Pen ở đây, không thì thôi
            using (Pen pen = new Pen(btn.BackColor, 1))
            {
                e.Graphics.DrawPath(pen, GetRoundedPath(btn.ClientRectangle, borderRadius));
            }
        }

        private void btn_Outline_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int borderRadius = 20; // Độ bo
            int borderWidth = 2;   // Độ dày viền

            // Màu sắc mày tự chỉnh ở đây
            Color fillColor = Color.White; // Màu nền (Xanh Facebook)
            Color borderColor = Color.FromArgb(24, 119, 242);                // Màu viền (Trắng)

            // Tạo khung vẽ (thụt vào 1px để không bị cắt mép)
            Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);

            using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedPath(rect, borderRadius))
            {
                // Bước 1: Cắt vùng hiển thị của Button theo đường bo
                btn.Region = new Region(path);

                // Bước 2: Tô màu nền (Fill)
                using (Brush brush = new SolidBrush(fillColor))
                {
                    g.FillPath(brush, path);
                }

                // Bước 3: Vẽ đường viền (Stroke)
                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    g.DrawPath(pen, path);
                }
            }

            // Bước 4: Vẽ lại chữ của Button (Vì mình đã tô màu đè lên chữ mặc định)
            TextRenderer.DrawText(g, btn.Text, btn.Font, rect, btn.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

    }
}
