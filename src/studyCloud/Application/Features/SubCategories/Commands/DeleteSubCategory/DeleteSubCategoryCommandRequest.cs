using MediatR;

namespace Application.Features.SubCategories.Commands.DeleteSubCategory;

public class DeleteSubCategoryCommandRequest:IRequest<DeleteSubCategoryCommandResponse>
{
    public int Id { get; set; }
    
}