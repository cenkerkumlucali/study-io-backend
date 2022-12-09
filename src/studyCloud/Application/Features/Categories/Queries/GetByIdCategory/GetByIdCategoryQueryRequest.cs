using MediatR;

namespace Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQueryRequest:IRequest<GetByIdCategoryQueryResponse>
{
    public long Id { get; set; }
   
}