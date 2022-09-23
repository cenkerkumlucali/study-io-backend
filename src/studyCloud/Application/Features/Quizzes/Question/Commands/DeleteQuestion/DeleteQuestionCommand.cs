using Application.Features.Quizzes.Question.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Question.Commands.DeleteQuestion;

public class DeleteQuestionCommand:IRequest<DeletedQuestionDto>
{
    public int Id { get; set; }
    public class DeleteQuestionCommandHandler:IRequestHandler<DeleteQuestionCommand,DeletedQuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;
        private IMapper _mapper;

        public DeleteQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<DeletedQuestionDto> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Question question = _mapper.Map<Domain.Entities.Quizzes.Question>(request);
            Domain.Entities.Quizzes.Question deletedQuestion =
                await _questionRepository.DeleteAsync(question);
            DeletedQuestionDto deletedQuestionDto =
                _mapper.Map<DeletedQuestionDto>(deletedQuestion);
            return deletedQuestionDto;
        }
    }
}