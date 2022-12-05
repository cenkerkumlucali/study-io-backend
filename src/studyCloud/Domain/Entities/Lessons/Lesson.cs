using Domain.Entities.Categories;
using Domain.Entities.Common;

namespace Domain.Entities.Lessons;

public class Lesson : BaseEntity
{
    public string Name { get; set; }
    public int SubCategoryId { get; set; }
    public virtual SubCategory SubCategory { get; set; }
    public virtual ICollection<LessonSubject> LessonSubjects { get; set; }
}