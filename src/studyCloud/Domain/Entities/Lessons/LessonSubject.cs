using Domain.Entities.Common;
using Domain.Entities.Quizzes;

namespace Domain.Entities.Lessons;

public class LessonSubject : BaseEntity
{
    public string Name { get; set; }
    public long? ParentId { get; set; }
    public long LessonId { get; set; }
    public virtual Lesson Lesson { get; set; }
    public virtual LessonSubject Parent { get; set; }
    public virtual ICollection<LessonSubject>? Children { get; set; }
    public virtual ICollection<Quiz>? Quizzes { get; set; }

}