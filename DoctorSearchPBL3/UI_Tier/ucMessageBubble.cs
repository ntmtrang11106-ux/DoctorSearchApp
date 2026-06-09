using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DTO_Tier;

namespace UI_Tier
{
    /// <summary>
    /// UserControl đại diện cho một bong bóng tin nhắn (Message Bubble) trong cuộc trò chuyện.
    /// Hỗ trợ căn lề động (trái cho người nhận, phải cho người gửi) và tự động tính toán kích thước theo độ dài văn bản.
    /// </summary>
    public partial class ucMessageBubble : UserControl
    {
        private readonly int _marginLeft;
        private readonly int _marginRight;
        private readonly int _marginTop;
        private readonly int _paddingLeft;
        private readonly int _paddingRight;
        private readonly int _paddingTop;
        private readonly int _paddingBottom;

        private MessagesDTO _message;
        public event EventHandler<int> MessageRecalled;
        public event EventHandler<int> MessageEdited;

        public string MessageContent { get; private set; }
        public DateTime SentAt { get; private set; }
        public bool IsSender { get; private set; }

        /// <summary>
        /// Hàm khởi tạo của ucMessageBubble
        /// </summary>
        public ucMessageBubble()
        {
            InitializeComponent();
            
            // Kích hoạt Double Buffered chống nhấp nháy khi hiển thị danh sách tin nhắn dài
            UIHelper.SetDoubleBuffered(this);
            
            // Đọc các thông số lề và đệm từ cấu hình thiết kế (Designer) để đảm bảo đồng bộ động
            _marginLeft = pnlBubble.Location.X;
            _marginRight = pnlBubble.Location.X; // Lề phải mặc định đối xứng với lề trái
            _marginTop = pnlBubble.Location.Y;
            _paddingLeft = lblText.Location.X;
            _paddingRight = lblText.Location.X; // Padding phải đối xứng với padding trái
            _paddingTop = lblText.Location.Y;
            _paddingBottom = lblText.Location.Y; // Padding dưới đối xứng với padding trên
        }

