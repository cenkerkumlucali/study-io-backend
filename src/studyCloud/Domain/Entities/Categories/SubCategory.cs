using Domain.Entities.Lessons;
using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.Categories;

public class SubCategory : BaseEntity
{
    public string Name { get; set; }
    public long CategoryId { get; set; }
    public long? ParentId { get; set; }
    public virtual SubCategory Parent { get; set; }
    public virtual Category Category { get; set; }
    public virtual List<Lesson> Lessons { get; set; }
    public virtual List<SubCategory> Children { get; set; }
}