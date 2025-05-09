using WaruSmart.API.Forum.Domain.Model.Commands;
using WaruSmart.API.Forum.Interfaces.REST.Resources;

namespace WaruSmart.API.Forum.Interfaces.REST.Transform;

public static class CreateAnswerCommandFromResourceAssembler
{
    public static CreateAnswerCommand ToCommandFromResource(CreateAnswerResource resource)
    {
        return new CreateAnswerCommand(resource.AuthorId, resource.QuestionId, resource.AnswerText);
    }
}