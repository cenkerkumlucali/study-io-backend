using Domain.Entities.Categories;

namespace Application.Services.Repositories.Categories;

public interface ISubCategoryRepository:IAsyncRepository<SubCategory>,IRepository<SubCategory>
{
    
}