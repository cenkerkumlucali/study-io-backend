using Core.Persistence.Repositories;

namespace Domain.Entities.Categories;

public class Category:Entity
{ 
    public string Name { get; set; }

    public Category()
    {
        
    }

    public Category(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}