using WaruSmart.API.OperationMonitoring.Domain.Model.Aggregates;
using WaruSmart.API.OperationMonitoring.Domain.Model.Queries;

namespace WaruSmart.API.OperationMonitoring.Domain.Services;

public interface ICropQueryService
{
    Task<Crop?> Handle(GetCropByIdQuery query);
 
    /**
     * Return all products
     */
    Task<IEnumerable<Crop>> Handle(GetAllCropsQuery query);
}