using Domain.Entities.Common;
using Domain.Entities.Lessons;

namespace Domain.Entities.Categories;

public class Category:BaseEntity
{ 
    public string Name { get; set; }
    public virtual IList<SubCategory> SubCategories { get; set; }
    public virtual List<Lesson> Lessons { get; set; }
}