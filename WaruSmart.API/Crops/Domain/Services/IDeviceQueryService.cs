using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Model.Queries;

namespace WaruSmart.API.Crops.Domain.Services;

public interface IDeviceQueryService
{
    Task<IEnumerable<Device>> Handle(GetAllDevicesBySowingId query);

    Task<IEnumerable<Device>> Handle(GetAllDevicesQuery query);
}