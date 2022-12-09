namespace SignalR.Hubs;

public interface INotificationClient
{
    Task MessageToUser(Object outgoingMessage);
    Task UpdatedUserList(Object onlineUsers);   
}