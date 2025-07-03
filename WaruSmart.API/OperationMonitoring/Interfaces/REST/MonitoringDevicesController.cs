using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WaruSmart.API.ResourcesManagement.Application.InboundServices;
using WaruSmart.API.ResourcesManagement.Domain.Services;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST;

[ApiController]
[Route("/api/v1/crops-management/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MonitoringDevicesController : ControllerBase
{
    private readonly IFogSyncService _fogSyncService;

    public MonitoringDevicesController(IFogSyncService fogSyncService)
    {
        _fogSyncService = fogSyncService;
    }

    [HttpPost("sync-fog-data")]
    public async Task<IActionResult> SyncFogData()
    {
        try
        {
            await _fogSyncService.SyncFogDataAsync();
            return Ok(new { message = "Fog data synchronized successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}