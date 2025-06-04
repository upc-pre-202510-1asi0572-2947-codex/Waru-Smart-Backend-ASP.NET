using WaruSmart.API.OperationMonitoring.Domain.Model.Aggregates;
using WaruSmart.API.OperationMonitoring.Domain.Model.Queries;
using WaruSmart.API.OperationMonitoring.Domain.Repositories;
using WaruSmart.API.OperationMonitoring.Domain.Services;

namespace WaruSmart.API.OperationMonitoring.Application.QueryServices;

public class CropQueryService(ICropRepository cropRepository)
    : ICropQueryService
{
    public async Task<Crop?> Handle(GetCropByIdQuery query)
    {
        return await cropRepository.FindByIdAsync(query.Id);
    }    
    
    public async Task<IEnumerable<Crop>> Handle(GetAllCropsQuery query)
    {
        return await cropRepository.FindAllAsync();
    }
}
