namespace Application.Features.Users.UserCoin.Commands.CreateUserCoin;

public class CreateUserCoinCommandResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public int Coin { get; set; }
}