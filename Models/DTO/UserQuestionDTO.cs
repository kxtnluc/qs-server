namespace Questionnaire.Models.DTOs;

public class UserQuestionDTO
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public QuestionDTO? Question { get; set; }
    public int QuestionId { get; set; }
    public string Response { get; set; }
}