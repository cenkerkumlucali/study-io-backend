namespace Application.Features.Users.UserCoin.Dtos;

public class CreateUserCoinCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Coin { get; set; }
}