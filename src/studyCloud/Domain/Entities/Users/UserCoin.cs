using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.Users;

public class UserCoin:BaseEntity
{
    public long UserId { get; set; }
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