using Application.Features.FlashCards.Rules;
using Application.Repositories.Services.FlashCards;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FlashCards.Commands.CreateFlashCard;

public class CreateFlashCardCommandHandler:IRequestHandler<CreateFlashCardCommandRequest,CreateFlashCardCommandResponse>
{
    private readonly IFlashCardRepository _flashCardRepository;
    private readonly FlashCardBusinessRules _flashCardBusinessRules;
    private IMapper _mapper;

    public CreateFlashCardCommandHandler(IFlashCardRepository flashCardRepository, IMapper mapper, FlashCardBusinessRules flashCardBusinessRules)
    {
        _flashCardRepository = flashCardRepository;
        _mapper = mapper;
        _flashCardBusinessRules = flashCardBusinessRules;
    }

    public async Task<CreateFlashCardCommandResponse> Handle(CreateFlashCardCommandRequest request, CancellationToken cancellationToken)
    {
        FlashCard? mappedFlashCard = _mapper.Map<FlashCard>(request);
        await _flashCardBusinessRules.FlashCardNotSame(mappedFlashCard);
        FlashCard createdFlashCard = await _flashCardRepository.AddAsync(mappedFlashCard);
        CreateFlashCardCommandResponse? mappedCreatedFlashCard = _mapper.Map<CreateFlashCardCommandResponse>(createdFlashCard);
        return mappedCreatedFlashCard;
    }
}