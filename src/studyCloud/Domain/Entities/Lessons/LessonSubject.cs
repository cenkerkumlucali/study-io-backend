using Domain.Entities.Common;

namespace Domain.Entities.Lessons;

public class LessonSubject : BaseEntity
{
    public string Name { get; set; }
    public int LessonId { get; set; }
    public int? ParentId { get; set; }
    public virtual LessonSubject Parent { get; set; }
    public virtual Lesson Lesson { get; set; }
}