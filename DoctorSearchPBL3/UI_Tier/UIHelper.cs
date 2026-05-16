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

        // --- TỐI ƯU CUỘN CHUỘT (Smooth Scrolling) ---
        public static void SetupSmoothScrolling(Panel pnl)
        {
            if (pnl == null) return;
            pnl.MouseWheel += (s, e) => {
                // Hủy bỏ hành vi cuộn mặc định (thường bị giật theo nấc)
                HandledMouseEventArgs hme = (HandledMouseEventArgs)e;
                hme.Handled = true;

                // Tính toán khoảng cách cuộn: Càng nhỏ càng mượt (ví dụ 60px mỗi lần xoay)
                // Delta 120 là 1 nấc xoay chuẩn
                int scrollStep = 60; 
                int direction = e.Delta > 0 ? -1 : 1;
                int scrollAmount = direction * scrollStep;

                int newValue = pnl.VerticalScroll.Value + scrollAmount;

                // Đảm bảo không cuộn quá giới hạn
                if (newValue < pnl.VerticalScroll.Minimum) newValue = pnl.VerticalScroll.Minimum;
                if (newValue > pnl.VerticalScroll.Maximum) newValue = pnl.VerticalScroll.Maximum;

                pnl.VerticalScroll.Value = newValue;
            };
        }
        
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

        /// <summary>
        /// Vẽ khung viền 2px Đen và vạch 4px (Focus) theo chuẩn High-Fidelity (Sắc nét hơn)
        /// </summary>
        public static void PaintInputStandard(Graphics g, Rectangle rect, bool isFocused, Color highlightColor)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 1. Vẽ khung viền đen bo góc 8px (Độ dày 2)
            // Sử dụng Inset để nét vẽ 2px nằm hoàn toàn bên trong, không bị Region cắt
            using (var path = UIHelper.GetRoundedPath(new Rectangle(0, 0, rect.Width, rect.Height), 8))
            {
                using (Pen blackPen = new Pen(Color.Black, 2))
                {
                    blackPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    g.DrawPath(blackPen, path);
                }
            }

            // 2. Nếu đang focus, vẽ vạch dưới dày 4px (Nằm hẳn bên trong viền đen)
            if (isFocused)
            {
                using (Pen highlightPen = new Pen(highlightColor, 4))
                {
                    // Vẽ vạch xanh cách đáy một chút để tách biệt với viền đen
                    g.DrawLine(highlightPen, 15, rect.Height - 3, rect.Width - 15, rect.Height - 3);
                }
            }
        }

        public static void SetupInputFocusEffect(Control inputControl, Control borderControl, Color focusBackColor, Color unfocusBackColor, Color highlightColor)
        {
            if (borderControl != null)
            {
                borderControl.Paint += (s, ev) =>
                {
                    Rectangle rect = new Rectangle(0, 0, borderControl.Width, borderControl.Height);
                    PaintInputStandard(ev.Graphics, rect, inputControl.Focused, highlightColor);
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

        public static void SetupTabHover(Panel pnl, Color hoverColor, Color activeColor, Color normalColor)
        {
            pnl.MouseEnter += (s, e) => {
                if (pnl.BackColor != activeColor) pnl.BackColor = hoverColor;
            };
            pnl.MouseLeave += (s, e) => {
                if (pnl.BackColor != activeColor) pnl.BackColor = normalColor;
            };

            foreach (Control child in pnl.Controls)
            {
                child.MouseEnter += (s, e) => {
                    if (pnl.BackColor != activeColor) pnl.BackColor = hoverColor;
                };
                child.MouseLeave += (s, e) => {
                    if (pnl.BackColor != activeColor) pnl.BackColor = normalColor;
                };
            }
        }

        // --- HÀM MỚI: Hiệu ứng Fade In cho Form khi mở ---
        public static async System.Threading.Tasks.Task FadeInForm(Form form, int speed = 5)
        {
            form.Opacity = 0;
            while (form.Opacity < 1)
            {
                await System.Threading.Tasks.Task.Delay(10);
                form.Opacity += (double)speed / 100;
            }
            form.Opacity = 1;
        }

        // --- HÀM MỚI: Hiệu ứng Fade Out cho Form khi đóng ---
        public static async System.Threading.Tasks.Task FadeOutForm(Form form, int speed = 5)
        {
            while (form.Opacity > 0)
            {
                await System.Threading.Tasks.Task.Delay(10);
                form.Opacity -= (double)speed / 100;
            }
            form.Opacity = 0;
        }

        // --- HÀM MỚI: Chuyển đổi UserControl mượt mà (Tối ưu tốc độ) ---
        public static void SwitchControlSmoothly(Control container, Control? oldCtrl, Control newCtrl)
        {
            if (newCtrl == null || container == null) return;
            if (oldCtrl == newCtrl) return;

            container.SuspendLayout();
            
            // Ép kích thước ngay lúc còn ẩn để tránh hiệu ứng vẽ từ giữa ra
            newCtrl.Size = container.ClientSize;
            newCtrl.Location = new Point(0, 0);
            newCtrl.Dock = DockStyle.Fill;
            
            SetDoubleBuffered(newCtrl);

            newCtrl.BringToFront();
            newCtrl.Visible = true;
            newCtrl.Update(); // Ép vẽ ngay lập tức

            if (oldCtrl != null)
            {
                oldCtrl.Visible = false;
            }
            
            container.ResumeLayout(true);
        }

        // --- HÀM MỚI: Vẽ sẵn các Tab vào RAM (Gộp logic để dùng chung) ---
        public static void PreLoadTabs(Panel container, Dictionary<Panel, Type> typeMapping, Dictionary<Panel, UserControl> instanceMapping, Panel priorityTab = null, bool loadAll = true, Action<UserControl, Panel> onInit = null)
        {
            if (container == null || typeMapping == null || instanceMapping == null) return;

            container.SuspendLayout();
            
            // 1. Vẽ tab ưu tiên trước (Để hiện lên ngay lập tức)
            if (priorityTab != null && typeMapping.ContainsKey(priorityTab) && !instanceMapping.ContainsKey(priorityTab))
            {
                CreateTab(container, priorityTab, typeMapping[priorityTab], instanceMapping, onInit);
            }

            // 2. Vẽ các tab còn lại (Nếu loadAll = true)
            if (loadAll)
            {
                foreach (var item in typeMapping)
                {
                    Panel pnlTab = item.Key;
                    if (pnlTab == priorityTab) continue; // Đã vẽ ở bước 1

                    if (!instanceMapping.ContainsKey(pnlTab))
                    {
                        CreateTab(container, pnlTab, item.Value, instanceMapping, onInit);
                    }
                }
            }
            container.ResumeLayout(true);
        }

        public static async Task BackgroundPreLoadTabs(Panel container, Dictionary<Panel, Type> typeMapping, Dictionary<Panel, UserControl> instanceMapping, Panel priorityTab, Action<UserControl, Panel> onInit)
        {
            // Nạp từng tab một cách chậm rãi để không gây treo UI (UI Responsive)
            foreach (var item in typeMapping)
            {
                Panel pnlTab = item.Key;
                if (pnlTab == priorityTab) continue; 
                if (instanceMapping.ContainsKey(pnlTab)) continue;

                // Nghỉ một chút giữa mỗi tab để luồng UI xử lý các sự kiện khác (click, hover, scroll)
                await Task.Delay(200); 

                // Thực hiện vẽ Tab vào RAM trên luồng UI
                container.BeginInvoke(new Action(() => {
                    CreateTab(container, pnlTab, item.Value, instanceMapping, onInit);
                }));
            }
        }

        private static void CreateTab(Panel container, Panel pnlTab, Type type, Dictionary<Panel, UserControl> instanceMapping, Action<UserControl, Panel> onInit)
        {
            if (instanceMapping.ContainsKey(pnlTab)) return;

            UserControl uc = (UserControl)Activator.CreateInstance(type);
            uc.Dock = DockStyle.Fill;
            uc.Visible = false;
            
            // QUAN TRỌNG: Ép hệ thống tạo Handle và chạy sự kiện Load ngay lập tức trong RAM
            uc.CreateControl(); 
            
            container.Controls.Add(uc);
            instanceMapping.Add(pnlTab, uc);

            // Bật DoubleBuffered đệ quy để chống nháy khi Switch
            SetDoubleBuffered(uc);

            // Callback để xử lý riêng (nạp dữ liệu Profile, Lịch hẹn...)
            onInit?.Invoke(uc, pnlTab);
        }

        // --- BỔ SUNG: Helper bật DoubleBuffered cho mọi Control con ---
        public static void SetDoubleBuffered(Control c)
        {
            if (c == null) return;
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;
            
            System.Reflection.PropertyInfo dbProp = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            dbProp?.SetValue(c, true, null);

            // Đệ quy cho toàn bộ control con bên trong
            foreach (Control child in c.Controls)
            {
                SetDoubleBuffered(child);
            }
        }

        /// <summary>
        /// Cấu hình tối ưu cho các Container có thanh cuộn (Scrollable)
        /// Chống giật (flicker) và cuộn mượt mà hơn.
        /// </summary>
        public static void SetupScrollableContainer(Control container)
        {
            if (container == null) return;

            // 1. Bật DoubleBuffered đệ quy để chống nháy khi vẽ lại các item lúc cuộn
            SetDoubleBuffered(container);

            // 2. Nếu là Panel hoặc FlowLayoutPanel, cài đặt cuộn mượt (Smooth Scrolling)
            if (container is Panel pnl)
            {
                // Logic for smooth scrolling setup can be added here
            }
        }

        public static void LogoutAndCleanup(Form dashboard, Dictionary<Panel, UserControl> tabMapping)
        {
            // 1. Hiện lại Guest (Owner) ngay lập tức để không bị lộ màn hình máy tính (Desktop)
            if (dashboard.Owner != null)
            {
                dashboard.Owner.Show();
                dashboard.Owner.Update(); // Ép vẽ Guest xong mới đóng Dashboard
            }

            // 2. Đăng xuất tài khoản
            DTO_Tier.GlobalAccount.Logout();

            // 3. Giải phóng RAM: Hủy toàn bộ UserControls đã cache
            if (tabMapping != null)
            {
                foreach (var uc in tabMapping.Values)
                {
                    if (uc != null && !uc.IsDisposed)
                    {
                        uc.Dispose();
                    }
                }
                tabMapping.Clear();
            }

            // 4. Đóng Dashboard
            dashboard.Close();

            // 5. Ép dọn RAM ngay lập tức
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
