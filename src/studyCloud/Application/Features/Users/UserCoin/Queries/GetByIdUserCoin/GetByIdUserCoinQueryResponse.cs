namespace Application.Features.Users.UserCoin.Dtos;

public class GetByIdUserCoinQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public int Coin { get; set; }
}