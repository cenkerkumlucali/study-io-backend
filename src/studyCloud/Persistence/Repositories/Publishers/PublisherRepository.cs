using Application.Repositories.Services.Publishers;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Publishers;

public class PublisherRepository:EfRepositoryBase<Publisher,BaseDbContext>,IPublisherRepository
{
    public PublisherRepository(BaseDbContext context) : base(context)
    {
    }
}