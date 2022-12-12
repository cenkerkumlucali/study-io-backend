using Application.Repositories.Services.FlashCards;
using AutoMapper;
using MediatR;

namespace Application.Features.FlashCard.Commands.DeleteFlashCard;

public class DeleteFlashCardCommandHandler:IRequestHandler<DeleteFlashCardCommandRequest,DeleteFlashCardCommandResponse>
{
    private readonly IFlashCardRepository _flashCardRepository;
    private IMapper _mapper;

    public DeleteFlashCardCommandHandler(IFlashCardRepository flashCardRepository, IMapper mapper)
    {
        _flashCardRepository = flashCardRepository;
        _mapper = mapper;
    }

    public async Task<DeleteFlashCardCommandResponse> Handle(DeleteFlashCardCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.FlashCard? flashCard = await  _flashCardRepository.GetAsync(c=>c.Id == request.Id);
        Domain.Entities.FlashCard deletedFlashCard = await _flashCardRepository.DeleteAsync(flashCard);
        DeleteFlashCardCommandResponse? mappedDeletedUser = _mapper.Map<DeleteFlashCardCommandResponse>(deletedFlashCard);
        return mappedDeletedUser;
    }
}