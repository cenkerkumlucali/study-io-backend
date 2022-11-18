using Application.DTOs.User;
using Application.Features.Auths.Dtos;
using MediatR;

namespace Application.Features.Auths.Commands.Register;

public class RegisterCommandRequest : IRequest<RegisterCommandResponse>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IPAddress { get; set; }

    
}