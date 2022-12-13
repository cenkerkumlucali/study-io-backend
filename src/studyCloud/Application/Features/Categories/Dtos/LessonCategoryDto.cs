using Application.Features.Lesson.Dtos;
using Application.Features.SubCategories.Dtos;

namespace Application.Features.Categories.Dtos;

public class LessonCategoryDto
{
    public string Name { get; set; }
    public List<LessonDto>? Lessons { get; set; }
    public List<LessonSubCategoryDto>? SubCategories { get; set; }
}