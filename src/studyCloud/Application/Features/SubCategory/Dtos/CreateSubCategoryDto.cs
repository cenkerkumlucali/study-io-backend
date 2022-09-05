namespace Application.Features.SubCategory.Dtos;

public class CreateSubCategoryDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
}