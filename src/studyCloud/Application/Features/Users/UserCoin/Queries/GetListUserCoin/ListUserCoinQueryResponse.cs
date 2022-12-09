namespace Application.Features.Users.UserCoin.Queries.GetListUserCoin;

public class ListUserCoinQueryResponse
{
    public long Id { get; set; }
    public string UserEmail { get; set; }
    public int Coin { get; set; }
}