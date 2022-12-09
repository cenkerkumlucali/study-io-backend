using Application.Abstractions.Services;
using Application.Features.Users.Chat.Dtos;
using Application.Repositories.Services.Users;
using Domain.Entities.Users;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;

namespace Persistence.Services;

public class ChatManager:IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly IHubContext<NotificationHub, INotificationClient> _hubContext;
    
    public ChatManager(IChatRepository chatRepository, IHubContext<NotificationHub, INotificationClient> hubContext)
    {
        _chatRepository = chatRepository;
        _hubContext = hubContext;
    }

    public async Task<OutgoingChatMessage> SendMessageAsync(IncommingChatMessage incommingChatMessage)
    {
        Chat chatMessage = new Chat()
        {
            Message = incommingChatMessage.Message,
            ToId = incommingChatMessage.ToId,
            FromId = incommingChatMessage.FromId,
            Type=incommingChatMessage.Type,
        };
        await _chatRepository.AddAsync(chatMessage);
        OutgoingChatMessage outGoingMessage = new OutgoingChatMessage
        {
            Id = chatMessage.Id,
            FromId = chatMessage.FromId,
            ToId = chatMessage.ToId,
            Message = chatMessage.Message,
            CreatedAt = chatMessage.CreatedDate,
            UpdatedAt = chatMessage.UpdatedDate,
            FromUserName = incommingChatMessage.FromUserName,
            ToUserName = incommingChatMessage.ToUserName,
            Type= incommingChatMessage.Type,
        };
        await _hubContext.Clients.Users(
                incommingChatMessage.ToId.ToString(),outGoingMessage.FromId.ToString())
            .MessageToUser(outGoingMessage);
        return outGoingMessage;
    }
}