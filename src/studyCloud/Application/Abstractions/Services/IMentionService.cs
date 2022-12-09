using Domain.Entities;
using Domain.Entities.Comments;
using Domain.Entities.Feeds;
using Domain.Entities.Users;
using Domain.Enums;

namespace Application.Abstractions.Services;

public interface IMentionService
{
    Task<List<Mention>> MentionMembers(User user, Post post);
    Task<List<Mention>> MentionMembers(User user, Comment comment);
    Task<bool> DeleteAll(Post post);
    Task<bool> DeleteAll(List<long> comments);
}