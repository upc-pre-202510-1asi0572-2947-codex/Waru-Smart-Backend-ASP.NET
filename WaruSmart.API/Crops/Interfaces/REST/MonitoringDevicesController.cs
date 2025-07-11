﻿using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WaruSmart.API.Crops.Domain.Services;
using WaruSmart.API.Crops.Domain.Model.Events;
using WaruSmart.API.Crops.Interfaces.REST.Resources;
using WaruSmart.API.Crops.Interfaces.REST.Transform;
using WaruSmart.API.Resources.Domain.Repositories;
using WaruSmart.API.Resources.Domain.Services;

namespace WaruSmart.API.Crops.Interfaces.REST;

[ApiController]
[Route("/api/v1/crops-management/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MonitoringDevicesController : ControllerBase
{
    private readonly IFogSyncService _fogSyncService;
    private readonly IDeviceCommandService deviceCommandService;
    private readonly IIoTDataRepository ioTDataRepository;
    private readonly IDeviceEventService deviceEventService;

    public MonitoringDevicesController(IFogSyncService fogSyncService, 
        IDeviceCommandService deviceCommandService,
        IIoTDataRepository ioTDataRepository,
        IDeviceEventService deviceEventService)
    {
        _fogSyncService = fogSyncService;
        this.deviceCommandService = deviceCommandService;
        this.ioTDataRepository = ioTDataRepository;
        this.deviceEventService = deviceEventService;
    }

    // TODO: Eliminate this endpoint if not needed, just to test the fog sync service
    [HttpPost("sync-fog-data")]
    public async Task<IActionResult> SyncFogData()
    {
        try
        {
            await _fogSyncService.SyncFogDataAsync();
            // After that execute the SyncDeviceWithIoTData method
            //First, we need to get the IoT data from the repository
            var iotDataList = await ioTDataRepository.GetAllDataAsync();
            if (iotDataList == null || !iotDataList.Any())
            {
                return NotFound(new { message = "No IoT data found to sync." });
            }
            // Now we can sync the devices with the IoT data
            await deviceCommandService.SyncDeviceWithIoTData(iotDataList);
            return Ok(new { message = "Fog data synchronized successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
    
    /*
     * Function to update the status of a device in a sowing.
     */
    [HttpPut("{sowingId}/devices/{deviceId}")]
    public async Task<IActionResult> UpdateDeviceStatus(int sowingId, int deviceId, [FromBody] UpdateStatusDeviceResource resource)
    {
        var command = UpdateStatusDeviceCommandFromResourceAssembler.ToCommandFromResource(resource);
        try
        {
            var result = await deviceCommandService.Handle(command, deviceId);
            //After tha succes, I need to launch the event to update the status of the device
            var updateEvent = new UpdateStatusDeviceEvent(deviceId, resource.Status);
            var eventResult = await deviceEventService.Handle(updateEvent);
            var response = DeviceResourceFromEntityAssembler.ToResourceFromEntity(result);
            if (eventResult)
            {
                return Ok(new { message = "Updated and event dispatched", device = response });
            }
            else
            {
                return Ok(new { message = "Updated but not dispatched", device = response });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }

    }
}