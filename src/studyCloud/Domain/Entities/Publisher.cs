using Domain.Entities.Common;
using Domain.Entities.ImageFile;
using Domain.Entities.Quizzes;

namespace Domain.Entities;

public class Publisher : BaseEntity
{
    public string Name { get; set; }
    public List<Quiz> Quizzes { get; set; }
    public virtual ICollection<PublisherImage>? PublisherImages { get; set; }
}