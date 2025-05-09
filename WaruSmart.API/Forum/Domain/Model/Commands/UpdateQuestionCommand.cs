namespace WaruSmart.API.Forum.Domain.Model.Commands;

public record UpdateQuestionCommand(int QuestionId, int CategoryId, string QuestionText);