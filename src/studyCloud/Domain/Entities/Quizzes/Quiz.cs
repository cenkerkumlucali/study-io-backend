using Domain.Entities.Categories;
using Domain.Entities.Lessons;
using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.Quizzes;

public class Quiz:BaseEntity
{
    public string Name { get; set; }
    public long? SubCategoryId { get; set; }
    public long? LessonId { get; set; }
    public long? LessonSubjectId { get; set; }
    public long? PublisherId { get; set; }
    public virtual Lesson Lesson { get; set; }
    public virtual LessonSubject LessonSubject { get; set; }
    public virtual SubCategory SubCategory { get; set; }
    public virtual Publisher Publisher { get; set; }
    public virtual List<Question> Questions { get; set; }
}