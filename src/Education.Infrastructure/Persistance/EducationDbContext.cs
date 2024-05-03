using Education.Application.Abstractions;
using Education.Domain.Entities;
using Education.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Infrastructure.Persistance
{
    public class EducationDbContext : IdentityDbContext<UserModel>, IEducationDbContext
    {
        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options) { }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CouponModel> Coupons { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<LessonModel> Lessons { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<QuizModel> Quizes { get; set; }
        public DbSet<StatisticModel> Statistics { get; set; }
        public DbSet<VideoModel> Videos { get; set; }
        public DbSet<CourseFeedbackModel> CourseFeedbacks { get; set; }
        public DbSet<VideoFeedbackModel> VideoFeedbacks { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<UserActivityModel> UserActivityModels { get; set; }
    }
}
