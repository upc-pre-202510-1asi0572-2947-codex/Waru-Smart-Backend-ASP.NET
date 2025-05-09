﻿using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WaruSmart.API.Forum.Domain.Model.Commands;
using WaruSmart.API.Forum.Domain.Model.Queries;
using WaruSmart.API.Forum.Domain.Services;
using WaruSmart.API.Forum.Interfaces.REST.Resources;
using WaruSmart.API.Forum.Interfaces.REST.Transform;

namespace WaruSmart.API.Forum.Interfaces.REST;

[ApiController]
[Route("api/v1/forum/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AnswersController(IAnswerCommandService answerCommandService, IAnswerQueryService answerQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateAnswer([FromBody] CreateAnswerResource createAnswerResource)
    {
        var createAnswerCommand = CreateAnswerCommandFromResourceAssembler.ToCommandFromResource(createAnswerResource);
        var answer = await answerCommandService.Handle(createAnswerCommand);
        if (answer is null) return BadRequest();
        var resource = AnswerResourceFromEntityAssembler.ToResourceFromEntity(answer);
        return CreatedAtAction(nameof(GetAnswerById), new { answerId = resource.AnswerId }, resource);
    }
    
    [HttpPut("{answerId}")]
    public async Task<ActionResult> UpdateQuestion([FromRoute] int answerId, [FromBody] UpdateAnswerResource updateAnswerResource)
    {
        var updateAnswerCommand = UpdateAnswerCommandFromResourceAssembler.ToCommandFromResource(answerId,updateAnswerResource);
        var answer = await answerCommandService.Handle(updateAnswerCommand);
        if (answer is null) return NotFound();
        var resource = AnswerResourceFromEntityAssembler.ToResourceFromEntity(answer);
        return Ok(resource);
    }
    
    [HttpDelete("{answerId}")]
    public async Task<ActionResult> DeleteAnswer([FromRoute] int answerId)
    {
        var deleteAnswerCommand = new DeleteAnswerCommand(answerId);
        await answerCommandService.Handle(deleteAnswerCommand);
        return Ok("Answer with given id successfully deleted.");
    }
    
    
    [HttpGet]
    public async Task<ActionResult> GetAllAnswers()
    {
        var getAllAnswersQuery = new GetAllAnswersQuery();
        var answers = await answerQueryService.Handle(getAllAnswersQuery);
        var resources = answers.Select(AnswerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{answerId}")]
    public async Task<ActionResult> GetAnswerById([FromRoute] int answerId)
    {
        var answer = await answerQueryService.Handle(new GetAnswerByIdQuery(answerId));
        if (answer is null) return NotFound();
        var resource = AnswerResourceFromEntityAssembler.ToResourceFromEntity(answer);
        return Ok(resource);
    }
}