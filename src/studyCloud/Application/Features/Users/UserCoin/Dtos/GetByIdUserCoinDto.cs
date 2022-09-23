namespace Application.Features.Users.UserCoin.Dtos;

public class GetByIdUserCoinDto
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public int Coin { get; set; }
}