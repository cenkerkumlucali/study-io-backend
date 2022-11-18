using MediatR;

namespace Application.Features.SubCategories.Commands.CreateSubCategory;

public class CreateSubCategoryCommandRequest:IRequest<CreateSubCategoryCommandResponse>
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    
    
}