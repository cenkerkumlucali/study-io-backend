using Application.Features.Users.User.Dtos;

namespace Application.Abstractions.Services;

public interface ISearchUserService
{
    Task<IList<UserDto>> GetUserAutoComplete(string text);
    Task<List<int>> GetUserIdsByTextLike(string text);
    Task CheckMatchingUser(string text, IList<int> userIds);
}