using Application.DTOs.Paging;
using Application.Features.Categories.Queries.GetListCategory;

namespace Application.Features.Categories.Models;

public class CategoryListModel:BasePageableModel
{
    public IList<ListCategoryQueryResponse> Items { get; set; }
}