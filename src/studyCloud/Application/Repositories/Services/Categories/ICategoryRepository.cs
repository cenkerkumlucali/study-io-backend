using Domain.Entities.Categories;

namespace Application.Repositories.Services.Categories;

public interface ICategoryRepository:IAsyncRepository<Category>,IRepository<Category>
{
    
}