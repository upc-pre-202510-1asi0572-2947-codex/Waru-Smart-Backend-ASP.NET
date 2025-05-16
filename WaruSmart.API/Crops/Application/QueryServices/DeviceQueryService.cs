using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Model.Queries;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;

namespace WaruSmart.API.Crops.Application.QueryServices;

public class DeviceQueryService(IDeviceRepository deviceRepository): IDeviceQueryService
{
    public async Task<IEnumerable<Device>> Handle(GetAllDevicesBySowingId query)
    {
        return await deviceRepository.FindBySowingIdAsync(query.sowingId);
    }

    public async Task<IEnumerable<Device>> Handle(GetAllDevicesQuery query)
    {
        return await deviceRepository.FindAllAsync();
    }
}