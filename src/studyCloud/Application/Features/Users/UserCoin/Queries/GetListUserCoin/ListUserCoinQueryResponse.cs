namespace Application.Features.Users.UserCoin.Dtos;

public class ListUserCoinQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public int Coin { get; set; }
}