using Application.DTOs.Paging;
using Application.Features.SubCategories.Dtos;

namespace Application.Features.SubCategories.Models;

public class SubCategoryListModel:BasePageableModel
{
    public IList<ListSubCategoryQueryResponse> Items { get; set; }
}