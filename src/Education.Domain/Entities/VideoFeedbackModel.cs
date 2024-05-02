using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class VideoFeedbackModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid VideoModelId { get; set; }
        public virtual VideoModel VideoModel { get; set; }
    }
}
