using Application.Features.Mentions.Dtos;
using Application.Features.Quizzes.Answer.Dtos;
using Application.Services.Repositories.Mentions;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using Domain.Entities.Mentions;
using MediatR;

namespace Application.Features.Quizzes.Answer.Commands.DeleteAnswer;

public class DeleteAnswerCommand:IRequest<DeletedAnswerDto>
{
    public int Id { get; set; }
    public class DeleteAnswerCommandHandler:IRequestHandler<DeleteAnswerCommand,DeletedAnswerDto>
    {
        private readonly IAnswerRepository _answerRepository;
        private IMapper _mapper;

        public DeleteAnswerCommandHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<DeletedAnswerDto> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Answer answer = _mapper.Map<Domain.Entities.Quizzes.Answer>(request);
            Domain.Entities.Quizzes.Answer deletedAnswer =
                await _answerRepository.DeleteAsync(answer);
            DeletedAnswerDto deletedAnswerDto =
                _mapper.Map<DeletedAnswerDto>(deletedAnswer);
            return deletedAnswerDto;
        }
    }
}