using MediatR;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandRequest:IRequest<UpdatedCategoryCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
}