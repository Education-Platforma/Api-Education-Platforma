using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.LessonCase.Commands
{
    public class CreateLessonCommand : IRequest<ResponseModel>
    {
        public string Title { get; set; }
        public int ExpForWatching { get; set; }
        public Guid VideoModelId { get; set; }
        public Guid CourseId { get; set; }
    }
}
