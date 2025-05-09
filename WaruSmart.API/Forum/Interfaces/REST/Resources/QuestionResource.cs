namespace WaruSmart.API.Forum.Interfaces.REST.Resources;

public record QuestionResource(int QuestionId, int AuthorId, int CategoryId, string QuestionText, DateTime Date);