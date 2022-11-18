using MediatR;

namespace Application.Features.SubCategories.Queries.GetByIdSubCategory;

public class GetByIdSubCategoryQueryRequest:IRequest<GetByIdSubCategoryQueryResponse>
{
    public int Id { get; set; }
   
}