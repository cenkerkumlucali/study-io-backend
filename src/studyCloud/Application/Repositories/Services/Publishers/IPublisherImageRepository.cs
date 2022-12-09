using Domain.Entities.ImageFile;

namespace Application.Repositories.Services.Publishers;

public interface IPublisherImageRepository: IAsyncRepository<PublisherImage>, IRepository<PublisherImage>
{
    
}