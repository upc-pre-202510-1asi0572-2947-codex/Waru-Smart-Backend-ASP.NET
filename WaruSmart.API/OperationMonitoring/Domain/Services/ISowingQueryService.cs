using WaruSmart.API.OperationMonitoring.Domain.Model.Aggregates;
using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Model.Queries;

namespace WaruSmart.API.OperationMonitoring.Domain.Services;

public interface ISowingQueryService
{
    Task<Sowing?> Handle(GetSowingByIdQuery query);
    Task<IEnumerable<Sowing>> Handle(GetSowingByStatusQuery query);
    
    Task<IEnumerable<Product>> Handle(GetProductsBySowingQuery query);
    Task<IEnumerable<Sowing>> Handle(GetAllSowingsQuery query);
    
    Task<IEnumerable<Sowing>> Handle(GetAllSowingsByUserIdQuery query);

}