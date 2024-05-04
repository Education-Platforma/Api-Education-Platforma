using Education.Domain.Entities.Auth;
using System;

namespace Education.Domain.Entities
{
    public class MessageModel
    {
        public Guid Id { get; set; } 
        public string Message { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public Guid GroupId { get; set; }
        public string SenderId { get; set; }

        public virtual GroupModel Group { get; set; }

        public virtual UserModel Sender { get; set; }
    }
}
