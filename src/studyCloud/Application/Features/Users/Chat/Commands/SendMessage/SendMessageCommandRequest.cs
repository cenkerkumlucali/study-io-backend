using MediatR;

namespace Application.Features.Users.Chat.Commands.SendMessage;

public class SendMessageCommandRequest:IRequest<SendMessageCommandResponse>
{
    public string Message { get; set; }
    public long FromId { get; set; }
    public long ToId { get; set; }
    public string Type { get; set; }
    public bool IsTypeSet => !String.IsNullOrWhiteSpace(Type);
}