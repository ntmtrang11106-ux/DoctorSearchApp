using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Tier
{
    /// <summary>
    /// UserControl quản lý giao diện nhắn tin chính giữa Bệnh nhân và Bác sĩ.
    /// Hỗ trợ nạp danh sách hội thoại, hiển thị tin nhắn thời gian thực dạng bong bóng,
    /// tự động co giãn bong bóng tin nhắn và tối ưu hóa hiệu năng bằng cơ chế cập nhật từng phần (không giật nháy).
    /// </summary>
    public partial class ucPatient_Chat : UserControl
    {
        private readonly ChatBUS _chatBUS = new ChatBUS();
        
        // Thông tin phiên đăng nhập hiện tại của người dùng
        private int _profileId;
        private string _role;
        private int _userId;

        private List<ConversationDTO> _conversations = new List<ConversationDTO>();
        
        // Cuộc hội thoại hiện đang được mở và tương tác
        private ConversationDTO _activeConversation = null;
        
        // Item hiển thị cuộc hội thoại đang được lựa chọn trên giao diện danh sách bên trái
        private ucConversationItem _selectedItem = null;

        /// <summary>
        /// Hàm khởi tạo của ucPatient_Chat
        /// </summary>
        public ucPatient_Chat()
        {
            InitializeComponent();
            
            // Kích hoạt Double Buffered chống nhấp nháy giao diện khi cuộn danh sách hội thoại/tin nhắn dài
            UIHelper.SetDoubleBuffered(this);
        }

        /// <summary>
        /// Xử lý thiết lập ban đầu khi UserControl được tải lên (được gọi tự động qua sự kiện Load đã cấu hình trong Designer)
        /// </summary>
        private void ucPatient_Chat_Load(object sender, EventArgs e)
        {
            // Lấy thông tin tài khoản đang đăng nhập trong hệ thống phục vụ định danh chat
            _profileId = GlobalAccount.GetProfileId();
            _role = GlobalAccount.GetRole();
            _userId = GlobalAccount.GetUserId();

            // Sử dụng UIHelper để bo tròn các khung giao diện theo thiết kế hiện đại (Layout scaled 3x)
            UIHelper.ApplyRoundedRegion(lblHeaderAvatar, 45); // Ảnh đại diện dạng tròn (bán kính 45 cho kích thước 90x90)
            UIHelper.ApplyRoundedRegion(btnSend, 25); // Nút gửi tin nhắn dạng tròn (bán kính 25 cho kích thước 50x50)

            // Thiết lập Placeholder động gợi ý tìm kiếm theo vai trò (Bác sĩ/Bệnh nhân)
            string searchPlaceholder = _role == "Patient" ? "Tìm kiếm bác sĩ..." : "Tìm kiếm bệnh nhân...";
            UIHelper.SetupPlaceholder(txtSearch, searchPlaceholder);
            UIHelper.SetupPlaceholder(txtInput, "Nhập tin nhắn...");

            // Cấu hình thanh cuộn mượt mà (Smooth Scrolling) cho các danh sách cuộn dọc
            UIHelper.SetupSmoothScrolling(flowConversations);
            UIHelper.SetupSmoothScrolling(flowMessages);

            // Sự kiện SizeChanged để tự động tính toán lại chiều rộng của toàn bộ bong bóng chat khi kéo giãn cửa sổ
            flowMessages.SizeChanged += (s, ev) =>
            {
                if (flowMessages.Controls.Count == 0) return;
                flowMessages.SuspendLayout();
                
                // Trừ đi khoảng cách 40px an toàn để không xuất hiện thanh cuộn ngang (Horizontal Scrollbar)
                int newWidth = flowMessages.ClientSize.Width - 50;
                foreach (Control ctrl in flowMessages.Controls)
                {
                    if (ctrl is ucMessageBubble bubble)
                    {
                        bubble.UpdateWidth(newWidth);
                    }
                }
                flowMessages.ResumeLayout(true);
            };

            // Khởi động Timer thăm dò tin nhắn mới và cập nhật danh sách hội thoại tự động (Thiết lập 4000ms trong Designer)
            pollTimer.Start();



            // Tải danh sách hội thoại lần đầu tiên
            LoadConversations();
        }

        /// <summary>
        /// Kích hoạt khi chuyển đổi tab hoặc thay đổi trạng thái hiển thị của UserControl
        /// </summary>
        private void ucPatient_Chat_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadConversations();
            }
        }

        /// <summary>
        /// Sự kiện Tick của Timer định kỳ (4 giây một lần) chạy ngầm để cập nhật dữ liệu tự động
        /// </summary>
        private void PollTimer_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                // Chỉ cập nhật dữ liệu của danh sách hội thoại thay vì vẽ lại (tránh nhấp nháy màn hình)
                RefreshConversationsOnly();
                
                // Nếu đang mở một khung chat cụ thể, nạp thêm tin nhắn mới phát sinh (nếu có)
                if (_activeConversation != null)
                {
                    RefreshActiveMessages();
                }
            }
        }

        /// <summary>
        /// Tải danh sách các cuộc hội thoại từ Cơ sở dữ liệu và hiển thị lên FlowLayoutPanel bên trái
        /// </summary>
        /// <param name="filterText">Từ khóa lọc tìm kiếm tên đối phương trò chuyện</param>
        private void LoadConversations(string filterText = "")
        {
            if (_profileId <= 0) return;

            try
            {
                // Gọi Bus lấy toàn bộ cuộc trò chuyện của người dùng hiện tại
                _conversations = _chatBUS.GetConversations(_profileId, _role);

                // Thực hiện lọc theo từ khóa tìm kiếm (nếu người dùng nhập từ khóa hợp lệ)
                var listToDisplay = _conversations;
                if (!string.IsNullOrWhiteSpace(filterText) && filterText != "Tìm kiếm..." && filterText != "Tìm kiếm bác sĩ..." && filterText != "Tìm kiếm bệnh nhân...")
                {
                    listToDisplay = _conversations.Where(c =>
                    {
                        string partnerName = "";
                        if (_role == "Patient")
                        {
                            partnerName = c.Doctor?.User?.FullName ?? "";
                        }
                        else
                        {
                            partnerName = c.Patient?.User?.FullName ?? "";
                        }
                        return partnerName.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0;
                    }).ToList();
                }

                // Tạm hoãn vẽ giao diện để tối ưu hóa hiệu năng render danh sách
                flowConversations.SuspendLayout();
                flowConversations.Controls.Clear();

                foreach (var conv in listToDisplay)
                {
                    var item = new ucConversationItem();
                    int unread = _chatBUS.GetUnreadCount(conv.Id, _userId);
                    
                    // Gán dữ liệu hội thoại và số lượng tin nhắn chưa đọc vào item
                    item.SetData(conv, _role, unread);
                    item.Width = flowConversations.ClientSize.Width - 25; // Cân chỉnh padding thanh cuộn đứng

                    // Lắng nghe sự kiện click chọn cuộc hội thoại từ Item
                    item.ConversationSelected += (s, selectedConv) =>
                    {
                        SelectConversation(selectedConv, item);
                    };

                    // Duy trì trạng thái active (đang chọn) nếu cuộc trò chuyện này đang mở
                    if (_activeConversation != null && _activeConversation.Id == conv.Id)
                    {
                        _selectedItem = item;
                        item.IsSelected = true;
                    }

                    flowConversations.Controls.Add(item);
                }

                flowConversations.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải danh sách hội thoại: " + ex.Message);
            }
        }

        /// <summary>
        /// Chỉ làm mới dữ liệu của các Item trong danh sách hội thoại (Tránh việc Clear và Add lại liên tục gây giật lag)
        /// </summary>
        private void RefreshConversationsOnly()
        {
            if (_profileId <= 0) return;

            try
            {
                var latestConvs = _chatBUS.GetConversations(_profileId, _role);

                // Duyệt qua các Item hội thoại đang hiển thị trên giao diện và cập nhật thông tin mới nhất
                foreach (Control ctrl in flowConversations.Controls)
                {
                    if (ctrl is ucConversationItem item && item.Conversation != null)
                    {
                        var updated = latestConvs.FirstOrDefault(c => c.Id == item.Conversation.Id);
                        if (updated != null)
                        {
                            int unread = _chatBUS.GetUnreadCount(updated.Id, _userId);
                            item.SetData(updated, _role, unread);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi RefreshConversationsOnly: " + ex.Message);
            }
        }

        /// <summary>
        /// Thiết lập trạng thái hiển thị chi tiết khi chọn một cuộc hội thoại cụ thể
        /// </summary>
        /// <param name="conv">DTO chứa thông tin hội thoại</param>
        /// <param name="selectedItem">Control hiển thị dòng hội thoại tương ứng</param>
        private void SelectConversation(ConversationDTO conv, ucConversationItem selectedItem)
        {
            // Bỏ chọn dòng hội thoại cũ
            if (_selectedItem != null)
            {
                _selectedItem.IsSelected = false;
            }

            // Gán dòng hội thoại mới hoạt động
            _selectedItem = selectedItem;
            _selectedItem.IsSelected = true;
            _activeConversation = conv;

            // Đánh dấu tất cả tin nhắn trong cuộc hội thoại này đã đọc
            _chatBUS.MarkAsRead(conv.Id, _userId);
            _selectedItem.SetData(conv, _role, 0); // Reset số lượng tin nhắn chưa đọc về 0 lập tức trên giao diện

            // Chuyển đổi hiển thị: Ẩn thông báo mặc định, hiện khung chat hoạt động
            pnlNoChatSelected.Visible = false;
            pnlChatActive.Visible = true;

            // Thiết lập thông tin Header bên phải (Tên, Ảnh đại diện đối phương)
            string partnerName = "Người dùng";
            string partnerPic = "";
            string partnerSpecialty = "";
            if (_role == "Patient")
            {
                partnerName = conv.Doctor?.User?.FullName ?? "Bác sĩ";
                partnerPic = conv.Doctor?.User?.Picture ?? "";
                partnerSpecialty = conv.Doctor?.Department?.DepartmentName ?? "Tim mạch";
            }
            else
            {
                partnerName = conv.Patient?.User?.FullName ?? "Bệnh nhân";
                partnerPic = conv.Patient?.User?.Picture ?? "";
                partnerSpecialty = "Bệnh nhân";
            }

            lblHeaderName.Text = (_role == "Patient" ? "BS. " : "") + partnerName;
            lblHeaderSpecialty.Text = partnerSpecialty;

            // Giải phóng vùng nhớ ảnh cũ của Header
            if (lblHeaderAvatar.Image != null)
            {
                lblHeaderAvatar.Image.Dispose();
                lblHeaderAvatar.Image = null;
            }

            // Tiến hành tải ảnh đại diện từ thư mục tài nguyên cục bộ
            bool imageLoaded = false;
            if (!string.IsNullOrWhiteSpace(partnerPic))
            {
                string imageFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images");
                string imagePath = System.IO.Path.Combine(imageFolder, partnerPic.Trim());
                if (System.IO.File.Exists(imagePath))
                {
                    try
                    {
                        using (var fs = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            var bmp = new Bitmap(fs);
                            lblHeaderAvatar.Image = new Bitmap(bmp, new Size(90, 90));
                            imageLoaded = true;
                        }
                    }
                    catch { }
                }
            }

            // Nếu không có hình ảnh, hiển thị ký tự cái tên đầu tiên làm biểu tượng đại diện
            if (imageLoaded)
            {
                lblHeaderAvatar.Text = "";
            }
            else
            {
                lblHeaderAvatar.Text = string.IsNullOrEmpty(partnerName) ? "?" : partnerName[0].ToString().ToUpper();
            }

            // Tải toàn bộ danh sách tin nhắn của cuộc trò chuyện được chọn
            LoadMessages(conv.Id);
        }

        /// <summary>
        /// Nạp và hiển thị toàn bộ lịch sử tin nhắn dạng bong bóng chat
        /// </summary>
        /// <param name="conversationId">Mã định danh cuộc hội thoại cần tải</param>
        private void LoadMessages(int conversationId)
        {
            try
            {
                var messages = _chatBUS.GetMessages(conversationId);

                // Tạm hoãn vẽ giao diện flowMessages để tránh giật lag khi render hàng loạt bong bóng tin nhắn
                flowMessages.SuspendLayout();
                flowMessages.Controls.Clear();

                foreach (var msg in messages)
                {
                    var bubble = new ucMessageBubble();
                    bool isSender = (msg.SenderID == _userId);
                    
                    // Chiều rộng bong bóng = chiều rộng khung chứa trừ đi khoảng cách đệm 40px an toàn
                    bubble.SetMessage(msg, isSender, flowMessages.ClientSize.Width - 40);
                    // Đăng ký sự kiện thu hồi tin nhắn
                    bubble.MessageRecalled += (s, msgId) => {
                        RecallMessage(msgId);
                    };
                    flowMessages.Controls.Add(bubble);
                }

                flowMessages.ResumeLayout(true);
                
                // Tự động cuộn xuống cuối cùng để xem tin nhắn mới nhất
                ScrollChatToBottom();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nạp tin nhắn: " + ex.Message);
            }
        }

        /// <summary>
        /// Chỉ nạp thêm các tin nhắn mới phát sinh (Dành cho cơ chế Polling chạy ngầm, tránh vẽ lại toàn bộ)
        /// </summary>
        private void RefreshActiveMessages()
        {
            if (_activeConversation == null) return;

            try
            {
                var messages = _chatBUS.GetMessages(_activeConversation.Id);
                int currentBubbleCount = flowMessages.Controls.Count;

                // Nếu số lượng tin nhắn trong Cơ sở dữ liệu lớn hơn số lượng bong bóng đang hiển thị
                if (messages.Count > currentBubbleCount)
                {
                    flowMessages.SuspendLayout();

                    // Chỉ nạp thêm các tin nhắn mới vào cuối danh sách
                    for (int i = currentBubbleCount; i < messages.Count; i++)
                    {
                        var msg = messages[i];
                        var bubble = new ucMessageBubble();
                        bool isSender = (msg.SenderID == _userId);
                        bubble.SetMessage(msg, isSender, flowMessages.ClientSize.Width - 40);
                        // Đăng ký sự kiện thu hồi tin nhắn
                        bubble.MessageRecalled += (s, msgId) => {
                            RecallMessage(msgId);
                        };
                        flowMessages.Controls.Add(bubble);
                    }

                    flowMessages.ResumeLayout(true);
                    ScrollChatToBottom();

                    // Đánh dấu đã đọc các tin nhắn mới
                    _chatBUS.MarkAsRead(_activeConversation.Id, _userId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi RefreshActiveMessages: " + ex.Message);
            }
        }

        /// <summary>
        /// Cuộn FlowLayoutPanel chứa tin nhắn xuống vị trí tin nhắn cuối cùng
        /// </summary>
        private void ScrollChatToBottom()
        {
            if (flowMessages.Controls.Count > 0)
            {
                Control lastControl = flowMessages.Controls[flowMessages.Controls.Count - 1];
                flowMessages.ScrollControlIntoView(lastControl);
            }
        }

        /// <summary>
        /// Lọc danh sách cuộc trò chuyện mỗi khi thay đổi văn bản tìm kiếm
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchVal = txtSearch.Text.Trim();
            if (searchVal == "Tìm kiếm..." || searchVal == "Tìm kiếm bác sĩ..." || searchVal == "Tìm kiếm bệnh nhân...")
            {
                LoadConversations();
            }
            else
            {
                LoadConversations(searchVal);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút gửi tin nhắn
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessageFromInput();
        }

        /// <summary>
        /// Xử lý gửi tin nhắn nhanh bằng phím Enter (không kèm Shift)
        /// </summary>
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true; // Ngăn tiếng bíp mặc định của Windows Forms và ngăn tạo dòng mới
                SendMessageFromInput();
            }
        }

        /// <summary>
        /// Thực hiện gửi tin nhắn từ ô nhập liệu lên Cơ sở dữ liệu và hiển thị lên giao diện
        /// </summary>
        private void SendMessageFromInput()
        {
            string content = txtInput.Text.Trim();
            
            // Bỏ qua nếu tin nhắn rỗng hoặc chỉ là văn bản gợi ý (Placeholder)
            if (string.IsNullOrEmpty(content) || content == "Nhập tin nhắn...") return;

            if (_activeConversation == null) return;

            try
            {
                // 1. Lưu tin nhắn vào Cơ sở dữ liệu thông qua BUS
                var sentMsg = _chatBUS.SendMessage(_activeConversation.Id, _userId, content);

                // 2. Làm sạch ô nhập liệu và đưa con trỏ tập trung lại ô nhập tin nhắn
                txtInput.Text = "";
                txtInput.Focus();

                // 3. Tải tin nhắn mới lên giao diện tức thời và cập nhật nội dung xem trước ở danh sách bên trái
                RefreshActiveMessages();
                RefreshConversationsOnly();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể gửi tin nhắn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Sự kiện click nút Emoji để hiển thị ContextMenu nhanh các icon
        private void btnEmoji_Click(object sender, EventArgs e)
        {
            ContextMenuStrip emojiMenu = new ContextMenuStrip();
            string[] emojis = { "😊", "👍", "❤️", "😆", "😮", "😢", "🙏", "👏", "😷", "💉" };
            foreach (var emoji in emojis)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(emoji);
                item.Click += (s, ev) =>
                {
                    if (txtInput.Text == "Nhập tin nhắn...")
                    {
                        txtInput.Text = emoji;
                        txtInput.ForeColor = Color.Black;
                    }
                    else
                    {
                        txtInput.Text += emoji;
                    }
                    txtInput.Focus();
                };
                emojiMenu.Items.Add(item);
            }
            emojiMenu.Show(btnEmoji, new Point(0, -emojiMenu.Height));
        }

        private void pnlSearchBox_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (pnl.Parent != null)
            {
                using (SolidBrush parentBrush = new SolidBrush(pnl.Parent.BackColor))
                {
                    e.Graphics.FillRectangle(parentBrush, pnl.ClientRectangle);
                }
            }
            Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            using (System.Drawing.Drawing2D.GraphicsPath path = UIHelper.GetRoundedPath(rect, 15))
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(249, 250, 251)))
                {
                    e.Graphics.FillPath(brush, path);
                }
                using (Pen pen = new Pen(Color.FromArgb(209, 213, 219), 1))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void pnlInputBox_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (pnl.Parent != null)
            {
                using (SolidBrush parentBrush = new SolidBrush(pnl.Parent.BackColor))
                {
                    e.Graphics.FillRectangle(parentBrush, pnl.ClientRectangle);
                }
            }
            Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            using (System.Drawing.Drawing2D.GraphicsPath path = UIHelper.GetRoundedPath(rect, 20))
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(249, 250, 251)))
                {
                    e.Graphics.FillPath(brush, path);
                }
                using (Pen pen = new Pen(Color.FromArgb(209, 213, 219), 1))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        // Sự kiện click nút đính kèm để mở tệp tin
        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (_activeConversation == null) return;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Tất cả tập tin|*.*|Ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tài liệu|*.pdf;*.doc;*.docx;*.xls;*.xlsx;*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileName = System.IO.Path.GetFileName(ofd.FileName);
                        string ext = System.IO.Path.GetExtension(ofd.FileName).ToLower();
                        
                        string messageType = "File";
                        if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif" || ext == ".bmp")
                        {
                            messageType = "Image";
                        }

                        string uploadDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads", "attachments");
                        if (!System.IO.Directory.Exists(uploadDir)) System.IO.Directory.CreateDirectory(uploadDir);

                        string uniqueFileName = $"chat_{_activeConversation.Id}_{DateTime.Now.Ticks}{ext}";
                        string destPath = System.IO.Path.Combine(uploadDir, uniqueFileName);
                        string relativePath = System.IO.Path.Combine("uploads", "attachments", uniqueFileName);

                        System.IO.File.Copy(ofd.FileName, destPath, true);

                        // Gửi tin nhắn chứa tệp đính kèm thông qua BUS
                        var sentMsg = _chatBUS.SendMessage(_activeConversation.Id, _userId, fileName, messageType, fileName, relativePath);

                        if (sentMsg != null)
                        {
                            RefreshActiveMessages();
                            RefreshConversationsOnly();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải tệp lên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Sự kiện click nút tùy chọn góc trên bên phải
        private void btnOptions_Click(object sender, EventArgs e)
        {
            if (_activeConversation == null) return;

            ContextMenuStrip optionsMenu = new ContextMenuStrip();
            
            ToolStripMenuItem viewProfileItem = new ToolStripMenuItem("Xem thông tin đối phương");
            viewProfileItem.Click += (s, ev) => ViewPartnerProfile();
            optionsMenu.Items.Add(viewProfileItem);

            ToolStripMenuItem deleteConvItem = new ToolStripMenuItem("Xóa cuộc trò chuyện");
            deleteConvItem.ForeColor = Color.Red;
            deleteConvItem.Click += (s, ev) => DeleteActiveConversation();
            optionsMenu.Items.Add(deleteConvItem);

            optionsMenu.Show(btnOptions, new Point(0, btnOptions.Height));
        }

        // Xem thông tin chi tiết của đối phương trò chuyện
        private void ViewPartnerProfile()
        {
            if (_activeConversation == null) return;

            string partnerName = "";
            string details = "";
            
            if (_role == "Patient")
            {
                var doc = _activeConversation.Doctor;
                if (doc != null)
                {
                    partnerName = doc.User?.FullName ?? "Bác sĩ";
                    details = $"Họ tên bác sĩ: {partnerName}\n" +
                              $"Chuyên khoa: {doc.Department?.DepartmentName}\n" +
                              $"Học vị/Chức vụ: {doc.Position}\n" +
                              $"Kinh nghiệm: {doc.ExperienceYears} năm\n" +
                              $"Phí khám: {doc.ConsultationFee:N0} VNĐ\n" +
                              $"Số điện thoại: {doc.User?.PhoneNumber}";
                }
            }
            else
            {
                var pat = _activeConversation.Patient;
                if (pat != null)
                {
                    partnerName = pat.User?.FullName ?? "Bệnh nhân";
                    details = $"Họ tên bệnh nhân: {partnerName}\n" +
                              $"Mã y tế: {pat.MedicalCode}\n" +
                              $"Nhóm máu: {pat.BloodType}\n" +
                              $"Số điện thoại: {pat.User?.PhoneNumber}\n" +
                              $"Ghi chú y khoa: {pat.Note}";
                }
            }

            MessageBox.Show(details, $"Thông tin: {partnerName}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa cuộc trò chuyện hoạt động (Soft Delete)
        private void DeleteActiveConversation()
        {
            if (_activeConversation == null) return;

            var confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa cuộc trò chuyện này? Toàn bộ lịch sử sẽ bị ẩn.", 
                "Xác nhận xóa cuộc trò chuyện", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                bool success = _chatBUS.DeleteConversation(_activeConversation.Id);
                if (success)
                {
                    _activeConversation = null;
                    _selectedItem = null;
                    pnlChatActive.Visible = false;
                    pnlNoChatSelected.Visible = true;
                    LoadConversations();
                    MessageBox.Show("Đã xóa cuộc trò chuyện thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể xóa cuộc trò chuyện.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Thu hồi tin nhắn và nạp lại lịch sử
        private void RecallMessage(int msgId)
        {
            var confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn thu hồi tin nhắn này?", 
                "Thu hồi tin nhắn", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                bool success = _chatBUS.RecallMessage(msgId);
                if (success)
                {
                    if (_activeConversation != null)
                    {
                        LoadMessages(_activeConversation.Id);
                        RefreshConversationsOnly();
                    }
                }
                else
                {
                    MessageBox.Show("Không thể thu hồi tin nhắn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblHeaderName_Click(object sender, EventArgs e)
        {
            ShowOptionsAtControl(lblHeaderName);
        }

        private void lblHeaderAvatar_Click(object sender, EventArgs e)
        {
            ShowOptionsAtControl(lblHeaderAvatar);
        }

        private void ShowOptionsAtControl(Control ctrl)
        {
            ContextMenuStrip optionsMenu = new ContextMenuStrip();
            
            ToolStripMenuItem viewProfileItem = new ToolStripMenuItem("Xem thông tin đối phương");
            viewProfileItem.Click += (s, ev) => ViewPartnerProfile();
            optionsMenu.Items.Add(viewProfileItem);

            ToolStripMenuItem deleteConvItem = new ToolStripMenuItem("Xóa cuộc trò chuyện");
            deleteConvItem.ForeColor = Color.Red;
            deleteConvItem.Click += (s, ev) => DeleteActiveConversation();
            optionsMenu.Items.Add(deleteConvItem);

            optionsMenu.Show(ctrl, new Point(0, ctrl.Height));
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {
            if (_activeConversation == null) return;
            string partnerName = _role == "Patient" 
                ? (_activeConversation.Doctor?.User?.FullName ?? "Bác sĩ")
                : (_activeConversation.Patient?.User?.FullName ?? "Bệnh nhân");
            MessageBox.Show($"Đang kết nối cuộc gọi thoại đến {partnerName}...", "Cuộc gọi thoại", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            if (_activeConversation == null) return;
            string partnerName = _role == "Patient" 
                ? (_activeConversation.Doctor?.User?.FullName ?? "Bác sĩ")
                : (_activeConversation.Patient?.User?.FullName ?? "Bệnh nhân");
            MessageBox.Show($"Đang kết nối cuộc gọi video đến {partnerName}...", "Cuộc gọi video", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            if (_activeConversation == null) return;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "Chọn ảnh gửi đi";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileName = System.IO.Path.GetFileName(ofd.FileName);
                        string ext = System.IO.Path.GetExtension(ofd.FileName).ToLower();

                        string uploadDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads", "attachments");
                        if (!System.IO.Directory.Exists(uploadDir)) System.IO.Directory.CreateDirectory(uploadDir);

                        string uniqueFileName = $"chat_{_activeConversation.Id}_{DateTime.Now.Ticks}{ext}";
                        string destPath = System.IO.Path.Combine(uploadDir, uniqueFileName);
                        string relativePath = System.IO.Path.Combine("uploads", "attachments", uniqueFileName);

                        System.IO.File.Copy(ofd.FileName, destPath, true);

                        var sentMsg = _chatBUS.SendMessage(_activeConversation.Id, _userId, fileName, "Image", fileName, relativePath);

                        if (sentMsg != null)
                        {
                            RefreshActiveMessages();
                            RefreshConversationsOnly();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi gửi ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
