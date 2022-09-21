using Application.Services.Repositories.Mentions;
using Core.Persistence.Repositories;
using Domain.Entities.Mentions;
using Persistence.Contexts;

namespace Persistence.Repositories.Mentions;

public class MentionRepository:EfRepositoryBase<Mention,BaseDbContext>,IMentionRepository
{
    public MentionRepository(BaseDbContext context) : base(context)
    {
    }
}