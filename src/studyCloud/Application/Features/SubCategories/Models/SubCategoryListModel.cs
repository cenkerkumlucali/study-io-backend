using Application.Features.SubCategories.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.SubCategories.Models;

public class SubCategoryListModel:BasePageableModel
{
    public IList<ListSubCategoryDto> Items { get; set; }
}