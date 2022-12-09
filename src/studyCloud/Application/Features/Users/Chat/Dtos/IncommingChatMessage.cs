namespace Application.Features.Users.Chat.Dtos;

public class IncommingChatMessage
{
    public string Message { get; set; }
    public long FromId { get; set; }
    public string FromUserName { get; set; }
    public long ToId { get; set; }
    public string ToUserName { get; set; }
    public string Type { get; set; }
    public bool IsTypeSet => !String.IsNullOrWhiteSpace(Type);
}