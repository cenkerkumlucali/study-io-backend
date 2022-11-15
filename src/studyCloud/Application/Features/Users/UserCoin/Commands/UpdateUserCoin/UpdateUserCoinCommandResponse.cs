namespace Application.Features.Users.UserCoin.Dtos;

public class UpdateUserCoinCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Coin { get; set; }
}