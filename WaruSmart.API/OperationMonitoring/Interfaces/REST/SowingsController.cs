﻿using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Domain.Model.Queries;
using WaruSmart.API.OperationMonitoring.Domain.Services;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST;



//[Route("/api/v1/sowings/{sowingId}/controls")] SowingControlsController


[ApiController]
[Route("/api/v1/crops-management/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SowingsController(ISowingCommandService sowingCommandService,
    ISowingQueryService sowingQueryService, IControlCommandService controlCommandService
    , IControlQueryService controlQueryService
    )
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateSowing([FromBody] CreateSowingResource resource)
    {
        var createSowingCommand =
            CreateSowingSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await sowingCommandService.Handle(createSowingCommand);
        return CreatedAtAction(nameof(GetSowingById), new { id = result.Id },
                SowingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSowing(int id, [FromBody] UpdateSowingResource resource)
    {
        var updateSowingCommand = UpdateSowingSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await sowingCommandService.Handle(id, updateSowingCommand);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(SowingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetSowingById(int id)
    {
        var getSowingByIdQuery = new GetSowingByIdQuery(id);
        var result = await sowingQueryService.Handle(getSowingByIdQuery);
        var resource = SowingResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    /*private async Task<ActionResult> GetSowingByStatusQuery(bool status)
    {
        var getSowingByStatus = new GetSowingByStatusQuery(status);
        var result = await sowingQueryService.Handle(getSowingByStatus);
        var resources = result.Select(SowingResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetSowingsFromQuery([FromQuery] bool? status)
    {
        if (status.HasValue)
        {
            return await GetSowingByStatusQuery(status.Value);
        }
        else
        {
            return Ok();
        }
    }
  
    [HttpGet("controls/{id}")]
    public async Task<ActionResult> GetControlById(int id)
    {
        var getControlByIdQuery = new GetControlByIdQuery(id);
        var result = await controlQueryService.Handle(getControlByIdQuery);
        var resource = ControlResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpPost("{sowingId}/controls")]
    public async Task<ActionResult> CreateControl(int sowingId, [FromBody] CreateControlResource resource)
    {
        var createControlCommand = CreateControlSourceCommandFromResourceAssembler.ToCommandFromResource(sowingId, resource);
        var result = await controlCommandService.Handle(createControlCommand);
        return CreatedAtAction(nameof(GetControlById), new { id = result.Id },
            ControlResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
      */
    [HttpGet]
    public async Task<ActionResult> GetAllSowings()
    {
        try
        {
            var getAllSowingsQuery = new GetAllSowingsQuery();
            var sowings = await sowingQueryService.Handle(getAllSowingsQuery);
            var resources = sowings.Select(SowingResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving sowings: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteSowing(int id)
    {
        var deleteSowingCommand = new DeleteSowingCommand(id);
        var result = await sowingCommandService.Handle(deleteSowingCommand);
        if (!result)
        {
            return NotFound();
        }
    
        return Ok("Sowing deleted successful!");
    }

    

    [HttpPut("{sowingId}/phenological-phase/{phase-id}")]
    public async Task<ActionResult> UpdatePhenologicalPhaseBySowingId(int sowingId)
    {
        var updatePhenologicalPhaseBySowingIdCommand = new UpdatePhenologicalPhaseBySowingIdCommand(sowingId);
        var result = await sowingCommandService.Handle(updatePhenologicalPhaseBySowingIdCommand);
        if (result == null)

        {
            return NotFound();
        }
        return Ok("Phenological phase updated successfully");
    }
    
    [HttpGet("{userId}/user")]
    public async Task<ActionResult> GetSowingsByUserId(int userId)
    {
        var getSowingsByUserIdQuery = new GetAllSowingsByUserIdQuery(userId);
        var result = await sowingQueryService.Handle(getSowingsByUserIdQuery);
        var resources = result.Select(SowingResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    /*
     * Endpoint to get all sowings by a user with role of 'Cooperative'
     */
 
}