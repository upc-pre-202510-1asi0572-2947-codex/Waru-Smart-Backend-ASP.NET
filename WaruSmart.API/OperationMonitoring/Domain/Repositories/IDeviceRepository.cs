using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.OperationMonitoring.Domain.Repositories;

public interface IDeviceRepository:IBaseRepository<Device> {
    
    /**
     * Method of the interface that allows to search for a device by its type
     */
    Task<IEnumerable<Device>> FindBySowingIdAsync(int sowingId);
    
    /**
     * Method of the interface that allows to search for a device by its type
     */
    //Task<IEnumerable<Device>> FindBySensorTypeAsync(int sensorType);
    
    /**
     * Method of the interface that allows to search all devices
     */
    Task<IEnumerable<Device>> FindAllAsync();
}