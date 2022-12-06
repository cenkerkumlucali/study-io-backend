using MediatR;

namespace Application.Features.Lessons.Lesson.Queries.GetListLesson;

public class GetListLessonQueryRequest : IRequest<List<GetListLessonQueryResponse>>
{
}