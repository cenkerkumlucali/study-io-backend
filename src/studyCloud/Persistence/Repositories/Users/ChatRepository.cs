using Application.Repositories.Services.Users;
using Domain.Entities.Users;
using Persistence.Contexts;

namespace Persistence.Repositories.Users;

public class ChatRepository : EfRepositoryBase<Chat, BaseDbContext>, IChatRepository
{
    public ChatRepository(BaseDbContext context) : base(context)
    {
    }
}