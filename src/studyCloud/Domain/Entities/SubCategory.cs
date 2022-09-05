using Core.Persistence.Repositories;

namespace Domain.Entities;

public class SubCategory:Entity
{
    public int CategoryId { get; set; }
    public string Name { get; set; }

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