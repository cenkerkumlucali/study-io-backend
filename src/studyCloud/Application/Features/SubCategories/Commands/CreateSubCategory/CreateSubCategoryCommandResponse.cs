namespace Application.Features.SubCategories.Commands.CreateSubCategory;

public class CreateSubCategoryCommandResponse
{
    public long Id { get; set; }
    public long CategoryId { get; set; }
    public string Name { get; set; }
}