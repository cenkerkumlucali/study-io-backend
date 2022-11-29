using Domain.Entities;
using Domain.Entities.Feeds;
using Domain.Entities.Users;
using Domain.Enums;

namespace Application.Abstractions.Services;

public interface IMentionService
{
    Task<List<Mention>> MentionMembers(User user, Post post);
}