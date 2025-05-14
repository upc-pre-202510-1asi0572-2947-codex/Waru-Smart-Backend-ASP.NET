/*
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Model.Queries;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;

namespace WaruSmart.API.Crops.Application.QueryServices;

public class PestQueryService(IPestRepository pestRepository)
    : IPestQueryService
{
    public async Task<Pest?> Handle(GetPestByIdQuery query)
    {
        return await pestRepository.FindByIdAsync(query.Id);
    }
    
    public Task<IEnumerable<Pest>> Handle(GetAllPestsQuery query)
    {
        return pestRepository.FindAllAsync();
    }
    public Task<IEnumerable<Pest>> Handle(GetPestByCropIdQuery query)
    {
        return pestRepository.GetPestByCropIdQuery(query.CropId);
    }
}
*/
