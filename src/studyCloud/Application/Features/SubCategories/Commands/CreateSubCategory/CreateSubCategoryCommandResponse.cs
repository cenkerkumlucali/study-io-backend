namespace Application.Features.SubCategories.Dtos;

public class CreateSubCategoryCommandResponse
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
}