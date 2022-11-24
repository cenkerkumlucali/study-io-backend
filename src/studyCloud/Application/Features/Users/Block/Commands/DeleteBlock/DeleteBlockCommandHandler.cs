using Application.Abstractions.Services;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Block.Commands.DeleteBlock;

public class DeleteBlockCommandHandler:IRequestHandler<DeleteBlockCommandRequest,DeleteBlockCommandResponse>
{
    private IBlockService _blockService;
    private IMapper _mapper;

    public DeleteBlockCommandHandler(IBlockService blockService, IMapper mapper)
    {
        _blockService = blockService;
        _mapper = mapper;
    }

    public async Task<DeleteBlockCommandResponse> Handle(DeleteBlockCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.Block? mappedBlock = _mapper.Map<Domain.Entities.Users.Block>(request);
        await _blockService.Unblock(mappedBlock);
        return new();
    }
}