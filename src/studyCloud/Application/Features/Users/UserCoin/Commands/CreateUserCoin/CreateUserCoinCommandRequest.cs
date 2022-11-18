using MediatR;

namespace Application.Features.Users.UserCoin.Commands.CreateUserCoin;

public class CreateUserCoinCommandRequest : IRequest<CreateUserCoinCommandResponse>
{
    public int UserId { get; set; }
    public int Coin { get; set; }

    
}