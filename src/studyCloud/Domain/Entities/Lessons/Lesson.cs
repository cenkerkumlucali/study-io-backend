using Domain.Entities.Categories;
using Domain.Entities.Common;
using Domain.Entities.Quizzes;

namespace Domain.Entities.Lessons;

public class Lesson : BaseEntity
{
    public string Name { get; set; }
    public long SubCategoryId { get; set; }
    public virtual SubCategory SubCategory { get; set; }
    public virtual ICollection<LessonSubject> LessonSubjects { get; set; }
    public virtual ICollection<Quiz> Quizzes { get; set; }
}