using Application.Features.Users.UserCoin.Dtos;
using MediatR;

namespace Application.Features.Users.UserCoin.Commands.DeleteUserCoin;

public class DeleteUserCoinCommandRequest:IRequest<DeleteUserCoinCommandResponse>
{
    public int Id { get; set; }
   
}