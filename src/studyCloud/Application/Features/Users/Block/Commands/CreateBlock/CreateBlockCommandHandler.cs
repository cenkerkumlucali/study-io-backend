using Application.Abstractions.Services;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Block.Commands.CreateBlock;

public class CreateBlockCommandHandler:IRequestHandler<CreateBlockCommandRequest,CreateBlockCommandResponse>
{
    private readonly IBlockService _blockService;
    private IMapper _mapper;

    public CreateBlockCommandHandler(IBlockService blockService, IMapper mapper)
    {
        _blockService = blockService;
        _mapper = mapper;
    }

    public async Task<CreateBlockCommandResponse> Handle(CreateBlockCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.Block mappedBlock = _mapper.Map<Domain.Entities.Users.Block>(request);

        await _blockService.Block(mappedBlock);
        return new();
    }
}