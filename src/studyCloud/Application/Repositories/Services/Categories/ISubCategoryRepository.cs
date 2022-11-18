using Domain.Entities.Categories;

namespace Application.Repositories.Services.Categories;

public interface ISubCategoryRepository:IAsyncRepository<SubCategory>,IRepository<SubCategory>
{
    
}