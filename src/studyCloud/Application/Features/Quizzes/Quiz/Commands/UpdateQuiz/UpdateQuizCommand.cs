using Application.Features.Quizzes.Answer.Dtos;
using Application.Features.Quizzes.Quiz.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Commands.UpdateQuiz;

public class UpdateQuizCommand : IRequest<UpdatedQuizDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }

    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, UpdatedQuizDto>
    {
        private readonly IQuizRepository _quizRepository;
        private IMapper _mapper;

        public UpdateQuizCommandHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedQuizDto> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Quiz quiz = _mapper.Map<Domain.Entities.Quizzes.Quiz>(request);
            Domain.Entities.Quizzes.Quiz createdQuiz =
                await _quizRepository.UpdateAsync(quiz);
            UpdatedQuizDto updatedQuizDto =
                _mapper.Map<UpdatedQuizDto>(createdQuiz);
            return updatedQuizDto;
        }
    }
}