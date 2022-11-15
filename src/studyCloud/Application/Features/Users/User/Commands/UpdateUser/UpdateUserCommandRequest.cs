using Application.Abstractions.Pipelines.Authorization;
using Application.Features.Users.User.Dtos;
using MediatR;
using static Application.Features.Users.User.Constants.OperationClaims;

namespace Application.Features.Users.User.Commands.UpdateUser;

public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
}