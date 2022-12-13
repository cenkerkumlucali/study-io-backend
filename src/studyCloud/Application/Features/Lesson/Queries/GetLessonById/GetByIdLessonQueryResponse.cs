using Application.Features.LessonSubject.Dtos;

namespace Application.Features.Lesson.Queries.GetLessonById;

public class GetByIdLessonQueryResponse
{
    public string CategoryName { get; set; }
    public string SubCategoryName { get; set; }
    public string Name { get; set; }
    public List<LessonSubjectDto>? Subjects { get; set; }
}