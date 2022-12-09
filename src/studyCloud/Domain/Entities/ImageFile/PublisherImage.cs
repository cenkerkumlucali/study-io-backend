namespace Domain.Entities.ImageFile;

public class PublisherImage : File
{
    public ICollection<Publisher> Publishers { get; set; }
}