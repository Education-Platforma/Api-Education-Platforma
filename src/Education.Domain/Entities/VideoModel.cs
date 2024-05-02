using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class VideoModel
    {
        public Guid Id {  get; set; }
        public string VideoPath { get; set; }
        public string Length { get; set; }
    }
}
