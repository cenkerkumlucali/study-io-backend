using MediatR;

namespace Application.Features.Users.UserCoin.Commands.UpdateUserCoin;

public class UpdateUserCoinCommandRequest : IRequest<UpdateUserCoinCommandResponse>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public int Coin { get; set; }

    
}