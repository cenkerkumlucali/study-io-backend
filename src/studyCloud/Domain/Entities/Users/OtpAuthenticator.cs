using Domain.Entities.Common;


namespace Domain.Entities.Users;

public class OtpAuthenticator : BaseEntity
{
    public int UserId { get; set; }
    public byte[] SecretKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; }

    public OtpAuthenticator()
    {
    }

    public OtpAuthenticator(int id, int userId, byte[] secretKey, bool isVerified) : this()
    {
        Id = id;
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = isVerified;
    }
}