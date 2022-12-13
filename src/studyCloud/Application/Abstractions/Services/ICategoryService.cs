using Domain.Entities.Categories;

namespace Application.Abstractions.Services;

public interface ICategoryService
{
    Task<List<Category>> GetListAsync();
}