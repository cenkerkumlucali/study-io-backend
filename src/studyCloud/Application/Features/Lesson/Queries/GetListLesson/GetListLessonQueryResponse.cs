using Application.Features.Lesson.Dtos;
using Application.Features.SubCategories.Dtos;

namespace Application.Features.Lesson.Queries.GetListLesson;

public class GetListLessonQueryResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<LessonDto>? Lessons { get; set; }
    public List<LessonSubCategoryDto>? SubCategories { get; set; }
}