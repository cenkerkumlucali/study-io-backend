using Domain.Entities;

namespace Application.Repositories.Services.Mentions;

public interface IMentionRepository:IAsyncRepository<Mention>,IRepository<Mention>
{
    
}