using Application.Repositories.Services.Publishers;
using Domain.Entities.ImageFile;
using Persistence.Contexts;

namespace Persistence.Repositories.Publishers;

public class PublisherImageRepository:EfRepositoryBase<PublisherImage,BaseDbContext>,IPublisherImageRepository
{
    public PublisherImageRepository(BaseDbContext context) : base(context)
    {
    }
}