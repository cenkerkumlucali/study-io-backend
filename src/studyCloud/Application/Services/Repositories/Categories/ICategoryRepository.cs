using Domain.Entities.Categories;

namespace Application.Services.Repositories.Categories;

public interface ICategoryRepository:IAsyncRepository<Category>,IRepository<Category>
{
    
}