using Application.Features.Lessons.LessonSubject.Dtos;

namespace Application.Features.Lessons.Lesson.Queries.GetLessonById;

public class GetByIdLessonQueryResponse
{
    public string SubCategoryName { get; set; }
    public string Name { get; set; }
    public List<LessonSubjectDto>? Subjects { get; set; }
}