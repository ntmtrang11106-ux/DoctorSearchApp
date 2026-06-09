using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Tier
{
    public class ChatDAL
    {
        private readonly AppDbContext _context;

        public ChatDAL()
        {
            _context = new AppDbContext();
        }

        // Kiểm tra và khởi tạo dữ liệu mẫu nếu chưa có cuộc hội thoại nào
        public void SeedMockDataIfNeeded(int currentProfileId, string role)
        {
            try
            {
                if (_context.Conversations.Any()) return;

                // Lấy 4 bác sĩ đầu tiên và 4 bệnh nhân đầu tiên để làm liên hệ mẫu
                var doctors = _context.Doctors.Include(d => d.User).Take(4).ToList();
                var patients = _context.Patients.Include(p => p.User).Take(4).ToList();

                if (!doctors.Any() || !patients.Any()) return;

                // Chúng ta sẽ tạo ra một số cuộc hội thoại mẫu
                // Dựa trên ảnh: Nguyễn Văn A (Patient 1), Trần Thị B (Patient 2), Lê Văn C (Patient 3), Phạm Thị D (Patient 4)
                
                if (role == "Doctor")
                {
                    int docId = currentProfileId;
                    var currentDoc = _context.Doctors.Find(docId);
                    if (currentDoc == null) return;
                    int docUserId = currentDoc.UserId;

                    for (int i = 0; i < Math.Min(4, patients.Count); i++)
                    {
                        var patient = patients[i];
                        if (patient.User == null) continue;
                        
                        if (i == 0) patient.User.FullName = "Nguyễn Văn A";
                        else if (i == 1) patient.User.FullName = "Trần Thị B";
                        else if (i == 2) patient.User.FullName = "Lê Văn C";
                        else if (i == 3) patient.User.FullName = "Phạm Thị D";
                        
                        _context.Entry(patient.User).State = EntityState.Modified;

                        var conv = new ConversationDTO
                        {
                            PatientID = patient.Id,
                            DoctorID = docId,
                            LastMessage = i == 0 ? "Cảm ơn bác sĩ rất nhiều!" :
                                          i == 1 ? "Bác sĩ cho em hỏi về đơn thuốc..." :
                                          i == 2 ? "Em muốn đặt lịch tái khám" : "Triệu chứng đã giảm nhiều ạ",
                            LastActive = DateTime.Now.AddMinutes(-10 * (i + 1) - (i == 3 ? 1440 : 0)),
                            IsActive = true,
                            IsDeleted = false
                        };
                        _context.Conversations.Add(conv);
                        _context.SaveChanges();

                        if (i == 0)
                        {
                            var msg1 = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = patient.UserId,
                                Content = "Chào bác sĩ, em muốn hỏi về kết quả xét nghiệm",
                                SentAt = DateTime.Now.AddMinutes(-72),
                                IsRead = true,
                                MessageType = "Text"
                            };
                            var msg2 = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = docUserId,
                                Content = "Chào bạn, kết quả xét nghiệm của bạn đã về. Các chỉ số đều trong ngưỡng bình thường.",
                                SentAt = DateTime.Now.AddMinutes(-67),
                                IsRead = true,
                                MessageType = "Text"
                            };
                            var msg3 = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = patient.UserId,
                                Content = "Vậy em có cần tái khám không ạ?",
                                SentAt = DateTime.Now.AddMinutes(-65),
                                IsRead = true,
                                MessageType = "Text"
                            };
                            var msg4 = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = docUserId,
                                Content = "Bạn nên tái khám sau 2 tuần để theo dõi. Bạn có thể đặt lịch qua hệ thống.",
                                SentAt = DateTime.Now.AddMinutes(-62),
                                IsRead = true,
                                MessageType = "Text"
                            };
                            var msg5 = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = patient.UserId,
                                Content = "Cảm ơn bác sĩ rất nhiều!",
                                SentAt = DateTime.Now.AddMinutes(-60),
                                IsRead = true,
                                MessageType = "Text"
                            };

                            _context.Messages.AddRange(msg1, msg2, msg3, msg4, msg5);
                        }
                        else
                        {
                            var msg = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = patient.UserId,
                                Content = conv.LastMessage,
                                SentAt = conv.LastActive,
                                IsRead = false,
                                MessageType = "Text"
                            };
                            _context.Messages.Add(msg);
                        }
                    }
                }
                else // Vai trò hiện tại là Patient:
                {
                    int patId = currentProfileId;
                    var currentPat = _context.Patients.Find(patId);
                    if (currentPat == null) return;
                    int patUserId = currentPat.UserId;

                    for (int i = 0; i < Math.Min(4, doctors.Count); i++)
                    {
                        var doctor = doctors[i];
                        if (doctor.User == null) continue;

                        if (i == 0) doctor.User.FullName = "Nguyễn Văn A";
                        else if (i == 1) doctor.User.FullName = "Trần Thị B";
                        else if (i == 2) doctor.User.FullName = "Lê Văn C";
                        else if (i == 3) doctor.User.FullName = "Phạm Thị D";

                        _context.Entry(doctor.User).State = EntityState.Modified;

                        var conv = new ConversationDTO
                        {
                            PatientID = patId,
                            DoctorID = doctor.Id,
                            LastMessage = i == 0 ? "Cảm ơn bác sĩ rất nhiều!" :
                                          i == 1 ? "Bác sĩ cho em hỏi về đơn thuốc..." :
                                          i == 2 ? "Em muốn đặt lịch tái khám" : "Triệu chứng đã giảm nhiều ạ",
                            LastActive = DateTime.Now.AddMinutes(-10 * (i + 1) - (i == 3 ? 1440 : 0)),
                            IsActive = true,
                            IsDeleted = false
                        };
                        _context.Conversations.Add(conv);
                        _context.SaveChanges();

                        if (i == 0)
                        {
                            var msg1 = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = patUserId,
                                Content = "Chào bác sĩ, em muốn hỏi về kết quả xét nghiệm",
                                SentAt = DateTime.Now.AddMinutes(-72),
                                IsRead = true,
                                MessageType = "Text"
                            };
                            var msg2 = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = doctor.UserId,
                                Content = "Chào bạn, kết quả xét nghiệm của bạn đã về. Các chỉ số đều trong ngưỡng bình thường.",
                                SentAt = DateTime.Now.AddMinutes(-67),
                                IsRead = true,
                                MessageType = "Text"
                            };
                            var msg3 = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = patUserId,
                                Content = "Vậy em có cần tái khám không ạ?",
                                SentAt = DateTime.Now.AddMinutes(-65),
                                IsRead = true,
                                MessageType = "Text"
                            };
                            var msg4 = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = doctor.UserId,
                                Content = "Bạn nên tái khám sau 2 tuần để theo dõi. Bạn có thể đặt lịch qua hệ thống.",
                                SentAt = DateTime.Now.AddMinutes(-62),
                                IsRead = true,
                                MessageType = "Text"
                            };
                            var msg5 = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = patUserId,
                                Content = "Cảm ơn bác sĩ rất nhiều!",
                                SentAt = DateTime.Now.AddMinutes(-60),
                                IsRead = true,
                                MessageType = "Text"
                            };

                            _context.Messages.AddRange(msg1, msg2, msg3, msg4, msg5);
                        }
                        else
                        {
                            var msg = new MessagesDTO
                            {
                                ConversationId = conv.Id,
                                SenderID = doctor.UserId,
                                Content = conv.LastMessage,
                                SentAt = conv.LastActive,
                                IsRead = false,
                                MessageType = "Text"
                            };
                            _context.Messages.Add(msg);
                        }
                    }
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error seeding mock chat data: " + ex.Message);
            }
        }

        // Lấy danh sách hội thoại hoạt động (IsActive == true && IsDeleted == false)
        public List<ConversationDTO> GetConversations(int profileId, string role)
        {
            SeedMockDataIfNeeded(profileId, role);

            int currentUserId = -1;
            if (role == "Patient") {
                var p = _context.Patients.Find(profileId);
                if (p != null) currentUserId = p.UserId;
            } else {
                var d = _context.Doctors.Find(profileId);
                if (d != null) currentUserId = d.UserId;
            }

            List<ConversationDTO> convs;
            if (role == "Patient")
            {
                convs = _context.Conversations
                    .Include(c => c.Doctor).ThenInclude(d => d.User)
                    .Where(c => c.PatientID == profileId && c.IsActive && !c.IsDeleted)
                    .OrderByDescending(c => c.LastActive)
                    .ToList();
            }
            else
            {
                convs = _context.Conversations
                    .Include(c => c.Patient).ThenInclude(p => p.User)
                    .Where(c => c.DoctorID == profileId && c.IsActive && !c.IsDeleted)
                    .OrderByDescending(c => c.LastActive)
                    .ToList();
            }

            // Cập nhật LastMessage hiển thị dựa trên lịch sử xóa của user hiện tại
            foreach (var c in convs)
            {
                var clearTime = _context.Messages
                    .Where(m => m.ConversationId == c.Id && m.SenderID == currentUserId && m.MessageType == "System_Clear")
                    .Max(m => (DateTime?)m.SentAt);

                if (clearTime.HasValue)
                {
                    var realLast = _context.Messages
                        .Where(m => m.ConversationId == c.Id && m.MessageType != "System_Clear" && m.SentAt >= clearTime.Value && !m.IsDeleted)
                        .OrderByDescending(m => m.SentAt)
                        .FirstOrDefault();

                    if (realLast != null)
                        c.LastMessage = realLast.MessageType == "Text" ? realLast.Content : $"[{realLast.MessageType}] {realLast.AttachmentName}";
                    else
                        c.LastMessage = "Gửi lời chào";
                }
            }
            return convs;
        }

        public List<MessagesDTO> GetMessages(int conversationId, int currentUserId)
        {
            var clearTime = _context.Messages
                .Where(m => m.ConversationId == conversationId && m.SenderID == currentUserId && m.MessageType == "System_Clear")
                .Max(m => (DateTime?)m.SentAt);

            DateTime filterTime = clearTime ?? DateTime.MinValue;

            return _context.Messages
                .Include(m => m.Sender)
                .Where(m => m.ConversationId == conversationId && m.MessageType != "System_Clear" && m.SentAt >= filterTime)
                .OrderBy(m => m.SentAt)
                .ToList();
        }

        // Đánh dấu tin nhắn hoạt động đã nhận là đã đọc
        public void MarkAsRead(int conversationId, int currentUserId)
        {
            var unreadMsgs = _context.Messages
                .Where(m => m.ConversationId == conversationId && m.SenderID != currentUserId && !m.IsRead && !m.IsDeleted)
                .ToList();

            if (unreadMsgs.Any())
            {
                foreach (var msg in unreadMsgs)
                {
                    msg.IsRead = true;
                    msg.ReadAt = DateTime.Now;
                }
                _context.SaveChanges();
            }
        }

        // Lấy số lượng tin nhắn chưa đọc và chưa bị xóa
        public int GetUnreadCount(int conversationId, int currentUserId)
        {
            return _context.Messages.Count(m => m.ConversationId == conversationId && m.SenderID != currentUserId && !m.IsRead && !m.IsDeleted);
        }

        // Gửi tin nhắn mới có hỗ trợ MessageType, AttachmentName, AttachmentPath
        public MessagesDTO SendMessage(int conversationId, int senderUserId, string content, string messageType = "Text", string attachmentName = null, string attachmentPath = null)
        {
            var msg = new MessagesDTO
            {
                ConversationId = conversationId,
                SenderID = senderUserId,
                Content = content,
                SentAt = DateTime.Now,
                IsRead = false,
                MessageType = messageType,
                AttachmentName = attachmentName,
                AttachmentPath = attachmentPath
            };

            _context.Messages.Add(msg);

            var conv = _context.Conversations.Find(conversationId);
            if (conv != null)
            {
                conv.LastMessage = messageType == "Text" ? content : $"[{messageType}] {attachmentName}";
                conv.LastActive = DateTime.Now;
            }

            _context.SaveChanges();
            return msg;
        }

        // Lấy hoặc tạo mới/khôi phục cuộc hội thoại giữa Patient và Doctor
        public ConversationDTO GetOrCreateConversation(int patientId, int doctorId)
        {
            var conv = _context.Conversations
                .Include(c => c.Patient).ThenInclude(p => p.User)
                .Include(c => c.Doctor).ThenInclude(d => d.User)
                .FirstOrDefault(c => c.PatientID == patientId && c.DoctorID == doctorId);

            if (conv == null)
            {
                conv = new ConversationDTO
                {
                    PatientID = patientId,
                    DoctorID = doctorId,
                    LastMessage = "Bắt đầu cuộc trò chuyện",
                    LastActive = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                };
                _context.Conversations.Add(conv);
                _context.SaveChanges();

                // Nạp đầy đủ thông tin để tránh NullReference ở UI
                _context.Entry(conv).Reference(c => c.Patient).Query().Include(p => p.User).Load();
                _context.Entry(conv).Reference(c => c.Doctor).Query().Include(d => d.User).Load();
            }
            else if (conv.IsDeleted || !conv.IsActive)
            {
                conv.IsDeleted = false;
                conv.IsActive = true;
                conv.LastActive = DateTime.Now;
                _context.SaveChanges();
            }

            return conv;
        }

        // Xóa lịch sử cuộc hội thoại (Clear History cho 1 người)
        public bool DeleteConversation(int conversationId, int userId)
        {
            var conv = _context.Conversations.Find(conversationId);
            if (conv != null)
            {
                // Thêm một tin nhắn hệ thống đánh dấu mốc xóa lịch sử
                var clearMsg = new MessagesDTO
                {
                    ConversationId = conversationId,
                    SenderID = userId,
                    Content = "System_Clear",
                    MessageType = "System_Clear",
                    SentAt = DateTime.Now,
                    IsRead = true
                };
                _context.Messages.Add(clearMsg);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Thu hồi tin nhắn (Soft Delete) và cập nhật LastMessage phù hợp
        public bool RecallMessage(int messageId)
        {
            var msg = _context.Messages.Find(messageId);
            if (msg != null)
            {
                msg.IsDeleted = true;
                msg.DeletedAt = DateTime.Now;

                msg.UpdatedAt = DateTime.Now;

                // Cập nhật LastMessage hiển thị ngoài danh sách hội thoại
                var conv = _context.Conversations.Find(msg.ConversationId);
                if (conv != null)
                {
                    var lastActiveMsg = _context.Messages
                        .Where(m => m.ConversationId == msg.ConversationId && !m.IsDeleted && m.Id != messageId)
                        .OrderByDescending(m => m.SentAt)
                        .FirstOrDefault();

                    if (lastActiveMsg != null)
                    {
                        conv.LastMessage = lastActiveMsg.MessageType == "Text" 
                            ? lastActiveMsg.Content 
                            : $"[{lastActiveMsg.MessageType}] {lastActiveMsg.AttachmentName}";
                    }
                    else
                    {
                        conv.LastMessage = "Tin nhắn đã bị thu hồi";
                    }
                    conv.UpdatedAt = DateTime.Now;
                }

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Chỉnh sửa tin nhắn
        public bool EditMessage(int messageId, string newContent)
        {
            var msg = _context.Messages.Find(messageId);
            if (msg != null && !msg.IsDeleted && msg.MessageType == "Text")
            {
                msg.Content = newContent;
                msg.EditedAt = DateTime.Now;
                msg.UpdatedAt = DateTime.Now;

                var conv = _context.Conversations.Find(msg.ConversationId);
                if (conv != null)
                {
                    var lastActiveMsg = _context.Messages
                        .Where(m => m.ConversationId == msg.ConversationId && !m.IsDeleted)
                        .OrderByDescending(m => m.SentAt)
                        .FirstOrDefault();

                    if (lastActiveMsg != null && lastActiveMsg.Id == messageId)
                    {
                        conv.LastMessage = newContent;
                    }
                    conv.UpdatedAt = DateTime.Now;
                }

                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
