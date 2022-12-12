using Application.Repositories.Services.FlashCards;
using AutoMapper;
using MediatR;

namespace Application.Features.FlashCard.Commands.CreateFlashCard;

public class CreateFlashCardCommandHandler:IRequestHandler<CreateFlashCardCommandRequest,CreateFlashCardCommandResponse>
{
    private readonly IFlashCardRepository _flashCardRepository;
    private IMapper _mapper;

    public CreateFlashCardCommandHandler(IFlashCardRepository flashCardRepository, IMapper mapper)
    {
        _flashCardRepository = flashCardRepository;
        _mapper = mapper;
    }

    public async Task<CreateFlashCardCommandResponse> Handle(CreateFlashCardCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.FlashCard? mappedFlashCard = _mapper.Map<Domain.Entities.FlashCard>(request);
        Domain.Entities.FlashCard createdFlashCard = await _flashCardRepository.AddAsync(mappedFlashCard);
        CreateFlashCardCommandResponse? mappedCreatedFlashCard = _mapper.Map<CreateFlashCardCommandResponse>(createdFlashCard);
        return mappedCreatedFlashCard;
    }
}