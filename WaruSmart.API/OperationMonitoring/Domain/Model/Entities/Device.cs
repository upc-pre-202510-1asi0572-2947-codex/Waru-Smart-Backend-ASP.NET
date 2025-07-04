using WaruSmart.API.OperationMonitoring.Domain.Model.Aggregates;
using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Domain.Model.ValueObjects;
using WaruSmart.API.ResourcesManagement.Domain.Model;

namespace WaruSmart.API.OperationMonitoring.Domain.Model.Entities;

public class Device
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public ESensorType SensorType { get;  set; }
    public string DeviceId { get; private set; }
    public string Status { get; private set; } //TODO: This should be an enum
    public DateTime? LastSyncDate { get; set; }
    public string? Location { get; private set; }
    
    public Sowing Sowing { get; private set; }
    
    public int SowingId { get; private set; }
    
    public double? Humidity { get; set; }
    
    public double? Temprature { get; set; }
    
    public double? SoilMoisture { get; set; }

    public Device(string name, string deviceId, string location)
    {
        Name = name;
        DeviceId = deviceId;
        Location = location;
        Status = "Inactive";
        LastSyncDate = DateTime.MinValue;
    }
    
    public Device()
    {
        Name = "";
        DeviceId = Guid.NewGuid().ToString();
        Status = "Inactive";
        LastSyncDate = null;
    }

    public Device(CreateDeviceCommand command, Sowing sowing)
    {
        DeviceId = "waru-smart-001";
        Name = string.Concat(command.SensorType, '-', DeviceId );
        SensorType = (ESensorType)Enum.Parse(typeof(ESensorType), command.SensorType);
        Location = command.location;
        Status = command.status;
        LastSyncDate = DateTime.Now;
        SowingId = command.sowingId;
        Sowing = sowing;
        Humidity = 0;
        Temprature = 0;
        SoilMoisture = 0;
    }

    public void UpdateStatus(UpdateStatusDeviceCommand command)
    {
        Status = command.Status;
    }

    public void UpdateLastSyncDate(DateTime syncDate)
    {
        LastSyncDate = syncDate;
    }

    public void UpdateGeolocation(string geolocation)
    {
        Location = geolocation;
    }
    
    public void UpdateSensorData(IoTData ioTData)
    {
        Humidity = ioTData.Humidity;
        Temprature = ioTData.TemperatureValue;
        SoilMoisture = ioTData.SoilMoistureValue;
        Location = ioTData.Zone;
        LastSyncDate = ioTData.Timestamp;
    }
}