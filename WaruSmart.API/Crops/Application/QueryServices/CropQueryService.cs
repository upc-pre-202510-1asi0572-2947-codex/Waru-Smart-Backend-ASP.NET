using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Queries;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;

namespace WaruSmart.API.Crops.Application.QueryServices;

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
