using Application.Abstractions.Services.Paging;
using Application.Exceptions;
using Application.Features.Categories.Constants;
using Application.Services.Repositories.Categories;
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
        if (result.Items.Any()) throw new BusinessException(Messages.NameExists);
    }
    public void CategoryShouldExistWhenRequested(Category category)
    {
        if (category == null) throw new BusinessException(Messages.DoesNotExists);
    }
}