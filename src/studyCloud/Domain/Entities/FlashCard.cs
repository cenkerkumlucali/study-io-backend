using Domain.Entities.Common;
using Domain.Entities.Lessons;

namespace Domain.Entities;

public class FlashCard : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public long LessonSubjectId { get; set; }
    public LessonSubject LessonSubject { get; set; }
}