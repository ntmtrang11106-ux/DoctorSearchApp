using System;
using System.Drawing;
using System.Windows.Forms;

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
        public void SetMessage(string content, DateTime sentAt, bool isSender, int containerWidth)
        {
            // Lưu lại thông tin tin nhắn phục vụ cho cơ chế cuộn và resize
            MessageContent = content;
            SentAt = sentAt;
            IsSender = isSender;

            Font textFont = lblText.Font;
            
            // Khống chế chiều rộng tối đa của bong bóng không vượt quá 70% chiều rộng khung chứa
            int maxBubbleWidth = (int)(containerWidth * 0.70);

            // Đo kích thước thực tế của văn bản khi bị giới hạn chiều rộng (WordBreak tự động xuống dòng)
            Size maxConstraint = new Size(maxBubbleWidth - _paddingLeft - _paddingRight, 0);
            Size textSize = TextRenderer.MeasureText(content, textFont, maxConstraint, 
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);

            // Tính toán kích thước bong bóng (bubble), đảm bảo chiều rộng tối thiểu là 90px để không bị méo góc
            int bubbleWidth = Math.Max(textSize.Width + _paddingLeft + _paddingRight, 90);
            int bubbleHeight = textSize.Height + _paddingTop + _paddingBottom;

            // Gán kích thước cho Panel nền của bong bóng
            pnlBubble.Size = new Size(bubbleWidth, bubbleHeight);
            
            // Định vị và gán nội dung cho Label hiển thị tin nhắn bên trong bong bóng
            lblText.Location = new Point(_paddingLeft, _paddingTop);
            lblText.Size = new Size(textSize.Width, textSize.Height);
            lblText.Text = content;

            // Định dạng thời gian theo chuẩn Giờ:Phút
            lblTime.Text = sentAt.ToString("HH:mm");

            // 1. Nếu là TIN NHẮN GỬI ĐI (Người dùng hiện tại gửi - Căn lề PHẢI)
            if (isSender)
            {
                // Nền xanh dương đậm, chữ màu trắng nổi bật
                pnlBubble.BackColor = Color.FromArgb(0, 98, 255);
                lblText.ForeColor = Color.White;

                // Đẩy vị trí Panel bong bóng về góc bên phải màn hình
                pnlBubble.Location = new Point(containerWidth - bubbleWidth - _marginRight, _marginTop);
                
                // Đẩy vị trí nhãn thời gian xuống dưới bong bóng và căn lề phải
                lblTime.Location = new Point(containerWidth - lblTime.Width - _marginRight - 8, pnlBubble.Bottom + 4);
                lblTime.TextAlign = ContentAlignment.TopRight;
            }
            // 2. Nếu là TIN NHẮN NHẬN VỀ (Đối phương gửi - Căn lề TRÁI)
            else
            {
                // Nền xám nhạt dịu mát, chữ màu xám tối/đen
                pnlBubble.BackColor = Color.FromArgb(243, 244, 246);
                lblText.ForeColor = Color.FromArgb(17, 24, 39);

                // Đẩy vị trí Panel bong bóng về góc bên trái màn hình
                pnlBubble.Location = new Point(_marginLeft, _marginTop);
                
                // Đẩy vị trí nhãn thời gian xuống dưới bong bóng và căn lề trái
                lblTime.Location = new Point(_marginLeft + 8, pnlBubble.Bottom + 4);
                lblTime.TextAlign = ContentAlignment.TopLeft;
            }

            // Gán kích thước cho toàn bộ UserControl này
            this.Width = containerWidth;
            
            // Tính toán động chiều cao dựa trên điểm đáy thực tế của nhãn thời gian (lblTime.Bottom) cộng thêm 12px đệm an toàn
            this.Height = lblTime.Bottom + 12;

            // Bo tròn mượt mà các góc của bong bóng chat (Bán kính bo góc 18px)
            UIHelper.ApplyRoundedRegion(pnlBubble, 18);
        }

        /// <summary>
        /// Hàm cập nhật lại chiều rộng bong bóng khi thay đổi kích thước cửa sổ (Resize)
        /// </summary>
        /// <param name="containerWidth">Chiều rộng khả dụng mới của khung chứa</param>
        public void UpdateWidth(int containerWidth)
        {
            SetMessage(MessageContent, SentAt, IsSender, containerWidth);
        }
    }
}
