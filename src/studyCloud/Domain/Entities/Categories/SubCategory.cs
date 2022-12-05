using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.Categories;

public class SubCategory : BaseEntity
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int? ParentId { get; set; }
    public virtual SubCategory Parent { get; set; }
    public virtual Category Category { get; set; }
}