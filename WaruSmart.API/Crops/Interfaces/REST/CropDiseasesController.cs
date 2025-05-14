/*using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WaruSmart.API.Crops.Domain.Model.Queries;
using WaruSmart.API.Crops.Domain.Services;
using WaruSmart.API.Crops.Interfaces.REST.Resources;
using WaruSmart.API.Crops.Interfaces.REST.Transform;

namespace WaruSmart.API.Crops.Interfaces.REST;

[ApiController]
[Route("/api/v1/crops-management/crops")]
[Produces(MediaTypeNames.Application.Json)]
public class CropDiseasesController : ControllerBase
{
    private readonly IDiseaseCommandService diseaseCommandService;
    private readonly IDiseaseQueryService diseaseQueryService;

    public CropDiseasesController(IDiseaseCommandService diseaseCommandService,
        IDiseaseQueryService diseaseQueryService)
    {
        this.diseaseCommandService = diseaseCommandService;
        this.diseaseQueryService = diseaseQueryService;
    }

    [HttpPost("diseases")]
    public async Task<ActionResult> CreateDisease([FromBody] CreateDiseaseResource resource)
    {
        var createDiseaseCommand =
            CreateDiseaseSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await diseaseCommandService.Handle(createDiseaseCommand);
        return CreatedAtAction(nameof(GetDiseaseById), new { id = result.Id },
            DiseaseResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("diseases/{id}")]
    public async Task<ActionResult> GetDiseaseById(int id)
    {
        var getDiseaseByIdQuery= new GetDiseaseByIdQuery(id);
        var result = await diseaseQueryService.Handle(getDiseaseByIdQuery);
        var resource = DiseaseResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("diseases")]
    public async Task<ActionResult> GetAllDiseases()
    {
        try
        {
            var getAllDiseasesQuery = new GetAllDiseasesQuery();
            var diseases = await diseaseQueryService.Handle(getAllDiseasesQuery);
            var resources = diseases.Select(DiseaseResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving diseases: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("{cropId}/diseases")]
    public async Task<ActionResult> GetDiseasesByCropId(int cropId)
    {
        try
        {
            var getDiseasesByCropIdQuery = new GetDiseaseByCropIdQuery(cropId);
            var diseases = await diseaseQueryService.Handle(getDiseasesByCropIdQuery);
            var resources = diseases.Select(DiseaseResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving diseases for crop {cropId}: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }
}*/