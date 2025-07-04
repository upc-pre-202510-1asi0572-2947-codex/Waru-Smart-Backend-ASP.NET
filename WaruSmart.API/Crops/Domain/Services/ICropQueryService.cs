using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Queries;

namespace WaruSmart.API.Crops.Domain.Services;

public interface ICropQueryService
{
    Task<Crop?> Handle(GetCropByIdQuery query);
 
    /**
     * Return all products
     */
    Task<IEnumerable<Crop>> Handle(GetAllCropsQuery query);
}