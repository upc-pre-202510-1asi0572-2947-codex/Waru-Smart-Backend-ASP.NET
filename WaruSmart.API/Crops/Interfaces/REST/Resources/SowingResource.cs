using WaruSmart.API.Crops.Domain.Model.ValueObjects;

namespace WaruSmart.API.Crops.Interfaces.REST.Resources;




public record SowingResource(int Id, DateTime StartDate, DateTime EndDate, 
    int AreaLand, bool Status, EPhenologicalPhase PhenologicalPhase, 
    int CropId,  string PhenologicalPhaseName, int UserId);