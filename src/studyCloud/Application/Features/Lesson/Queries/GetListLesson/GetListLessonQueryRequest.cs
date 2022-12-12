using MediatR;

namespace Application.Features.Lesson.Queries.GetListLesson;

public class GetListLessonQueryRequest:IRequest<List<GetListLessonQueryResponse>>
{
}