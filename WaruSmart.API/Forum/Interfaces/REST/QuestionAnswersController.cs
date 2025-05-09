using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WaruSmart.API.Forum.Domain.Model.Queries;
using WaruSmart.API.Forum.Domain.Services;
using WaruSmart.API.Forum.Interfaces.REST.Transform;

namespace WaruSmart.API.Forum.Interfaces.REST;

[ApiController]
[Route("api/v1/forum/")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Answers")]
public class QuestionAnswersController(IAnswerCommandService answerCommandService, IAnswerQueryService answerQueryService) : ControllerBase
{
    [HttpGet("question/{questionId}/answers")]
    public async Task<ActionResult> GetAnswersByQuestionId([FromRoute] int questionId)
    {
        var getAllAnswersByQuestionIdQuery = new GetAllAnswersByQuestionId(questionId);
        var answers = await answerQueryService.Handle(getAllAnswersByQuestionIdQuery);
        var resources = answers.Select(AnswerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}