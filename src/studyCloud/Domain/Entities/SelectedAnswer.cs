using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class SelectedAnswer
{
    [Key]
    public string QuestionId { get; set;}

    public string PossibleAnswerId { get; set; }

    public SelectedAnswer()
    {
        
    }

    public SelectedAnswer(string questionId, string possibleAnswerId)
    {
        QuestionId = questionId;
        PossibleAnswerId = possibleAnswerId;
    }
}