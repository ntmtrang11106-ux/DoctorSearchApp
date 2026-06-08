using BUS_Tier;
using DTO_Tier;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucConversationItem : UserControl
    {
        public ConversationDTO Conversation { get; private set; }
        private readonly ChatBUS _chatBUS = new ChatBUS();
        
        // Trạng thái cuộc hội thoại này có đang được người dùng chọn hay không
        private bool _isSelected = false;

        // Sự kiện kích hoạt khi người dùng click chọn cuộc trò chuyện này
        public event EventHandler<ConversationDTO> ConversationSelected;

        // Thuộc tính quản lý trạng thái chọn (Active) của mục hội thoại này
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                UpdateBackground(); // Cập nhật màu nền dựa trên trạng thái chọn
            }
        }

        /// <summary>
        /// Hàm khởi tạo của ucConversationItem
        /// </summary>
        public ucConversationItem()
        {
            InitializeComponent();
            
            // Kích hoạt tính năng Double Buffered giúp tối ưu hóa đồ họa, chống nhấp nháy khi cuộn hoặc di chuột
            UIHelper.SetDoubleBuffered(this);
            // Ủy quyền (Wire) sự kiện click từ các Control con (avatar, tên, tin nhắn cuối...) về sự kiện click của Control cha.
            // Điều này giúp người dùng click vào bất cứ vị trí nào trong thẻ thì thẻ đó cũng nhận diện là được chọn.
            WireClickEvents(this);
            // Ủy quyền hiệu ứng hover (rê chuột đổi màu) cho tất cả các Control con
            WireMouseHoverEvents(this);

            // Đăng ký sự kiện Load để bo góc giao diện
            this.Load += ucConversationItem_Load;
        }

        /// <summary>
        /// Sự kiện Load: Thực hiện bo tròn các thành phần giao diện theo chuẩn thiết kế hiện đại
        /// </summary>
        private void ucConversationItem_Load(object sender, EventArgs e)
        {
            // Bo tròn tuyệt đối ảnh đại diện (avatar) thành hình tròn đường kính 90px (Bán kính bo góc 45px)
            UIHelper.ApplyRoundedRegion(lblAvatar, 45);
            // Bo tròn chấm xanh online (Đường kính 24px, bán kính 12px)
            UIHelper.ApplyRoundedRegion(pnlOnlineDot, 12);
            // Bo tròn huy hiệu thông báo tin nhắn chưa đọc (Đường kính 30px, bán kính 15px)
            UIHelper.ApplyRoundedRegion(lblUnread, 15);
            // Bo tròn các góc ngoài của toàn bộ thẻ hội thoại này (Bán kính 15px)
            UIHelper.ApplyRoundedRegion(this, 15);
        }

        public void SetData(ConversationDTO conv, string currentRole, int unreadCount)
        {
            Conversation = conv;

            // Khởi tạo các giá trị mặc định cho đối phương (partner)
            string partnerName = "Người dùng";
            string partnerStatus = "Active";
            string partnerPic = "";

            if (currentRole == "Patient")
            {
                if (conv.Doctor != null && conv.Doctor.User != null)
                {
                    partnerName = conv.Doctor.User.FullName;
                    partnerStatus = conv.Doctor.User.Status;
                    partnerPic = conv.Doctor.User.Picture;
                }
            }
            else // Doctor viewing
            {
                if (conv.Patient != null && conv.Patient.User != null)
                {
                    partnerName = conv.Patient.User.FullName;
                    partnerStatus = conv.Patient.User.Status;
                    partnerPic = conv.Patient.User.Picture;
                }
            }

            lblName.Text = partnerName;
            lblLastMessage.Text = conv.LastMessage;
            
            // Định dạng thời gian hoạt động cuối thành dạng thân thiện tương đối (VD: "5 phút trước", "Hôm qua")
            lblTime.Text = _chatBUS.GetRelativeTimeString(conv.LastActive);

            // 3. Hiển thị chấm tròn trực tuyến nếu trạng thái đối phương là "Active"
            pnlOnlineDot.Visible = (partnerStatus == "Active");

            // 4. Quản lý việc giải phóng bộ nhớ ảnh đại diện cũ trước khi nạp ảnh mới
            if (lblAvatar.Image != null)
            {
                lblAvatar.Image.Dispose();
                lblAvatar.Image = null;
            }

            // 5. Nạp ảnh đại diện thực tế từ thư mục tài nguyên Resources_Images
            bool imageLoaded = false;
            if (!string.IsNullOrWhiteSpace(partnerPic))
            {
                string imageFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images");
                string imagePath = System.IO.Path.Combine(imageFolder, partnerPic.Trim());
                if (System.IO.File.Exists(imagePath))
                {
                    try
                    {
                        // Sử dụng FileStream để đọc file, giúp file không bị hệ thống khóa độc quyền
                        using (var fs = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            var bmp = new Bitmap(fs);
                            lblAvatar.Image = new Bitmap(bmp, new Size(90, 90)); // Ép ảnh về đúng tỷ lệ 90x90px
                            imageLoaded = true;
                        }
                    }
                    catch { }
                }
            }

            // Nếu nạp ảnh thành công, ẩn ký tự đại diện. Ngược lại, lấy chữ cái đầu của tên làm avatar trên nền xám tròn
            if (imageLoaded)
            {
                lblAvatar.Text = "";
            }
            else
            {
                lblAvatar.Text = string.IsNullOrEmpty(partnerName) ? "?" : partnerName[0].ToString().ToUpper();
            }

            // 6. Quản lý hiển thị huy hiệu tin nhắn chưa đọc (Unread badge)
            if (unreadCount > 0)
            {
                lblUnread.Text = unreadCount.ToString();
                lblUnread.Visible = true;
                
                // Tin nhắn chưa đọc: In đậm Tên và Tin nhắn cuối, chuyển màu tin nhắn cuối sang màu tối nổi bật
                lblName.Font = new Font(lblName.Font, FontStyle.Bold);
                lblLastMessage.Font = new Font(lblLastMessage.Font, FontStyle.Bold);
                lblLastMessage.ForeColor = Color.FromArgb(17, 24, 39); 
            }
            else
            {
                lblUnread.Visible = false;
                
                // Đã đọc hết: Chữ Tên và Tin nhắn cuối quay về dạng bình thường (Regular), tin nhắn cuối màu xám mờ
                lblName.Font = new Font(lblName.Font, FontStyle.Regular);
                lblLastMessage.Font = new Font(lblLastMessage.Font, FontStyle.Regular);
                lblLastMessage.ForeColor = Color.FromArgb(107, 114, 128);
            }
        }

        /// <summary>
        /// Cập nhật màu nền giao diện của thẻ hội thoại dựa trên trạng thái có đang được chọn hay không
        /// </summary>
        private void UpdateBackground()
        {
            if (_isSelected)
            {
                this.BackColor = Color.FromArgb(243, 248, 255); // Màu xanh dương nhạt dịu mắt khi được chọn
            }
            else
            {
                this.BackColor = Color.White; // Màu trắng mặc định khi không chọn
            }
        }

        /// <summary>
        /// Hàm đệ quy liên kết sự kiện Click của các Control con về sự kiện Click của thẻ chính
        /// </summary>
        private void WireClickEvents(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                child.Click += (s, e) => OnClick(e);
                WireClickEvents(child); // Gọi đệ quy cho các Control lồng nhau sâu hơn
            }
        }

        /// <summary>
        /// Hàm đệ quy liên kết sự kiện di chuột (Hover) của Control con về các hàm hover chung của thẻ chính
        /// </summary>
        private void WireMouseHoverEvents(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                child.MouseEnter += (s, e) => ucConversationItem_MouseEnter(s, e);
                child.MouseLeave += (s, e) => ucConversationItem_MouseLeave(s, e);
                WireMouseHoverEvents(child);
            }
            parent.MouseEnter += ucConversationItem_MouseEnter;
            parent.MouseLeave += ucConversationItem_MouseLeave;
        }

        /// <summary>
        /// Hiệu ứng đổi màu khi rê chuột vào thẻ (Chỉ áp dụng khi thẻ chưa được chọn hoạt động)
        /// </summary>
        private void ucConversationItem_MouseEnter(object sender, EventArgs e)
        {
            if (!_isSelected)
            {
                this.BackColor = Color.FromArgb(249, 250, 251); // Màu xám nhạt nhẹ (Soft Gray) khi di chuột qua
            }
        }

        /// <summary>
        /// Trả lại màu nền tương ứng khi rê chuột ra khỏi thẻ
        /// </summary>
        private void ucConversationItem_MouseLeave(object sender, EventArgs e)
        {
            UpdateBackground();
        }

        /// <summary>
        /// Ghi đè sự kiện click để kích hoạt sự kiện ConversationSelected gửi tín hiệu chọn thẻ về Form cha quản lý
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            ConversationSelected?.Invoke(this, Conversation);
        }
    }
}
