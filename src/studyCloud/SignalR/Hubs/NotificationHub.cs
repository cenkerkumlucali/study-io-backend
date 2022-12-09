using Application.Features.Users.User.Dtos;
using Application.Repositories.Services.Users;
using Domain.Entities.Users;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace SignalR.Hubs;

public class NotificationHub : Hub<INotificationClient>
{
    private static readonly Dictionary<String, User> Users = new Dictionary<String, User>();
    private readonly IUserRepository _userRepository;

    public NotificationHub(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public void RegisterUser(User OnlineUser)
    {
        NotificationHub.Users.Add(Context.ConnectionId, OnlineUser);
        UpdateUserList();
    }
    public override Task OnConnectedAsync()
    {
        UpdateUserList();
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        if (Users.ContainsKey(Context.ConnectionId))
        {
            Users.Remove(Context.ConnectionId);
            UpdateUserList();
        }

        return base.OnDisconnectedAsync(exception);
    }

    private Task UpdateUserList()
    {
        List<UserDto> usersList = _userRepository.GetAllAsync(include: c => c.Include(c => c.UserImageFiles)).Result
            .Select(x => new
                UserDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FullName = $"{x.FirstName} {x.LastName}",
                    PictureUrl = x.UserImageFiles.LastOrDefault()?.Url
                }).ToList();
        foreach (var user in usersList)
        {
            if (Users.Values.Any(x => x.Id == user.Id))
            {
                user.IsOnline = true;
            }
            
        }

        return Clients.All.UpdatedUserList(usersList);
    }
}