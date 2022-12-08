using MediatR;

namespace Application.Features.Lessons.Lesson.Queries.GetListLessonSubjects;

public class GetListLessonSubjectsQueryRequest : IRequest<List<GetListLessonSubjectsQueryResponse>>
{
}