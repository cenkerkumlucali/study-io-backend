using Application.Exceptions;
using Application.Repositories.Services.FlashCards;
using Domain.Entities;

namespace Application.Features.FlashCards.Rules;

public class FlashCardBusinessRules
{
    private readonly IFlashCardRepository _flashCardRepository;

    public FlashCardBusinessRules(IFlashCardRepository flashCardRepository)
    {
        _flashCardRepository = flashCardRepository;
    }

    public async Task FlashCardNotSame(Domain.Entities.FlashCard flashCard)
    {
     FlashCard? checkedFlashCard =  await _flashCardRepository.GetAsync(c => c.Content == flashCard.Content && c.Title == flashCard.Title);
     if(checkedFlashCard is not null) throw new BusinessException("Bilgi kartı zaten ekli. Lütfen farklı bilgi kartı oluşturmayı deneyin veya girdiğiniz bilgileri kontrol ediniz");
    }
}