using Education.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class VideoFeedbackModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public Guid UserId {  get; set; }
        public Guid VideoFeadbackModelId { get; set; }
        public virtual UserModel User { get; set; }
    }
}
