using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Quiz : Entity
{
    public string Question { get; set; }
    public List<Answer> Answers { get; set; }
    public Category Category { get; set; }
    public SubCategory SubCategory { get; set; }

    public Quiz()
    {
    }

    public Quiz(int id, string question, List<Answer> answers,  Category category,
        SubCategory subCategory) : this()
    {
        Id = id;
        Question = question;
        Answers = answers;
        Category = category;
        SubCategory = subCategory;
    }
}