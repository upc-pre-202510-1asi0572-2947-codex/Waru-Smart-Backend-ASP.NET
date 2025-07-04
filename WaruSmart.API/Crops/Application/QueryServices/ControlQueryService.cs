using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Model.Queries;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;

namespace WaruSmart.API.Crops.Application.QueryServices;

public class ControlQueryService (IControlRepository controlRepository) : IControlQueryService
{
    public async Task<IEnumerable<Control>> Handle(GetAllControlsQuery query)
    {
        return await controlRepository.ListAsync();
    }
    public async Task<Control?> Handle(GetControlByIdQuery query)
    {
        return await controlRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Control>> Handle(GetAllControlsBySowingIdQuery query)
    {
        return await controlRepository.FindBySowingIdAsync(query.SowingId);
    }
}