        public void SetMessage(MessagesDTO msg, bool isSender, int containerWidth)
        {
            _message = msg;
            MessageContent = msg.Content;
            SentAt = msg.SentAt;
            IsSender = isSender;

            pnlBubble.Controls.Clear();

            // Gỡ bỏ sự kiện click chuột phải cũ để tránh lặp lại sự kiện khi resize
            pnlBubble.MouseClick -= Bubble_MouseClick;
            lblText.MouseClick -= Bubble_MouseClick;

            // Đăng ký sự kiện click chuột phải mới để hiển thị tùy chọn thu hồi tin nhắn
            pnlBubble.MouseClick += Bubble_MouseClick;
            lblText.MouseClick += Bubble_MouseClick;

            if (msg.IsDeleted)
            {
                pnlBubble.Controls.Add(lblText);
                lblText.Cursor = Cursors.Default;
                lblText.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
                lblText.Text = "Đã thu hồi 1 tin nhắn";
                lblText.ForeColor = Color.Gray;

                lblText.MouseClick -= Bubble_MouseClick;
                pnlBubble.MouseClick -= Bubble_MouseClick;

                pnlBubble.Paint -= LeftBubblePanel_Paint;
                pnlBubble.Paint += LeftBubblePanel_Paint;

                Font textFont = lblText.Font;
                int maxBubbleWidth = (int)(containerWidth * 0.70);
                Size maxConstraint = new Size(maxBubbleWidth - _paddingLeft - _paddingRight, 0);
                Size textSize = TextRenderer.MeasureText(lblText.Text, textFont, maxConstraint, 
                    TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);

                int bubbleWidth = Math.Max(textSize.Width + _paddingLeft + _paddingRight, 90);
                int bubbleHeight = textSize.Height + _paddingTop + _paddingBottom;

                pnlBubble.Size = new Size(bubbleWidth, bubbleHeight);
                lblText.Location = new Point(_paddingLeft, _paddingTop);
                lblText.Size = new Size(textSize.Width, textSize.Height);

                lblTime.Text = GetFormattedTime(msg.SentAt);

                pnlBubble.BackColor = Color.White;
                if (isSender)
                {
                    pnlBubble.Location = new Point(containerWidth - bubbleWidth - _marginRight, _marginTop);
                    lblTime.Location = new Point(containerWidth - lblTime.PreferredWidth - _marginRight - 8, pnlBubble.Bottom + 4);
                    lblTime.TextAlign = ContentAlignment.TopRight;
                }
                else
                {
                    pnlBubble.Location = new Point(_marginLeft, _marginTop);
                    lblTime.Location = new Point(_marginLeft + 8, pnlBubble.Bottom + 4);
                    lblTime.TextAlign = ContentAlignment.TopLeft;
                }

                this.Width = containerWidth;
                this.Height = lblTime.Bottom + 12;
                UIHelper.ApplyRoundedRegion(pnlBubble, 18);
                return;
            }

            pnlBubble.Paint -= LeftBubblePanel_Paint;
            if ((!isSender || msg.MessageType == "File") && msg.MessageType != "Image")
            {
                pnlBubble.Paint += LeftBubblePanel_Paint;
            }

            if (msg.MessageType == "Image")
            {
                PictureBox pic = new PictureBox();
                string fullPath = System.IO.Path.IsPathRooted(msg.AttachmentPath) 
                    ? msg.AttachmentPath 
                    : System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, msg.AttachmentPath);

                if (System.IO.File.Exists(fullPath))
                {
                    try
                    {
                        using (var fs = new System.IO.FileStream(fullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            pic.Image = new Bitmap(fs);
                        }
                    }
                    catch
                    {
                        pic.Image = null;
                    }
                }
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Cursor = Cursors.Hand;
                pic.MouseClick += Bubble_MouseClick;

                int bubbleWidth = Math.Min(450, (int)(containerWidth * 0.7));
                int bubbleHeight = 350;

                pic.Location = new Point(0, 0);
                pic.Size = new Size(bubbleWidth, bubbleHeight);
                pnlBubble.Controls.Add(pic);
                pnlBubble.Size = new Size(bubbleWidth, bubbleHeight);

                lblTime.Text = GetFormattedTime(msg.SentAt);

                if (isSender)
                {
                    pnlBubble.BackColor = Color.Transparent;
                    pnlBubble.Location = new Point(containerWidth - bubbleWidth - _marginRight, _marginTop);
                    lblTime.Location = new Point(containerWidth - lblTime.PreferredWidth - _marginRight - 8, pnlBubble.Bottom + 4);
                    lblTime.TextAlign = ContentAlignment.TopRight;
                }
                else
                {
                    pnlBubble.BackColor = Color.Transparent;
                    pnlBubble.Location = new Point(_marginLeft, _marginTop);
                    lblTime.Location = new Point(_marginLeft + 8, pnlBubble.Bottom + 4);
                    lblTime.TextAlign = ContentAlignment.TopLeft;
                }

                this.Width = containerWidth;
                this.Height = lblTime.Bottom + 12;
                UIHelper.ApplyRoundedRegion(pnlBubble, 18);
            }
            else if (msg.MessageType == "File")
            {
                Label lblIcon = new Label();
                lblIcon.Font = new Font("Segoe MDL2 Assets", 16F);
                lblIcon.Text = "";
                lblIcon.AutoSize = true;
                lblIcon.ForeColor = Color.FromArgb(0, 102, 204);
                pnlBubble.Controls.Add(lblIcon);

                pnlBubble.Controls.Add(lblText);
                lblText.Cursor = Cursors.Hand;
                lblText.Font = new Font(lblText.Font, FontStyle.Underline);
                lblText.MouseClick -= Bubble_MouseClick;
                lblText.MouseClick += Bubble_MouseClick;

                string displayName = msg.AttachmentName ?? "Tập tin đính kèm";
                lblText.Text = displayName;

                Font textFont = lblText.Font;
                int maxBubbleWidth = (int)(containerWidth * 0.70);
                Size maxConstraint = new Size(maxBubbleWidth - _paddingLeft - _paddingRight - 55, 0);
                Size textSize = TextRenderer.MeasureText(displayName, textFont, maxConstraint, 
                    TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);

                int bubbleWidth = Math.Max(textSize.Width + _paddingLeft + _paddingRight + 65, 120);
                int bubbleHeight = Math.Max(textSize.Height, 30) + _paddingTop + _paddingBottom;

                pnlBubble.Size = new Size(bubbleWidth, bubbleHeight);
                lblIcon.Location = new Point(_paddingLeft, _paddingTop - 2);
                lblText.Location = new Point(_paddingLeft + 55, _paddingTop);
                lblText.Size = new Size(textSize.Width, textSize.Height);

                lblTime.Text = GetFormattedTime(msg.SentAt);

                if (isSender)
                {
                    pnlBubble.BackColor = Color.White;
                    lblText.ForeColor = Color.FromArgb(0, 102, 204); // Standard hyperlink blue
                    pnlBubble.Location = new Point(containerWidth - bubbleWidth - _marginRight, _marginTop);
                    lblTime.Location = new Point(containerWidth - lblTime.PreferredWidth - _marginRight - 8, pnlBubble.Bottom + 4);
                    lblTime.TextAlign = ContentAlignment.TopRight;
                }
                else
                {
                    pnlBubble.BackColor = Color.White;
                    lblText.ForeColor = Color.FromArgb(0, 102, 204); // Standard hyperlink blue
                    pnlBubble.Location = new Point(_marginLeft, _marginTop);
                    lblTime.Location = new Point(_marginLeft + 8, pnlBubble.Bottom + 4);
                    lblTime.TextAlign = ContentAlignment.TopLeft;
                }

                this.Width = containerWidth;
                this.Height = lblTime.Bottom + 12;
                UIHelper.ApplyRoundedRegion(pnlBubble, 18);
            }
            else // "Text"
            {
                pnlBubble.Controls.Add(lblText);
                lblText.Cursor = Cursors.Default;
                lblText.Font = new Font("Segoe UI Emoji", 16F, FontStyle.Regular);
                lblText.MouseClick -= Bubble_MouseClick;

                Font textFont = lblText.Font;
                int maxBubbleWidth = (int)(containerWidth * 0.70);
                Size maxConstraint = new Size(maxBubbleWidth - _paddingLeft - _paddingRight, 0);
                Size textSize = TextRenderer.MeasureText(msg.Content, textFont, maxConstraint, 
                    TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);

                int bubbleWidth = Math.Max(textSize.Width + _paddingLeft + _paddingRight, 90);
                int bubbleHeight = textSize.Height + _paddingTop + _paddingBottom;

                pnlBubble.Size = new Size(bubbleWidth, bubbleHeight);
                lblText.Location = new Point(_paddingLeft, _paddingTop);
                lblText.Size = new Size(textSize.Width, textSize.Height);
                lblText.Text = msg.Content;

                lblTime.Text = GetFormattedTime(msg.SentAt);

                if (isSender)
                {
                    pnlBubble.BackColor = Color.FromArgb(0, 98, 255);
                    lblText.ForeColor = Color.White;
                    pnlBubble.Location = new Point(containerWidth - bubbleWidth - _marginRight, _marginTop);
                    lblTime.Location = new Point(containerWidth - lblTime.PreferredWidth - _marginRight - 8, pnlBubble.Bottom + 4);
                    lblTime.TextAlign = ContentAlignment.TopRight;
                }
                else
                {
                    pnlBubble.BackColor = Color.White;
                    lblText.ForeColor = Color.FromArgb(17, 24, 39);
                    pnlBubble.Location = new Point(_marginLeft, _marginTop);
                    lblTime.Location = new Point(_marginLeft + 8, pnlBubble.Bottom + 4);
                    lblTime.TextAlign = ContentAlignment.TopLeft;
                }

                this.Width = containerWidth;
                this.Height = lblTime.Bottom + 12;
                UIHelper.ApplyRoundedRegion(pnlBubble, 18);
            }
            pnlBubble.Invalidate();
        }

