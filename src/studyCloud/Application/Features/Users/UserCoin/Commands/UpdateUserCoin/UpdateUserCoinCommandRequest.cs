using Application.Features.Users.UserCoin.Dtos;
using MediatR;

namespace Application.Features.Users.UserCoin.Commands.UpdateUserCoin;

public class UpdateUserCoinCommandRequest : IRequest<UpdateUserCoinCommandResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Coin { get; set; }

    
}