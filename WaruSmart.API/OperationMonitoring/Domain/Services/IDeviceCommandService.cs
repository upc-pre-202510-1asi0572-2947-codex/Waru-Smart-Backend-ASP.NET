using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;

namespace WaruSmart.API.OperationMonitoring.Domain.Services;

public interface IDeviceCommandService
{
    Task<Device?> Handle(CreateDeviceCommand command);
    
    Task<Device> Handle(UpdateStatusDeviceCommand command, int deviceId);
}