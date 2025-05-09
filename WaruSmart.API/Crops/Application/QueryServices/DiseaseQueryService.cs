using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Model.Queries;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;

namespace WaruSmart.API.Crops.Application.QueryServices;

public class DiseaseQueryService(IDiseaseRepository diseaseRepository)
    : IDiseaseQueryService
{
    public async Task<Disease?> Handle(GetDiseaseByIdQuery query)
    {
        return await diseaseRepository.FindByIdAsync(query.Id);
    }
    
    public Task<IEnumerable<Disease>> Handle(GetAllDiseasesQuery query)
    {
        return diseaseRepository.FindAllAsync();
    }
    
    Task<IEnumerable<Disease>> IDiseaseQueryService.Handle(GetDiseaseByCropIdQuery query)
    {
        return diseaseRepository.GetDiseasesByCropId(query.CropId);
    }
}
