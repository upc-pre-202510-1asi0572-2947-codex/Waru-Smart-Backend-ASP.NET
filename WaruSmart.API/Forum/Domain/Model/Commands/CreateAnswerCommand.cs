namespace WaruSmart.API.Forum.Domain.Model.Commands;

public record CreateAnswerCommand(int AuthorId, int QuestionId, string AnswerText);