using Domain.Entities.Categories;
using Domain.Entities.Lessons;
using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.Quizzes;

public class Quiz:BaseEntity
{
    public string Name { get; set; }
    public int? SubCategoryId { get; set; }
    public int? LessonId { get; set; }
    public int? LessonSubjectId { get; set; }
    public virtual Lesson Lesson { get; set; }
    public virtual LessonSubject LessonSubject { get; set; }
    public virtual SubCategory SubCategory { get; set; }
    public virtual List<Question> Questions { get; set; }
}