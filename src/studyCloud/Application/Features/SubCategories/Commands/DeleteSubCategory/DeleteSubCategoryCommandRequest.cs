using MediatR;

namespace Application.Features.SubCategories.Commands.DeleteSubCategory;

public class DeleteSubCategoryCommandRequest:IRequest<DeleteSubCategoryCommandResponse>
{
    public long Id { get; set; }
    
}