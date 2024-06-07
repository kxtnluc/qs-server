namespace Questionnaire.Models;

public class UserQuestion
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public Question? Question { get; set; }
    public int QuestionId { get; set; }
    public string Response { get; set; }
}