using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Quiz:Entity
{
    
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }

    public Quiz()
    {
        
    }

    public Quiz(int id, int categoryId, int subCategoryId) : this()
    {
        Id = id;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
    }
}