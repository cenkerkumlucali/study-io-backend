using Application.Repositories.Services.FlashCards;
using AutoMapper;
using MediatR;

namespace Application.Features.FlashCard.Commands.UpdateFlashCard;

public class
    UpdateFlashCardCommandHandler : IRequestHandler<UpdateFlashCardCommandRequest, UpdateFlashCardCommandResponse>
{
    private readonly IFlashCardRepository _flashCardRepository;
    private IMapper _mapper;

    public UpdateFlashCardCommandHandler(IFlashCardRepository flashCardRepository, IMapper mapper)
    {
        _flashCardRepository = flashCardRepository;
        _mapper = mapper;
    }

    public async Task<UpdateFlashCardCommandResponse> Handle(UpdateFlashCardCommandRequest request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.FlashCard? flashCard = await _flashCardRepository.GetAsync(c => c.Id == request.Id);
        Domain.Entities.FlashCard? mappedFlashCard = _mapper.Map(request, flashCard);
        Domain.Entities.FlashCard updatedFlashCard = await _flashCardRepository.UpdateAsync(mappedFlashCard);
        UpdateFlashCardCommandResponse? mappedUpdatedFlashCard = _mapper.Map<UpdateFlashCardCommandResponse>(updatedFlashCard);
        return mappedUpdatedFlashCard;
    }
}