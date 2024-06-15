namespace Questionnaire.Models.DTOs;

public class QuestionDTO
{
    public int Id { get; set; }
    public string Body { get; set; }
    public int QuestionGroupId { get; set; }
    public List<UserQuestionDTO>? UserQuestions { get; set; }
    public bool PaidUsersOnly { get; set; } = true;
    public bool MultipleResponses { get; set; } = false;


}