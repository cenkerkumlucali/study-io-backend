using Domain.Entities.Common;

namespace Domain.Entities.Categories;

public class Category:BaseEntity
{ 
    public string Name { get; set; }
    public virtual IList<SubCategory> SubCategories { get; set; }
}