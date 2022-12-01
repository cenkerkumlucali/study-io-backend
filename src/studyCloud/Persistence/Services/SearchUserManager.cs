using Application.Abstractions.Services;
using Application.Features.Users.User.Dtos;
using Application.Repositories.Services.Users;
using Domain.Entities.Users;

namespace Persistence.Services;

public class SearchUserManager : ISearchUserService
{
    private static int SEARCH_SIZE = 50;
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;

    public SearchUserManager(IUserRepository userRepository, IUserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }

    public async Task<IList<UserDto>> GetUserAutoComplete(string text)
    {
        string keyword = text.Trim().ToLower();
        List<int> userIds = await GetUserIdsByTextLike(keyword);
        await CheckMatchingUser(keyword, userIds);
        IList<User> members = await _userService.GetAllByIdIn(userIds);
        return members.Select(c => new UserDto
        {
            Id = c.Id,
            UserName = c.UserName,
            FullName = c.FirstName + " " + c.LastName,
            PictureUrl = c.UserImageFiles.FirstOrDefault()?.Url
        }).ToList();
    }

    public async Task<List<int>> GetUserIdsByTextLike(string text)
    {
        return (await _userRepository.GetListAsync(c => c.UserName.StartsWith(text))).Items.Select(c => c.Id).ToList();
    }

    public async Task CheckMatchingUser(string text, IList<int> userIds)
    {
        User? matchingSearch = await _userRepository.GetAsync(c => c.UserName == text);
        if (matchingSearch != null && !userIds.Contains(matchingSearch.Id))
        {
            userIds.Add(matchingSearch.Id);
            checkSearchSize(userIds);
        }
    }

    private void checkSearchSize(IList<int> list)
    {
        while (list.Count > SEARCH_SIZE)
        {
            list.Remove(list.Count - 1);
        }
    }
}