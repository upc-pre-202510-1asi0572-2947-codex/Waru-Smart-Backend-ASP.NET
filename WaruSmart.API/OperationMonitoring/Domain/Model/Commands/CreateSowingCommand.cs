namespace WaruSmart.API.OperationMonitoring.Domain.Model.Commands;

public record CreateSowingCommand(int AreaLand,int CropId, int UserId);