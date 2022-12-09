using Domain.Entities.Common;
using Redis.OM.Modeling;


namespace Domain.Entities.Users;

[Document(StorageType = StorageType.Json, Prefixes = new []{"StudyIo.RefreshToken"})]
public class RefreshToken : BaseEntity
{
    [Indexed] public long UserId { get; set; }
    [Indexed] [RedisIdField] [Searchable] public string Token { get; set; }
    [Indexed] public DateTime Expires { get; set; }
    [Indexed] public DateTime Created { get; set; }
    [Indexed] public string CreatedByIp { get; set; }
    [Indexed] public DateTime? Revoked { get; set; }
    [Indexed] public string? RevokedByIp { get; set; }
    [Indexed] public string? ReplacedByToken { get; set; }
    [Indexed] public string? ReasonRevoked { get; set; }
    //public bool IsExpired => DateTime.UtcNow >= Expires;
    //public bool IsRevoked => Revoked != null;
    //public bool IsActive => !IsRevoked && !IsExpired;

    public virtual User User { get; set; }

    public RefreshToken()
    {
    }

    public RefreshToken(int id, string token, DateTime expires, DateTime created, string createdByIp, DateTime? revoked,
        string revokedByIp, string replacedByToken, string reasonRevoked)
    {
        Id = id;
        Token = token;
        Expires = expires;
        Created = created;
        CreatedByIp = createdByIp;
        Revoked = revoked;
        RevokedByIp = revokedByIp;
        ReplacedByToken = replacedByToken;
        ReasonRevoked = reasonRevoked;
    }
}