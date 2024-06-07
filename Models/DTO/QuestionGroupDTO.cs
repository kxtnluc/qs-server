namespace Questionnaire.Models.DTOs;

public class QuestionGroupDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<QuestionDTO> Questions { get; set; }
}