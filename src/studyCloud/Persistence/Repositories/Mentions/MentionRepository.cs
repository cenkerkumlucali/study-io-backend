using Application.Repositories.Services.Mentions;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Mentions;

public class MentionRepository:EfRepositoryBase<Mention,BaseDbContext>,IMentionRepository
{
    public MentionRepository(BaseDbContext context) : base(context)
    {
    }
}