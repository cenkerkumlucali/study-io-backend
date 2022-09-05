using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CategoryRepository:EfRepositoryBase<Category,BaseDbContext>,ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }
}