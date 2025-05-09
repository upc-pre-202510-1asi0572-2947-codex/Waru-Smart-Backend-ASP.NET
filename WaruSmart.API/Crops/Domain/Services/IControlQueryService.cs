using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Model.Queries;

namespace WaruSmart.API.Crops.Domain.Services;

public interface IControlQueryService
{
    Task<IEnumerable<Control>> Handle(GetAllControlsQuery query);
    Task<Control?> Handle(GetControlByIdQuery query);
    
    Task<IEnumerable<Control>> Handle(GetAllControlsBySowingIdQuery query);
}