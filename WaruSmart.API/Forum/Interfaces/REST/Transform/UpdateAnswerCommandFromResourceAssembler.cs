using WaruSmart.API.Forum.Domain.Model.Commands;
using WaruSmart.API.Forum.Interfaces.REST.Resources;

namespace WaruSmart.API.Forum.Interfaces.REST.Transform;

public class UpdateAnswerCommandFromResourceAssembler
{
    public static UpdateAnswerCommand ToCommandFromResource(int answerId,UpdateAnswerResource resource)
    {
        return new UpdateAnswerCommand(answerId,resource.AnswerText);
    }
}