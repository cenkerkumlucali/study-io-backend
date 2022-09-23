using Application.Features.Quizzes.Question.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Question.Commands.UpdateQuestion;

public class UpdateQuestionCommand : IRequest<UpdatedQuestionDto>
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string Text { get; set; }

    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, UpdatedQuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;
        private IMapper _mapper;

        public UpdateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedQuestionDto> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Question question = _mapper.Map<Domain.Entities.Quizzes.Question>(request);
            Domain.Entities.Quizzes.Question createdQuestion =
                await _questionRepository.UpdateAsync(question);
            UpdatedQuestionDto updatedQuestionDto =
                _mapper.Map<UpdatedQuestionDto>(createdQuestion);
            return updatedQuestionDto;
        }
    }
}