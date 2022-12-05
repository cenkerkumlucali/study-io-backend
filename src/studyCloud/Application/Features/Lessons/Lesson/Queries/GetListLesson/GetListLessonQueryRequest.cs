using Application.Features.Lessons.Lesson.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Lessons.Lesson.Queries.GetListLesson;

public class GetListLessonQueryRequest:IRequest<LessonListModel>
{
    public PageRequest PageRequest { get; set; }
}