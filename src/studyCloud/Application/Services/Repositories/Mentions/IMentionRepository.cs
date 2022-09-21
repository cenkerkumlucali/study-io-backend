using Core.Persistence.Repositories;
using Domain.Entities.Mentions;

namespace Application.Services.Repositories.Mentions;

public interface IMentionRepository:IAsyncRepository<Mention>,IRepository<Mention>
{
    
}