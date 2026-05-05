using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Reflection;
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

        // Hàm này dùng để vẽ lại Button với bo góc và viền tùy chỉnh
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

        // Hàm này dùng để vẽ lại UserControl với bo góc và viền tùy chỉnh
        public static void uc_Paint(object sender, PaintEventArgs e, int radius, Color borderColor, int borderSize)
        {
            Control uc = (Control)sender;
            if (uc == null) return;

            // Khử răng cưa cực quan trọng để viền không bị nát
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // QUAN TRỌNG: Trừ đi 1 pixel ở Width và Height 
            // Điều này giúp đường vẽ của Pen nằm trọn vẹn bên trong khung đã cắt
            Rectangle rect = new Rectangle(0, 0, uc.Width - 1, uc.Height - 1);

            if (borderSize > 0)
            {
                using (GraphicsPath pathBorder = GetRoundedPath(rect, radius))
                {
                    using (Pen pen = new Pen(borderColor, borderSize))
                    {
                        // Inset giúp đẩy viền vào trong, tránh bị mất nét do Region cắt
                        pen.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawPath(pen, pathBorder);
                    }
                }
            }
        }

        // Hàm này dùng Reflection để bật Double Buffering cho Control, giúp giảm nhấp nháy khi vẽ lại
        public static void SetDoubleBuffered(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
        // --- HÀM MỚI: Xử lý hiển thị tiền tệ chuẩn Việt Nam ---
        public static string FormatVND(decimal? price)
        {
            // Kiểm tra nếu giá trị bị null hoặc bằng 0 theo đúng file Word [cite: 27]
            if (!price.HasValue || price == 0)
            {
                return "Liên hệ";
            }

            // "N0" giúp tự động thêm dấu chấm phân cách hàng nghìn (VD: 500.000)
            return price.Value.ToString("N0") + " đ";
        }
        public static void DrawControlBorder(object sender, PaintEventArgs e, int radius, Color borderColor, int borderSize)
        {
            Control ctrl = (Control)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, ctrl.Width - 1, ctrl.Height - 1);
            using (GraphicsPath path = GetRoundedPath(rect, radius))
            {
                using (Pen pen = new Pen(borderColor, borderSize))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}
