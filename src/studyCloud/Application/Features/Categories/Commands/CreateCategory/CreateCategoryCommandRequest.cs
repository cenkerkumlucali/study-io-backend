using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandRequest:IRequest<CreatedCategoryCommandResponse>
{
    public string Name { get; set; }
    
}