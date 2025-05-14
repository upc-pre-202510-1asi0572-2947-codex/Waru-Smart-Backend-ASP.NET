using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.ValueObjects;

namespace WaruSmart.API.Crops.Domain.Model.Entities;

public class Device
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public ESensorType SensorType { get;  set; }
    public string DeviceId { get; private set; }
    public string Status { get; private set; } //TODO: This should be an enum
    public DateTime? LastSyncDate { get; private set; }
    public string Location { get; private set; }
    
    public Sowing Sowing { get; private set; }
    
    public int SowingId { get; private set; }

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
        DeviceId = Guid.NewGuid().ToString();
        Name = string.Concat(command.SensorType, '-', DeviceId );
        SensorType = (ESensorType)Enum.Parse(typeof(ESensorType), command.SensorType);
        Location = command.location;
        Status = command.status;
        LastSyncDate = DateTime.Now;
        SowingId = command.sowingId;
        Sowing = sowing;
    }

    public void UpdateStatus(string status)
    {
        Status = status;
    }

    public void UpdateLastSyncDate(DateTime syncDate)
    {
        LastSyncDate = syncDate;
    }

    public void UpdateGeolocation(string geolocation)
    {
        Location = geolocation;
    }
}