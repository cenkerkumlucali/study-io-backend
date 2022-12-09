using MediatR;

namespace Application.Features.SubCategories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommandRequest:IRequest<UpdateSubCategoryCommandResponse>
{
    public long Id { get; set; }
    public string Name { get; set; }
    
}