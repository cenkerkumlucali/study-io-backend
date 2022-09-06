using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Quiz:Entity
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }

    public Quiz()
    {
    }

    public Quiz(int id, int categoryId, int subCategoryId, string name) : this()
    {
        Id = id;
        Name = name;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
    }
}