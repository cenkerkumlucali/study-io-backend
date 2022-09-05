using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SubCategoryRepository:EfRepositoryBase<SubCategory,BaseDbContext>,ISubCategoryRepository
{
    public SubCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}