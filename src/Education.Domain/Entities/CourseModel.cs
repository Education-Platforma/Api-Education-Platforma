using Education.Domain.Entities.Auth;
using Education.Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Education.Domain.Entities
{
    public class CourseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CourseName { get; set; }
        public string Description { get; set; }
        public double TotalTime { get; set; } = 0;
        public double Price { get; set; }
        public int SoldCount { get; set; } = 0;
        public string Language { get; set; }
        public CourseActivityModel Activity { get; set; } = CourseActivityModel.Blocked;
        public Guid CouponId { get; set; }
        public string TeacherId { get; set; } // Updated property name
        public Guid CategoryId { get; set; }
        public virtual CouponModel Coupon { get; set; }
        public virtual TeacherModel Teacher { get; set; } // Navigation property
        public virtual CategoryModel Category { get; set; }
        public virtual ICollection<LessonModel> Lessons { get; set; }
        public virtual ICollection<CourseFeedbackModel> CourseFeedbacks { get; set; }
    }
}
