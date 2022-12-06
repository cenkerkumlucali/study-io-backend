namespace Application.Features.Lessons.LessonSubject.Dtos;

public class LessonSubjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<LessonSubjectDto> Children { get; set; }
}