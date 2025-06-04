using WaruSmart.API.OperationMonitoring.Domain.Model.Aggregates;
using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Model.Queries;
using WaruSmart.API.OperationMonitoring.Domain.Repositories;
using WaruSmart.API.OperationMonitoring.Domain.Services;

namespace WaruSmart.API.OperationMonitoring.Application.QueryServices;

public class SowingQueryService(ISowingRepository sowingRepository)
: ISowingQueryService
{
    public async Task<Sowing?> Handle(GetSowingByIdQuery query)
    {
        return await sowingRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<Sowing>> Handle(GetSowingByStatusQuery query)
    {
        return await sowingRepository.FindByStatusAsync(query.Status);
    }

    public async Task<IEnumerable<Product>> Handle(GetProductsBySowingQuery query)
    {
        return await sowingRepository.FindProductsBySowing(query.SowingId);
    }

    public Task<IEnumerable<Sowing>> Handle(GetAllSowingsQuery query)
    {
        return sowingRepository.FindAllAsync();
    }

    public async Task<IEnumerable<Sowing>> Handle(GetAllSowingsByUserIdQuery query)
    {
        return await sowingRepository.FindAllByUserIdAsync(query.UserId);
    }
}