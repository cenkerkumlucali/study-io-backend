using Domain.Entities.Common;

namespace Domain.Entities.Users;

public class EmailAuthenticator : BaseEntity
{
    public long UserId { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; }

    public EmailAuthenticator()
    {
    }

    public EmailAuthenticator(int id, int userId, string? activationKey, bool isVerified) : this()
    {
        Id = id;
        UserId = userId;
        ActivationKey = activationKey;
        IsVerified = isVerified;
    }
}