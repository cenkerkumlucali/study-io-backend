using Application.Features.Category.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Category.Models;

public class CategoryListModel:BasePageableModel
{
    public IList<ListCategoryDto> Items { get; set; }
}