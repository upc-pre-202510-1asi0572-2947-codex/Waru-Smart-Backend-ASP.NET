using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WaruSmart.API.OperationMonitoring.Domain.Model.Queries;
using WaruSmart.API.OperationMonitoring.Domain.Services;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST;

[ApiController]
[Route("api/v1/crops-management/sowings")]
[Produces(MediaTypeNames.Application.Json)]
public class SowingsDevicesController : ControllerBase
{
    private readonly IDeviceCommandService deviceCommandService;
    private readonly IDeviceQueryService deviceQueryService;
    
    public SowingsDevicesController(IDeviceCommandService deviceCommandService, IDeviceQueryService deviceQueryService)
    {
        this.deviceCommandService = deviceCommandService;
        this.deviceQueryService = deviceQueryService;
    }
    
    [HttpGet("{sowingId}/devices")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllDevicesBySowingId(int sowingId)
    {
        var devices = await deviceQueryService.Handle(new GetAllDevicesBySowingId(sowingId));
        if (!devices.Any())
        {
            return NotFound();
        }
        
        var result = devices.Select(DeviceResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(result);
    }
    
    [HttpPost("{sowingId}/devices")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateDevice(int sowingId, [FromBody] CreateDeviceResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = CreateDeviceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var device = await deviceCommandService.Handle(command);

        if (device == null)
        {
            return NotFound();
        }

        var result = DeviceResourceFromEntityAssembler.ToResourceFromEntity(device);
        
        return CreatedAtAction(nameof(GetAllDevicesBySowingId), new { sowingId }, result);
    }
    
    [HttpGet("{sowingId}/indicators")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGeneralInformation(int sowingId)
    {
        var devices = await deviceQueryService.Handle(new GetAllDevicesBySowingId(sowingId));
        if (!devices.Any())
        {
            return NotFound();
        }

        var result = GeneralInformationDeviceResourceFromListEntitiesAssembler.ToResourceFromEntity(devices);
        return Ok(result);
    }
    
    [HttpPut("{deviceId}/devices")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateDevice( int deviceId, [FromBody] UpdateStatusDeviceResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = UpdateStatusDeviceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var device = await deviceCommandService.Handle(command, deviceId);
        

        var result = DeviceResourceFromEntityAssembler.ToResourceFromEntity(device);
        
        return Ok(result);
    }
    
    /*
     * Function to get all devices
     */
    [HttpGet("devices")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllDevices()
    {
        var devices = await deviceQueryService.Handle(new GetAllDevicesQuery());
        if (!devices.Any())
        {
            return NotFound();
        }
        
        var result = devices.Select(DeviceResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(result);
    }
}