        private void LeftBubblePanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, pnlBubble.Width - 1, pnlBubble.Height - 1);
            using (var path = UIHelper.GetRoundedPath(rect, 18))
            {
                using (Pen pen = new Pen(Color.FromArgb(229, 231, 235), 1))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void Bubble_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) && _message != null)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                
                if (IsSender)
                {
                    ToolStripMenuItem recallItem = new ToolStripMenuItem("Thu hồi tin nhắn");
                    recallItem.Click += (s, ev) => {
                        MessageRecalled?.Invoke(this, _message.Id);
                    };
                    menu.Items.Add(recallItem);
                }

                if (_message.MessageType == "Text" && IsSender)
                {
                    ToolStripMenuItem editItem = new ToolStripMenuItem("Chỉnh sửa tin nhắn");
                    editItem.Click += (s, ev) => {
                        MessageEdited?.Invoke(this, _message.Id);
                    };
                    menu.Items.Add(editItem);
                }
                else if (_message.MessageType == "Image")
                {
                    ToolStripMenuItem openItem = new ToolStripMenuItem("Xem hình ảnh");
                    openItem.Click += (s, ev) => OpenAttachment();
                    menu.Items.Add(openItem);
                }
                else if (_message.MessageType == "File")
                {
                    ToolStripMenuItem openItem = new ToolStripMenuItem("Mở tệp tin");
                    openItem.Click += (s, ev) => OpenAttachment();
                    menu.Items.Add(openItem);
                }

                if (menu.Items.Count > 0)
                {
                    menu.Show(Cursor.Position);
                }
            }
        }

        private void OpenAttachment()
        {
            if (_message == null || string.IsNullOrEmpty(_message.AttachmentPath)) return;
            try
            {
                string fullPath = System.IO.Path.IsPathRooted(_message.AttachmentPath) 
                    ? _message.AttachmentPath 
                    : System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _message.AttachmentPath);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fullPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở tài liệu/hình ảnh: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Hàm cập nhật lại chiều rộng bong bóng khi thay đổi kích thước cửa sổ (Resize)
        /// </summary>
        /// <param name="containerWidth">Chiều rộng khả dụng mới của khung chứa</param>
        public void UpdateWidth(int containerWidth)
        {
            if (_message != null)
            {
                SetMessage(_message, IsSender, containerWidth);
            }
        }

        private string GetFormattedTime(DateTime sentAt)
        {
            DateTime now = DateTime.Now;
            if (sentAt.Year != now.Year)
            {
                return sentAt.ToString("dd/MM/yyyy HH:mm");
            }
            if (sentAt.Date != now.Date)
            {
                return sentAt.ToString("dd/MM HH:mm");
            }
            return sentAt.ToString("HH:mm");
        }
    }
}
