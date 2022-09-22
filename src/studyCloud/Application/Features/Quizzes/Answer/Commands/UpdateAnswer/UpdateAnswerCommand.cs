using Application.Features.Mentions.Dtos;
using Application.Features.Quizzes.Answer.Dtos;
using Application.Services.Repositories.Mentions;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using Domain.Entities.Mentions;
using Domain.Enums;
using MediatR;

namespace Application.Features.Quizzes.Answer.Commands.UpdateAnswer;

public class UpdateAnswerCommand : IRequest<UpdatedAnswerDto>
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, UpdatedAnswerDto>
    {
        private readonly IAnswerRepository _answerRepository;
        private IMapper _mapper;

        public UpdateAnswerCommandHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedAnswerDto> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Answer answer = _mapper.Map<Domain.Entities.Quizzes.Answer>(request);
            Domain.Entities.Quizzes.Answer createdAnswer =
                await _answerRepository.UpdateAsync(answer);
            UpdatedAnswerDto updatedAnswerDto =
                _mapper.Map<UpdatedAnswerDto>(createdAnswer);
            return updatedAnswerDto;
        }
    }
}