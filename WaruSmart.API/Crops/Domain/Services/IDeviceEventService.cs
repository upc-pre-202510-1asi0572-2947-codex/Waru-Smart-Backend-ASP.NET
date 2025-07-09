using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Model.Events;

namespace WaruSmart.API.Crops.Domain.Services;

public interface IDeviceEventService
{
    Task<bool> Handle(UpdateStatusDeviceEvent updateStatusEvent);
}