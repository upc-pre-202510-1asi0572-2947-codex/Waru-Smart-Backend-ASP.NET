namespace WaruSmart.API.Forum.Interfaces.REST.Resources;

public record CreateAnswerResource(int AuthorId, int QuestionId, string AnswerText);