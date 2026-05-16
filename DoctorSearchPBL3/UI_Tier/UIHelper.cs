using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace UI_Tier
{
    public static class UIHelper
    {
        // Import các hàm API để kéo form mượt hơn (giảm load)
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public static void EnableNativeDrag(Control handle, Control target)
        {
            handle.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(target.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };
            handle.Cursor = Cursors.SizeAll;
        }

        // Hàm tạo đường dẫn hình chữ nhật bo tròn (Số nguyên)
        public static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            return GetRoundedPath(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height), radius);
        }

        // Hàm tạo đường dẫn hình chữ nhật bo tròn (Số thực - Độ chính xác cao)
        public static GraphicsPath GetRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

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
            if (control == null) return;
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

        // --- HÀM MỚI: Hiệu ứng Hover nhấc lên và đổi màu ---
        public static void SetupHoverEffect(Control ctrl, Color hoverColor, Color defaultColor, int liftAmount = 2)
        {
            if (ctrl == null) return;
            ctrl.Cursor = Cursors.Hand;
            ctrl.MouseEnter += (s, e) => {
                ctrl.ForeColor = hoverColor;
                ctrl.Top -= liftAmount;
            };
            ctrl.MouseLeave += (s, e) => {
                ctrl.ForeColor = defaultColor;
                ctrl.Top += liftAmount;
            };
        }

        public static void SetupPaginationLabels(Label lblPrev, Label lblNext)
        {
            Color defaultColor = Color.FromArgb(0, 120, 212);
            Color hoverColor = Color.FromArgb(0, 90, 158);
            SetupHoverEffect(lblPrev, hoverColor, defaultColor, 2);
            SetupHoverEffect(lblNext, hoverColor, defaultColor, 2);
        }

        public static void SetupSearchTextBox(TextBox txt, string placeholder)
        {
            txt.BackColor = Color.White;
            SetupPlaceholder(txt, placeholder);
        }

        public static void SetupComboBox(ComboBox cbo)
        {
            cbo.FlatStyle = FlatStyle.Standard;
            cbo.BackColor = Color.White;
            // Một số phiên bản Windows cần Invalidate để vẽ lại border chuẩn
            cbo.Invalidate();
        }

        public static void SetupPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            txt.Enter += (s, e) => {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        // --- HÀM MỚI: Hiệu ứng Focus cho ô nhập liệu (Đổi nền và vẽ highlight đáy) ---
        public static void SetupInputFocusEffect(Control inputControl, Control borderControl, int radius, Color focusBorderColor, Color unfocusBorderColor, int borderSize = 2)
        {
            inputControl.Enter += (s, e) => borderControl.Invalidate();
            inputControl.Leave += (s, e) => borderControl.Invalidate();

            borderControl.Paint += (s, e) => {
                Color currentColor = inputControl.Focused ? focusBorderColor : unfocusBorderColor;
                DrawControlBorder(borderControl, e, radius, currentColor, borderSize);
            };
        }

        // --- Overload cũ để tương thích với các màn hình khác ---
        public static void SetupInputFocusEffect(Control inputControl, Control borderControl, Color focusBackColor, Color unfocusBackColor, Color highlightColor)
        {
            if (borderControl != null)
            {
                UIHelper.ApplyRoundedRegion(borderControl, 8); // Áp dụng bo góc 8px cho khung
                
                borderControl.Paint += (s, e) => {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    
                    // 1. Vẽ khung viền dày 2px quanh toàn bộ borderControl (Đen - Bo góc 8)
                    Rectangle borderRect = new Rectangle(0, 0, borderControl.Width - 1, borderControl.Height - 1);
                    using (var path = UIHelper.GetRoundedPath(borderRect, 8))
                    {
                        using (Pen blackPen = new Pen(Color.Black, 2))
                        {
                            blackPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                            e.Graphics.DrawPath(blackPen, path);
                        }
                    }

                    // 2. Nếu đang focus, vẽ vạch dưới màu xanh dày 4px
                    if (inputControl.Focused)
                    {
                        using (Pen bluePen = new Pen(highlightColor, 4))
                        {
                            e.Graphics.DrawLine(bluePen, 0, borderControl.Height - 1, borderControl.Width, borderControl.Height - 1);
                        }
                    }
                };
            }

            Color originalBackColor = inputControl.BackColor;

            inputControl.Enter += (s, e) => {
                originalBackColor = inputControl.BackColor; // Lưu lại màu hiện tại (có thể là xám hoặc trắng)
                if (borderControl != null) borderControl.BackColor = focusBackColor;
                inputControl.BackColor = focusBackColor;
                if (borderControl != null) borderControl.Invalidate();
                else inputControl.Parent?.Invalidate(); 
            };
            inputControl.Leave += (s, e) => {
                if (borderControl != null) borderControl.BackColor = originalBackColor;
                inputControl.BackColor = originalBackColor; // Khôi phục lại màu cũ
                if (borderControl != null) borderControl.Invalidate();
                else inputControl.Parent?.Invalidate();
            };
        }

        public static void RegisterClickToUnfocus(Control parent)
        {
            RegisterClickToUnfocus(parent, parent);
        }

        public static void RegisterClickToUnfocus(Control parent, Control focusTarget)
        {
            parent.Click += (s, e) => { 
                // Không cướp focus nếu đang thao tác với ComboBox
                Form f = parent.FindForm();
                if (f?.ActiveControl is ComboBox cbo && cbo.DroppedDown) return;
                
                if (f != null) f.ActiveControl = null; 
            };
            foreach (Control child in parent.Controls)
            {
                if (!(child is TextBox || child is RichTextBox || child is Button || child is DateTimePicker || child is ComboBox))
                {
                    RegisterClickToUnfocus(child, focusTarget);
                }
            }
        }

        // --- HÀM MỚI: Cấu hình Label thông báo trống ở giữa container ---
        public static void SetupEmptyStateLabel(Label lbl, Control container, string text)
        {
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 11, FontStyle.Italic);
            lbl.ForeColor = Color.Gray;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.AutoSize = false;
            lbl.Size = new Size(container.Width - 40, container.Height - 40);
            lbl.Margin = new Padding(20);
        }

        // --- HÀM MỚI: Vẽ đổ bóng và đường trang trí cho các Section ---
        public static void DrawSectionShadow(object sender, PaintEventArgs e, int radius, Color accentColor)
        {
            Control pnl = sender as Control;
            if (pnl == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Đổ bóng mờ (Shadow)
            for (int i = 1; i <= 6; i++)
            {
                Rectangle shadowRect = new Rectangle(i, i, pnl.Width - i * 2, pnl.Height - i * 2);
                using (var path = GetRoundedPath(shadowRect, radius))
                {
                    using (Pen shadowPen = new Pen(Color.FromArgb(12 / i, Color.Black), i))
                    {
                        e.Graphics.DrawPath(shadowPen, path);
                    }
                }
            }

            // Vẽ viền và đường trang trí trên cùng
            Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            using (var path = GetRoundedPath(rect, radius))
            {
                using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
            using (Pen accentPen = new Pen(accentColor, 6))
            {
                e.Graphics.DrawLine(accentPen, 20, 0, pnl.Width - 20, 0);
            }
        }

        // --- HÀM MỚI: Ngăn ô ReadOnly nhận focus ---
        public static void SetupReadOnlyHandler(TextBox tb, Control alternativeFocus)
        {
            tb.Enter += (s, e) => {
                if (tb.ReadOnly) alternativeFocus.Focus();
            };
        }

        public static void SetupPaginationPanel(Panel pnl, int topPadding = 10)
        {
            pnl.Dock = DockStyle.Bottom;
            pnl.Height = 60;
            pnl.BackColor = Color.FromArgb(242, 246, 250); // Màu xanh nhạt nhẹ
            pnl.Padding = new Padding(0, topPadding, 0, 0); // Tạo khoảng cách phía trên

            // Vẽ đường kẻ mờ ở trên cùng để phân tách với danh sách
            pnl.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(230, 230, 230), 1), 0, 0, pnl.Width, 0);
            };
        }
        // --- HÀM MỚI: Cho phép di chuyển Control bằng cách nắm kéo một handle (ví dụ: Title) ---
        public static void MakeDraggable(Control handle, Control target)
        {
            bool isDragging = false;
            Point dragStartPoint = new Point(0, 0);

            handle.MouseDown += (s, ev) => {
                if (ev.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    dragStartPoint = ev.Location;
                }
            };

            handle.MouseMove += (s, ev) => {
                if (isDragging)
                {
                    Point p = target.Parent.PointToClient(Control.MousePosition);
                    target.Location = new Point(p.X - dragStartPoint.X, p.Y - dragStartPoint.Y);
                }
            };

            handle.MouseUp += (s, ev) => { isDragging = false; };
            handle.Cursor = Cursors.SizeAll;
        }
    }
}
