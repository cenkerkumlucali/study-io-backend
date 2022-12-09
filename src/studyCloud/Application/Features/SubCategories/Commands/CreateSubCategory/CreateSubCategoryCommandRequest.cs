using MediatR;

namespace Application.Features.SubCategories.Commands.CreateSubCategory;

public class CreateSubCategoryCommandRequest:IRequest<CreateSubCategoryCommandResponse>
{
    public long CategoryId { get; set; }
    public long? ParentId { get; set; }
    public string Name { get; set; }
}