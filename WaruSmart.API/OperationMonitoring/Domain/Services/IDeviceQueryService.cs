using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Model.Queries;

namespace WaruSmart.API.OperationMonitoring.Domain.Services;

public interface IDeviceQueryService
{
    Task<IEnumerable<Device>> Handle(GetAllDevicesBySowingId query);

    Task<IEnumerable<Device>> Handle(GetAllDevicesQuery query);
}