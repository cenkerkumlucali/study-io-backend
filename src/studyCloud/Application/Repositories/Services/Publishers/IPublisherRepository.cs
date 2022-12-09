using Domain.Entities;

namespace Application.Repositories.Services.Publishers;

public interface IPublisherRepository: IAsyncRepository<Publisher>, IRepository<Publisher>
{
    
}