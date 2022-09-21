using Application.Features.Category.Dtos;
using Application.Features.SubCategory.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.SubCategory.Models;

public class SubCategoryListModel:BasePageableModel
{
    public IList<ListSubCategoryDto> Items { get; set; }
}