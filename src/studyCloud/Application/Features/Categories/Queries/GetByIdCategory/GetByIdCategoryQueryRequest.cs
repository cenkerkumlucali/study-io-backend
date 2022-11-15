using MediatR;

namespace Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQueryRequest:IRequest<GetByIdCategoryCommandResponse>
{
    public int Id { get; set; }
   
}