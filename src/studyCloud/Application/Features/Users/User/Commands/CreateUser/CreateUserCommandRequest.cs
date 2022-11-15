using Application.Abstractions.Pipelines.Authorization;
using Application.Features.Users.User.Dtos;
using MediatR;

namespace Application.Features.Users.User.Commands.CreateUser;

public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }


   
}