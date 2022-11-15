using MediatR;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandRequest:IRequest<DeletedCategoryCommandResponse>
{
    public int Id { get; set; }
   
}