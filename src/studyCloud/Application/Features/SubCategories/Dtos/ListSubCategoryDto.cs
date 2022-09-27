using Domain.Entities.Categories;

namespace Application.Features.SubCategories.Dtos;

public class ListSubCategoryDto
{
    public int Id { get; set; }
    public Category Category { get; set; }
    public string Name { get; set; }
}