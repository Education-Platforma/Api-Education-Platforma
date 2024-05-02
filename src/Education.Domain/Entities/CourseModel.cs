using Education.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Entities
{
    public class CourseModel
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public double TotalTime { get; set; }
        public double Price { get; set; }
        public int SoldCount { get; set; }
        public string Language { get; set;}
        //Pasdagi ma'lumotlargaCRUD amali bo'lmaydi
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public Guid CouponId { get; set; }
        public virtual CouponModel Coupon { get; set; }
        public Guid CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }

        public virtual List<LessonModel> Lessons { get; set; }
        public virtual List<CourseFeedbackModel> Feedbacs { get; set; }
    }
}
