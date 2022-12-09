using Application.Features.Users.Chat.Dtos;

namespace Application.Abstractions.Services;

public interface IChatService
{
    Task<OutgoingChatMessage> SendMessageAsync(IncommingChatMessage incommingChatMessage);
}