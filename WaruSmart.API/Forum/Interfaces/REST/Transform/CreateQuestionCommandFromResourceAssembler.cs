using WaruSmart.API.Forum.Domain.Model.Commands;
using WaruSmart.API.Forum.Interfaces.REST.Resources;

namespace WaruSmart.API.Forum.Interfaces.REST.Transform;

public static class CreateQuestionCommandFromResourceAssembler
{
    public static CreateQuestionCommand ToCommandFromResource(CreateQuestionResource resource)
    {
        return new CreateQuestionCommand(resource.AuthorId, resource.CategoryId, resource.QuestionText, resource.Date);
    }
}