using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class LessonModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int ExpForWatching { get; set; }
        public  Guid VideoModelId { get; set; } 
        public virtual VideoModel VideoModel { get; set; }
    }
}
