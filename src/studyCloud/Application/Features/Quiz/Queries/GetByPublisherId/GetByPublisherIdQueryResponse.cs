using Application.Features.Quiz.Dtos;

namespace Application.Features.Quiz.Queries.GetByPublisherId;

public class GetByPublisherIdQueryResponse
{
    public long PublisherId { get; set; }
    public string PublisherName { get; set; }
    public string PublisherPictureUrl { get; set; }
    public List<PublisherQuizDto> Quizzes { get; set; }
}