namespace Application.Features.Users.Chat.Dtos;

public class OutgoingChatMessage
{
    public long Id { get; set; }
    public string Message { get; set; }
    public string Type { get; set; }
    public long FromId { get; set; }
    public String FromUserName { get; set; }
    public long ToId { get; set; }
    public String ToUserName { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Url { get; set; }
}