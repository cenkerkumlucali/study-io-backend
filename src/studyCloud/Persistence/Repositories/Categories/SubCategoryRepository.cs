using Application.Repositories.Services.Categories;
using Domain.Entities.Categories;
using Persistence.Contexts;

namespace Persistence.Repositories.Categories;

public class SubCategoryRepository:EfRepositoryBase<SubCategory,BaseDbContext>,ISubCategoryRepository
{
    public SubCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}