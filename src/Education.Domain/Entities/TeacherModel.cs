using Education.Domain.Entities.Auth;
using System;

namespace Education.Domain.Entities
{
    public class TeacherModel
    {
        public string Id { get; set; }
        public virtual UserModel User { get; set; }
        public virtual ICollection<CourseModel> Courses { get; set; } // Navigation property
    }
}
