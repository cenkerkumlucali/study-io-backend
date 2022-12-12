using MediatR;

namespace Application.Features.Lesson.Queries.GetListBySubCategory;

public class GetListBySubCategoryQueryRequest:IRequest<List<GetListBySubCategoryQueryResponse>>
{
    public int SubCategoryId { get; set; }
}