/*
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Model.Queries;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;

namespace WaruSmart.API.Crops.Application.QueryServices;

public class CareQueryService(ICareRepository careRepository)
    : ICareQueryService
{
    public async Task<Care?> Handle(GetCareByIdQuery query)
    {
        return await careRepository.FindByIdAsync(query.Id);
    }
    
    public Task<IEnumerable<Care>> Handle(GetCareByCropIdQuery query)
    {
        return careRepository.GetCaresByCropIdQuery(query.CropId);
    }
}
*/

