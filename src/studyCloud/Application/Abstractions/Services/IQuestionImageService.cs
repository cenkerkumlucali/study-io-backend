using Domain.Entities.ImageFile;
using Domain.Entities.Quizzes;

namespace Application.Abstractions.Services;

public interface IQuestionImageService : IImageFileService<QuestionImage>
{
}