using Application.Services.Repositories.Categories;
using Domain.Entities.Categories;
using Persistence.Contexts;

namespace Persistence.Repositories.Categories;

public class CategoryRepository:EfRepositoryBase<Category,BaseDbContext>,ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }
}