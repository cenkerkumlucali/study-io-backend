using Application.Abstractions.Services;
using Application.Features.Users.Chat.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Chat.Commands.SendMessage;

public class SendMessageCommandHandler:IRequestHandler<SendMessageCommandRequest,SendMessageCommandResponse>
{
    private readonly IChatService _chatService;
    private IMapper _mapper;

    public SendMessageCommandHandler(IChatService chatService, IMapper mapper)
    {
        _chatService = chatService;
        _mapper = mapper;
    }

    public async Task<SendMessageCommandResponse> Handle(SendMessageCommandRequest request, CancellationToken cancellationToken)
    {
        IncommingChatMessage? incommingChatMessage = _mapper.Map<IncommingChatMessage>(request);
        OutgoingChatMessage sendMessage = await _chatService.SendMessageAsync(incommingChatMessage);
        SendMessageCommandResponse? mappedMessage = _mapper.Map<SendMessageCommandResponse>(sendMessage);
        return mappedMessage;
    }
}