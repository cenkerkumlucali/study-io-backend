using MediatR;

namespace Application.Features.Lessons.Lesson.Queries.GetLessonById;

public class GetByIdLessonQueryRequest:IRequest<List<GetByIdLessonQueryResponse>>
{
    public int Id { get; set; }
}