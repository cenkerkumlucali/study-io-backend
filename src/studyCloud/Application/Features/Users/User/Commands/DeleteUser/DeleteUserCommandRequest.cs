using Application.Abstractions.Pipelines.Authorization;
using Application.Features.Users.User.Dtos;
using MediatR;

namespace Application.Features.Users.User.Commands.DeleteUser;

public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
{
    public int Id { get; set; }
}