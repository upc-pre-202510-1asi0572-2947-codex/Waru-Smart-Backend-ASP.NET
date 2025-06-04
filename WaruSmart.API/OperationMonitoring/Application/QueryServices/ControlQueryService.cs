using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Model.Queries;
using WaruSmart.API.OperationMonitoring.Domain.Repositories;
using WaruSmart.API.OperationMonitoring.Domain.Services;

namespace WaruSmart.API.OperationMonitoring.Application.QueryServices;

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