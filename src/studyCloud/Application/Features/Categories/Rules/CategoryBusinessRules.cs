using Application.Services.Repositories.Categories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities.Categories;

namespace Application.Features.Categories.Rules;

public class CategoryBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task CategoryNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<Category> result = await _categoryRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException("Category name exists.");
    }
}