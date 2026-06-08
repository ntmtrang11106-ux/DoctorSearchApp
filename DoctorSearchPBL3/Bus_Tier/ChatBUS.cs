using DAL_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class ChatBUS
    {
        private readonly ChatDAL _chatDAL = new ChatDAL();

        public List<ConversationDTO> GetConversations(int profileId, string role)
        {
            if (profileId <= 0) return new List<ConversationDTO>();
            return _chatDAL.GetConversations(profileId, role);
        }

        public List<MessagesDTO> GetMessages(int conversationId)
        {
            if (conversationId <= 0) return new List<MessagesDTO>();
            return _chatDAL.GetMessages(conversationId);
        }

        public void MarkAsRead(int conversationId, int currentUserId)
        {
            if (conversationId <= 0 || currentUserId <= 0) return;
            _chatDAL.MarkAsRead(conversationId, currentUserId);
        }

        public int GetUnreadCount(int conversationId, int currentUserId)
        {
            if (conversationId <= 0 || currentUserId <= 0) return 0;
            return _chatDAL.GetUnreadCount(conversationId, currentUserId);
        }

        public MessagesDTO SendMessage(int conversationId, int senderUserId, string content)
        {
            if (conversationId <= 0 || senderUserId <= 0 || string.IsNullOrWhiteSpace(content))
                return null;

            return _chatDAL.SendMessage(conversationId, senderUserId, content.Trim());
        }

        public ConversationDTO GetOrCreateConversation(int patientId, int doctorId)
        {
            if (patientId <= 0 || doctorId <= 0) return null;
            return _chatDAL.GetOrCreateConversation(patientId, doctorId);
        }

        // Định dạng thời gian tương đối
        public string GetRelativeTimeString(DateTime dateTime)
        {
            TimeSpan timeSpan = DateTime.Now - dateTime;

            if (timeSpan.TotalDays < 0)
            {
                return dateTime.ToString("HH:mm");
            }
            
            if (timeSpan.TotalMinutes < 1)
            {
                return "Vừa xong";
            }
            
            if (timeSpan.TotalMinutes < 60)
            {
                return $"{(int)timeSpan.TotalMinutes} phút trước";
            }
            
            if (timeSpan.TotalHours < 24)
            {
                if (dateTime.Date == DateTime.Today)
                {
                    return $"{(int)timeSpan.TotalHours} giờ trước";
                }
            }

            if (dateTime.Date == DateTime.Today.AddDays(-1))
            {
                return "Hôm qua";
            }

            return dateTime.ToString("dd/MM/yyyy");
        }
    }
}
