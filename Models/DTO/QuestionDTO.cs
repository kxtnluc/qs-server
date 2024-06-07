namespace Questionnaire.Models.DTOs;

public class QuestionDTO
{
    public int Id { get; set; }
    public string Body { get; set; }
    public int QuestionGroupId { get; set; }
    public List<UserQuestionDTO> UserQuestions { get; set; }
}