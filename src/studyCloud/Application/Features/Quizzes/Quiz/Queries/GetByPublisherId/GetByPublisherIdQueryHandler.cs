using Application.Repositories.Services.Publishers;
using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Quizzes.Quiz.Queries.GetByPublisherId;

public class GetByPublisherIdQueryHandler:IRequestHandler<GetByPublisherIdQueryRequest,GetByPublisherIdQueryResponse>
{
    private readonly IQuizRepository _quizRepository;
    private readonly IPublisherRepository _publisherRepository;
    private IMapper _mapper;

    public GetByPublisherIdQueryHandler(IPublisherRepository publisherRepository, IMapper mapper, IQuizRepository quizRepository)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
        _quizRepository = quizRepository;
    }

    public async Task<GetByPublisherIdQueryResponse> Handle(GetByPublisherIdQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Quiz quiz = await _quizRepository.GetAsync(c => c.PublisherId == request.PublisherId,
            include: c => c.Include(c=>c.Lesson)
                .Include(c=>c.LessonSubject)
                .Include(c=>c.SubCategory)
                .Include(c=>c.Questions)
                .Include(c => c.Publisher).ThenInclude(c=>c.PublisherImages));
        
        GetByPublisherIdQueryResponse? mappedPublisher = _mapper.Map<GetByPublisherIdQueryResponse>(quiz);
        return mappedPublisher;
    }
}