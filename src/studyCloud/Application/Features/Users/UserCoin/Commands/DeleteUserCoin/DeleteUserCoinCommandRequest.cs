using MediatR;

namespace Application.Features.Users.UserCoin.Commands.DeleteUserCoin;

public class DeleteUserCoinCommandRequest:IRequest<DeleteUserCoinCommandResponse>
{
    public long Id { get; set; }
   
}