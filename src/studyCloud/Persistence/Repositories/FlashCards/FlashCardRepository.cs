using Application.Repositories.Services.FlashCards;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.FlashCards;

public class FlashCardRepository:EfRepositoryBase<FlashCard,BaseDbContext>,IFlashCardRepository
{
    public FlashCardRepository(BaseDbContext context) : base(context)
    {
    }
}