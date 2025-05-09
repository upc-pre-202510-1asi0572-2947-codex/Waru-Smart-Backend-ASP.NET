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
public class QuestionsController(IQuestionCommandService questionCommandService, IQuestionQueryService questionQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateQuestion([FromBody] CreateQuestionResource createQuestionResource)
    {
        var createQuestionCommand = CreateQuestionCommandFromResourceAssembler.ToCommandFromResource(createQuestionResource);
        var question = await questionCommandService.Handle(createQuestionCommand);
        if (question is null) return BadRequest();
        var resource = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);
        return CreatedAtAction(nameof(GetQuestionById), new { questionId = resource.QuestionId }, resource);
    }
    
    [HttpPut("{questionId}")]
    public async Task<ActionResult> UpdateQuestion([FromRoute] int questionId, [FromBody] UpdateQuestionResource updateQuestionResource)
    {
        var updateQuestionCommand = UpdateQuestionCommandFromResourceAssembler.ToCommandFromResource(questionId, updateQuestionResource);
        var question = await questionCommandService.Handle(updateQuestionCommand);
        if (question == null) return NotFound();
        var resource = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);
        return Ok(resource);
    }
    
    [HttpDelete("{questionId}")]
    public async Task<ActionResult> DeleteQuestion([FromRoute] int questionId)
    {
        var deleteQuestionCommand = new DeleteQuestionCommand(questionId);
        await questionCommandService.Handle(deleteQuestionCommand);
        return Ok("Question with given id successfully deleted.");
    }
    
    
    
    [HttpGet]
    public async Task<ActionResult> GetAllQuestions()
    {
        var getAllQuestionsQuery = new GetAllQuestionsQuery();
        var questions = await questionQueryService.Handle(getAllQuestionsQuery);
        Console.WriteLine(questions);
        var resources = questions.Select(QuestionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    
    [HttpGet("{questionId}")]
    public async Task<ActionResult> GetQuestionById([FromRoute] int questionId)
    {
        var getQuestionByIdQuery = new GetQuestionByIdQuery(questionId);
        var question = await questionQueryService.Handle(getQuestionByIdQuery);
        Console.WriteLine(question);
        if (question is null) return NotFound();
        var resource = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);
        return Ok(resource);
    }
    
    //TODO: Implement this method when bounded context profiles is finished
    /*[HttpGet("author/{authorId}")]
    public async Task<ActionResult> GetQuestionsByUserId([FromRoute] int userId)
    {
        var getAllQuestionsByUserId = new GetAllQuestionsByUserId(userId);
        var questions = await questionQueryService.Handle(getAllQuestionsByUserId);
        var resources = questions.Select(QuestionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }*/
}