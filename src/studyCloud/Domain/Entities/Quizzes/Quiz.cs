using Domain.Entities.Categories;
using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.Quizzes;

public class Quiz:BaseEntity
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }
    public Category Category { get; set; }
    public SubCategory SubCategory { get; set; }


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