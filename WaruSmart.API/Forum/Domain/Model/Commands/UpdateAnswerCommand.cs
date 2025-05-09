namespace WaruSmart.API.Forum.Domain.Model.Commands;

public record UpdateAnswerCommand(int AnswerId, string AnswerText);