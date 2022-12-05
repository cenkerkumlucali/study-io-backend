using Application.Features.Lessons.LessonSubject.Dtos;

namespace Application.Features.Lessons.Lesson.Queries.GetListLesson;

public class GetListLessonQueryResponse
{
    public string SubCategoryName { get; set; }
    public string Name { get; set; }
    public ICollection<LessonSubjectDto> Subjects { get; set; }
}