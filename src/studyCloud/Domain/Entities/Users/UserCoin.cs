using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities.Users;

public class UserCoin:Entity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int Coin { get; set; }

    public UserCoin()
    {
        
    }

    public UserCoin(int id, int userId, int coin) : this()
    {
        Id = id;
        UserId = userId;
        Coin = coin;
    }
}