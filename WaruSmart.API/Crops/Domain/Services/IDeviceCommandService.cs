using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Resources.Domain.Model;

namespace WaruSmart.API.Crops.Domain.Services;

public interface IDeviceCommandService
{
    Task<Device?> Handle(CreateDeviceCommand command);
    
    Task<Device> Handle(UpdateStatusDeviceCommand command, int deviceId);
    
    Task SyncDeviceWithIoTData(IEnumerable<IoTData> iotDataList);
}