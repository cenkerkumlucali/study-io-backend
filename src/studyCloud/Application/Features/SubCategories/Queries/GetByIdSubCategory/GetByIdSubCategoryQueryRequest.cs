using MediatR;

namespace Application.Features.SubCategories.Queries.GetByIdSubCategory;

public class GetByIdSubCategoryQueryRequest:IRequest<GetByIdSubCategoryQueryResponse>
{
    public long Id { get; set; }
   
}