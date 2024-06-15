namespace Questionnaire.Models;

public class QuestionGroup
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<Question>? Questions { get; set; }
}