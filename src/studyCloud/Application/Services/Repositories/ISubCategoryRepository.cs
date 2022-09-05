using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ISubCategoryRepository:IAsyncRepository<SubCategory>,IRepository<SubCategory>
{
    
}