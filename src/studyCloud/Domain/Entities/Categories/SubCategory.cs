using Core.Persistence.Repositories;

namespace Domain.Entities.Categories;

public class SubCategory:Entity
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public virtual Category Category { get; set; }

    public SubCategory()
    {
        
    }

    public SubCategory(int id, int categoryId, string name) : this()
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
    }
}