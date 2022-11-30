namespace Application.Features.Alarm.Dtos;

public class AlarmDto
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Message { get; set; }
    public string PictureUrl { get; set; }
    public DateTime CreatedDate { get; set; }
}