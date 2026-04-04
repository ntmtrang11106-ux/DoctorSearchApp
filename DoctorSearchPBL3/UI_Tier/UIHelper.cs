using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;

namespace UI_Tier
{
    public static class UIHelper
    {
        // Hàm tạo đường dẫn hình chữ nhật bo tròn
        public static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
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

        // Hàm áp dụng bo góc cho một Control bất kỳ
        public static void ApplyRoundedRegion(Control control, int radius)
        {
            control.Region = new Region(GetRoundedPath(control.ClientRectangle, radius));
        }

        public static void btn_Paint(object sender, PaintEventArgs e)
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

    }
}
