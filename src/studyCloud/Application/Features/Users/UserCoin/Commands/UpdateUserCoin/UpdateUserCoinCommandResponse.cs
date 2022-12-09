namespace Application.Features.Users.UserCoin.Commands.UpdateUserCoin;

public class UpdateUserCoinCommandResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public int Coin { get; set; }
}