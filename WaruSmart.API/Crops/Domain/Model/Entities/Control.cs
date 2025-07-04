using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.ValueObjects;

namespace WaruSmart.API.Crops.Domain.Model.Entities;

public class Control
{
    public int Id { get; }
    
    public int SowingId { get;  set; }
    
    public DateTime Date { get;  set; }
    
    public Sowing Sowing { get; private set; }
    
    public ESowingCondition SowingCondition{ get;  set; }
    
    public ESowingStemCondition StemCondition { get;  set; }
    public ESowingSoilMoisture SoilMoisture { get;  set; }
    
  
    
    public Control()
    {
    }
    public Control(CreateControlCommand command)
    {
        SowingId = command.SowingId;
        SowingCondition = command.SowingCondition;
        StemCondition = command.StemCondition;
        SoilMoisture = command.SoilMoisture;
        Date = DateTime.Now;
    }
    
}