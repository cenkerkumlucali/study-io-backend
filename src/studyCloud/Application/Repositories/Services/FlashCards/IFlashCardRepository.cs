using Domain.Entities;

namespace Application.Repositories.Services.FlashCards;

public interface IFlashCardRepository:IAsyncRepository<FlashCard>,IRepository<FlashCard>
{
    
}