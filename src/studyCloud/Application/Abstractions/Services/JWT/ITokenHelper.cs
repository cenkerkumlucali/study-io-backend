using Application.DTOs.JWT;
using Domain.Entities.Users;

namespace Application.Abstractions.Services.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);

    RefreshToken CreateRefreshToken(User user, string ipAddress);
}