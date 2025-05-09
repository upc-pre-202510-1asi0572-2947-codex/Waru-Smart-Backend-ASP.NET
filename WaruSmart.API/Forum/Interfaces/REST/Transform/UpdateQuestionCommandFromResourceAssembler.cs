using WaruSmart.API.Forum.Domain.Model.Commands;
using WaruSmart.API.Forum.Interfaces.REST.Resources;

namespace WaruSmart.API.Forum.Interfaces.REST.Transform;

public class UpdateQuestionCommandFromResourceAssembler
{
    public static UpdateQuestionCommand ToCommandFromResource(int questionId,UpdateQuestionResource resource)
    {
        return new UpdateQuestionCommand(questionId, resource.CategoryId, resource.QuestionText);
    }
}