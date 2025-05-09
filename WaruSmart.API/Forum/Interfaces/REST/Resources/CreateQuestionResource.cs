namespace WaruSmart.API.Forum.Interfaces.REST.Resources;

public record CreateQuestionResource(int AuthorId ,int CategoryId, string QuestionText, DateTime Date);