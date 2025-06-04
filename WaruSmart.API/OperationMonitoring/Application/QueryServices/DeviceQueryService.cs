using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Model.Queries;
using WaruSmart.API.OperationMonitoring.Domain.Repositories;
using WaruSmart.API.OperationMonitoring.Domain.Services;

namespace WaruSmart.API.OperationMonitoring.Application.QueryServices;

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