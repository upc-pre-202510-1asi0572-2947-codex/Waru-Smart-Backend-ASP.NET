﻿using Microsoft.AspNetCore.Mvc;
using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.Queries;
using WaruSmart.API.Crops.Domain.Services;
using WaruSmart.API.Crops.Interfaces.REST.Resources;
using WaruSmart.API.Crops.Interfaces.REST.Transform;

namespace WaruSmart.API.Crops.Interfaces.REST
{
    [ApiController]
    [Route("/api/v1/crops-management/sowings")]
    public class SowingControlsController : ControllerBase
    {
        private readonly IControlCommandService controlCommandService;
        private readonly IControlQueryService controlQueryService;
        private readonly ISowingQueryService sowingQueryService;

        public SowingControlsController(IControlCommandService controlCommandService, IControlQueryService controlQueryService, ISowingQueryService sowingQueryService)
        {
            this.controlCommandService = controlCommandService;
            this.controlQueryService = controlQueryService;
            this.sowingQueryService = sowingQueryService;
        }

        [HttpGet("{sowingId}/controls")]
        public async Task<ActionResult<List<ControlResource>>> GetAllControlsBySowingId(int sowingId)
        {
            var getAllControlsBySowingIdQuery = new GetAllControlsBySowingIdQuery(sowingId);
            var controls = await controlQueryService.Handle(getAllControlsBySowingIdQuery);
            var controlResources = controls.Select(ControlResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(controlResources);
        }
        
        [HttpGet("{sowingId}/controls/{controlId}")]
        public async Task<ActionResult<ControlResource>> GetControlById(int sowingId, int controlId)
        {
            var getControlByIdQuery = new GetControlByIdQuery(controlId);
            var controlOptional = await controlQueryService.Handle(getControlByIdQuery);
            if (controlOptional == null)
                return BadRequest("No se encontró un Control con el ID proporcionado: " + controlId);

            var controlResourceResponse = ControlResourceFromEntityAssembler.ToResourceFromEntity(controlOptional);
            return Ok(controlResourceResponse);
        }

        [HttpDelete("{sowingId}/controls/{controlId}")]
        public async Task<ActionResult> DeleteControl(int sowingId, int controlId)
        {
            var getSowingByIdQuery = new GetSowingByIdQuery(sowingId);
            var sowingOptional = await sowingQueryService.Handle(getSowingByIdQuery);
            if (sowingOptional == null)
                return BadRequest("No se encontró un Sowing con el ID proporcionado: " + sowingId);

            var deleteControlCommand = new DeleteControlCommand(sowingId, controlId);
            await controlCommandService.Handle(deleteControlCommand);
            return Ok("Control with given id successfully deleted");
        }

        [HttpGet("/api/v1/crops-management/sowings/controls")]
        public async Task<ActionResult<List<ControlResource>>> GetAllControls()
        {
            var getAllControlsQuery = new GetAllControlsQuery();
            var controls = await controlQueryService.Handle(getAllControlsQuery);
            var controlResources = controls.Select(ControlResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(controlResources);
        }

        [HttpPut("{sowingId}/controls/{controlId}")]
        public async Task<ActionResult<ControlResource>> UpdateControl(int sowingId, int controlId, [FromBody] UpdateControlResource resource)
        {
            var updateControlCommand = UpdateControlSourceFromResourceAssembler.ToCommandFromResource(resource, sowingId, controlId);
            await controlCommandService.Handle(updateControlCommand);

            var getControlByIdQuery = new GetControlByIdQuery(controlId);
            var controlOptional = await controlQueryService.Handle(getControlByIdQuery);
            if (controlOptional == null)
                return BadRequest();

            var controlResourceResponse = ControlResourceFromEntityAssembler.ToResourceFromEntity(controlOptional);
            return Ok(controlResourceResponse);
        }
        
        
        [HttpPost("{sowingId}/controls")]
        public async Task<ActionResult<ControlResource>> CreateControl(int sowingId, [FromBody] CreateControlResource resource)
        {
            var getSowingByIdQuery = new GetSowingByIdQuery(sowingId);
            var sowingOptional = await sowingQueryService.Handle(getSowingByIdQuery);
            if (sowingOptional == null)
                return BadRequest("No se encontró un Sowing con el ID proporcionado: " + sowingId);

            var createControlCommand = CreateControlSourceCommandFromResourceAssembler.ToCommandFromResource(sowingId, resource);
            var control = await controlCommandService.Handle(createControlCommand);
            var controlResource = ControlResourceFromEntityAssembler.ToResourceFromEntity(control);
            return CreatedAtAction(nameof(GetControlById), new {sowingId = sowingId, controlId = control.Id}, controlResource);
        }
    }
}