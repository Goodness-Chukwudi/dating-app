using System;

namespace API.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderUsername { get; set; }
        public AppUser Sender { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverUsername { get; set; }
        public AppUser Receiver { get; set; }
        public string Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime DateSent { get; set; } = DateTime.UtcNow;
        public bool SenderDeleted { get; set; } = false;
        public bool ReceiverDeleted { get; set; } = false;
    }
}