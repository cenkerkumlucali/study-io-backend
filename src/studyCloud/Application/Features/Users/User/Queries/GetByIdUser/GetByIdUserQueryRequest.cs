using Application.Features.Users.User.Dtos;
using MediatR;

namespace Application.Features.Users.User.Queries.GetByIdUser;

public class GetByIdUserQueryRequest : IRequest<GetByIdUserQueryResponse>
{
    public int Id { get; set; }

   
}