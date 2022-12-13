using Application.Features.Lesson.Dtos;

namespace Application.Features.SubCategories.Dtos;

public class LessonSubCategoryDto
{
    public string Name { get; set; }
    public List<LessonDto> Lessons { get; set; }
    public List<LessonSubCategoryDto> Children { get; set; }
}