using MediatR;

namespace Application.Features.SubCategories.Commands.CreateSubCategory;

public class CreateSubCategoryCommandRequest:IRequest<CreateSubCategoryCommandResponse>
{
    public int CategoryId { get; set; }
    public int? ParentId { get; set; }
    public string Name { get; set; }
}